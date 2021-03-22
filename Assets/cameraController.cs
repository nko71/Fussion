using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{


	public GameObject CameraFollowObj;


	public float disFromTarget = 2;
	public Vector3 followOffset;
	public float pitchmin = -40;
	public float pitchmax = 85;
	public float mouseX;
	public float mouseY;

	float yaw;
	float pitch;

	public float mouseSensitivity = 10;
	public float rotationSmoothTime = 0.1f;
	public Vector3 rotationSmoothVelocity;
	Vector3 currentRotation;








	// Use this for initialization
	void Start()
	{

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;


	}

	




	void LateUpdate()
	{


		mouseX = Input.GetAxis("Mouse X");
		mouseY = Input.GetAxis("Mouse Y");



		yaw += mouseX * mouseSensitivity;
		pitch -= mouseY * mouseSensitivity;

		pitch = Mathf.Clamp(pitch, pitchmin, pitchmax);



		currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);




		transform.eulerAngles = currentRotation;


		transform.position = CameraFollowObj.transform.position + followOffset - transform.forward * disFromTarget;





	}




}
