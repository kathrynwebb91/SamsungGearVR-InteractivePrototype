using UnityEngine;
using System.Collections;

public class ObjectState : MonoBehaviour
{
	public enum RotateDirection
	{
		None,
		Left,
		Right,
		Up,
		Down
	};


	/**
     * Interaction states
     * @see Raycast detection script
	 * @see Selectable script
     **/
	[HideInInspector]
	public bool hit = false;

    //Trigegrs if object is in the line of sight, not just the first collided
    [HideInInspector]
    public bool anyhit = false;
	
	[HideInInspector]
	public bool selected = false;

	[HideInInspector]
	public bool firstHit = true;


	/**
     * Default distance at which objects are held from camera when dragged
     **/
	[HideInInspector]
	public float distance = 15;

    /**
     * Needed by SwapPrefab script
     **/
    [HideInInspector]
	public bool switchable = false;

	/**
	 * 
	 * Needed by rotateable script
	 * */
	[HideInInspector]
	public bool rotateable = false;

	[HideInInspector]
	public RotateDirection rotateDirection = RotateDirection.None;


	/**
     * Basic Object States
     **/
	[HideInInspector]
	public Vector3 origScale = new Vector3(1,1,1);


	public void Awake ()
	{
		origScale = gameObject.transform.localScale;
	}
}

