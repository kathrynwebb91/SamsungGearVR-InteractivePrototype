using UnityEngine;
using System.Collections;


/**
 * Applied to objects we'd like to manage the position of at play time for example.
 * 
 */
[RequireComponent (typeof (ObjectState))]
public class RollOver : MonoBehaviour {

    private ObjectState state;
	private bool        scaled;
    public AudioClip    clickSound;
    private AudioSource source;

	void Awake(){
		state =  GetComponentInParent<ObjectState>();
		scaled = false;
        source = gameObject.AddComponent<AudioSource>() as AudioSource;
        clickSound = Resources.Load("Audio/Click") as AudioClip;
        source.volume = 10;
        source.clip = clickSound;
	}

	void Update () {
		if(state.hit)
		{
            if (!scaled)
            {
                source.Play();
                iTween.ScaleTo(gameObject, 1.5F * state.origScale, 0.4f);
                scaled = true;
            }
		}else{
			if(scaled)
			{
				iTween.ScaleTo(gameObject, state.origScale ,0.4f);
                scaled = false;
			}
		}
	}
}
