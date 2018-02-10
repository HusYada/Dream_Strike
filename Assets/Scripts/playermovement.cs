// Player Movement Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour {

	public player plyr;					// A script variable to access variables from the player script
	public abtscreen abt;				// A script variable to access variables from the abtscreen script
	public bool canwalkleft = true;		// Checks if the player can walk left
	public bool canwalkright = true;	// Checks if the player can walk right
	private Animator anim;				// The animator for the player

	void Start () {

		// Getting the components
		anim = this.GetComponent<Animator>();
	}

	void Update () {

		// A variable set to the control stick's horizontal axis
		float hmove = Input.GetAxis("Horizontal");

		// If left is pressed/control stick is pushed left, the player will move left
		if ((Input.GetKey("left") || hmove < -0.1f)) {

			//rb.AddForce(Vector2.left * speed);
			//rb.MovePosition(transform.position + transform.right * -speed * Time.deltaTime);

			// If the "Walk Left" ability is equipped, then the player can perform the action
			if(abt.eqpdwalkleft == true && canwalkleft == true) {
				transform.Translate (new Vector3 (0.5f, 0.0f, 0.0f) * plyr.speed * Time.deltaTime);
				plyr.idle = false;

				if (plyr.grounded == true) {
					anim.SetFloat("Horizontal", -1);
				}
			}

			// Using the left vector to rotate the player to the left direction
			transform.eulerAngles = plyr.leftvector;

		// Or if right is pressed/control stick is pushed right, the player will move right
		} else if ((Input.GetKey("right") || hmove > 0.1f)) {

			//rb.AddForce(Vector2.right * speed);
			//rb.MovePosition(transform.position + transform.right * speed * Time.deltaTime);

			// If the "Walk Right" ability is equipped, then the player can perform the action
			if(abt.eqpdwalkright == true && canwalkright == true) {
				transform.Translate (new Vector3 (0.5f, 0.0f, 0.0f) * plyr.speed * Time.deltaTime);
				plyr.idle = false;

				if (plyr.grounded == true){
					anim.SetFloat("Horizontal", 1);
				}
			}

			// Using the right vector to rotate the player to the right direction
			transform.eulerAngles = plyr.rightvector;

			// If the player is not moving left or right, then the player is idle
		} else { 
			plyr.idle = true;
		}
	}

	// If the player is collides with something on the left of it, it cannot move left, vice versa for moving right
	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == "Lwl") {
			canwalkleft = false;
		}

		if(col.gameObject.tag == "Rwl") {
			canwalkright = false;
		}
	}

	// If the player is colliding with something on the left of it, it cannot move left, vice versa for moving right
	void OnCollisionStay2D(Collision2D col) {
		if(col.gameObject.tag == "Lwl") {
			canwalkleft = false;
		}

		if(col.gameObject.tag == "Rwl") {
			canwalkright = false;
		}
	}

	// If the player stop colliding with something on the left of it, it can move left, vice versa for moving right
	void OnCollisionExit2D(Collision2D col) {
		if(col.gameObject.tag == "Lwl") {
			canwalkleft = true;
		}

		if(col.gameObject.tag == "Rwl") {
			canwalkright = true;
		}
	}
}
