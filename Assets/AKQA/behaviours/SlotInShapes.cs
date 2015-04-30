using UnityEngine;
using System.Collections;

public class SlotInShapes : MonoBehaviour
{
		GameObject targethole;

		// Use this for initialization
		void Awake ()
		{
			targethole = GameObject.Find (this.gameObject.name + "Hole");
		}
	
		public bool checkShapeMatch(){

			if(this.transform.rotation.eulerAngles.x == targethole.transform.rotation.eulerAngles.x){
				iTween.MoveTo (this.gameObject, targethole.transform.position, 1.0F);
				return true;
			}else{
				return false;
			}
		}

}

