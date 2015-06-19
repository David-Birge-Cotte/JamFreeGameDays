﻿using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public int points;
	public float speed = 500;

	public float Xmin = -17f;
	public float Xmax = 17f;
	public float Ymin = -9.3f;
	public float Ymax = 9.3f;

	public float YAttack = 5f;
	public float YStopZone = -5f;
	public float timerDown = 1f;
	public GameObject localSigne;
	public GameObject Cam;

	private Rigidbody2D _rigidbody;
	private Vector2 _velocity;
	private bool _isAttacking = false;
	private bool _isGoingUp = false;
	private float _acceleration;
	
	private Animator _anim;

	public GameObject fienteOutput;
	public GameObject fiente;

	private enum PositionLayer{
		UP,
		MIDDLE,
		DOWN,
		ERROR
	}

	public enum Player{
		J1,
		J2,
		J3,
		J4
	}
	public Player numPlayer;

	private PositionLayer _pos;
	
	void Start () 
	{
		_anim = GetComponent<Animator>();

		_rigidbody = transform.GetComponent<Rigidbody2D>();
		_velocity = Vector2.zero;
	}

	void Update () 
	{

		if(transform.position.y > YAttack)
			_pos = PositionLayer.UP;
		else if(transform.position.y < YAttack && transform.position.y > YStopZone)
			_pos = PositionLayer.MIDDLE;
		else if(transform.position.y < YStopZone)
			_pos = PositionLayer.DOWN;
		else
			_pos = PositionLayer.ERROR;

		if(_pos == PositionLayer.DOWN)
		{
			_isAttacking = false;
			timerDown -= Time.deltaTime;
		}

		if(timerDown <= 0){
			_isGoingUp = true;
			timerDown = 1f;
		}

		if(_pos == PositionLayer.UP){
			_isGoingUp = false;
			//_isAttacking = false;
		}
		if(numPlayer == Player.J1)
		{
			if(Input.GetKeyDown(KeyCode.Joystick1Button0))
			{
				if(_isGoingUp == false && timerDown == 1){
					_isAttacking = true;
				}
				if(_isAttacking == false){
					timerDown = 0;
				}
			}
		} else if(numPlayer == Player.J2)
		{
			if(Input.GetKeyDown(KeyCode.Joystick2Button0))
			{
				if(_isGoingUp == false && timerDown == 1){
					_isAttacking = true;
				}
				if(_isAttacking == false){
					timerDown = 0;
				}
			}
		}else if(numPlayer == Player.J3)
		{
			if(Input.GetKeyDown(KeyCode.Joystick3Button0))
			{
				if(_isGoingUp == false && timerDown == 1){
					_isAttacking = true;
				}
				if(_isAttacking == false){
					timerDown = 0;
				}
			}
		}else if(numPlayer == Player.J4)
		{
			if(Input.GetKeyDown(KeyCode.Joystick4Button0))
			{
				if(_isGoingUp == false && timerDown == 1){
					_isAttacking = true;
				}
				if(_isAttacking == false){
					timerDown = 0;
				}
			}
		}
		
		if(_isAttacking)
		{
			_velocity = new Vector2(0, -2);

			_acceleration += Time.deltaTime;
			_velocity += new Vector2(0, -_acceleration);
		} else 
		{
			_velocity = Vector2.zero;
			_acceleration = 0;
		}

		if(_isGoingUp){
			_velocity += new Vector2(0, 2);
		}
		switch (numPlayer) {
		case Player.J1 :
			_velocity += new Vector2(Input.GetAxis("X_J1"), Input.GetAxis("Y_J1"));
			break;
		case Player.J2:
			_velocity += new Vector2(Input.GetAxis("X_J2"), Input.GetAxis("Y_J2"));
			break;
		case Player.J3 :
			_velocity += new Vector2(Input.GetAxis("X_J3"), Input.GetAxis("Y_J3"));
			break;
		case Player.J4:
			_velocity += new Vector2(Input.GetAxis("X_J4"), Input.GetAxis("Y_J4"));
			break;

		default:
			break;
		}

		if(_velocity.x > 0 && transform.position.x >= Xmax)
			_velocity.x = 0;
		else if(_velocity.x < 0 && transform.position.x <= Xmin)
			_velocity.x = 0;

		if(_velocity.y > 0 && transform.position.y >= Ymax)
			_velocity.y = 0;
		else if(_velocity.y < 0 && transform.position.y <= Ymin)
			_velocity.y = 0;

		if(_velocity.y < 0 && transform.position.y < YAttack+0.2f && _pos == PositionLayer.UP && !_isAttacking)
			_velocity.y = 0;

		_velocity *= speed * Time.deltaTime;
		_rigidbody.velocity = _velocity;

		if(_isAttacking){
			_anim.SetBool("isAttacking", true);
			transform.eulerAngles = new Vector3(0, 0, -55f);
		} else {
			_anim.SetBool("isAttacking", false);
			transform.eulerAngles = new Vector3(0, 0, 0);
		}

		if(Input.GetKeyDown(KeyCode.Joystick1Button1) && numPlayer == Player.J1)
		{
			Instantiate(fiente, fienteOutput.transform.position, Quaternion.identity);
		} 
		else if(Input.GetKeyDown(KeyCode.Joystick2Button1) && numPlayer == Player.J2)
		{
			Instantiate(fiente, fienteOutput.transform.position, Quaternion.identity);
		} 
		else if(Input.GetKeyDown(KeyCode.Joystick3Button1) && numPlayer == Player.J3)
		{
			Instantiate(fiente, fienteOutput.transform.position, Quaternion.identity);
		} 
		else if(Input.GetKeyDown(KeyCode.Joystick4Button1) && numPlayer == Player.J4)
		{
			Instantiate(fiente, fienteOutput.transform.position, Quaternion.identity);
		}
	}

	void GetPoints(int pts)
	{
		points += pts;
	}

	public void HitByFiente(){
		speed = 50;
		Invoke("resetSpeed", 5f);
	}

	void resetSpeed(){
		speed = 500;
	}
}












