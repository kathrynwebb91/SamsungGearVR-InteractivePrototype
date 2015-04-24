using UnityEngine;
using System;
using System.Reflection;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

[RequireComponent(typeof(ObjectState))]
public class TargetView : View
{
        private ObjectState     state;
        private int             activeChild { get; set; }
	    private float 			dragPositionMultiplier;
	    private float			targetDistance;

        void Awake()
        {
            state = GetComponentInParent<ObjectState>();
            if (this.transform.childCount > 0)
            {
                //Switchable childstate =  (Switchable) this.transform.GetChild(1);
            }
        }

		// Use this for initialization
		void Start ()
		{
            activeChild = 0;
			//dragPositionMultiplier = 1.5F;
			//targetDistance = this.transform.position.magnitude; 

		}

        public void tapped()
        {
            if (state.hit)
            {
                state.selected = !state.selected;
            }
        }

        public void swipedLeft()
        {
            state.distance++;
        }

        public void swipedRight()
        {
            state.distance--;
        }

        public void swipedUp()
        {
            state.prefabNum--;
        }

        public void swipedDown()
        {
            state.prefabNum++;
        }

		// Update is called once per frame
		void Update ()
		{

            //state.selected = false;// this might work dependin gon the order of things.
		}

		
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

