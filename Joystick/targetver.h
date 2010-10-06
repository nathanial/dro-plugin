#pragma once

#ifndef _DEFAULT_WIN
#define _DEFAULT_WIN 0x0501 //windows xp
#endif


#ifndef WINVER
#define WINVER _DEFAULT_WIN
#endif

#ifndef _WIN32_WINDOWS
#define _WIN32_WINDOWS _DEFAULT_WIN
#endif

#ifndef _WIN32_IE
#define _WIN32_IE 0x0700
#endif