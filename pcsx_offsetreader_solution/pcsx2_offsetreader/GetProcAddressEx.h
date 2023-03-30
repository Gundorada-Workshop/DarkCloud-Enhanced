#pragma once
#include <Windows.h>

FARPROC GetProcAddressEx(HANDLE _Process, HMODULE _Module, LPCSTR _Name);

FARPROC GetProcAddressEx(HANDLE _Process, LPCSTR _Module, LPCSTR _Name);