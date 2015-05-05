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
	private Camera cam;
	public Transform camTrans;
	public Vector3 camForward;

	void Awake(){
		hit = false;
		state =  GetComponent<ObjectState>();
		setCamera (Camera.main);
	}

	void setCamera(Camera camera)
	{
		cam = camera;
		updateCameraVals ();
	}

    void updateCameraVals()
    {
        camTrans = cam.transform;
        camForward = cam.transform.forward;
    }

	void Update () {
		RaycastHit rayHit;
		Ray ray;
		updateCameraVals ();
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
