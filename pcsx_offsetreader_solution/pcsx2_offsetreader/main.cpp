// Hi there, this tool is to give an example of how to read the current recompiler base offset at runtime
// Due to how our (pcsx2) recompiler memory is managed, we are no longer able to ensure that a static address will be available
// Make sure this process is the same bitness as pcsx2

#include <Windows.h>
#include <iostream>
#include <TlHelp32.h>
#include <Psapi.h>
#include "GetProcAddressEx.h"
#include "main.h"

int main()
{
	return 0;
}

long GetEEMem(int procID)
{
	HANDLE hProcess = OpenProcess(PROCESS_ALL_ACCESS, FALSE, procID);

    // Get a list of all the modules in this process.

	HMODULE hModule[1024];
	DWORD hModuleSizeNeeded;
	
	if (!EnumProcessModules(hProcess, hModule, sizeof(hModule), &hModuleSizeNeeded))
	{
		std::cout << "EnumProcessModules Failed --> " << GetLastError();
		return -1;
	}

	if (hModuleSizeNeeded > sizeof(hModule))
	{
		std::cout << "hModule too small, oops.\n";
		return -1;
	}

	DWORD modulesFound = hModuleSizeNeeded / sizeof(HMODULE);
	std::cout << "Found " << modulesFound << " modules\n";

	// ASSUME THAT THE EXE IS THE FIRST MODULE, THIS _SHOULD_ BE THE CASE NO?

	PVOID EEmemAddress = GetProcAddressEx(hProcess, hModule[0], "EEmem");
	return (long)EEmemAddress;

	//std::cout << "EEmemAddress is " << std::hex << EEmemAddress << "\n";

	//uintptr_t baseAddress;
	//SIZE_T readBytes;

	//ReadProcessMemory(hProcess, EEmemAddress, &baseAddress, sizeof(uintptr_t), &readBytes);

	//std::cout << "EEmemAddress offset is " << std::hex << baseAddress << "\n";

	//long EEmem_Offset = (long)baseAddress;

	//CloseHandle(hProcess);

	//return EEmem_Offset;
}