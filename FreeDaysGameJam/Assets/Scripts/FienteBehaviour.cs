using UnityEngine;
using System.Collections;

public class FienteBehaviour : MonoBehaviour {

	private Rigidbody2D _rigid;

	// Use this for initialization
	void Start () {
		_rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		_rigid.velocity = new Vector2(-2, _rigid.velocity.y);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player"){
			coll.gameObject.SendMessage("HitByFiente");
			Destroy(transform.gameObject);
		}
	}
}
