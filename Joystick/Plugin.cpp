#include "stdafx.h"
#include "Plugin.h"
#include "MachDevice.h"

#include <stdlib.h>

using namespace JoystickMach3Plugin;

bool piInitControl(){
	Joystick::Init();
	return true;
}

char* piSetProName(LPCSTR name){
	return "EM Joystick";
}

void piPostInitControl(){

}

void piConfig(){
	JoystickConfig^ config = gcnew JoystickConfig();
	config->Show();
}

void piStopPlug(){

}

static bool jogging_backward;
static bool jogging_forward;
const char* AXES[] = {
	"X1", "X2",
	"Y1", "Y2",
	"Z1", "Z2",
	"A1", "A2"
};
const int AXIS_COUNT = 8;

static void StartJoggingBackward(int axis){
	jogging_backward = true;
	jogging_forward = false;
	Engine->Axis[axis].JoggDir = 0;
	Engine->Axis[axis].MaxVelocity = Joystick::GetMaxVelocity();
	Engine->Axis[axis].Acceleration = Joystick::GetAcceleration();
	Engine->Axis[axis].MasterVelocity = Joystick::GetMasterVelocity();
	Engine->Axis[axis].Jogging = true;
}

static void StartJoggingForward(int axis){
	jogging_backward = false;
	jogging_forward = true;
    Engine->Axis[axis].JoggDir = 1;
	Engine->Axis[axis].MaxVelocity = Joystick::GetMaxVelocity();
	Engine->Axis[axis].Acceleration = Joystick::GetAcceleration();
	Engine->Axis[axis].MasterVelocity = Joystick::GetMasterVelocity();
	Engine->Axis[axis].Jogging = true;
}

static void StopJogging(int axis){
	jogging_backward = false;
	jogging_forward = false;
	Engine->Axis[axis].Jogging = false;
}

static void UpdateDirection(int axis, Direction d){
	switch(d){
		case Direction::FORWARD:
			StartJoggingForward(axis);
			break;
		case Direction::BACKWARD:
			StartJoggingBackward(axis);
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
	UpdateDirection(XAXIS, direction[0]);
	UpdateDirection(YAXIS, direction[1]);
	UpdateDirection(ZAXIS, direction[2]);
	UpdateDirection(AAXIS, direction[3]);
}

void piNotify(int id){

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

