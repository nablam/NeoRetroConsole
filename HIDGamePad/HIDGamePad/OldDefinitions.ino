//#include <math.h>
//

//*******************************************************************************************************************
//                HID iD               num of buttons up 50, num hatswitches up to 2 max, X, Y, Z, rotX, rotY, rotZ, rudder, throttle, accelerometr, break  steering)
//Joystick_ Joystick(0x07, JOYSTICK_TYPE_JOYSTICK, 4, 0, true, true, false, false, false, false, false, false, false, false, false);
//************************************************************



void ReadAnalogAndMap(int rangemin, int rangemax) {
    Pad1_PotValue = analogRead(A0);
    Pad2_PotValue = analogRead(A1);

    Pad1_potCleanVal = map(Pad1_PotValue, 0, 1023, rangemin, rangemax);//   round( sensorValue) / 10;
    Pad2_potCleanVal = map(Pad2_PotValue, 0, 1023, rangemin, rangemax);
}

void ReadAnSetButtons() {

    for (int index = 0; index < 4; index++)
    {
        int currentButtonState = !digitalRead(index + pinToButtonMap);
        if (currentButtonState != lastButtonStates[index])
        {
            //************************************************************
            if (_isAndroid) {
                if (index == 0) {
                    Joystick.setButton(0, currentButtonState);
                }
                else
                    if (index == 1) {
                        Joystick.setButton(1, currentButtonState);
                    }
                    else
                        if (index == 2) {
                            Joystick.setButton(3, currentButtonState);
                        }
                        else
                            if (index == 3) {
                                Joystick.setButton(4, currentButtonState);
                            }

            }
            else
                Joystick.setButton(index, currentButtonState);
            //************************************************************
            lastButtonStates[index] = currentButtonState;
        }
    }
}

void TestSwitch_to_pin(int argpin, int JoyButNum) {
    int testButtonState = !digitalRead(argpin);
    if (testButtonState != Last_testButtonState) {
        Joystick.setButton(JoyButNum, testButtonState);
        Last_testButtonState = testButtonState;
    }
}

void ReadModeButton() {
    MODE_lastButtonState = MODE_currentButtonState;
    MODE_currentButtonState = digitalRead(Mode_Pin);

    if (MODE_lastButtonState == HIGH && MODE_currentButtonState == LOW) {
        MODE_ledState = !MODE_ledState;

        if (MODE_ledState == HIGH) {
            _isAndroid = true;
        }
        else
            _isAndroid = false;
        digitalWrite(LED_PIN, MODE_ledState);
    }
}

void Do_setup() {
    // put your setup code here, to run once:

    pinMode(Button1_pin, INPUT_PULLUP);
    pinMode(Button2_pin, INPUT_PULLUP);
    pinMode(Button3_pin, INPUT_PULLUP);
    pinMode(Button4_pin, INPUT_PULLUP);
    pinMode(Mode_Pin, INPUT_PULLUP);
    pinMode(LED_PIN, OUTPUT);
    MODE_currentButtonState = digitalRead(Mode_Pin);
    //************************************************************
    Joystick.begin();
    delay(10);
     //************************************************************
}

void Do_loop() {
    ReadModeButton();
    ReadAnSetButtons();

    if (_isAndroid) { _min = 0; _max = 1023; }
    else {
        _min = 512;
        _max = 1023;
    }

    ReadAnalogAndMap(_min, _max);



    // TestSwitch_to_pin(11,_indexOfJsButtonTotest);

     //************************************************************
    Joystick.setYAxis(Pad1_potCleanVal);
    Joystick.setXAxis(Pad2_potCleanVal);
    //************************************************************


    delay(30);
}