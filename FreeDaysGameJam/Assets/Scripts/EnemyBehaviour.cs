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
			case EnemyType.plagiste: 
				pointsReceived = 10;
				break;
			case EnemyType.nageur: 
				pointsReceived = 15;
			break;
				case EnemyType.poisson: 
				pointsReceived = 5;
				break;
			case EnemyType.requin: 
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