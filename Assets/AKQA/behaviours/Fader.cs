using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void updateAlpha(float val)
		{
			print ("updating val!");
			this.renderer.material.SetColor("_Color",new Color(val,val,val,val));
		}

		public void FadeOut(){
			//iTween.FadeTo(GameObject.Find(target).renderer.material, 0.0f, 1f);
			Hashtable hash = new Hashtable ();
			hash.Add ("from", 1);
			hash.Add ("to", 0);
			hash.Add ("time", 1);
			hash.Add ("onupdate", "updateAlpha");
			print (gameObject.name);
			iTween.ValueTo (gameObject, hash);
			print ("faded!");

			if (transform.childCount > 0) {
				for (int i=0; i<transform.childCount; i++) {
					if(transform.GetChild(i).GetComponent<Fader>()){
						transform.GetChild(i).GetComponent<Fader>().FadeOut();
					}
				}
			}
		}
}

