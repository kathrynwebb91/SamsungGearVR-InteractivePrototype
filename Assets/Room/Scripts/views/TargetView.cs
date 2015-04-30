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
		private ChangeColour	colorSwitcher;
		private SwapPrefab		prefabSwitcher;
		private Rotateable		rotateScript;
		private SlotInShapes	shapeSlotScript;

        void Awake()
        {
            state = this.GetComponent<ObjectState>();
			colorSwitcher = this.GetComponent<ChangeColour>();
			prefabSwitcher = this.GetComponent<SwapPrefab>();
			rotateScript = this.GetComponent<Rotateable>();
			shapeSlotScript = this.GetComponent<SlotInShapes>();
        }

		// Use this for initialization
		void Start ()
		{
            activeChild = 0;
		}

		public void receivedInteraction(TouchEvent evt)
		{

			if(state.hit || state.selected)
			{
				print (evt.ToString());
				print (state.hit.ToString() + state.selected.ToString());
				switch (evt)
				{
				case TouchEvent.Tap:
					if(!state.selected){
						state.selected = true;
					}else{
						state.selected = false;
					}

					break;
				case TouchEvent.SwipeLeft:

						if(colorSwitcher){
							colorSwitcher.previousColor();
							//iTween.RotateAdd(this.gameObject, new Vector3(0, 360 ,0), 1.0F);
						}

						if(prefabSwitcher){
							prefabSwitcher.previousPrefab();
						}

						if(rotateScript){
							state.rotateDirection = ObjectState.RotateDirection.Left;
						}

					break;
				case TouchEvent.SwipeRight:

					if(colorSwitcher){
						colorSwitcher.nextColor();
					}
					
					if(prefabSwitcher){
						prefabSwitcher.previousPrefab();
					}

					if(rotateScript){
						state.rotateDirection = ObjectState.RotateDirection.Right;
					}

					if(shapeSlotScript){
						if(shapeSlotScript.checkShapeMatch()){
							state.selected = false;
		 				}
					}

					break;
				case TouchEvent.SwipeUp:
					if (state.selected) {
						if (state.rotateable) {
							state.rotateDirection = ObjectState.RotateDirection.Up;
						} 
					}
					break;
				case TouchEvent.SwipeDown:
					if (state.selected) {
						if (state.rotateable) {
							state.rotateDirection = ObjectState.RotateDirection.Down;
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

