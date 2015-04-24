using UnityEngine;
using System.Collections;

public class ObjectState : MonoBehaviour
{
	[HideInInspector]
	public bool hit = false;

    //Needed by Selectable script
	[HideInInspector]
	public bool selected = false;

    //Needed by SwapPrefab script
    [HideInInspector]
    public int prefabNum = 0;

    //Default distance at which objects are held from camera when dragged
    [HideInInspector]
    public float distance = 15;

	public Vector3 origScale = new Vector3(1,1,1);


	public void Awake ()
	{
		origScale = gameObject.transform.localScale;
	}
}

