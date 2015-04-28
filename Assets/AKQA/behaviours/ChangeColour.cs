using UnityEngine;
using System.Collections;

public class ChangeColour : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setColour(Color color)
	{
		renderer.material.color = color;
	}

	void setPalletIndex(int index)
	{
		// if has pallet.

	}

}
