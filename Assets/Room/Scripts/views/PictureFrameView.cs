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
		public bool				faded;

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
		}


		public void receivedInteraction(TouchEvent evt)
		{
			if(state.hit || state.selected)
			{
				switch (evt)
				{
				case TouchEvent.Tap:
					frameColour.setColour(Color.cyan);
					state.selected = !state.selected;
					//frame.GetComponent<SwapPrefab>().nextPrefab();
					break;
				case TouchEvent.SwipeLeft:
					artwork.GetComponent<SwapMaterial>().nextMaterial();
					photosphere.GetComponent<SwapMaterial> ().setMaterial(artwork.renderer.material);
					break;
				case TouchEvent.SwipeRight:
					artwork.GetComponent<SwapMaterial>().previousMaterial();
					photosphere.GetComponent<SwapMaterial> ().setMaterial(artwork.renderer.material);
					break;
				case TouchEvent.SwipeUp:

					break;
				case TouchEvent.SwipeDown:

					break;
				}
			}
		}

		void Update(){
			if (state.selected) {
				print ("selected!");
			}
			if (state.selected && !faded) {
				print ("about to fade!");
				//GameObject.Find("Room").SetActive(false);
				GameObject.Find ("Room").GetComponent<Fader>().FadeOut();
				faded=true;
			}
		}
		

		
		/*void FadeOut(string target){
			//iTween.FadeTo(GameObject.Find(target).renderer.material, 0.0f, 1f);
			Hashtable hash = new Hashtable ();
			hash.Add ("from", 1);
			hash.Add ("to", 0);
			hash.Add ("time", 1);
			hash.Add ("onupdate", "updateAlpha");
			GameObject wall = GameObject.Find ("Room").transform.GetChild (2).gameObject;
			print (wall.name);
			iTween.ValueTo (wall, hash);
			faded = true;
		}*/


		
	}
}