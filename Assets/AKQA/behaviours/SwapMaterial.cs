using UnityEngine;
using System.Collections;

public class SwapMaterial : MonoBehaviour
{

	private int materialIndex = 0;

	public bool isChanging {get;set;}
	public Material[] materialNames = new Material[4];

	public void UpdateImage(){
		// it might change over time, so isChanging.
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
		print ("pre update " + materialIndex);
		setMaterialIndex(materialIndex + 1);
		print ("post update " + materialIndex);
		UpdateImage ();
	}


	public void previousMaterial()
	{
		print ("pre update " + materialIndex);
		setMaterialIndex(materialIndex - 1);
		print ("post update " + materialIndex);
		UpdateImage ();
	}

}

