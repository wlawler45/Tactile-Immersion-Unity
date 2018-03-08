Quick links
Leap motion Docs: https://developer.leapmotion.com/documentation/
Unity Docs: https://docs.unity3d.com/Manual/index.html

Steps to get running from scratch
Download Unity 2017.3.0f3 (what you are actually downloading is the assistant). 
Open Unity download assistant to and follow instructions to install Unity.
Download Leap motion core assets 4.3.3 
	When prompted also choose to also download Leap motion interaction engine (1.1.0), Hands module (2.1.2) as well as those items that are checked by default.

New Project Instructions
These instructions are for getting tactile feedback working for a new project within Unity. 
Make a new folder to host your projects related to tactile feedback. Make a new unity project saved within this folder. 
A window will come up with an empty world. Press control-S to save this scene. 
Make a new folder in “assets” called ”_scenes”. Save this scene with a name of your choice under “assets”->”_scenes”.
If you have an older version of leap motion already imported, DELETE IT. Otherwise there will be a bunch of file conflicts that mess everything up :((
Click “Assets”->”Import Package”->”Custom Package...” Select  “Leap motion core assets 4.3.3” from your saved location. When the progress bar is done click import.
Under Hierarchy, click create->create empty. This will make a new GameObject. Title it “person”.
Drag main camera into “person” to make it a child of the object.
Search “LeapHandController” in the project window. You should see it come up as a prefab (appears as a blue cube). Drag this to “person” to make it a child.
Search “Interaction Manager” in the project window. Drag this over into the hierarchy window, separate of the other objects
INSTRUCTIONS NOT FINISHED

Old Project Instructions
These instructions are for getting tactile feedback working for an old project when you change leap motion versions.
Save a backup of your edited leap motion files. For later ease, mark what your edits are so you can go back and find them easily. Now delete your old leap motion that is already imported. Right click leap_motion->delete. Click “Assets”->”Import Package”->”Custom Package...” Select  “Leap motion core assets 4.3.3” from your saved location.

Serial
For simplicity, the first communication protocol we are using is Serial. Unity doesn’t usually include the libraries needed to use the SerialPort class. To get around this, go to Edit->Project Settings->Player. Scroll down to “configuration”. Click the box next to “API compatibility level*” and choose “.NET 2.0”.


Inside of “Compileandsend.cs”’s “Compileandsend : Monobehavior” class’s Start(), change the variable portName to the name of the port you are using. If the portName is incorrect or there is no valid device there with which to communicate, an exception will be thrown. This exception appears as: “IOException: the port ‘COM3’ does not exist. System.IO.Ports.WinSerialStream.ReportIOError (System.String optional_arg)”. This won’t affect the running of the program besides not being able to communicate (stream.write handles the port not being open without crashing).

Lockup/Hang/Freeze Problem
Unity freezes, without using excessive processing or memory resources, the stream was successfully opened, when stream.write is called, and the Arduino calls Serial.print() (It is verified that the stream was successfully opened because nothing is printed from the exception catch block after SerialPort.write was called). To avoid Unity freezing, don’t call Serial.print() in the Arduino code.

Data Format

The baud rate is 115200. 
The data structure is an array of chars with each magnet represented by 2 bytes as seen in the image below.

<PICTURE OF TOUCHPOINT LOCATIONS LABELED WITH ARRAY NUMBER>
<TABLE OF ARRAY NUMBER WITH PIN NUMBERS>
Verification of Data Transfer from Unity to Arduino
Given the performance of the glove relies on the magnets triggering correctly, it is crucial to verify the Arduino receives accurate data from Unity. Verification of data is being performed incrementally. The first test was done by having the Arduino turn on an LED when it reads Serial data and off when there is no data to read. The light is dim meaning it is successfully switching between the two states. A second successful test was to switch the LED on/off after every 20th byte read by the Arduino (this switching was visible to the naked eye). These two tests can be found under “Arduino Code -> unityToArduinoSerial (1_3_2018)” in the Google Drive. A third successful test was to have the Arduino send “hello” back for Unity to read when it reads the start code from the buffer. The next step is to have the Arduino send what it receives to a Raspberry Pi and check the result against what Unity said it sent.

