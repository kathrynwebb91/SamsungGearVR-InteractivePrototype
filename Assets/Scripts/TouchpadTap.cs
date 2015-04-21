using UnityEngine;
using System;

public class TouchpadTap : MonoBehaviour {

	private GameObject[] 	colorTargets;
	private GameObject[] 	rotateTargets;
	private GameObject[] 	productTargets;
	private GameObject 		currentTarget;
	private string			targetType;
	private bool			targetChosen;
	private Color			targetColor;
	private int				targetIndex;
	public OVRCameraRig		cameraController;
	private bool			highlighted;
	private GameObject 		objectmesh;

	// Use this for initialization
	void Start () {
		targetChosen = false;
		targetColor = Color.gray;
		//StoreTargets ("Sphere",4);
		StoreTargets ("Cube",4);
		//StoreTargets ("Product",1);
		OVRTouchpad.TouchHandler += TouchEventCallback;
		highlighted = false;
		GameObject objectmesh = new GameObject();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!targetChosen) {
			//currentTarget = DetectTarget ();
			//Debug.Log(targetIndex);
		}
	}

	void StoreTargets(String targetName, int targetNum){

		int curTargetNum = 0;
		String curTargetName;
		if (targetName.Equals ("Sphere")) {

			colorTargets = new GameObject[targetNum];
			for (int i = 1; i <= targetNum; i++) {
					curTargetName = targetName + i.ToString ();
					curTargetNum = i - 1;
					colorTargets [curTargetNum] = GameObject.Find (curTargetName);
			}

		} else if (targetName.Equals ("Cube")) {

			rotateTargets = new GameObject[targetNum];
			for (int i = 1; i <= targetNum; i++) {
					curTargetName = targetName + i.ToString ();
					curTargetNum = i - 1;
					rotateTargets [curTargetNum] = GameObject.Find (curTargetName);
			}

		} else if (targetName.Equals ("Product")) {

			Debug.Log ("Added a product\n\n\n\n");

			productTargets = new GameObject[targetNum];
			for (int i = 1; i <= targetNum; i++) {
				curTargetName = targetName + i.ToString ();
				curTargetNum = i - 1;
				productTargets [curTargetNum] = GameObject.Find (curTargetName);
			}

			Debug.Log (productTargets.ToString());
			
		}
		

	}

	void TouchEventCallback(object sender, EventArgs args)
	{
		var touchArgs = (OVRTouchpad.TouchArgs)args;
		OVRTouchpad.TouchEvent touchEvent = touchArgs.TouchType;
		Debug.Log ("Touch event");

		switch(touchEvent)
		{
		case OVRTouchpad.TouchEvent.SingleTap:
			Debug.Log("SINGLE CLICK\n");
			if(!targetChosen){
				targetChosen = true;
				//currentTarget.transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);
			}else{
				targetChosen = false;
				//currentTarget.transform.localScale += new Vector3(-0.1F, -0.1F, -0.1F);
			}
			//targetColor = Color.gray;
			break;
			
		case OVRTouchpad.TouchEvent.Left:
			Debug.Log("LEFT SWIPE\n");
			if(targetChosen){
				switch(targetType)
				{
				case "color":
					targetColor = Color.yellow;
					break;
				case "rotate":
					iTween.RotateBy(currentTarget, new Vector3(0F,-0.2F,0F) , 0.3F);
					break;
				case "product":
					iTween.RotateBy(currentTarget, new Vector3(0F,-0.2F,0F) , 0.3F);
					break;
				}
				Debug.Log ("Color chosen");
			}
			break;
			
		case OVRTouchpad.TouchEvent.Right:
			Debug.Log("RIGHT SWIPE\n");
			if(targetChosen){
				switch(targetType)
				{
				case "color":
					targetColor = Color.red;
					break;
				case "rotate":
					iTween.RotateBy(currentTarget, new Vector3(0F,0.2F,0F) , 0.3F);
					break;
				case "product":
					iTween.RotateBy(currentTarget, new Vector3(0F,0.2F,0F) , 0.3F);
					break;
				}
			}
			break;
			
		case OVRTouchpad.TouchEvent.Up:
			Debug.Log("UP SWIPE\n");
			if(targetChosen){
				switch(targetType)
				{
				case "color":
					targetColor = Color.blue;
					break;
				case "rotate":
					iTween.RotateBy(currentTarget, new Vector3(0.2F,0F,0F) , 0.3F);
					break;
				case "product":
					//Swap Models
					break;
				}
			}
			break;
			
		case OVRTouchpad.TouchEvent.Down:
			Debug.Log("DOWN SWIPE\n");
			if(targetChosen){
				switch(targetType)
				{
				case "color":
					targetColor = Color.green;
					break;
				case "rotate":
					iTween.RotateBy(currentTarget, new Vector3(-0.2F,0F,0F) , 0.3F);
					break;
				case "product":
					//Swap Models
					break;
				}
			}
			break;
		}

		if (currentTarget) {
			//currentTarget.renderer.material.color = targetColor;
			Debug.Log("Color Set");
		}

	}

	GameObject DetectTarget(){
		// handle user gaze
		Ray ray = new Ray (cameraController.centerEyeAnchor.position, cameraController.centerEyeAnchor.forward);
		// find the intersection of the ray
		RaycastHit hit = new RaycastHit ();

		/*for (int i = 0; i < colorTargets.Length; i++) {
			if (colorTargets [i].GetComponent<Collider> ().Raycast (ray, out hit, 100.0f)) {
					highlightTarget (colorTargets [i]);
					targetType = "color";
					targetIndex = i;
					return colorTargets [i];
					break;
			} else {
					defaultTargetSettings (colorTargets [i]);
			}
		}*/
		for (int i = 0; i < rotateTargets.Length; i++) {
			if (rotateTargets [i].GetComponent<Collider> ().Raycast (ray, out hit, 100.0f)) {
					highlightTarget (rotateTargets [i]);
					targetType = "rotate";
					targetIndex = i;
					return rotateTargets [i];
					break;
			} else {
					defaultTargetSettings (rotateTargets [i]);
			}
		}
		for (int i = 0; i < productTargets.Length; i++) {
			if (productTargets [i].GetComponent<Collider> ().Raycast (ray, out hit, 100.0f)) {
				highlightTarget (productTargets [i]);
				targetType = "product";
				targetIndex = i;
				return productTargets [i];
				break;
			} else {
				defaultTargetSettings (productTargets [i]);
			}
		}
		
		return null;
	}

	void highlightTarget(GameObject target){
		//target.renderer.material.color = Color.magenta;
		//iTween.ScaleTo(target,new Vector3(0.5F,0.5F,0.5F), 0.2F);
		if (!highlighted) {
			target.transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);
			highlighted = true;
		}
	}

	void defaultTargetSettings(GameObject target){
		//target.renderer.material.color = Color.grey;
		//iTween.ScaleTo(target,new Vector3(0.4F,0.4F,0.4F), 0.2F);
		if(highlighted){
			target.transform.localScale += new Vector3(-0.1F, -0.1F, -0.1F);
			highlighted = false;
		}
	}

}
