using UnityEngine;
using System.Collections;


/**
 * Applied to objects we'd like to manage the position of at play time for example.
 * 
 */
[RequireComponent (typeof (ObjectState))]
public class RayInteractions : MonoBehaviour {

	protected bool hit = false;

	private ObjectState	state;
	public OVRCameraRig cameraController;
	public Camera cameraControllerTest;


	void Awake(){
		hit = false;
		state =  GetComponentInParent<ObjectState>();
	}

	void Start () {
		
	}

	void Update () {
		RaycastHit rayHit;
		Ray ray;
		if (cameraControllerTest.enabled) {
			ray = new Ray (cameraControllerTest.transform.position, cameraControllerTest.transform.forward);
		} else {
			ray = new Ray (cameraController.centerEyeAnchor.position, cameraController.centerEyeAnchor.forward);
		}

		if (Physics.Raycast(ray, out rayHit ,100.0F)) {
			if(rayHit.collider.gameObject == gameObject)
			{
				state.hit = true;
				print ("Hit!");
			}else{
				state.hit = false;
			}
		}else{


		}
	}
}
