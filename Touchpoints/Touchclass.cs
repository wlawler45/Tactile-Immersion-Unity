using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchclass : MonoBehaviour {
	//should have a rigidbody, this should be a collider that exists on the outer edge of the finger, finger colliders are already fine, use layering to avoid interaction with leap hand
	public int number_points=7;
	public bool set_visible;
	public float x_offset;
	public float y_offset;
	public float z_offset;
	public GameObject[] finger;
	// Use this for initialization
	void createTouchpoints () {
		
		for (int i = 0; i < number_points; i++) {
			
			if(number_points==7){
				GameObject seven = Instantiate (Resources.Load ("seven_touch_points", typeof(GameObject))) as GameObject;
				finger [i] = seven;
			}	if (number_points == 4) {
			//	touchpoint.transform.localScale = Vector3 (four_cylinder_radius, four_cylinder_radius, height);
				GameObject four = Instantiate (Resources.Load ("four_touch_points", typeof(GameObject))) as GameObject;
				finger [i] = four;
			}	if (number_points == 1) {
				GameObject one = Instantiate (Resources.Load ("one_touch_points", typeof(GameObject))) as GameObject;
				finger [i] = one;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void softlyContacting (){

	}
}
