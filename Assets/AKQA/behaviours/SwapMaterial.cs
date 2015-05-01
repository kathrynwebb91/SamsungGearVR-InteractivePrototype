using UnityEngine;
using System.Collections;

//Changes the material of an object, either by setting it directly or by itterating through an array of Materials set through the Editor
public class SwapMaterial : MonoBehaviour
{

	private int materialIndex = 0;

	public bool isChanging {get;set;}
	public Material[] materialNames = new Material[4];

	public void UpdateImage(){
		isChanging = true;
		this.renderer.sharedMaterial = materialNames[materialIndex];
		isChanging = false;
	}

	public void setMaterialIndex(int index)
	{
		 materialIndex = index < 0 ? materialNames.Length -1 : (index >= materialNames.Length ? 0 : index);
	}

	public void setMaterial(Material mat)
	{
		this.renderer.sharedMaterial = mat;
	}

	public void nextMaterial()
	{
		setMaterialIndex(materialIndex + 1);
		UpdateImage ();
	}


	public void previousMaterial()
	{
		setMaterialIndex(materialIndex - 1);
		UpdateImage ();
	}

}

