using UnityEngine;
using System.Collections;

public class ObjectState : MonoBehaviour
{
	[HideInInspector]
	public bool hit = false;
	[HideInInspector]
	public bool selected = false;

	public Vector3 origScale = new Vector3(1,1,1);


	public void Awake ()
	{
		origScale = gameObject.transform.localScale;
	}
}

