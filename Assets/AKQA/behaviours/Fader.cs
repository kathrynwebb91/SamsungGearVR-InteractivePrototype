using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour
{
	
		void updateAlpha(float val)
		{
			this.renderer.material.SetColor("_Color",new Color(val,val,val,val));
		}

		public void FadeOut(){

			if (this.renderer) {
				Hashtable hash = new Hashtable ();
				hash.Add ("from", 1);
				hash.Add ("to", 0);
				hash.Add ("time", 1);
				hash.Add ("onupdate", "updateAlpha");
				iTween.ValueTo (gameObject, hash);
			}

			if (transform.childCount > 0) {
				for (int i=0; i<transform.childCount; i++) {
					if(transform.GetChild(i).GetComponent<Fader>()){
						transform.GetChild(i).GetComponent<Fader>().FadeOut();
					}
				}
			}
		}

		public void FadeIn(){

			if (this.renderer) {
				Hashtable hash = new Hashtable ();
				hash.Add ("from", 0);
				hash.Add ("to", 1);
				hash.Add ("time", 1);
				hash.Add ("onupdate", "updateAlpha");
				iTween.ValueTo (gameObject, hash);
			}
			
			if (transform.childCount > 0) {
				for (int i=0; i<transform.childCount; i++) {
					if(transform.GetChild(i).GetComponent<Fader>()){
						transform.GetChild(i).GetComponent<Fader>().FadeIn();
					}
				}
			}
		}
}

