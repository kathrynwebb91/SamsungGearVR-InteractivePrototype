using UnityEngine;
using System.Collections;

public class CameraPreviewRig : MonoBehaviour {



	public GameObject yaw;
	public GameObject pitch;
	public GameObject tilt;

	float sensitivity = 2f;

	void Start () {

	}
	

	void Update () {
		if (Input.GetAxis("Horizontal") >0 || Input.GetAxis("Horizontal") <0 )
		{
			float rotationX = Input.GetAxis("Horizontal") * sensitivity;
			yaw.transform.Rotate(0, rotationX, 0);
		}
		if (Input.GetAxis("Vertical") >0 || Input.GetAxis("Vertical") <0 )
		{
			float rotationY = Input.GetAxis("Vertical") * sensitivity;
			pitch.transform.Rotate(-rotationY,0, 0);
		}
	}


}
