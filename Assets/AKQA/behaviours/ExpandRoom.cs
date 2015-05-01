using UnityEngine;
using System.Collections;

public class ExpandRoom : MonoBehaviour
{

	void Awake ()
	{
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

		switchOnLightsWithDelays ();
	}

	void switchOnLightsWithDelays(){
		StartCoroutine (delayedLightsOn());
	}

	IEnumerator delayedLightsOn(){
		yield return new WaitForSeconds(0.3F);
		switchOnLight(1);
		yield return new WaitForSeconds(0.6F);
		switchOnLight (2);
		yield return new WaitForSeconds(0.6F);
		switchOnLight (3);
	}

	 void switchOnLight(int lightnum){
		GameObject.Find ("Spotlight" + lightnum).GetComponent<Light> ().intensity = 3.6F;
	}

	void switchOffLights(){
		GameObject.Find ("Spotlight1").GetComponent<Light> ().intensity = 0;
		GameObject.Find ("Spotlight2").GetComponent<Light> ().intensity = 0;
		GameObject.Find ("Spotlight3").GetComponent<Light> ().intensity = 0;
	}

}

