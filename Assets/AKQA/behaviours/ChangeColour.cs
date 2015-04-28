using UnityEngine;
using System.Collections;

public class ChangeColour : MonoBehaviour {

	public Color[] palette = new Color[5];
	private int paletteIndex = 0;
	public bool isChanging {get;set;}


	public void UpdateColor(){
		// it might change over time, so isChanging.
		isChanging = true;
		this.transform.GetChild (0).renderer.material.color = palette[paletteIndex];
		isChanging = false;
	}

	public void setColour(Color color)
	{
		isChanging = true;
		this.renderer.material.color = color;
		isChanging = false;
	}

	void setPalleteIndex(int index)
	{
		// if has palette.
		paletteIndex = index < 0 ? palette.Length -1 : (index >= palette.Length ? 0 : index);

	}

	public void nextColor()
	{
		setPalleteIndex(paletteIndex + 1);
		UpdateColor ();
	}
	
	
	public void previousColor()
	{
		setPalleteIndex(paletteIndex - 1);
		UpdateColor ();
	}

}


	
	
	

	

	
	



