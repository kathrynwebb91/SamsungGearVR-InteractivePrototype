using UnityEngine;
using System.Collections;

public class Drop : MonoBehaviour
{

	public bool dropped = false;


		public void drop()
		{
		print ("oops!");
			this.GetComponent<Rigidbody> ().isKinematic = false;
		}
}

