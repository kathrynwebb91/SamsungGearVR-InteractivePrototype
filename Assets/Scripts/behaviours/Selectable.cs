using UnityEngine;
using System.Collections;


/**
 * Applied to objects we'd like to manage the position of at play time for example.
 * 
 */
[RequireComponent (typeof (ObjectState))]
public class Selectable : MonoBehaviour {


	private ObjectState state;
    
	private bool highlighted;

	void Awake(){
		state =  GetComponentInParent<ObjectState>();
		highlighted = false;
	}

	void Start () {
		
	}

	void Update () {
		if(state.selected)
		{
            if (!highlighted)
            {
                highlighted = true;
                this.gameObject.AddComponent("Halo");
            }

		}else{
			if(highlighted)
			{   
                Destroy(this.gameObject.GetComponent("Halo"));
                highlighted = false;
			}
		}
	}
}
