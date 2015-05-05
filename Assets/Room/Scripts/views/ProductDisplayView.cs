using UnityEngine;
using System.Collections;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace Demo {

	public class ProductDisplayView : View {

		public GameObject[] products = new GameObject[3];
        public GameObject[] productInfo = new GameObject[3];
        private int         currentIndex;
        private bool        fading = false;
        private bool        faded = true;
        private bool        infoOnShow = false;
        private bool        objectRolledOver = true;

		private ObjectState state;

		override protected void Awake()
		{
			base.Awake();
			state = this.GetComponent<ObjectState>();
            HideAllInfo();
            currentIndex = 0;
		}

        void HideAllInfo()
        {
            foreach (GameObject infoBox in productInfo)
            {
                infoBox.GetComponent<Fader>().FadeOut();
            }
        }

        void ToggleInfo(GameObject infoBox)
        {
            faded = false;
            fading = true;
            if (infoOnShow == false)
            {
                infoBox.GetComponent<Fader>().FadeIn();
            }
            else
            {
                infoBox.GetComponent<Fader>().FadeOut();
            }
            fading = false;
            faded = true;
        }

		public void receivedInteraction(TouchEvent evt)
		{
            switch (evt)
				{
				case TouchEvent.Tap:

                    if (!(products[currentIndex].GetComponent<ObjectState>().selected))
                    {
                        print("activate!");
                        productInfo[currentIndex].GetComponent<Fader>().FadeIn();
                    }
                    else
                    {
                        print("Deactivate!");
                        productInfo[currentIndex].GetComponent<Fader>().FadeOut();
                    }

					break;
				case TouchEvent.SwipeLeft:
					break;
				case TouchEvent.SwipeRight:
					break;
				case TouchEvent.SwipeUp:
					break;
				case TouchEvent.SwipeDown:
					break;
				}
			
		}

		void Update(){

            //int previousIndex = currentIndex;
            //currentIndex = 0;

            for (int i = 0; i < products.Length; i++)
            {
                objectRolledOver = false;
                if (products[i].GetComponent<ObjectState>().hit)
                {
                    currentIndex = i;
                    objectRolledOver = true;
                }

                if (objectRolledOver && !infoOnShow && !fading)
                {
                    print("Toggle On");
                    ToggleInfo(productInfo[currentIndex]);
                    infoOnShow = true;

                }
                else if (!objectRolledOver && infoOnShow && !fading)
                {
                    print("Toggle Off");
                    ToggleInfo(productInfo[currentIndex]);
                    infoOnShow = false;

                }
            }
		}
		

	}
}