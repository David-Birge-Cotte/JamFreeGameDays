using UnityEngine;
using System.Collections;

public class Destruction : MonoBehaviour {

	void OnTriggerExit2D (Collider2D other) 
	{
		Destroy(other.gameObject);
	}
}
