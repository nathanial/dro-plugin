#pragma once

namespace JoystickMach3Interface {}

#include "stdafx.h"

bool piInitControl();
char* piSetProName(LPCSTR name);
void piPostInitControl();
void piConfig();
void piStopPlug();
void piUpdate();
void piNotify(int id);
void piDoDwell(double time);
void piReset();
void piJogOn(short axis, short dir, double speed);
void piJogOff(short axis);
void piPurge(short flags);
void piProbe();
void piHome(short axis);