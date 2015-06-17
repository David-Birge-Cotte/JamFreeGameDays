using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	private Rigidbody2D _rigidbody;

	// Use this for initialization
	void Start () 
	{
		_rigidbody = transform.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 _velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		_velocity *= speed * Time.deltaTime;

		_rigidbody.velocity = _velocity;
	}
}
