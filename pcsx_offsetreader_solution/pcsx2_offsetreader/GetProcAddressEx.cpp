#include "GetProcAddressEx.h"

#include <TlHelp32.h>

#undef MODULEENTRY32
#undef Module32First
#undef Module32Next

#include <unordered_map>
#include <exception>
#include <iostream>
#include <memory>
#include <string>
#include <list>

class IReader {

public:

	virtual ~IReader() = default;

	virtual bool Read(UINT_PTR _Address, SIZE_T _Size, LPVOID _Buf) = 0;

};

class BasicReader : public IReader {

private:

	HANDLE m_Process;

public:

	BasicReader(HANDLE _Process) : m_Process(_Process) {};

	virtual bool Read(UINT_PTR _Address, SIZE_T _Size, LPVOID _Buf) override {

		SIZE_T size = { 0 };

		return ReadProcessMemory(m_Process, reinterpret_cast<LPCVOID>(_Address), _Buf, _Size, &size);

	}

};

class CacheReader : public BasicReader {

private:

	DWORD m_PageSize;

	std::list<UINT8*> m_Free;

	using Entry = std::pair<UINT_PTR, UINT8*>;

	std::unordered_map<UINT_PTR, std::list<Entry>::iterator> m_Map;

	std::list<Entry> m_List;

	UINT8* Require(UINT_PTR _Address) {

		const auto map_it = m_Map.find(_Address);

		if (map_it != m_Map.end()) {

			m_List.splice(m_List.end(), m_List, map_it->second);

			return map_it->second->second;

		}
		else if (!m_Free.empty()) {

			const auto result = m_Free.front();

			m_Free.pop_front();

			m_List.push_back({ _Address, result });

			auto back = m_List.end();

			--back;

			m_Map[_Address] = back;

			if (BasicReader::Read(_Address * m_PageSize, m_PageSize, result)) {

				return result;

			}
			else {

				m_Free.push_back(result);

				m_List.pop_back();

				m_Map.erase(_Address);

				return nullptr;

			}

		}
		else {

			const auto front = m_List.begin();

			m_List.splice(m_List.end(), m_List, front);

			m_Map.erase(front->first);

			front->first = _Address;

			m_Map[_Address] = front;

			if (BasicReader::Read(_Address * m_PageSize, m_PageSize, front->second)) {

				return front->second;

			}
			else {

				m_Free.push_back(front->second);

				m_List.pop_back();

				m_Map.erase(_Address);

				return nullptr;

			}

		}

	}

public:

	CacheReader(HANDLE _Process, SIZE_T _CacheSize) : BasicReader(_Process) {

		SYSTEM_INFO system_info = { 0 };

		GetSystemInfo(&system_info);

		m_PageSize = system_info.dwPageSize;

		for (SIZE_T i = 0; i < _CacheSize; ++i) {

			m_Free.push_back(new UINT8[m_PageSize]);

		}

	};

	~CacheReader() {

		for (UINT8* e : m_Free) {

			delete[] e;

		}

		for (Entry& e : m_List) {

			delete[] e.second;

		}

	}

	virtual bool Read(UINT_PTR _Address, SIZE_T _Size, LPVOID _Buf) override {

		UINT8* buf = reinterpret_cast<UINT8*>(_Buf);

		UINT_PTR cur_addr = _Address;

		SIZE_T cur_off = 0;

		SIZE_T req_size = _Size;

		while (req_size > 0) {

			UINT8* cur_page = Require(cur_addr / m_PageSize);

			if (!cur_page)
				return false;

			SIZE_T page_off = cur_addr % m_PageSize;

			SIZE_T src_size = m_PageSize - page_off;

			SIZE_T copy_size = min(src_size, req_size);

			memcpy(buf + cur_off, cur_page + page_off, copy_size);

			req_size -= copy_size;

			cur_addr += copy_size;

			cur_off += copy_size;

		}

		return true;

	}

};

static bool ReadName(IReader& _Reader, UINT_PTR _Base, DWORD _Name, std::string& _Res) {

	constexpr SIZE_T BUF_SIZE = 32;
	constexpr SIZE_T LIMIT = 16;

	char buf[BUF_SIZE];

	_Res.clear();

	for (SIZE_T i = 0; i < LIMIT; ++i) {

		if (!_Reader.Read(_Base + static_cast<UINT_PTR>(_Name), BUF_SIZE, buf))
			return false;

		for (SIZE_T j = 0; j < BUF_SIZE; ++j) {

			if (buf[j] == '\0')
				return true;

			_Res.push_back(buf[j]);

		}

	}

	return false;

}

static bool ParseForward(const std::string& _Forward, std::string& _Module, std::string& _Name) {

	const size_t find_period = _Forward.find('.');

	if (find_period == std::string::npos)
		return false;

	_Module = _Forward.substr(0, find_period) + ".dll";

	_Name = _Forward.substr(find_period + 1);

	return true;

}

