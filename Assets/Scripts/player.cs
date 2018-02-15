// Player Script for Dream Strike

// Using unity's engine and system collections
using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	// Public Script Variables	
	public playerjump jump;								// A script variable to access variables from the playerjump script
	public playerattack attack;							// A script variable to access variables from the playerattack script
	public abtscreen gotornot;							// A script variable to access variables from the abtscreen script
	// End of Public Script Variables

	// Public Variables	
	public int currenthp = 5;							// The current HP for the player
	public int hpmax = 5;								// The maximum amount of HP the player has
	public int apcurrent = 19;							// The current AP for the player
	public int apmax = 20;								// The maximum amount of AP the player has
	public int gold = 0;								// The current amount of gold the player has
	public float speed = 15f;       					// The speed the player moves at
	public float sloperotate;
	public float sloperotatemax = 40;
	public bool grounded = true;						// Checks if the player is on the ground
	public bool idle = false;							// Checks if the player is idle
	public bool bigjump = false;						// Checks if the player has the "Big Jump" ability
	public Vector3 leftvector = new Vector3(0, 180); 	// A vector that looks left
   	public Vector3 rightvector = new Vector3(0, 0); 	// A vector that looks right
	// End of Public Variables

	// Private Variables
	private Rigidbody2D rb;								// The rigidbody for the player
	private Animator anim;								// The animator for the player
   	// End of Private Variables
		
	void Start() {

		// Getting the components
		rb   = this.GetComponent<Rigidbody2D>();
		anim = this.GetComponent<Animator>();
	}
		
	void Update() {

	// A variable that is set to the player's rigidbody's velocity
	Vector2 velocitystop = rb.velocity;

	//sloperotate = transform.localEulerAngles.z;

		// If the player isn't jumping, attacking nor grounded, then the falling animation should play
		if (attack.attacking == false && grounded == false && jump.jumping == false && jump.djumpcurrentframe == 0) {
			anim.SetBool("Falling", true);

			// If the player double jumped, the double jump cooldown will start
			if(jump.djumped == false){
				jump.candjumpcurrentframe++;
			}
		}
			
		// If the player is idle, the idle animation will play
		if (idle == true) {
			anim.SetFloat("Horizontal", 0);
			// So the player doesn't slide around due to add force
			velocitystop.x = 0.0f;
			rb.velocity = velocitystop;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		
	// Checks if player is on the ground, if so then the player is grounded, can jump again, cannot double jump and animations are changed
		if(col.gameObject.tag == "Gnd" || col.gameObject.tag == "Lslp" || col.gameObject.tag == "Rslp") {
			grounded = true;
			jump.candoublejump = false;
			jump.jumpcurrentframe = 0;
			jump.candjumpcurrentframe = 0;
			jump.djumpcurrentframe = 0;
			jump.djumped = false;
			anim.SetBool("Jumping", false);
			anim.SetBool("Double Jumping", false);
			anim.SetBool("Falling", false);
		}

		if(col.gameObject.tag == "Rslp") {

			//if(transform.rotation.z < sloperotatemax) {
			// 	transform.Rotate(0, 0, 10);
			//}

			transform.eulerAngles = new Vector3(0, 0, 40);
		}
	}

	void OnCollisionStay2D(Collision2D col) {
		// If the player is on the ground, then they are still grounded
		if(col.gameObject.tag == "Gnd" || col.gameObject.tag == "Lslp" || col.gameObject.tag == "Rslp") {
			grounded = true;
			anim.SetBool("Falling", false);
		}

		if(col.gameObject.tag == "Rslp") {
			transform.eulerAngles = new Vector3(0, 0, 40);
		}
	}

	void OnCollisionExit2D(Collision2D col) {

		// If the player is no longer colliding with the ground, then the player is not grounded
		if(col.gameObject.tag == "Gnd" || col.gameObject.tag == "Lslp" || col.gameObject.tag == "Rslp") {
			grounded = false;
			jump.candoublejump = false;
			anim.SetBool("Falling", true);
		}

		if(col.gameObject.tag == "Rslp") {
			 transform.eulerAngles = new Vector3(0, 0, 0);
		}
	}
}