using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.IO.Ports;

public class impulsecode : MonoBehaviour {
	//public CommSerial commSerial;
	//public Ardunity.CommSerial sp=new Ardunity.CommSerial();
	public int count = 0;
	public int average = 0;
	public SerialPort sp = new SerialPort ("COM9", 115200);

	public void Start () {
		
		//	sp.ReadTimeout = 50;
			sp.Open();
			Debug.Log ("Start eating shit more");
			sp.Write ("" + 110);
		//WaitForSecondsRealtime (0.01);

		// Open current serial port
		//commSerial.Open();
		//string [] ports=System.IO.Ports.SerialPort.GetPortNames();
		//foreach (string s in ports) {
		//	Debug.Log (s);
		//}
		//sp.Open();

		//sp.ReadTimeout = 50;
	}
	// Use this for initialization
	void OnCollisionEnter (Collision col) {
		float impact = col.impulse.sqrMagnitude;

		float multiple = impact * 10;
		Debug.Log ("Entered");
		int sender = Mathf.RoundToInt (impact);

		//sp.WriteLine("110");
		//sp.Write ("" + 110);
		//sp.Write ("" + 155);
		//sp.Write ("" + 210);
		//sp.Write ("" + 255);
		if (sender > 255)
			sender = 255;
//		bool flag = false;
		byte biter=(byte)sender;
		Debug.Log (biter.ToString());
		sp.WriteLine(biter.ToString());
		//commSerial.Write(bit,flag);
		//Serialout.SendSerialMessage (sender.ToString());
		Debug.Log ("Sent first");
		//WaitForEndOfFrame;
		//Debug.Log (sender.ToString());

	}
	void OnCollisionStay (Collision col){
		float impact = col.impulse.sqrMagnitude;
		Debug.Log ("Impulse:");


		Debug.Log (impact.ToString ());

		int sender = Mathf.RoundToInt (impact);
		if (sender > 255)
			sender = 255;
		float velocity = col.relativeVelocity.sqrMagnitude;
		Debug.Log ("Velocity=");
		Debug.Log (velocity);
		sender = 150;
		byte biter = (byte)sender;
		//Debug.Log ("average:");
		//Debug.Log (biter.ToString ());
		sp.WriteLine (biter.ToString ());
		/*if (count < 5) {
			average += sender;
			count += 1;
		}
		if (count >= 5) {
			count = 0;
			average /= 5;
			sender = Mathf.RoundToInt (average);

			if (sender > 255)
				sender = 255;
			sender = 150;
			byte bit = (byte)sender;

			average = 0;
			Debug.Log ("average:");
			Debug.Log (bit.ToString ());
			sp.WriteLine (bit.ToString ());
			//WaitForEndOfFrame;
		}*/
		//Debug.Log (sender.ToString ());
		//if (sender > 255)
		//	sender = 255;
		//byte bit = (byte)sender;
		//Debug.Log ("It's inside of you"); 
		//Debug.Log (bit.ToString ());
		//sender = 80;
		//while (!sp.IsOpen);
		//sp.WriteLine (bit.ToString ());

		//Serialout.SendSerialMessage (sender.ToString());
		Debug.Log("Sending current");
	}
	void OnCollisionExit (Collision col){
		sp.WriteLine ("0");
		Debug.Log ("Exited");
	}

	// Update is called once per frame

}