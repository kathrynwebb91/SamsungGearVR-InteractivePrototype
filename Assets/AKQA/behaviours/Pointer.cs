using UnityEngine;
using System.Collections;

public class Pointer : MonoBehaviour {

	public float moveSpeed = 100f;  // Units per second


	void Start () {
	
	}

	void Update () {

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		if (Physics.Raycast(ray, out hit , 1000)) {
			Debug.DrawLine (ray.origin, hit.point);
			Vector3 targetPos = hit.collider.transform.position;
			targetPos = hit.point;
			transform.position = targetPos;//Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
		}


		if (Input.GetMouseButton(0)) {

			//			var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//
			//			//targetPos.z = transform.position.z;
			//			Debug.Log(targetPos);
			//			transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
		}
	}
}
