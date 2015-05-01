using UnityEngine;
using System.Collections;

public class Drop : MonoBehaviour
{

	public bool dropped = false;


		public void drop()
		{
			this.GetComponent<Rigidbody> ().isKinematic = false;
			dropped = true;
		}

		void Update(){
			if (dropped){
				this.GetComponent<Rigidbody> ().velocity = new Vector3 (0, -100, 0);
			}
		}
}

