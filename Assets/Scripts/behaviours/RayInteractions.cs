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


	void Awake(){
		hit = false;
		state =  GetComponentInParent<ObjectState>();
	}

	void Start () {
		
	}

	void Update () {
		RaycastHit rayHit;
		Ray ray = new Ray (cameraController.centerEyeAnchor.position, cameraController.centerEyeAnchor.forward);
		
		if (Physics.Raycast(ray, out rayHit ,1000)) {
			if(rayHit.collider.gameObject == gameObject)
			{
				state.hit = true;
			}else{
				state.hit = false;
			}
		}else{


		}
	}
}
