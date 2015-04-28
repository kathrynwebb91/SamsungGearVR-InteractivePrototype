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
	private Transform camTrans;
	private Vector3 camForward;

	void Awake(){
		hit = false;
		state =  GetComponent<ObjectState>();

		setCamera(Camera.main);
	}

	void Start () {
		
	}

	void setCamera(Camera camera)
	{
		camTrans = camera.transform;
		camForward = camera.transform.forward;
	}

	void Update () {
		RaycastHit rayHit;
		Ray ray;
		ray = new Ray (camTrans.position, camForward);

		if (Physics.Raycast(ray, out rayHit ,1000)) {
			if(rayHit.collider.gameObject == gameObject)
			{
				state.hit = true;
				if(state.firstHit){
					state.distance = rayHit.distance;
					state.firstHit = false;
				}
			}else{
				state.hit = false;
			}
		}
	}


}
