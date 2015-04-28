using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectState))]
public class SwapDestination : MonoBehaviour
{
	private ObjectState state;
	private int			currentDestinationID;
	private bool		destinationChanging;
	private string[] 	destinationNames = {
		"exhibition",
		"purpleRoom",
		"apartment",
		"nightOutside"
	};

		// Use this for initialization
		void Awake ()
		{
			state =  this.GetComponent<ObjectState>();
			currentDestinationID = 0;
			destinationChanging = true;
			//UpdateImage ();
		}
	
		// Update is called once per frame
		void Update ()
		{
			int newDestinationID = state.destinationNum;
			
			if (newDestinationID != currentDestinationID)
			{
				print("destination changing!");
				destinationChanging = true;
				if (newDestinationID > currentDestinationID)
				{
					NextDest();
				}
				if (newDestinationID < currentDestinationID)
				{
					PrevDest();
				}
				
				UpdateImage();
				destinationChanging = false;
				
			}
		}

		void UpdateImage(){
			print("updating image!");
			Material newDestMaterial = (Material)Resources.Load(destinationNames[currentDestinationID], typeof(Material));
			this.renderer.sharedMaterial = newDestMaterial;
			currentDestinationID = state.destinationNum;
		}

		void NextDest(){
			if (state.destinationNum >= destinationNames.Length)
			{
				state.destinationNum = 0;
			}
			
		}
		
		void PrevDest(){
		if (state.destinationNum < 0)
			{
				state.destinationNum = destinationNames.Length - 1;
			}
			
		}
}

