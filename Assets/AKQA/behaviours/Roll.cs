using UnityEngine;
using System.Collections;

public class Roll : MonoBehaviour
{
    public float force;

        void Awake()
        {
            force = 10;
        }

		public void roll(Vector3 direction)
		{
            this.GetComponent<Rigidbody>().AddForce(transform.forward * force);
		}

		void Update(){

		}
}

