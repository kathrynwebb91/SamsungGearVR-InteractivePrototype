using UnityEngine;
using System.Collections;

public class SwapMaterial : MonoBehaviour
{

	private int materialIndex = 0;

	public bool isChanging {get;set;}
	public Material[] materialNames = new Material[5];

	void Awake ()
	{

	}



	public void UpdateImage(){
		print (materialIndex);
		// it might change over time, so isChanging.
		isChanging = true;
		this.renderer.sharedMaterial = materialNames[materialIndex];
		isChanging = false;
	}

	public int setMaterialIndex(int index)
	{
		return materialIndex = materialIndex < 0 ? materialNames.Length -1 : (materialIndex >= materialNames.Length ? 0 : materialIndex);
	}

	public int nextMaterial()
	{
		return setMaterialIndex(materialIndex + 1);
	}


	public int previousMaterial()
	{
		return setMaterialIndex(materialIndex - 1);
	}

}

