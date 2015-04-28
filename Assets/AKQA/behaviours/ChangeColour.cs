using UnityEngine;
using System.Collections;

public class ChangeColour : MonoBehaviour {

	public Color[] palette = new Color[5];
	private int paletteIndex = 0;
	public bool isChanging {get;set;}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateColor(){
		// it might change over time, so isChanging.
		isChanging = true;
		renderer.material.color = palette[paletteIndex];
		isChanging = false;
	}

	public void setColour(Color color)
	{
		isChanging = true;
		renderer.material.color = color;
		isChanging = false;
	}

	void setPalleteIndex(int index)
	{
		// if has palette.
		paletteIndex = paletteIndex < 0 ? palette.Length -1 : (paletteIndex >= palette.Length ? 0 : paletteIndex);

	}

	public void nextMaterial()
	{
		setPalleteIndex(paletteIndex + 1);
	}
	
	
	public void previousMaterial()
	{
		setPalleteIndex(paletteIndex - 1);
	}

}


	
	
	

	

	
	



