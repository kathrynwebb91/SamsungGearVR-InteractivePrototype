using UnityEngine;
using System.Collections;

/**
 * Applied to objects where we want to swap prefabs at runtime.
 * 
 */
public class Flicker : MonoBehaviour
{
    public AudioSource  flickerSound;
    public bool         ToggleFlicker;
    public bool         soundPlayed;
    float               minFlickerSpeed = 0.1F;
    float               maxFlickerSpeed = 1.0F;

    void Awake()
    {
        soundPlayed = false;
        ToggleFlicker = false;
    }

    void Update()
    {
        if (ToggleFlicker)
        {
            StartCoroutine(flicker());
        }
        else
        {
            this.light.enabled = true;
            soundPlayed = false;
        }

    }

    IEnumerator flicker()
    {
        if (!soundPlayed)
        {
            flickerSound.Play();
            soundPlayed = true;
        }

        this.light.enabled = true;
        yield return new WaitForSeconds (Random.Range(minFlickerSpeed, maxFlickerSpeed ));
        this.light.enabled = false;
        yield return new WaitForSeconds (Random.Range(minFlickerSpeed, maxFlickerSpeed ));
    }
    	
}
