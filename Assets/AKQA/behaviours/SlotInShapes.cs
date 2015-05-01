using UnityEngine;
using System.Collections;

//Matches a shape with it's designated "Hole"
public class SlotInShapes : MonoBehaviour
{
		GameObject targethole;

		void Awake ()
		{
			targethole = GameObject.Find (this.gameObject.name + "Hole");
		}
	
		//Match shape with hole if angle of rotation are the same
		public bool checkShapeMatch(){

			if(this.transform.rotation.eulerAngles.x == targethole.transform.rotation.eulerAngles.x){
				iTween.MoveTo (this.gameObject, targethole.transform.position, 1.0F);
				return true;
			}else{
				return false;
			}
		}

}

