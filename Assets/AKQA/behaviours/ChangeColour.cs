using UnityEngine;
using System.Collections;

public class ChangeColour : MonoBehaviour {

	public Color[] palette = new Color[5];
	private int paletteIndex = 0;
	private Color currentColor;
	private Color newColor;
	public bool isChanging {get;set;}
	private float duration = 5; // duration in seconds
	private float t = 0; // lerp control variable

	void Awake(){
		isChanging = false;
		if (this.GetComponent<Renderer>()) {
			currentColor = this.GetComponent<Renderer>().material.color;
		}
	}

	void Update(){

		if (this.GetComponent<Renderer>()) {

			if (isChanging) {
				print (this.name + " is changing!");
				print (newColor.ToString () + " is the new color");
				this.GetComponent<Renderer>().material.color = Color.Lerp (currentColor, newColor, t);
			}
			if (t < 1) { // while t below the end limit...
				// increment it at the desired rate every update:
				t += Time.deltaTime / duration;
			} 
			if (this.GetComponent<Renderer>().material.color == newColor) {
				isChanging = false;
			}

		} else if (transform.childCount > 0) {

			for (int i=0; i<transform.childCount; i++) {
				if(transform.GetChild(i).GetComponent<ChangeColour>()){
					if(isChanging){
						//transform.GetChild(i).GetComponent<ChangeColour>().setColour(newColor);
						transform.GetChild(i).GetComponent<Renderer>().material.color = Color.Lerp (currentColor, newColor, t);
						newColor = palette[paletteIndex];
						isChanging = true;
					}
					if (t < 1) { // while t below the end limit...
						// increment it at the desired rate every update:
						t += Time.deltaTime / duration;
					} 
					if (transform.GetChild(i).GetComponent<Renderer>().material.color == newColor) {
						isChanging = false;
					}
				}
			}

		}
	
	}
	
	public void UpdateColor(){

		if (this.GetComponent<Renderer>()) {
			currentColor = this.GetComponent<Renderer>().material.color;
			newColor = palette[paletteIndex];
			print (currentColor.ToString() + " is the current color");
			print (newColor.ToString() + " is the new color");
			print (paletteIndex.ToString() + " is the new color palette index");
			isChanging = true;
		}else if (transform.childCount > 0) {
			for (int i=0; i<transform.childCount; i++) {
				if(transform.GetChild(i).GetComponent<ChangeColour>()){
					//transform.GetChild(i).GetComponent<ChangeColour>().setColour(newColor);
					currentColor = transform.GetChild(i).GetComponent<Renderer>().material.color;
					newColor = palette[paletteIndex];
					print (currentColor.ToString() + " is the current color");
					print (newColor.ToString() + " is the new color");
					print (paletteIndex.ToString() + " is the new color palette index");
					isChanging = true;
				}
			}
		}
	}

	public void setColour(Color color)
	{

		if (this.GetComponent<Renderer>()) {
			currentColor = this.GetComponent<Renderer>().material.color;
			newColor = color;
			isChanging = true;
		}
		if (transform.childCount > 0) {
			for (int i=0; i<transform.childCount; i++) {
				if(transform.GetChild(i).GetComponent<ChangeColour>()){
					transform.GetChild(i).GetComponent<ChangeColour>().setColour(color);
				}
			}
		}

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


	
	
	

	

	
	



