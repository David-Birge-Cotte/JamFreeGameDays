using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerBehaviour : NetworkBehaviour {

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


	private enum PositionLayer{
		UP,
		MIDDLE,
		DOWN,
		ERROR
	}

	private PositionLayer _pos;

	
	void Start () 
	{
		if(isLocalPlayer){
			localSigne.SetActive(true);
			//Camera.main.enabled = false;
			//GameObject _cam = (GameObject)Instantiate(Cam, Vector3.zero, Quaternion.identity);
			//_cam.GetComponent<CameraBehaviour>().target = transform.gameObject;
		}



		_anim = GetComponent<Animator>();

		Color newColor = new Color();

		newColor.r = Random.Range(0.5f, 1f);
		newColor.g = Random.Range(0.5f, 1f);
		newColor.b = Random.Range(0.5f, 1f);
		newColor.a = 1;

		transform.GetComponent<SpriteRenderer>().color = newColor;

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
			_isAttacking = false;
		}

		if(Input.GetKey(KeyCode.Joystick1Button0) || _pos == PositionLayer.MIDDLE)
		{
			if(_isGoingUp == false && timerDown == 1){
				_isAttacking = true;
			}
			if(_isAttacking == false){
				timerDown = 0;
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


		if(_isAttacking){
			_anim.SetBool("isAttacking", true);
			transform.eulerAngles = new Vector3(0, 0, -55f);
		} else {
			_anim.SetBool("isAttacking", false);
			transform.eulerAngles = new Vector3(0, 0, 0);
		}


	}

	void GetPoints(int pts)
	{
		points += pts;
	}
}



/*
	#region ROTATION
	Vector2 v = _rigidbody.velocity;
	float angle = Mathf.Atan2(v.y, Mathf.Abs(v.x)) * Mathf.Rad2Deg;

	transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	#endregion
*/















