using UnityEngine;
using System;
using System.Reflection;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

[RequireComponent(typeof(ObjectState))]
public class TargetView : View
{
        private ObjectState state;
	    private float 			dragPositionMultiplier;
	    private float			targetDistance;
		
		// Use this for initialization
		void Start ()
		{
			//active = false;
			//selected = false;

			//haloHighlight = this.GetComponent("Halo");
			
			//dragPositionMultiplier = 1.5F;
			//targetDistance = this.transform.position.magnitude; 

		}

        public void tapped()
        {

            state.selected = !state.selected;
        }


		// Update is called once per frame
		void Update ()
		{

            //state.selected = false;// this might work dependin gon the order of things.
		}

		/*// Called if item is selected
		void Select(){
			//selected = true;
			ScaleTarget (0.05F);
			ToggleHalo (true);
		}

		// Called if item is unselected
		void Deselect(){
			//selected = false;
			ScaleTarget (-0.05F);
			ToggleHalo (false);
		}

		void Reset(){
			//Revert this to usual state
			//if (active) {
			//	active = false;
			//}
			//if (selected) {
			//	selected = false;
			//}
		}*/

		/***Interaction functions***/

		/*void RotateTarget(string axis, string direction){
			if (direction == "clockwise") {

			} else if (direction == "anticlockwise") {

			}
		}

		void MoveProduct(Vector3 direction){
			transform.Translate (direction);
		}
		
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
		*/
	
}

