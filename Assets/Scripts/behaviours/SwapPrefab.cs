using UnityEngine;
using System.Collections;


/**
 * Applied to objects where we want to swap prefabs at runtime.
 * 
 */
[RequireComponent (typeof (ObjectState))]
public class SwapPrefab : MonoBehaviour {


	private ObjectState     state;
    private string          currentPrefabName;
    private int             currentPrefabID;
    private GameObject      currentPrefab;
    private bool            prefabChanging;

    private string[] prefabNames = {
        "Object1",
        "Object2",
        "Object3"
    };

	void Awake(){
        state = this.GetComponent<ObjectState>();  
        prefabChanging = true;
        InstatiatePrefab();
	}

    void Update()
    {

		if (state.selected)
        {
            int newPrefabID = state.prefabNum;

            if (newPrefabID != currentPrefabID)
            {
                prefabChanging = true;
                if (newPrefabID > currentPrefabID)
                {
                    NextPrefab();
                }
                if (newPrefabID < currentPrefabID)
                {
                    PrevPrefab();
                }

                UpdatePrefab();
                prefabChanging = false;

            }
        }

    }

    void UpdatePrefab()
    {
        Destroy(currentPrefab);
        InstatiatePrefab();
    }

    void InstatiatePrefab()
    {
        //Load Prefab
        currentPrefabID = state.prefabNum;
        currentPrefabName = prefabNames[currentPrefabID];
		currentPrefab = (GameObject)Instantiate(Resources.Load(currentPrefabName),transform.position, transform.rotation);

    }

    void NextPrefab()
    {
        if (state.prefabNum >= prefabNames.Length)
        {
            state.prefabNum = 0;
        }
   
    }

    void PrevPrefab(){
        if (state.prefabNum < 0)
        {
            state.prefabNum = prefabNames.Length;
        }

    }
}
