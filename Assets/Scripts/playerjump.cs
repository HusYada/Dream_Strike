// Player Jump Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerjump : MonoBehaviour {

	// Public Script Variables	
	public player plyr;								// A script variable to access variables from the player script
	public menu menuu;								// A script variable to access variables from the menu script
	public abtscreen abt;							// A script variable to access variables from the abtscreen script
	// End of Public Script Variables	

	// Public Variables	
	public float jump = 150f;      					// The jump power the player has
	public int jumpcurrentframe = 0;				// The number of the frames that's passed for the jump animation
	public int jumptime = 7;						// The time it takes for the jump animation to finish
	public int candjumpcurrentframe = 0;			// The number of frames that's passed for if the player can double jump
	public int djumpcurrentframe = 0;				// The number of frames that's passed for the double jump animation
	public int djumptime = 3;						// The time it takes for the double jump animation to both be available or finish
	public bool jumping = false;					// Checks if the player is jumping
	public bool candoublejump = false;				// Checks if the player can use the "Double Jump" ability
	public bool djumped = false;					// Checks if the player double jumped
	// End of Public Variables	

	// Private Variables
	private Rigidbody2D rb;							// The rigidbody for the player
	private Animator anim;							// The animator for the player
	// End of Private Variables

	void Start () {

		// Getting the components
		rb   = this.GetComponent<Rigidbody2D>();
		anim = this.GetComponent<Animator>();
	}
	
	void Update () {

		// A variable set to the Xbox 360/Xbox One controller's A button to see if it's been pressed
		bool xboxp1_a = Input.GetButtonDown("XBOXP1_A");

		// A variable set to the Xbox 360/Xbox One controller's A button to see if it's been released
		bool xboxp1_aup = Input.GetButtonUp("XBOXP1_A");

		// A variable that is set to the player's rigidbody's velocity
		Vector2 velocitystop = rb.velocity;

		// If z/A button is pressed and the player is on the ground and the "Jump" ability is equipped and the game is unpaused, the player will jump
		if ((Input.GetKey("z") || xboxp1_a == true) && plyr.grounded == true && abt.eqpdjump == true && menuu.paused == false) {
			jumping = true;
		}

		// If the player is jumping, the player will be forced upwards
		if (jumping == true) {
			rb.AddForce(Vector2.up * (jump - 60));
			anim.SetBool("Jumping", true);
			candoublejump = false;
			plyr.grounded = false;
			plyr.idle = false;
			anim.SetBool("Falling", false);
			djumped = false;
			jumpcurrentframe++;
		}

		// If z/A button is released, the jump will stop
		if ((Input.GetKeyUp("z") || xboxp1_aup == true) && jumpcurrentframe > 0) {
			rb.velocity = new Vector2(0, 0);
		}

		// If z/A button is pressed and the player is not on the ground and the player can double jump and the "Jump" ability is equipped, the player will jump again in midair
		if ((Input.GetKeyDown("z") || xboxp1_a == true) && candoublejump == true && plyr.grounded == false && abt.eqpdjump == true) {
			rb.velocity = new Vector2(0, 0);
			rb.AddForce(Vector2.up * jump * 3);
			anim.SetBool("Double Jumping", true);
			anim.SetBool("Falling", false);
			plyr.idle = false;
			plyr.grounded = false;
			djumped = true;
		}

		// If the number of the frames that's passed for the jump animation surpasses the time it should take for the jump animation to finish, the jump will stop
		if (jumpcurrentframe > jumptime) {
			jumping = false;
			anim.SetBool("Jumping", false);
			anim.SetBool("Double Jumping", false);
			anim.SetBool("Falling", true);
			jumpcurrentframe = 0;
		}

		// If the number of the frames that's passed for the double jump animation surpasses the time it should take for the double jump animation to finish, the double jump will stop 
		if(candjumpcurrentframe > djumptime){
			candoublejump = true;
			candjumpcurrentframe = 0;
		}

		// If the number of the frames that's passed for if the player can double jump surpasses the time it should take for the double jump animation to finish, the player will be able to double jump
		if (djumpcurrentframe > djumptime) {
			jumping = false;
			candoublejump = false;
			anim.SetBool("Jumping", false);
			anim.SetBool("Double Jumping", false);
			anim.SetBool("Falling", true);
			djumpcurrentframe = 0;
		}

		// If the player has double jumped, then the double jump counter will start and the player will not be able to perform the action again
		if (djumped == true) {
			jumping = false;
			candoublejump = false;
			anim.SetBool("Jumping", false);
			djumpcurrentframe++;
		}
	}
}
