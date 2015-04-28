using UnityEngine;
using System;
using System.Reflection;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace Demo{

[RequireComponent(typeof(ObjectState))]
public class TargetView : View
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

		public void receivedInteraction(TouchEvent evt)
		{
			if(state.hit || state.selected)
			{
				switch (evt)
				{
				case TouchEvent.Tap:
					state.selected = !state.selected;
					break;
				case TouchEvent.SwipeLeft:
					if (state.rotateable) {
						state.rotateDirection = ObjectState.RotateDirection.Left;
					} else if(state.switchable) {
						//state.colorNum++;
					} else{
						state.distance++;
					}
					break;
				case TouchEvent.SwipeRight:
					if (state.rotateable) {
						state.rotateDirection = ObjectState.RotateDirection.Right;
					} else if(state.switchable) {
						//state.colorNum--;
					} else{
						state.distance--;
					}
					break;
				case TouchEvent.SwipeUp:
					if (state.selected) {
						if (state.rotateable) {
							state.rotateDirection = ObjectState.RotateDirection.Up;
						} else if(state.switchable) {
							//state.prefabNum--;
						} else{
							
						}
					}
					break;
				case TouchEvent.SwipeDown:
					if (state.selected) {
						if (state.rotateable) {
							state.rotateDirection = ObjectState.RotateDirection.Down;
						} else if(state.switchable) {
							//state.prefabNum++;
						} else{
							
						}
					}
					break;
				}
			}
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
}

