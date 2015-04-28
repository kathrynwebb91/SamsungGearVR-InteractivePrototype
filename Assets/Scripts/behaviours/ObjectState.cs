using UnityEngine;
using System.Collections;

public class ObjectState : MonoBehaviour
{
	//Needed by raycast detection script
	[HideInInspector]
	public bool hit = false;

    //Needed by Selectable script
	[HideInInspector]
	public bool selected = false;
	[HideInInspector]
	public bool firstHit = true;
	//Default distance at which objects are held from camera when dragged
	[HideInInspector]
	public float distance = 15;

    //Needed by SwapPrefab script
    [HideInInspector]
	public bool switchable = false;
	[HideInInspector]
    public int prefabNum = 0;
	[HideInInspector]
	public int colorNum = 0;

	//Needed by rotateable script
	[HideInInspector]
	public bool rotateable = false;
	[HideInInspector]
	public string rotateDirection = "stay";

	//Needed by destination swapper script
	public int destinationNum = 0;

	[HideInInspector]
	public Vector3 origScale = new Vector3(1,1,1);


	public void Awake ()
	{
		origScale = gameObject.transform.localScale;
	}
}

