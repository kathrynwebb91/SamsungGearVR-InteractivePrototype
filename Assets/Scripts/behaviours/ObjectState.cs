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
	public bool firstHit = true;
	//Default distance at which objects are held from camera when dragged
	public float distance = 15;

    //Needed by SwapPrefab script
    [HideInInspector]
	public bool switchable = false;
    public int prefabNum = 0;
	public int colorNum = 0;

	[HideInInspector]
	public bool rotateable = false;
	public string rotateDirection = "stay";

	public Vector3 origScale = new Vector3(1,1,1);


	public void Awake ()
	{
		origScale = gameObject.transform.localScale;
	}
}

