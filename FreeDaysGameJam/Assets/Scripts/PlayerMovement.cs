using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 500;

	public float Xmin = -17f;
	public float Xmax = 17f;
	public float Ymin = -9.3f;
	public float Ymax = 9.3f;

	public float YAttack = -2f;


	private Rigidbody2D _rigidbody;
	private Vector2 _velocity;
	
	void Start () 
	{
		_rigidbody = transform.GetComponent<Rigidbody2D>();
		_velocity = Vector2.zero;
	}

	void Update () 
	{
		_velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		if(Input.GetKey(KeyCode.Joystick1Button0) || transform.position.y < YAttack)
		{
			Attack();
		}

		if(_velocity.x > 0 && transform.position.x >= Xmax)
			_velocity.x = 0;
		else if(_velocity.x < 0 && transform.position.x <= Xmin)
			_velocity.x = 0;

		if(_velocity.y > 0 && transform.position.y >= Ymax)
			_velocity.y = 0;
		else if(_velocity.y < 0 && transform.position.y <= Ymin)
			_velocity.y = 0;


		_velocity *= speed * Time.deltaTime;
		_rigidbody.velocity = _velocity;

		/*
		#region ROTATION
		Vector2 v = _rigidbody.velocity;
		float angle = Mathf.Atan2(v.y, Mathf.Abs(v.x)) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		#endregion
		*/
	}

	void Attack()
	{
		_velocity += new Vector2(0, -2);
	}



}
















