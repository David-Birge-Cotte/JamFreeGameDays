using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	public  GameObject target;
	
	// Update is called once per frame
	void Update () 
	{
		float Y = target.transform.position.y;

		transform.position = new Vector3(0, Y, -10);
	}
}
