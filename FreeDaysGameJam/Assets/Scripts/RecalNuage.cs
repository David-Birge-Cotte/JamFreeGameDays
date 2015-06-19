using UnityEngine;
using System.Collections;

public class RecalNuage : MonoBehaviour {

	private Vector3 recalStadard;
	public GameObject destructor;

	// Use this for initialization
	void Start () {
		recalStadard = new Vector3(30, 5, 0);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject == destructor){
			Vector3 newPos = new Vector3();
			newPos = recalStadard;
			newPos = new Vector3(newPos.x, newPos.y + Random.Range(-1, 1), newPos.z);

			//transform.localScale = new Vector3(1 * Random.Range(0.8f, 1.2f), 1 * Random.Range(0.8f, 1.2f), 1);
			transform.position = newPos;
		}
	}
}
