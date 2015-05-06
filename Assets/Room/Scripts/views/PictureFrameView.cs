using UnityEngine;
using System.Collections;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace Demo {

	public class PictureFrameView : View {

		private ChangeColour frameColour;
		private GameObject frame;
		private GameObject artwork;
		public GameObject photosphere;

		private ObjectState state;
		public bool			roomFaded;
		public bool			backToBase;

		override protected void Awake()
		{
			base.Awake();
			state = this.GetComponent<ObjectState>();
			frameColour = gameObject.GetComponentInChildren<ChangeColour>();
			frame = gameObject.transform.FindChild("Frame").gameObject;
			artwork = gameObject.transform.FindChild("ArtWork").gameObject;
			photosphere = GameObject.Find("Sphere360");

			photosphere.GetComponent<SwapMaterial> ().UpdateImage ();
			roomFaded = false;
			backToBase = false;
		}


		public void receivedInteraction(TouchEvent evt)
		{
			if(state.hit || state.selected)
			{
				switch (evt)
				{
				case TouchEvent.Tap:
					//if(!state.selected){
						frameColour.setColour(Color.cyan);
						if(artwork.renderer.material.name == "room (Instance)"){
							backToBase = true;
						}else{
                            backToBase = false;
							photosphere.GetComponent<SwapMaterial> ().setMaterial(artwork.renderer.material);
						}

						state.selected = true;
					//}
					break;
				case TouchEvent.SwipeLeft:
					artwork.GetComponent<SwapMaterial>().nextMaterial();
					break;
				case TouchEvent.SwipeRight:
					artwork.GetComponent<SwapMaterial>().previousMaterial();
					break;
				case TouchEvent.SwipeUp:
					break;
				case TouchEvent.SwipeDown:
					break;
				}
			}
		}

		void Update(){
			if (state.selected && !roomFaded && !backToBase) {
				GameObject.Find ("Room").GetComponent<Fader> ().FadeOut ();
                photosphere.GetComponent<Fader>().FadeIn();
				roomFaded = true;
			}
			if (backToBase && roomFaded) {
				GameObject.Find ("Room").GetComponent<Fader> ().FadeIn();
                photosphere.GetComponent<Fader>().FadeOut();
				roomFaded = false;
				backToBase = false;
				state.selected = false;
			}
		}
		

	}
}