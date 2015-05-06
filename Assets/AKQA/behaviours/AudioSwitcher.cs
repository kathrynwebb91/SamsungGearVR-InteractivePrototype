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
    bool faded;
    float volume;
	
	void Awake ()
	{
        volume = 0;
        faded = false;
        playing = false;
        string[] targetNameArray = this.name.Split();
        sources = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource source in sources)
        {
            string[] audioNameArray =  source.name.Split();
            if (audioNameArray[0] == targetNameArray[0])
            {
                print("new Audio source in " + this.name + "!");
                localAudio = source;
            }
        }
	}

    void Update()
    {
        //print("playing = " + playing + " anyhit " + this.GetComponent<ObjectState>().anyhit);
        if (this.GetComponent<ObjectState>().anyhit)
        {
           // print("play that funky music");
            fadeInOnUpdate();
        }

        if (!(this.GetComponent<ObjectState>().anyhit) && playing)
        {
            //print("stop! in the name of love!");
            fadeOutOnUpdate();
        }
    }
	
      
 
 
     void fadeOutOnUpdate() {
         if (playing)
         {
            if (volume > 0)
            {
                volume -= 0.01F;
                localAudio.volume = volume;
            }
            else
            {
                localAudio.volume = 0.0F;
                localAudio.volume = volume;
                localAudio.Pause();
                playing = false;

            }   
         }
     }

     void fadeInOnUpdate()
     {
         if (!playing)
         {
             localAudio.Play();
             playing = true;
             faded = false;
         }
         if (!faded)
         {
             if (volume < 1)
             {
                 volume += 0.01F;
                 localAudio.volume = volume;
             }
             else
             {
                 localAudio.volume = 1.0F;
                 localAudio.volume = volume;
                 faded = true;
             }
         }
     }
    	
}
