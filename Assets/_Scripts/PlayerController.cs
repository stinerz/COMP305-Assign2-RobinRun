using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	// PRIVATE INSTANCE VARIABLES
	private Transform _transform; //
	private Rigidbody2D _rigidbody; //

	private float _move;
	private float _jump;
	private bool _isFacingRight;
	private bool _isGrounded;

	//private Animator _animator;
	private GameObject _camera;
	private GameObject _spawnPoint;
	private GameObject _gameControllerObject;
	private GameController _gameController;


	//PUBLIC INSTANCE VARIABLES
	public float Velocity = 10f; 
	public Camera camera; //reference to the camera object 

	// Use this for initialization
	void Start () {
		this._initialize (); 
	}

	// Update is called once per frame (Physics)
	void FixedUpdate () {
		//to move, need to check if input is present for movement 
		this._move = Input.GetAxis("Horizontal"); 
		if (this._move > 0f) { //to the right "1"
			this._move = 1; 
			this._isFacingRight = true; 
			this._flip (); 
		} else if (this._move < 0f) { //to the left "-1"
			this._move = -1; 
			this._isFacingRight = false; 
			this._flip (); 
		} else {
			this._move = 0; 
		}
		//Debug.Log (this._move); 

		//Adding force to rigid body right or left, move is multipled by the velocity 
		this._rigidbody.AddForce(new Vector2 (this._move * this.Velocity, 0f), ForceMode2D.Force); 

		//Camera - take the players position 
		this.camera.transform.position = new Vector3(this._transform.position.x, -5.8f, -10f); 

		Debug.Log (this._isGrounded);
	}

	//Private method initialized variables and object when called 
	private void _initialize(){
		this._transform = GetComponent<Transform> (); 
		this._rigidbody = GetComponent < Rigidbody2D> (); 
		this._move = 0f; 
		this._isFacingRight = true;
		this._isGrounded = false; 
	}

	//Private method lfips ther character's bitmap across the x-asis
	private void _flip () {
		if (this._isFacingRight) {
			this._transform.localScale = new Vector2 (0.3f, 0.3f);
		} else {
			this._transform.localScale = new Vector2 (-0.3f, 0.3f);
		}
	}

	private void OnCollisionStay2D(Collider2D other){ //checks if still colliding after 
		if (other.gameObject.CompareTag("Platform")){
			this._isGrounded = true;
		}
	}
		

	private void OnCollisionExit2D(Collision2D other){ //leaving a collider, player is not grounded 
		this._isGrounded = false; 	
	}

}
