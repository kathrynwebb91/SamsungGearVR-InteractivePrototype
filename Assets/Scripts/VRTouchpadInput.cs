using UnityEngine;
using System;
using System.Reflection;

[RequireComponent (typeof (ObjectState))]
public class TouchpadVR : MonoBehaviour
{
	protected bool touch = false;
	private ObjectState 	state;
	public OVRCameraRig		cameraController;

	// Use this for initialization
	void Start ()
	{
		//OVRTouchpad.TouchHandler += CheckTouchInput;
	}
	
	// Update is called once per frame
	void Update ()
	{
		DetectGaze();
	}
	
	void DetectGaze(){
		// handle user gaze
		Ray photosphereray = new Ray (cameraController.centerEyeAnchor.position, cameraController.centerEyeAnchor.forward);
		// find the intersection of the ray with the photosphere
		RaycastHit spherehit = new RaycastHit ();
		
		//To check photosphere collision, Reverse ray so that it hits the collider even though it is inside it.
		photosphereray.origin = photosphereray.GetPoint(100);
		photosphereray.direction = -photosphereray.direction;
		
	}
	
}

