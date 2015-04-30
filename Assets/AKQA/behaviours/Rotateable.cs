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
		if (state.rotateDirection != ObjectState.RotateDirection.None) {
				switch(state.rotateDirection){
					case ObjectState.RotateDirection.Left:
							//iTween.RotateAdd (this.gameObject, new Vector3(0,45,0), 0.4F);
						break;
					case ObjectState.RotateDirection.Right:
							//iTween.RotateAdd (this.gameObject, new Vector3(0,-45,0), 0.4F);
						break;
					case ObjectState.RotateDirection.Up:
							//iTween.RotateAdd (this.transform.GetChild(0).gameObject, new Vector3(0,0,45), 0.4F);
							iTween.RotateAdd (this.gameObject, new Vector3(-45,0,0), 0.4F);
						break;
					case ObjectState.RotateDirection.Down:
							//iTween.RotateAdd (this.transform.GetChild(0).gameObject, new Vector3(0,0,-45), 0.4F);
							iTween.RotateAdd (this.gameObject, new Vector3(45,0,0), 0.4F);
						break;
				}
			state.rotateDirection = ObjectState.RotateDirection.None;
			}
		}

}

