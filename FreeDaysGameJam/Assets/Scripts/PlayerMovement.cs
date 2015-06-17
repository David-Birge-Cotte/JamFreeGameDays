using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 500;

	public float Xmin = -17f;
	public float Xmax = 17f;
	public float Ymin = -9.3f;
	public float Ymax = 9.3f;

	private Rigidbody2D _rigidbody;
	private Vector2 _velocity;
	
	void Start () 
	{
		_rigidbody = transform.GetComponent<Rigidbody2D>();
		_velocity = Vector2.zero;
	}

	void Update () 
	{
		//reset à chaque frame
		_velocity = Vector2.zero;

		if(Input.GetAxis("Horizontal") > 0 && transform.position.x < Xmax){
			_velocity = new Vector2(Input.GetAxis("Horizontal"), _velocity.y);
		} else if(Input.GetAxis("Horizontal") < 0 && transform.position.x > Xmin){
			_velocity = new Vector2(Input.GetAxis("Horizontal"), _velocity.y);
		}

		if(Input.GetAxis("Vertical") > 0 && transform.position.y < Ymax){
			_velocity = new Vector2(_velocity.x, Input.GetAxis("Vertical"));
		} else if(Input.GetAxis("Vertical") < 0 && transform.position.y > Ymin){
			_velocity = new Vector2(_velocity.x, Input.GetAxis("Vertical"));
		}

		_velocity *= speed * Time.deltaTime;
		_rigidbody.velocity = _velocity;

	}
}