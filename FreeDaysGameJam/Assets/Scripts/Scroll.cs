using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public float speed = 15;

	
	// Update is called once per frame
	void Update () 
	{
		float _Xadd = speed * Time.deltaTime;

		transform.position += new Vector3(_Xadd, 0, 0);
	}
}
