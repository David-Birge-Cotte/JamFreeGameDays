using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

//	public enum EnemyType
//	{
//		plagiste,
//		poisson,
//		requin,
//		nageur,
//		ballon
//
//	}

	public int pointsReceived = 0;

//	public EnemyType enemyType;

//	public Sprite spriteNageur;
//	public Sprite spritePoisson;
//	public Sprite spriteRequin;
//	public Sprite spritePlagiste;
//	public Sprite SpriteBallon;



	// Use this for initialization
	void Start () {
	
//		switch (enemyType) {
//		case EnemyType.plagiste: 
//			 
//			break;
//		case EnemyType.nageur: 
//			 
//			break;
//		case EnemyType.poisson: 
//			 
//			break;
//		case EnemyType.requin: 
//			 
//			break;	
//		case EnemyType.ballon: 
//			
//			break;	
//		default:
//			break;
//		}

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D coll ) 
	{
		if (coll.gameObject.tag == "Player") {


//			switch (enemyType) {
//			case EnemyType.plagiste: 
//				pointsReceived = 10;
//				break;
//			case EnemyType.nageur: 
//				pointsReceived = 15;
//			break;
//				case EnemyType.poisson: 
//				pointsReceived = 5;
//				break;
//			case EnemyType.requin: 
//				pointsReceived = 20;
//			case EnemyType.ballon 
//				pointsReceived = 10;
//				break;	
//			default:
//				break;
//			}
			coll.gameObject.SendMessage ("GetPoints", pointsReceived);
			Destroy(transform.gameObject);
		}
	}
}