using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.IO.Ports;
//
//class assigned to prefab touch points to generate output values for force feedback
public class impulsecode : MonoBehaviour {
	
	public int count = 0;
	public int average = 0;
	public int mass; //undefined variables are given values in the Unity scene or by prefab units brought into the scene, purposefully left undefined here
	public int ID;
	public Color onColor = new Color (1, (float)0.92, (float) 0.016, 1);
	public Color offColor = new Color (0,0,0,1);
	
	public Collisioncollector cc;

	//grab collisioncollector object from scene, calls on initialization
	public void Start () {
		cc = transform.parent.GetComponent<Collisioncollector> ();
	}
	//function called when object first comes into contact with something, generates collision data 
	void OnCollisionEnter (Collision col) {
		//only send the velocity and mass not the derivative of anything
		float momentum =((col.relativeVelocity.sqrMagnitude)*mass)/(mass+col.rigidbody.mass); //this may not be the best way to get momentum
		int sender = Mathf.RoundToInt(momentum*200); //momentum values were around 5, so multiply by 200 to maintain more precision
		if (sender > 4095) sender=4095;
		cc.addvalue(ID,sender);

		//Change color of touchpoint on collision
		this.gameObject.GetComponent<Renderer>().material.color = onColor;
	}
	
	//function called while object is still in contact with object
	void OnCollisionStay (Collision col){
		//send the derivative by storing the previous value, ((current velocity-previous velocity)/period)*mass of objects possibly divided by collision area if the area makes a difference to the pressure calculation.
		//float impact = col.impulse.sqrMagnitude;
		//Debug.Log ("Impulse:");
		//still experimenting with best way to obtain collision data because Impulse function in Unity fails to reliably return correct data
		float velocity = col.relativeVelocity.sqrMagnitude;
		int velocitint = Mathf.RoundToInt (velocity*100); //*100 is added for increased precision
		if (velocitint > 4094) 
			velocitint=4094; //4095 will be the terminaion int for serial
		
		cc.addvalue (ID, velocitint); 
		//if (velocity > 255)
		//	velocity = 255;
		

		//byte biter = (byte)velocity;

		//sp.WriteLine (biter.ToString ());

		//Debug.Log("Sending current");


	}
	
	//function called when object exits collision, sets color of object back and also ensures data is set to zero
	void OnCollisionExit (Collision col){
		//sp.WriteLine ("0");
		cc.addvalue(ID,0);
		//Debug.Log ("Exited");

		//Change color of touchpoint back since the collision is done
		this.gameObject.GetComponent<Renderer>().material.color = offColor;
	}

	// Update is called once per frame

}
