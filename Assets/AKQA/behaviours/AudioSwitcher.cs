using UnityEngine;
using System.Collections;

/**
 * Applied to objects where we want to swap prefabs at runtime.
 * 
 */
public class AudioSwitcher : MonoBehaviour
{
    public AudioSource[] sources;
    AudioSource localAudio;
    bool playing;
	
	void Awake ()
	{
        playing = false;
        string[] targetNameArray = this.name.Split();
        sources = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource source in sources)
        {
            string[] audioNameArray =  source.name.Split();
            if (audioNameArray[0] == targetNameArray[0])
            {
                localAudio = source;
            }
        }
	}

    void Update()
    {
        if (this.GetComponent<ObjectState>().anyhit && !playing)
        {
            localAudio.Play();
            playing = true;
        }

        if (!(this.GetComponent<ObjectState>().anyhit) && playing)
        {
            localAudio.Pause();
            playing = false;
        }
    }
	
    	
}
