using UnityEngine;
using System.Collections;


/**
 * Applied to objects we'd like to manage the position of at play time for example.
 * 
 */
[RequireComponent (typeof (ObjectState))]
public class Selectable : MonoBehaviour {

    public OVRCameraRig cameraController;
	public Camera cameraControllerTest;

	private ObjectState state;
    
	private bool highlighted;
    private bool firstHit;

	void Awake(){
		state =  GetComponent<ObjectState>();
		highlighted = false;
        firstHit = true;

	}

	void Start () {
		
	}

	void Update () {
		if(state.selected)
		{
            /*if (!highlighted)
            {
                highlighted = true;
                this.gameObject.AddComponent("Halo");
            }*/

                CheckHit();

				Ray ray;

                if (cameraControllerTest.enabled) {
					print ("CamEnabled");
					ray = new Ray (cameraControllerTest.transform.position, cameraControllerTest.transform.forward);
				} else {
					ray = new Ray (cameraController.centerEyeAnchor.position, cameraController.centerEyeAnchor.forward);
				}

                //GameObject.Find("PhotoSphereExhibition").GetComponent<Collider> ().Raycast (photosphereray, out spherehit, 100.0f);
                //Vector3 newpoint = spherehit.point - new Vector3(0.1F, 0.1F, 0.1F);

                Vector3 newpoint = ray.origin + (ray.direction * state.distance);
 			    this.transform.position = newpoint;

                //this.transform.LookAt(ray.origin);


		}else{
			/*if(highlighted)
			{   
                Destroy(this.gameObject.GetComponent("Halo"));
                highlighted = false;
			}*/
		}
	}

    void CheckHit()
    {
		Ray ray;
		if (cameraControllerTest.enabled) {
			print ("CamEnabled");
			ray = new Ray (cameraControllerTest.transform.position, cameraControllerTest.transform.forward);
		} else {
			ray = new Ray (cameraController.centerEyeAnchor.position, cameraController.centerEyeAnchor.forward);
		}
        RaycastHit hit = new RaycastHit();

        if (this.GetComponent<Collider>().Raycast(ray, out hit, 1000) && firstHit)
        {
            state.distance = hit.distance;
            firstHit = false;
        }
    }
}
