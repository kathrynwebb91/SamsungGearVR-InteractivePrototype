using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
		float speed = 75.0F;
		Vector3 v3;

		// Use this for initialization
		void Start ()
		{
			Vector3 v3 = new Vector3 ();
		}
	
		// Update is called once per frame
		void Update ()
		{

			v3 = new Vector3(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), 0.0F);
			transform.Rotate(v3 * speed * Time.deltaTime); 

		}
}

