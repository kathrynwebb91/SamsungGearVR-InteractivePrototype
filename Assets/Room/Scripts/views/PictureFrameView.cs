using UnityEngine;
using System.Collections;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace Demo {

	public class PictureFrameView : View {

		private ChangeColour frameColour;
		private GameObject frame;
		private GameObject artwork;
		private GameObject photosphere;

		private ObjectState state;
		public bool			faded;
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
			faded = false;
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
							GameObject.Find("Pano").SetActive(true);
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
			if (state.selected && !faded && !backToBase) {
				GameObject.Find ("Room").GetComponent<Fader> ().FadeOut ();
				faded = true;
			}
			if (backToBase && faded) {
				GameObject.Find ("Room").GetComponent<Fader> ().FadeIn();
				faded = false;
				backToBase = false;
				state.selected = false;
			}
		}
		

	}
}