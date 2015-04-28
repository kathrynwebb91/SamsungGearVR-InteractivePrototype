using UnityEngine;
using System;
using System.Collections;
using System.Reflection;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

[RequireComponent(typeof(ObjectState))]
public class PortalMenuView : View
{
        public ObjectState     	state;
		public bool				faded;

        void Awake()
        {
            state = this.GetComponent<ObjectState>();
			faded = false;
        }


        public void tapped()
        {
            if (state.hit)
            {
				print ("PORTAL MENU GOT TAPPED!");
                state.selected = !state.selected;
            }
        }

        public virtual void swipedLeft()
        {

			state.destinationNum++;

        }

		public virtual void swipedRight()
        {

			state.destinationNum--;

		}

		public virtual void swipedUp()
        {

            
        }

		public virtual void swipedDown()
        {

        }

		void Update(){
			if (state.selected && !faded) {
				print ("about to fade!");
				//GameObject.Find("Room").SetActive(false);
				FadeOut("Room");     
			}
		}

		void updateTrailAlpha(float val)
		{
			print ("updating val!");
			renderer.material.SetColor("_Color",new Color(val,val,val,val));
		}
	
		void FadeOut(string target){
			//iTween.FadeTo(GameObject.Find(target).renderer.material, 0.0f, 1f);
			Hashtable hash = new Hashtable ();
			hash.Add ("from", 1);
			hash.Add ("to", 0);
			hash.Add ("time", 1);
			hash.Add ("onupdate", "updateTrailAlpha");
			iTween.ValueTo (GameObject.Find ("PortalWall").gameObject, hash);
		print ("faded!");
			faded = true;
		}


	
	
	
}

