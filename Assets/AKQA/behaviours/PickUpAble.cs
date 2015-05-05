using UnityEngine;
using System.Collections;


/**
 * Applied to objects such that they are attatched to the gaze of the user when selected
 * 
 */
[RequireComponent (typeof (ObjectState))]
[RequireComponent(typeof(RayInteractions))]
public class PickUpAble : MonoBehaviour {


	private Camera cam;
	private Transform camTrans;
	private Vector3 camForward;

	private ObjectState state;
    private RayInteractions rayData;

	void Awake(){
		state =  GetComponent<ObjectState>();
        rayData= GetComponent<RayInteractions>();
	}

	void Update () {
		if (state.selected) {

			Ray ray;

            ray = new Ray(rayData.camTrans.position, rayData.camForward);

			Vector3 newpoint = ray.origin + (ray.direction * state.distance);
			this.transform.position = newpoint;

		}
	}

}
