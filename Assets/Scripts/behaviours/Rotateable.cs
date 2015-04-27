using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectState))]
public class Rotateable : MonoBehaviour
{
		
	private ObjectState state;

		void Awake(){
			state =  this.GetComponent<ObjectState>();
			state.rotateable = true;
		}

	
		// Update is called once per frame
		void Update ()
		{
			if (state.rotateDirection != "stay") {
				switch(state.rotateDirection){
					case "left":
						iTween.RotateAdd (this.gameObject, new Vector3(0,45,0), 0.4F);
						state.rotateDirection = "stay";
					break;
					case "right":
						iTween.RotateAdd (this.gameObject, new Vector3(0,-45,0), 0.4F);
						state.rotateDirection = "stay";	
					break;
					case "up":
						iTween.RotateAdd (this.gameObject, new Vector3(0,0,45), 0.4F);
						state.rotateDirection = "stay";	
					break;
					case "down":
						iTween.RotateAdd (this.gameObject, new Vector3(0,0,-45), 0.4F);
						state.rotateDirection = "stay";
					break;
				}
			}
		}

}

