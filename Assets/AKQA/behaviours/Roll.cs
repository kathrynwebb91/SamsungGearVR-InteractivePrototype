using UnityEngine;
using System.Collections;

public class Roll : MonoBehaviour
{

		public void roll()
		{
            print(" Keep rollin rollin rollin WHAT!");
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0,10,0));
		}

		void Update(){

		}
}

