using UnityEngine;
using System.Collections;

public class Destruction : MonoBehaviour {

	public GameObject spawner;

	void OnTriggerExit2D (Collider2D other) 
	{

		if (other.gameObject.tag == "Background") 
		{
			spawner.SendMessage("SpawnBackground");
		}
		Destroy(other.gameObject);
	}
}
