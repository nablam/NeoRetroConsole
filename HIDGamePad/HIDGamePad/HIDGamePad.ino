/*
 Name:		HIDGamePad.ino
 Created:	1/25/2022 11:21:51 AM
 Author:	Nabz
*/

// the setup function runs once when you press reset or power the board

#include "Joystick.h"
const int TotalButtons = 20;
// Create Joystick
Joystick_ Joystick(JOYSTICK_DEFAULT_REPORT_ID, JOYSTICK_TYPE_GAMEPAD, TotalButtons, 0, true, true, false, false, false, false, false, false, false, false, false);

#pragma region vars

const bool initAutostate = true; //true sends auto, false needs polling with .sendSate()
bool _isAndroid = false;
int _xAxis = 0; //xAxis is RESERVED!!
int _yAxis = 0;

const int Button1_pin = 8;
const int Button2_pin = 9;
const int Button3_pin = 10;
const int Button4_pin = 11;

const int Mode_Pin = 12;
const int LED_PIN = 13;

int Last_testButtonState = 0;
int lastButtonStates[4] = { 0,0,0,0 };
const int pinToButtonMap = 8;

float Pad1_PotValue;
uint16_t Pad1_potCleanVal;
float Pad2_PotValue;
uint16_t Pad2_potCleanVal;
const int ledPin = 13;

int MODE_ledState = LOW;     // the current state of LED
int MODE_lastButtonState;    // the previous state of button
int MODE_currentButtonState;

uint16_t _min; //0 for unity and -127 for raspi
uint16_t _max;

int _indexOfJsButtonTotest = 0;
int x = 900;
bool flip = true;
#pragma endregion
void setup() {
    //  Serial.begin(9600);
    Do_setup();
}


void loop() {
    Do_loop();

}

