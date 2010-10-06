#include "stdafx.h"					
#include "MachDevice.h"				
#include "Plugin.h"					
#pragma unmanaged

VoidShort			DoButton;		
IntShort			GetMenuRange;	
DoubleShort			GetDRO;			
VoidShortDouble		SetDRO;			
BoolShort			GetLED;			
VoidShortBool		SetLED;			
VoidLPCSTR			Code;			

char	*ProfileName;		
TrajBuffer			*Engine;		
setup				*_setup;		
_TrajectoryControl	*MainPlanner;	
_CMach4View			*MachView;		
									

extern "C" __declspec(dllexport) void SetGetMenuRange(IntShort pFunc)
{
   GetMenuRange = pFunc; 
}

extern "C" __declspec(dllexport) bool InitControl( void *oEngine , void *oSetup , void *oMainPlanner, void *oView)
{
	bool	startPrinter;		// function return - if true, start the printer port

	Engine		= (TrajBuffer *) oEngine;
	_setup		= (setup *) oSetup;
	MainPlanner = (_TrajectoryControl *) oMainPlanner;
	MachView	= (_CMach4View *) oView;

	startPrinter = piInitControl();
	return startPrinter;
}

extern "C" __declspec(dllexport) void SetDoButton(VoidShort pFunc)
{
   DoButton = pFunc; 
}

extern "C" __declspec(dllexport) void SetSetDRO(VoidShortDouble pFunc)
{
   SetDRO = pFunc; 
}

extern "C" __declspec(dllexport) void SetGetDRO(DoubleShort pFunc)
{
   GetDRO = pFunc; 
}

extern "C" __declspec(dllexport) void SetGetLED(BoolShort pFunc)
{
   GetLED = pFunc; 
}

extern "C" __declspec(dllexport) void SetSetLED(VoidShortBool pFunc)
{
   SetLED = pFunc; 
}

extern "C" __declspec(dllexport) void SetCode(VoidLPCSTR pFunc)
{
   Code = pFunc; 
}


extern "C" __declspec(dllexport) char* SetProName(LPCSTR name)  
{
	char*	pluginName;
	ProfileName = _strdup(name);
	pluginName = piSetProName(name);
	return pluginName;
}

extern "C" __declspec(dllexport) void PostInitControl()
{
	piPostInitControl();
}

extern "C" __declspec(dllexport) void Config()
{
	piConfig();
}

extern "C" __declspec(dllexport) void StopPlug(void)
{
	piStopPlug();
}

extern "C" __declspec(dllexport) void Update()
{
	piUpdate();
}

extern "C" __declspec(dllexport) void Notify(int id)
{
	piNotify(id);
}


extern "C" __declspec(dllexport) void DoDwell(double time)
{
	piDoDwell(time);
}

extern "C" __declspec(dllexport) void Reset()
{
	piReset();
}

extern "C" __declspec(dllexport) void JogOn(short axis, short dir, double speed)
{
	piJogOn(axis, dir, speed);
}

extern "C" __declspec(dllexport) void JogOff(short axis)
{
	piJogOff(axis);
}

extern "C" __declspec(dllexport) void Purge(short flags)
{
#ifdef	PI_PURGE
	piPurge(flags);
#endif
}

extern "C" __declspec(dllexport) void Probe()
{
	piProbe();
}

extern "C" __declspec(dllexport) void Home(short axis)
{
	piHome(axis);
}
