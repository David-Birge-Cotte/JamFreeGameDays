using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	public float timer;
	
	void Update () 
	{
		timer -= Time.deltaTime;

		if(timer < 0){
			Destroy(transform.gameObject);
		}
	}
}
