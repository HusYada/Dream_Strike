// Player Slam Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerslam : MonoBehaviour {

	public player plyr;					// A script variable to access variables from the player script
	public abtscreen abt;				// A script variable to access variables from the player script
	public bool slamming = false;		// Checks if the player is slamming
	private int slamcurrentframe = 0;	// The number of the frames that's passed for the slam animation
	private int slamtime = 30;			// The time it takes to finish the slam
	private Rigidbody2D rb;				// The rigidbody for the player
	private Animator anim;				// The animator for the player

	void Start () {

		// Getting the components
		rb   = this.GetComponent<Rigidbody2D>();
		anim = this.GetComponent<Animator>();
	}

	void Update () {

		// A variable set to the Xbox 360/Xbox One controller's X button to see if it's been pressed
		bool xboxp1_x = Input.GetButton("XBOXP1_X");
		
		// A variable that is set to the player's rigidbody's velocity
		Vector3 velocitystop = rb.velocity;

		// If c/X button is pressed and the player is facing right and the player isn't slamming and the "Cyber Slam" ability is equipped, the player will slam to the right
		if(xboxp1_x == true && this.transform.eulerAngles == plyr.rightvector && slamming == false && abt.eqpdcyberslam == true
			|| Input.GetKey("c") && this.transform.eulerAngles == plyr.rightvector && slamming == false && abt.eqpdcyberslam == true) {
			rb.MovePosition(transform.position + transform.right * plyr.speed * 10 * Time.deltaTime);
			velocitystop.y = 0f;
			rb.velocity = velocitystop;
			slamming = true;

		// If c/X button is pressed and the player is facing left and the player isn't slamming and the "Cyber Slam" ability is equipped, the player will slam to the left
		} else if (xboxp1_x == true && this.transform.eulerAngles == plyr.leftvector && slamming == false && abt.eqpdcyberslam == true
			|| Input.GetKey("c") && this.transform.eulerAngles == plyr.leftvector && slamming == false && abt.eqpdcyberslam == true) {
			rb.MovePosition(transform.position + transform.right * plyr.speed * 10 * Time.deltaTime);
			velocitystop.y = 0f;
			rb.velocity = velocitystop;
			slamming = true;
		}

		// If the player is slamming, the slam timer will start too
		if(slamming == true) {
			slamcurrentframe++;
			anim.SetBool("Slamming", true);
			anim.SetBool("Falling", true);
		}

		// When the counter for the slam is greater than one third of the attack time, the slam animation will finish
		if(slamcurrentframe > slamtime / 3) {
			anim.SetBool("Slamming", false);

			if(plyr.grounded == true){
				anim.SetFloat("Horizontal", 0);
				anim.SetBool("Falling", false);
			} else {
				anim.SetBool("Falling", true);
			}
		}

		// When the counter for the slam is greater than the slam time, the slam will finish and slamcurrentframe is reset
		if(slamcurrentframe > slamtime) {
			slamcurrentframe = 0;
			slamming = false;
		}
	}

	void OnCollisionEnter2D (Collision2D col) {

		// Checks if player's hitbox is inside an enemy while it's slamming, the enemy will take damage
		if(col.gameObject.tag == "Enm" && slamming == true && col.gameObject.GetComponent<enemy>().invincible == false) {
			col.gameObject.GetComponent<enemy>().health -= 2;
			col.gameObject.GetComponent<enemy>().invincible = true;
		}
	}
}
