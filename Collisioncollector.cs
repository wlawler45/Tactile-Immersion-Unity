using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class used to gather data from the different touch points on each fingertip, assign values to them and write them into an array, this class is attached to every fingertip prefab
public class Collisioncollector : MonoBehaviour {
	public GameObject ArduinoController;//=GetComponent<Compileandsend>();
	
	public Compileandsend outputter;
	private int IDoffset;  //IDoffset allows this code to determine which finger it is on and adapt the ID number of the actuator
	//    Use this for initialization
	void Start(){ 
		ArduinoController = GameObject.FindWithTag ("SerialSender");
		//LATER ADD EXCEPTION CATCHER FOR IF THIS RETURNS NULL TO HELP PEOPLE WITH INITIALIZATION
		outputter=ArduinoController.GetComponent<Compileandsend>();
		IDoffset = 0;
		//name is set in the scene after the prefab is instantiated
		if (gameObject.name.Contains ("Index")) {  
			IDoffset=5; //each finger has 5 actuators except for ring and pinky finger which have 3
		}
		if (gameObject.name.Contains ("Middle")) {
			IDoffset=10;
		}
		if (gameObject.name.Contains ("Ring")) {
			IDoffset=15;
		}
		if (gameObject.name.Contains ("Pinky")) {
			IDoffset=18;
		}
	}


	public void addvalue(int ID, int value){ //ID is number of actuator in array (between 1 and 5 since it is per finger) and value is collision information recorded
		
		//Debug.Log ("addvalue");
		int x=ID+IDoffset; //Full actuator ID determination


		outputter.editOut (x, value); //writes value to overall array
		//Debug.Log (value);
	}
}
