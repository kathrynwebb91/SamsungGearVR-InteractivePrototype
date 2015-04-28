using UnityEngine;
using System.Collections;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace Demo {

	public class PictureFrameView : View {

		private ChangeColour frameColour;
		private GameObject frame;
		private GameObject artwork;


		private ObjectState state;

		override protected void Awake()
		{
			base.Awake();
			state = this.GetComponent<ObjectState>();
			frameColour = gameObject.GetComponentInChildren<ChangeColour>();
			frame = gameObject.transform.FindChild("Frame").gameObject;
			artwork = gameObject.transform.FindChild("ArtWork").gameObject;
		}


		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}


		public void receivedInteraction(TouchEvent evt)
		{
			if(state.hit || state.selected)
			{
				switch (evt)
				{
				case TouchEvent.Tap:
					frameColour.setColour(Color.cyan);
					frame.GetComponent<SwapPrefab>().nextPrefab();
					break;
				case TouchEvent.SwipeLeft:
					artwork.GetComponent<SwapMaterial>().nextMaterial();
					artwork.GetComponent<SwapMaterial>().UpdateImage();
					break;
				case TouchEvent.SwipeRight:
					artwork.GetComponent<SwapMaterial>().previousMaterial();
					artwork.GetComponent<SwapMaterial>().UpdateImage();
					break;
				case TouchEvent.SwipeUp:

					break;
				case TouchEvent.SwipeDown:

					break;
				}
			}
		}


		
	}
}