using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContorl : MonoBehaviour
{
	//Variables
	//This objects transform
	//the transform of the object that this object is looking at
	public Transform CameraTransform, TargetTransform;
	
	//zoom speed
	//rotation speed
	public float ZoomSpeed, RotationSpeed;

	//FPS zoom position(vector3)
	//Furthest 3rd Person mode zoom position(vector3)
	public Vector3 FPSZoomPosition, RdPersonZoomPosition;

	//bool IsCameraIn3rdPersonMode
	public bool IsCameraIn3rdPersonMode;

	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{

	}
}
