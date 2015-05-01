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
			"time",3.0F,
			"oncomplete","switchOnLightsWithDelays",
			"oncompletetarget", this.gameObject
			)
		);

		//Expands rest of the room
		int nextIndex = transform.GetSiblingIndex ();
		for (int i = 0; i<4; i++) {
			GameObject focus = this.transform.parent.GetChild(nextIndex + i + 1).gameObject;
			iTween.ScaleAdd(focus, new Vector3(0,0,400), 3.0F);
			iTween.MoveAdd(focus, new Vector3(0,0,-200), 3.0F);
		}
	}

	IEnumerator switchOnLightsWithDelays(){
		StartCoroutine(switchOnLight(1));
		yield return (StartCoroutine(switchOnLight(2)));
	}

	 IEnumerator switchOnLight(int lightnum){
		GameObject.Find ("Spotlight" + lightnum).GetComponent<Light> ().intensity = 3.6F;
		yield return new WaitForSeconds(5);
	}

	void switchOffLights(){
		GameObject.Find ("Spotlight1").GetComponent<Light> ().intensity = 0;
		GameObject.Find ("Spotlight2").GetComponent<Light> ().intensity = 0;
	}

}

