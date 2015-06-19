using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public float speed = -2;
	private float _Xadd;

	
	// Update is called once per frame
	void Update () 
	{
		_Xadd = speed * Time.deltaTime;

		transform.position += new Vector3(_Xadd, 0, 0);
	}
}
