using UnityEngine;
using System.Collections;

public class TetrisBlockState : MonoBehaviour
{
		public enum BlockType{
			T = 0,
			Fat = 1,
			S = 2,
			L = 3,
			Line = 4,
			NumberOfTypes
		}

		public bool moving = true;

		void OnTriggerEnter(Collider collisionInfo)
		{
			print("a collision!");
			print("Detected collision between " + gameObject.name + " and " + collisionInfo.GetComponent<Collider>().name);
			
		}

		void Awake(){
			print ("block state is here");
		}

}

