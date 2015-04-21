using UnityEngine;
using System;
using System.Reflection;

public class TouchpadTarget : MonoBehaviour
{
	private bool 			active;
	private bool 			selected;
	private string 			type;
	private Vector3 		targetSize;
	private int 			targetId;
	public OVRCameraRig		cameraController;
	private Shader 			highlightShader;
	private Component		haloHighlight;
	private GameObject[]	children;
	private int				currentChild;
	private int 			childCount;
	private float 			dragPositionMultiplier;
	private float			targetDistance;
		
		// Use this for initialization
		void Start ()
		{
			active = false;
			selected = false;

			OVRTouchpad.TouchHandler += CheckTouchInput;
			haloHighlight = this.GetComponent("Halo");
			
			//Suports up to 10 different choices within target
			children = new GameObject[10];	

			childCount = 0;
			foreach (Transform child in this.transform) {
				children [childCount] = child.gameObject;
				childCount ++;
			}
			
			currentChild = 0;

			dragPositionMultiplier = 1.5F;
			targetDistance = this.transform.position.magnitude; 

			//Set other children to be inactive
			/*for(int i=0; i< this.transform.childCount; i++)
			{
				children[i] = this.transform.GetChild(i).gameObject;
				Debug.Log(children[i].name);
			//children.setActive(false);
			}*/
			
		}
	
	// Update is called once per frame
		void Update ()
		{
			DetectGaze();
		}

		//Called if item is hovered over
		void Activate(){
			active = true;
			ScaleTarget (0.05F);
		}

		//Called if item leaves hover state
		void Deactivate(){
			active = false;
			ScaleTarget (-0.05F);
			//DropTarget ();
		}

		// Called if item is selected
		void Select(){
			selected = true;
			ScaleTarget (0.05F);
			ToggleHalo (true);
		}

		// Called if item is unselected
		void Deselect(){
			selected = false;
			ScaleTarget (-0.05F);
			ToggleHalo (false);
		}

		void Reset(){
			//Revert this to usual state
			if (active) {
				active = false;
			}
			if (selected) {
				selected = false;
			}
		}
	

		void DetectGaze(){
			// handle user gaze
			Ray ray = new Ray (cameraController.centerEyeAnchor.position, cameraController.centerEyeAnchor.forward);
			Ray photosphereray = new Ray (cameraController.centerEyeAnchor.position, cameraController.centerEyeAnchor.forward);
			// find the intersection of the ray
			RaycastHit hit = new RaycastHit ();
			// find the intersection of the ray with the photosphere
			RaycastHit spherehit = new RaycastHit ();
		
		
			//Reverse ray so that it hits the collider even though it is inside it.
			photosphereray.origin = photosphereray.GetPoint(100);
			photosphereray.direction = -photosphereray.direction;


			if (this.GetComponent<Collider> ().Raycast (ray, out hit, 100.0f)) {
				if(!active){
					Activate();
				}
				if(selected){
					//GameObject.Find("PhotoSphereExhibition").GetComponent<Collider> ().Raycast (photosphereray, out spherehit, 100.0f);
					//Vector3 newpoint = spherehit.point - new Vector3(0.1F, 0.1F, 0.1F);
					
					Vector3 newpoint = ray.origin + (ray.direction * dragPositionMultiplier);
					StickTarget(newpoint);
					//this.transform.LookAt(ray.origin);
				}
		} else {
				if(active){
					Deactivate();
				}
				if(selected){
					Deselect();
				}
			}

		}

		void CheckTouchInput(object sender, EventArgs args)
		{
			if (active) {
				var touchArgs = (OVRTouchpad.TouchArgs)args;
				OVRTouchpad.TouchEvent touchEvent = touchArgs.TouchType;
				Debug.Log ("Touch event");

				switch (touchEvent) {
				case OVRTouchpad.TouchEvent.SingleTap:
					Debug.Log ("SINGLE CLICK\n");
					if(!selected){
						Select();
					}else{
						Deselect();
					}
				break;
		
				case OVRTouchpad.TouchEvent.Left:
					Debug.Log ("LEFT SWIPE\n");
				if(selected){
					dragPositionMultiplier = dragPositionMultiplier + 0.1F;
					//MoveProduct(new Vector3(0,0,-0.1F));
				}
				break;
		
				case OVRTouchpad.TouchEvent.Right:
					Debug.Log ("RIGHT SWIPE\n");
				if(selected){
					dragPositionMultiplier = dragPositionMultiplier - 0.1F;
					//MoveProduct(new Vector3(0,0,0.1F));
				}
				break;
		
				case OVRTouchpad.TouchEvent.Up:
						Debug.Log ("UP SWIPE\n");
				if(selected){
					ChangeProduct(1);
					//MoveProduct(new Vector3(0,0.1F,0));
				}
				break;
		
				case OVRTouchpad.TouchEvent.Down:
						Debug.Log ("DOWN SWIPE\n");
				if(selected){
					ChangeProduct(-1);
					//MoveProduct(new Vector3(0,-0.1F,0));
				}
				break;
				}

			}

		}

	/***Interaction functions***/

		void RotateTarget(string axis, string direction){
			if (direction == "clockwise") {

			} else if (direction == "anticlockwise") {

			}
		}

		void ChangeProduct(int direction){
			//not tested, switching stuff
			children [currentChild].SetActive(false);
			if (direction == 1) {
				if ((currentChild + 1) < childCount) {
						currentChild++;
				} else {
						currentChild = 0;
				}
			} else {
				if ((currentChild - 1) < 0) {
					currentChild = childCount - 1;
				} else {
					currentChild--;
				}
			}
			children [currentChild].SetActive(true);
		}

		void MoveProduct(Vector3 direction){
			transform.Translate (direction);
		}
		
		/***Helper Functions***/
		
		//Select helper function. Shows/hides glow effect when item is selected/deselected
		void ToggleHalo(bool switcher){
			//Highlight product
			var haloEnabledProperty = haloHighlight.GetType().GetProperty("enabled");
			if (switcher) {
				haloEnabledProperty.SetValue (haloHighlight, true, null);
			} else {
				haloEnabledProperty.SetValue (haloHighlight, false, null);
			}
		}
		
		void ScaleTarget(float amount){
			iTween.ScaleAdd(this.gameObject, new Vector3(amount,amount,amount) , 0.3F);
		}
	
		void StickTarget(Vector3 location){
			this.transform.position = location;
		}
		
		void DropTarget(){
		
		}
	
}

