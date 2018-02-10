	// Player Attack Script for Dream Strike

	// Using unity's engine and system collections
	using UnityEngine;
	using System.Collections;
	
	public class playerattack : MonoBehaviour {

		public player plyr;					// A script variable to access variables from the player script
		public abtscreen abt;				// A script variable to access variables from the abtscreen script
		public bool attacking = false;		// Checks if the player is attacking
		private int attackcurrentframe = 0;	// The number of the frames that's passed for the attack animation
		private int attacktime = 15;		// The time it takes to finish the attack
		private Rigidbody2D rb;				// The rigidbody for the player
		private Animator anim;				// The animator for the player

		void Start () {

			// Getting the components
			rb   = plyr.GetComponent<Rigidbody2D>();
			anim = plyr.GetComponent<Animator>();
		}

		void Update () {

			// A variable set to the Xbox 360/Xbox One controller's B button to see if it's been pressed
			bool xboxp1_b = Input.GetButton("XBOXP1_B");

			// If x/B button is pressed and the "Attack" ability is equipped, then the player will be attacking
			if ((Input.GetKey("x") || xboxp1_b == true) && abt.eqpdattack == true) {
				attacking = true;
			}

			// If the player is attacking, they will stand still and attack; the attack timer will start too
			if (attacking == true) {

				// If the player is on the ground while attacking, the player will not be able to move
				if(plyr.grounded == true){
					rb.velocity = new Vector2(0, 0);
				}

				anim.SetBool("Jumping", false);
				anim.SetBool("Falling", false);
				anim.SetBool("Attacking", true);
				plyr.idle = false;
				attackcurrentframe++;
			}

			// When the counter for the attack is greater than the attack time, the attack will finish and attackcurrentframe is reset
			if (attackcurrentframe > attacktime) {
				attacking = false;
				anim.SetBool("Attacking", false);
				attackcurrentframe = 0;

				// If the player was attacking in the air, they will go back to the previous animation
				if (plyr.grounded == false) {
					anim.SetBool("Falling", true);
				}
			}
		}

		void OnTriggerStay2D(Collider2D col) {
		
		// Checks if player's hitbox is inside an enemy while it's attacking, the enemy will take damage
			if(col.gameObject.tag == "Enm" && attacking == true && col.gameObject.GetComponent<enemy>().invincible == false) {
				col.gameObject.GetComponent<enemy>().health -= 1;
				col.gameObject.GetComponent<enemy>().invincible = true;
			}
		}
}