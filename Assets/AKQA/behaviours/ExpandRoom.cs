using UnityEngine;
using System.Collections;

public class ExpandRoom : MonoBehaviour
{

    Flicker[] flickers;
    GameObject[] lights;

    void Awake ()
	{
        lights = new GameObject[3];
        lights[0] = GameObject.Find("Spotlight1");
        lights[1] = GameObject.Find("Spotlight2");
        lights[2] = GameObject.Find("Spotlight3");
        flickers = new Flicker[3];
        flickers[0] = lights[0].GetComponent<Flicker>();
        flickers[1] = lights[1].GetComponent<Flicker>();
        flickers[2] = lights[2].GetComponent<Flicker>();
		switchOffLights ();
	}

	public void pushWall(){
		//Hide photosphere if there is one
		if (GameObject.Find ("Pano")) {
			GameObject.Find ("Pano").SetActive (false);
		}

		//Moves target wall
		iTween.MoveBy(this.gameObject, iTween.Hash (
			"y",-400,
			"time",3.0F
			)
		);

		//Expands rest of the room
		int nextIndex = transform.GetSiblingIndex ();
		for (int i = 0; i<4; i++) {
			GameObject focus = this.transform.parent.GetChild(nextIndex + i + 1).gameObject;
			iTween.ScaleAdd(focus, new Vector3(0,0,400), 3.0F);
			iTween.MoveAdd(focus, new Vector3(0,0,-200), 3.0F);
		}

        switchOnLightsWithDelays();

	}

	public void switchOnLightsWithDelays(){
		StartCoroutine (delayedLightsOn());
	}

	IEnumerator delayedLightsOn(){

        flickers[0].ToggleFlicker = true;
		yield return new WaitForSeconds(0.3F);
		switchOnLight(0);
        flickers[1].ToggleFlicker = true;
		yield return new WaitForSeconds(0.6F);
		switchOnLight (1);
        flickers[2].ToggleFlicker = true;
		yield return new WaitForSeconds(0.6F);
		switchOnLight (2);
        yield return new WaitForSeconds(1.0F);
        flickers[0].ToggleFlicker = false;
        yield return new WaitForSeconds(0.6F);
        flickers[1].ToggleFlicker = false;
        yield return new WaitForSeconds(0.6F);
        flickers[2].ToggleFlicker = false;
	}

	void switchOnLight(int lightnum){
	    lights[lightnum].GetComponent<Light> ().intensity = 3.6F;
	}

	void switchOffLights(){
        foreach(GameObject spot in lights){
            spot.GetComponent<Light>().intensity = 0;
        }
	}

}

