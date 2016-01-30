using UnityEngine;
using System.Collections;

public class Free2DMovement : MovementScript {

	private Vector2 direction;
	private Rigidbody2D rb2d;
	private Animator animator;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxisRaw ("Horizontal");
		float inputY = Input.GetAxisRaw ("Vertical");
        direction = new Vector2 (inputX , inputY);
	}
	
	void FixedUpdate() {
		rb2d.velocity = new Vector2 (direction.x * speed, direction.y * speed)*Time.fixedDeltaTime;
	}

}