static HMODULE FindModule(HANDLE _Process, const std::string& _Module) {

	HANDLE snapshot = CreateToolhelp32Snapshot(TH32CS_SNAPMODULE | TH32CS_SNAPMODULE32, GetProcessId(_Process));

	if (snapshot == INVALID_HANDLE_VALUE)
		return nullptr;

	MODULEENTRY32 entry = { 0 };

	entry.dwSize = sizeof(entry);

	for (BOOL status = Module32First(snapshot, &entry); status == TRUE; status = Module32Next(snapshot, &entry)) {

		if (!_strcmpi(_Module.c_str(), entry.szModule)) {

			CloseHandle(snapshot);

			return entry.hModule;

		}

	}

	CloseHandle(snapshot);

	return nullptr;

}

FARPROC GetProcAddressEx(HANDLE _Process, HMODULE _Module, LPCSTR _Name) {

	const UINT_PTR base = reinterpret_cast<UINT_PTR>(_Module);

	using Reader = CacheReader;

	Reader reader(_Process, 32);

	IMAGE_DOS_HEADER dos_header = { 0 };

	if (!reader.Read(base, sizeof(dos_header), &dos_header))
		return nullptr;

	if (dos_header.e_magic != IMAGE_DOS_SIGNATURE)
		return nullptr;

	DWORD nt_signature = { 0 };

	if (!reader.Read(base + dos_header.e_lfanew, sizeof(nt_signature), &nt_signature))
		return nullptr;

	if (nt_signature != IMAGE_NT_SIGNATURE)
		return nullptr;

	IMAGE_FILE_HEADER file_header = { 0 };

	if (!reader.Read(base + dos_header.e_lfanew + sizeof(DWORD), sizeof(file_header), &file_header))
		return nullptr;

	UINT_PTR export_directory_offset = { 0 };

	SIZE_T export_directory_size = { 0 };

	if (file_header.Machine & IMAGE_FILE_32BIT_MACHINE) {

		IMAGE_OPTIONAL_HEADER32 optional_header = { 0 };

		if (!reader.Read(base + dos_header.e_lfanew + sizeof(DWORD) + sizeof(IMAGE_FILE_HEADER), sizeof(optional_header), &optional_header))
			return nullptr;

		export_directory_offset = static_cast<UINT_PTR>(optional_header.DataDirectory[0].VirtualAddress);

		export_directory_size = static_cast<SIZE_T>(optional_header.DataDirectory[0].Size);

	}
	else {

		IMAGE_OPTIONAL_HEADER64 optional_header = { 0 };

		if (!reader.Read(base + dos_header.e_lfanew + sizeof(DWORD) + sizeof(IMAGE_FILE_HEADER), sizeof(optional_header), &optional_header))
			return nullptr;

		export_directory_offset = static_cast<UINT_PTR>(optional_header.DataDirectory[0].VirtualAddress);

		export_directory_size = static_cast<SIZE_T>(optional_header.DataDirectory[0].Size);

	}

	IMAGE_EXPORT_DIRECTORY export_directory = { 0 };

	if (!reader.Read(base + export_directory_offset, sizeof(export_directory), &export_directory))
		return nullptr;

	const std::unique_ptr<DWORD[]> name_alloc(new DWORD[export_directory.NumberOfNames]);

	if (!reader.Read(base + export_directory.AddressOfNames, export_directory.NumberOfNames * sizeof(DWORD), name_alloc.get()))
		return nullptr;

	const std::unique_ptr<USHORT[]> ordinal_alloc(new USHORT[export_directory.NumberOfNames]);

	if (!reader.Read(base + export_directory.AddressOfNameOrdinals, export_directory.NumberOfNames * sizeof(USHORT), ordinal_alloc.get()))
		return nullptr;

	const std::unique_ptr<DWORD[]> function_alloc(new DWORD[export_directory.NumberOfFunctions]);

	if (!reader.Read(base + export_directory.AddressOfFunctions, export_directory.NumberOfFunctions * sizeof(DWORD), function_alloc.get()))
		return nullptr;

	std::string cur_name;

	for (DWORD i = 0; i < export_directory.NumberOfNames; ++i) {

		const DWORD name = name_alloc[i];

		if (ReadName(reader, base, name, cur_name) && cur_name == _Name) {
			const USHORT ordinal = ordinal_alloc[i];

			const DWORD function = function_alloc[ordinal];

			if (function > export_directory_offset && function < export_directory_offset + export_directory_size) {

				std::string forward_str;

				if (!ReadName(reader, base, function, forward_str))
					return nullptr;

				std::string forward_module, forward_name;

				if (!ParseForward(forward_str, forward_module, forward_name))
					return nullptr;

				HMODULE module_handle = FindModule(_Process, forward_module);

				if (!module_handle)
					return nullptr;

				return GetProcAddressEx(_Process, module_handle, forward_name.c_str());

			}
			else {

				return reinterpret_cast<FARPROC>(base + static_cast<UINT_PTR>(function));

			}
			
		}
		std::cout << "name" << cur_name << std::endl;

	}

	return nullptr;

}

FARPROC GetProcAddressEx(HANDLE _Process, LPCSTR _Module, LPCSTR _Name) {

	HMODULE module_handle = FindModule(_Process, _Module);

	if (!module_handle)
		return nullptr;

	return GetProcAddressEx(_Process, module_handle, _Name);

}