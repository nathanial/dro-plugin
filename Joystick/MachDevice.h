#pragma once

#include "Engine.h"
#include "rs274ngc.h"
#include "_TrajectoryControl.h"
#include "_Mach4View.h"

typedef void	(_cdecl *VoidShort) (short);
typedef int		(_cdecl *IntShort) (short);
typedef double	(_cdecl *DoubleShort) (short);
typedef void	(_cdecl *VoidShortDouble) (short, double);
typedef bool	(_cdecl *BoolShort) (short);
typedef void	(_cdecl *VoidLPCSTR) (LPCTSTR);
typedef void	(_cdecl *VoidShortBool) (short, bool);

//=====================================================================
//
//	global variables provided by MachDevice.cpp - mainly pointers
//
//	see MachDevice.cpp for documentation
//
//=====================================================================

extern VoidShort			DoButton;		// void		DoButton(short code)
extern IntShort				GetMenuRange;	// int		GetMenuRange(short count)
extern DoubleShort			GetDRO;			// double	GetDRO(short code)
extern VoidShortDouble		SetDRO;			// void		SetDRO(short code, double value);
extern BoolShort			GetLED;			// bool		GetLED(short code);
extern VoidShortBool		SetLED;			// void		SetLED(short code, bool value);
extern VoidLPCSTR			Code;			// void		Code("G0X10Y10");

extern char	*ProfileName;					// file specification for the XML file

extern TrajBuffer			*Engine;		// Ring0 memory for printer port control and other device syncronisation
extern setup				*_setup;		// Trajectory planners setup block. Always in effect
extern _TrajectoryControl	*MainPlanner;	// used for most planner functions and program control 
extern _CMach4View			*MachView;		// used for most framework and configuration calls
											// therefore not very usable by a plugi