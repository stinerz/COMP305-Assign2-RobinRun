using UnityEngine;
using System.Collections;

/*Christina Kuo - 300721385 
 * Enemy Controller - controls the behaviour of the enemy*/

public class LargeEnemyController : MonoBehaviour {

	// PRIVATE INSTANCE VARIABLES 
	private Transform _transform;
	private Rigidbody2D _rigidbody;
	private bool _isGrounded;
	private bool _isGroundAhead;
	private bool _isPlayerDetected;

	// PUBLIC INSTANCE VARIABLES
	public float Speed = 5f;
	public float MaximumSpeed = 4f;
	public Transform SightStart;
	public Transform SightEnd;


	// Use this for initialization
	void Start () {
		this._transform = GetComponent<Transform> ();
		this._rigidbody = GetComponent<Rigidbody2D> ();
		this._isGrounded = false;
		this._isGroundAhead = true;
	}

	// Update is called once per frame (Physics)
	void FixedUpdate () {
		if (this._isGrounded) {  // check if the object is grounded 

			this._rigidbody.velocity = new Vector2(this._transform.localScale.x, 0) * this.Speed; // move the object in the direction of his local scale

			this._isGroundAhead = Physics2D.Linecast (
				this.SightStart.position,
				this.SightEnd.position,
				1 << LayerMask.NameToLayer ("Solid"));

			if (this._isGroundAhead == false) {
				// flip the direction
				this._flip();
			}
			// for debugging purposes only
			Debug.DrawLine(this.SightStart.position, this.SightEnd.position);

		}
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			this._flip ();
		}
	}

	// object is grounded if it stays on the platform
	private void OnCollisionStay2D(Collision2D other) {
		if (other.gameObject.CompareTag ("Platform")) {
			this._isGrounded = true;
		}
	}


	// object is not grounded if it leaves the platform
	private void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject.CompareTag ("Platform")) {
			this._isGrounded = false;
		}
	}

	/**
	 * This method flips the character's bitmap across the x-axis
	 */
	private void _flip () {
		if (this._transform.localScale.x == 5f) {
			this._transform.localScale = new Vector2 (-5f, 5f);
		} else {
			this._transform.localScale = new Vector2 (5f, 5f);
		}
	}
}