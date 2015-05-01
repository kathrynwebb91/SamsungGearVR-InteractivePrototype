using UnityEngine;
using System.Collections;


/**
 * Applied to objects we'd like to manage the position of at play time for example.
 * 
 */
[RequireComponent (typeof (ObjectState))]
public class PickUpAble : MonoBehaviour {


	private Camera cam;
	private Transform camTrans;
	private Vector3 camForward;

	private ObjectState state;
    
	//private bool highlighted;

	void Awake(){
		state =  GetComponent<ObjectState>();
		setCamera (Camera.main);
	}

	void updateCameraVals()
	{
		camTrans = cam.transform;
		camForward = cam.transform.forward;
	}

	void setCamera(Camera camera)
	{
		cam = camera;
		updateCameraVals ();
	}

	void Update () {
		if (state.selected) {

			Ray ray;

			updateCameraVals ();
       
			ray = new Ray (camTrans.position, camForward);

			Vector3 newpoint = ray.origin + (ray.direction * state.distance);
			this.transform.position = newpoint;

		}
	}

}
