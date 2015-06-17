using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 500;

	public float Xmin = -17f;
	public float Xmax = 17f;
	public float Ymin = -9.3f;
	public float Ymax = 9.3f;

	public float YAttack = 5f;
	public float YStopZone = -5f;

	private Rigidbody2D _rigidbody;
	private Vector2 _velocity;
	private bool _isAttacking = false;
	private bool _isGoingUp = false;
	private float acceleration;

	public float timerDown = 1f;

	private enum PositionLayer{
		UP,
		MIDDLE,
		DOWN,
		ERROR
	}

	private PositionLayer pos;

	
	void Start () 
	{
		_rigidbody = transform.GetComponent<Rigidbody2D>();
		_velocity = Vector2.zero;
	}

	void Update () 
	{
		if(transform.position.y > YAttack)
			pos = PositionLayer.UP;
		else if(transform.position.y < YAttack && transform.position.y > YStopZone)
			pos = PositionLayer.MIDDLE;
		else if(transform.position.y < YStopZone)
			pos = PositionLayer.DOWN;
		else
			pos = PositionLayer.ERROR;

		
		if(Input.GetKey(KeyCode.Joystick1Button0) || pos == PositionLayer.MIDDLE)
		{
			if(_isGoingUp == false)
				_isAttacking = true;
		}

		if(pos == PositionLayer.DOWN)
		{
			_isAttacking = false;
			timerDown -= Time.deltaTime;
		}

		if(timerDown <= 0){
			_isGoingUp = true;
			timerDown = 1f;
		}

		if(pos == PositionLayer.UP){
			_isGoingUp = false;
		}

		if(_isAttacking)
		{
			_velocity = new Vector2(0, -2);

			acceleration += Time.deltaTime;
			_velocity += new Vector2(0, -acceleration);
		} else 
		{
			_velocity = Vector2.zero;
			acceleration = 0;
		}

		if(_isGoingUp){
			_velocity += new Vector2(0, 2);
		}

		_velocity += new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));


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

	}
}



/*
	#region ROTATION
	Vector2 v = _rigidbody.velocity;
	float angle = Mathf.Atan2(v.y, Mathf.Abs(v.x)) * Mathf.Rad2Deg;

	transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	#endregion
*/















