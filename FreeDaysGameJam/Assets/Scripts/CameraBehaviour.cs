using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {
	
	public  GameObject target;
	
	void Start(){
		transform.position = new Vector3(0, 5, -10);
	}
	
	void Update () 
	{
		float Y = target.transform.position.y;
		
		if(Y < 5 && Y > -5)
			transform.position = new Vector3(0, Y, -10);
	}
}