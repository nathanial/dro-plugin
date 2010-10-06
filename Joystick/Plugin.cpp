#include "stdafx.h"
#include "Plugin.h"
#include "MachDevice.h"

#include <stdlib.h>

using namespace JoystickMach3Plugin;

int menuStart;

bool piInitControl(){
	Joystick::Init();
	menuStart = GetMenuRange(MENU_COUNT);
	return true;
}

char* piSetProName(LPCSTR name){
	return "EM Joystick";
}

void piPostInitControl(){
	HMENU hMachMenu = GetMenu(MachView->MachFrame->m_hWnd);
	HMENU hPluginMenu = 0;
	int machMenuCnt = GetMenuItemCount(hMachMenu);
	MENUITEMINFO mii;
	LPTSTR txt;

	for(int i = 0; i < machMenuCnt; i++){
		mii.cbSize = sizeof(MENUITEMINFO);
		mii.fMask = MIIM_FTYPE | MIIM_ID | MIIM_SUBMENU | MIIM_STRING;
		mii.dwTypeData = NULL;

		if(GetMenuItemInfo(hMachMenu, i, true, &mii)){
			txt = (LPTSTR) malloc(++mii.cch);
			mii.dwTypeData = txt;

			if(GetMenuItemInfo(hMachMenu, i, true, &mii)){
				if(strcmp(txt, "PlugIn Control") == 0){
					hPluginMenu = mii.hSubMenu;
					i = machMenuCnt;
				}
			}
			free(txt);
		}
		
		if(hPluginMenu){
			InsertMenu(hPluginMenu, -1, MF_BYPOSITION, menuStart, "EM Joystick");
		}
	}
}

void piConfig(){
	JoystickConfig^ config = gcnew JoystickConfig();
	config->Show();
}

void piStopPlug(){

}

const char* AXES[] = {
	"X1", "X2",
	"Y1", "Y2",
	"Z1", "Z2",
	"A1", "A2"
};
const int AXIS_COUNT = 8;
static Direction old_directions[AXIS_COUNT / 2] = {Direction::NONE};

static void StartJoggingBackward(int axis){
	Engine->Axis[axis].JoggDir = 0;
	Engine->Axis[axis].MaxVelocity = Joystick::GetMaxVelocity();
	Engine->Axis[axis].Acceleration = Joystick::GetAcceleration();
	Engine->Axis[axis].MasterVelocity = Joystick::GetMasterVelocity();
	Engine->Axis[axis].Jogging = true;
}

static void StartJoggingForward(int axis){
    Engine->Axis[axis].JoggDir = 1;
	Engine->Axis[axis].MaxVelocity = Joystick::GetMaxVelocity();
	Engine->Axis[axis].Acceleration = Joystick::GetAcceleration();
	Engine->Axis[axis].MasterVelocity = Joystick::GetMasterVelocity();
	Engine->Axis[axis].Jogging = true;
}

static void StopJogging(int axis){
	Engine->Axis[axis].Jogging = false;
}

static void UpdateDirection(int axis, Direction new_direction, Direction old_direction){
	if(new_direction == old_direction) return;
	switch(new_direction){
		case Direction::FORWARD:
			if(Joystick::GetReverseAxes()){
				StartJoggingBackward(axis);
			} else {
				StartJoggingForward(axis);
			}
			break;
		case Direction::BACKWARD:
			if(Joystick::GetReverseAxes()){
				StartJoggingForward(axis);
			} else {
				StartJoggingBackward(axis);
			}
			break;
		case Direction::NONE:
			StopJogging(axis);
			break;
	}
	
}

void piUpdate(){
	Direction direction[AXIS_COUNT / 2] = {Direction::NONE};
	for(int i = 0; i < AXIS_COUNT; i++){
		if(direction[i / 2] == Direction::NONE){
			direction[i / 2] = Joystick::GetDirection(gcnew System::String(AXES[i]));
		}
	}
	UpdateDirection(XAXIS, direction[0], old_directions[0]);
	UpdateDirection(YAXIS, direction[1], old_directions[1]);
	UpdateDirection(ZAXIS, direction[2], old_directions[2]);
	UpdateDirection(AAXIS, direction[3], old_directions[3]);

	for(int i = 0; i < AXIS_COUNT / 2; i++){
		old_directions[i] = direction[i];
	}
}

void piNotify(int id){
	if(id == menuStart){
		JoystickConfig^ config = gcnew JoystickConfig();
		config->Show();
	}
}

void piDoDwell(double time){

}

void piReset(){

}

void piJogOn(short axis, short dir, double speed){

}

void piJogOff(short axis){

}

void piPurge(short flags){

}

void piProbe(){

}

void piHome(short axis){

}

