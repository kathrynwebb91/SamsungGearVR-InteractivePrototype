using UnityEngine;
using System.Collections;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

/*
 * 
 * Class to link an array of GameObject items (products) with an array of GameObject info boxes
 * Displays/hides info boxes depending on whether their relative items are looked at/selected
 * 
 */

namespace Demo {

	public class ProductDisplayView : View {

		public GameObject[] products = new GameObject[3];
        public GameObject[] productInfo = new GameObject[3];
        private int         currentIndex;
        private InfoBoxDisplayer currentDispInfo;

		private ObjectState state;

		override protected void Awake()
		{
			base.Awake();
			state = this.GetComponent<ObjectState>();

            currentIndex = 0;
            currentDispInfo = productInfo[currentIndex].GetComponent<InfoBoxDisplayer>();

            HideAllInfo();

		}

        void HideAllInfo()
        {
            foreach (GameObject infoBox in productInfo)
            {
                infoBox.GetComponent<Fader>().Fade(0.01F,infoBox.GetComponent<InfoBoxDisplayer>().originalBGAlpha, 0);
            }
        }

        

		void Update(){

            for (int i = 0; i < products.Length; i++)
            {

                //Check each product for a hit
                if (products[i].GetComponent<ObjectState>().hit)
                {     
                    currentIndex = i;
                    productInfo[currentIndex].GetComponent<InfoBoxDisplayer>().active = true;
                    currentDispInfo = productInfo[currentIndex].GetComponent<InfoBoxDisplayer>();

                }
                else
                {
                    productInfo[i].GetComponent<InfoBoxDisplayer>().active = false;
                }
                
                //Keep info box showing if item selected
                if (products[i].GetComponent<ObjectState>().selected)
                {
                    currentDispInfo.selected = true;
                }
                else
                {
                    currentDispInfo.selected = false;
                }

            }

            //Make info box visible if not already showing
            if (currentDispInfo.active && !currentDispInfo.infoOnShow)
            {
                currentDispInfo.ShowInfo();
            }

            //Hide info box if it is showing
            if (!currentDispInfo.active && currentDispInfo.infoOnShow)
            {
                currentDispInfo.HideInfo();

            }


            
		}
		

	}
}