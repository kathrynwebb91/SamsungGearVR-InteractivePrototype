using UnityEngine;
using System;
using System.Reflection;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

[RequireComponent(typeof(ObjectState))]
public class PortalMenuView : View
{
        public ObjectState     	state;
        private int             activeChild { get; set; }

        void Awake()
        {
            state = this.GetComponent<ObjectState>();
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

        public virtual void swipedLeft()
        {
			if (state.selected) {
				if (state.rotateable) {
					state.rotateDirection = "left";
				} else if(state.switchable) {
					state.colorNum++;
				} else{
					state.distance++;
				}
			}
        }

		public virtual void swipedRight()
        {
			if (state.selected) {
				if (state.rotateable) {
					state.rotateDirection = "right";
				} else if(state.switchable) {
					state.colorNum--;
				} else{
					state.distance--;
				}
			}
		}

		public virtual void swipedUp()
        {
			if (state.selected) {
				if (state.rotateable) {
					state.rotateDirection = "up";
				} else if(state.switchable) {
					state.prefabNum--;
				} else{

				}
			}
            
        }

		public virtual void swipedDown()
        {
			if (state.selected) {
				if (state.rotateable) {
						state.rotateDirection = "down";
				} else if(state.switchable) {
					state.prefabNum++;
				} else{

				}
			}
        }

		// Update is called once per frame
		void Update ()
		{

            //state.selected = false;// this might work dependin gon the order of things.
		}

		
		/***Interaction functions***/

	/*

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
		

		*/
	
}

