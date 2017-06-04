using UnityEngine;
using System.Collections;

public class FPS_motion : MonoBehaviour {

	public float sensitivity;
	public float mouseSensitivity = 100.0f;
	public float clampAngle = 80.0f;

	private float rotY = 0.0f; // rotation around the up/y axis
	private float rotX = 0.0f; // rotation around the right/x axis
	void Start () {
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("w"))
			transform.Translate (transform.forward * 1 * Time.deltaTime*sensitivity);
		if (Input.GetKey ("a"))
			transform.Translate (transform.right * -1 * Time.deltaTime*sensitivity);
		if (Input.GetKey ("d"))
			transform.Translate (transform.right * 1 * Time.deltaTime*sensitivity);
		if (Input.GetKey ("s"))
			transform.Translate (transform.forward * -1 * Time.deltaTime*sensitivity);
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = -Input.GetAxis("Mouse Y");

		rotY += mouseX * mouseSensitivity * Time.deltaTime;
		rotX += mouseY * mouseSensitivity * Time.deltaTime;

		rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
		transform.rotation = localRotation;
	}

}




