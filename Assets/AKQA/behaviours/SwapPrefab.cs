using UnityEngine;
using System.Collections;


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
		//GameObject newPrefab = (GameObject)Instantiate(Resources.Load(prefrabs[prefabIndex]),transform.position, transform.rotation);
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

/**
 * Applied to objects where we want to swap prefabs at runtime.
 * 
 */
//[RequireComponent (typeof (ObjectState))]
//public class SwapPrefab : MonoBehaviour {
//
//
//
//	private ObjectState     state;
//    private string          currentPrefabName;
//    private int             currentPrefabID;
//	private int             currentColorID;
//	private GameObject      currentPrefab;
//    private bool            prefabChanging;
//
//    private string[] prefabNames = {
//        "Object1",
//        "Object2",
//        "Object3"
//    };
//
//	private Color[] prefabColors = {
//		Color.red,
//		Color.blue,
//		Color.green
//	};
//	
//	void Awake(){
//		state = this.GetComponent<ObjectState>(); 
//		state.switchable = true;
//        prefabChanging = true;
//		currentPrefabID = state.prefabNum;
//		currentColorID = state.colorNum;
//        InstatiatePrefab();
//	}
//
//    void Update()
//    {
//        if (state.selected)
//        {
//            int newPrefabID = state.prefabNum;
//			int newColorID = state.colorNum;
//
//            if (newPrefabID != currentPrefabID)
//            {
//                prefabChanging = true;
//                if (newPrefabID > currentPrefabID)
//                {
//                    NextPrefab();
//                }
//                if (newPrefabID < currentPrefabID)
//                {
//                    PrevPrefab();
//                }
//
//                UpdatePrefab();
//                prefabChanging = false;
//
//            }
//
//			if (newColorID != currentColorID)
//			{
//				print (newColorID);
//				prefabChanging = true;
//				if (newColorID > currentColorID)
//				{
//					NextColor();
//				}
//				if (newColorID < currentColorID)
//				{
//					PrevColor();
//				}
//				
//				UpdatePrefabColor();
//				prefabChanging = false;
//				
//			}
//		}
//		
//	}
//	
//	void UpdatePrefab()
//	{
//		Destroy(currentPrefab);
//		InstatiatePrefab();
//	}
//
//	void UpdatePrefabColor()
//	{
//		currentPrefab.renderer.material.color = prefabColors[state.colorNum];
//		currentColorID = state.colorNum;
//	}
//	
//	void InstatiatePrefab()
//	{
//		//Load Prefab
//		currentPrefabID = state.prefabNum;
//        currentPrefabName = prefabNames[currentPrefabID];
//		currentPrefab = (GameObject)Instantiate(Resources.Load(currentPrefabName),transform.position, transform.rotation);
//		currentPrefab.transform.parent = this.gameObject.transform;
//		currentPrefab.transform.localPosition = new Vector3(0,0,0);
//		UpdatePrefabColor ();
//
//    }
//
//    void NextPrefab()
//    {
//        if (state.prefabNum >= prefabNames.Length)
//        {
//            state.prefabNum = 0;
//        }
//   
//    }
//
//    void PrevPrefab(){
//        if (state.prefabNum < 0)
//        {
//            state.prefabNum = prefabNames.Length - 1;
//        }
//
//    }
//
//	void NextColor(){
//		if (state.colorNum >= prefabColors.Length)
//		{
//			state.colorNum = 0;
//		}
//		
//	}
//
//	void PrevColor(){
//		if (state.colorNum < 0)
//		{
//			state.colorNum = prefabColors.Length - 1;
//		}
//		
//	}
//}
