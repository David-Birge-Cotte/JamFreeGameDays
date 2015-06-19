using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public GameObject sang;

	public int pointsReceived = 0;
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") 
		{
			coll.gameObject.SendMessage ("GetPoints", pointsReceived);
			Instantiate(sang, transform.position, Quaternion.identity);
			Destroy(transform.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Fiente") 
		{
			pointsReceived *= 2;
			GetComponent<SpriteRenderer>().color = Color.grey;
			Destroy(other.gameObject);
		}
	}
}