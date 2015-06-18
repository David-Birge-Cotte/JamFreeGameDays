using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public enum EnemyType
	{
		plagiste,
		poisson,
		requin,
		nageur

	}

	public EnemyType enemyType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D coll ) 
	{
		if (coll.gameObject.tag == "Player") {
			int pointsReceived = 0;

			switch (enemyType) {
			case EnnemyType.plagiste: 
				pointsReceived = 10;
				break;
			case EnnemyType.nageur: 
				pointsReceived = 15;
				break;
			case EnnemyType.poisson: 
				pointsReceived = 5;
				break;
			case EnnemyType.requin: 
				pointsReceived = 20;
				break;	
			default:
				break;
			}
			coll.gameObject.SendMessage ("GetPoints", pointsReceived);
			Destroy(transform.gameObject);
		}

			

	}

}