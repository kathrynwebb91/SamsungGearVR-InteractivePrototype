using UnityEngine;
using System.Collections;

/**
 * Applied to objects where we want to swap prefabs at runtime.
 * 
 */
public class SwapPrefab : MonoBehaviour
{
	
	private int prefabIndex = 0;
	private GameObject currentPrefab;
	

	public GameObject[] prefrabs = new GameObject[3];

	public bool isChanging {get;set;}

	void Awake ()
	{
		ApplyPrefab ();
	}
	

	public void ApplyPrefab(){

		isChanging = true;
		currentPrefab = (GameObject)Instantiate(prefrabs[prefabIndex],transform.position, transform.rotation);
		currentPrefab.transform.parent = this.gameObject.transform;
		currentPrefab.transform.localPosition = new Vector3(0,0,0);
		isChanging = false;
	}
	
	public void setPrefabIndex(int index)
	{
		prefabIndex = index < 0 ? prefrabs.Length -1 : (index >= prefrabs.Length ? 0 : index);
	}
	
	public void nextPrefab()
	{
		setPrefabIndex(prefabIndex + 1);
		Destroy (currentPrefab);
		ApplyPrefab ();
	}
	
	
	public void previousPrefab()
	{
		setPrefabIndex(prefabIndex - 1);
		Destroy (currentPrefab);
		ApplyPrefab ();
	}
	
}
