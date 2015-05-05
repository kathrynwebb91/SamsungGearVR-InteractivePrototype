using UnityEngine;
using System.Collections;


/**
 * Applied to objects we'd like to manage the position of at play time for example.
 * 
 */
[RequireComponent (typeof (ObjectState))]
public class RollOver : MonoBehaviour {


	private ObjectState state;
	private bool scaled;

	void Awake(){
		state =  GetComponentInParent<ObjectState>();
		scaled = false;
	}

	void Update () {
		if(state.hit)
		{
			scaled = true;
			iTween.ScaleTo(gameObject, 1.5F * state.origScale ,0.4f);
		}else{
			if(scaled)
			{
				iTween.ScaleTo(gameObject, state.origScale ,0.4f);
			}
		}
	}
}
