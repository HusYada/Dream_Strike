// Player Shoot Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershoot : MonoBehaviour {

	public player plyr;					// A script variable to access variables from the player script
	public abtscreen gotornot;			// A script variable to access variables from the abtscreen script
	public Transform leftprojectile; 	// The projectile that will be shot left, edit it in the Inspector
	public Transform rightprojectile; 	// The projectile that will be shot right, edit it in the Inspector
	public bool shooting = false;		// Checks if the player is shooting or not
	private int shootcurrentframe = 0;	// The number of the frames that's passed for the shoot animation
	private int shoottime = 30;			// The time it takes to finish the shoot
	private Animator anim;				// The animator for the player

	void Start () {

		// Getting the components
		anim = this.GetComponent<Animator>();
	}
	
	void Update () {

		// If the "Pea Shoot" ability is equipped, then the player can shoot
		if(gotornot.eqpdpeashoot == true) {

			// A variable set to the Xbox 360/Xbox One controller's Y button to see if it's been pressed
			bool xboxp1_y = Input.GetButton("XBOXP1_Y");

			// The time it will take for the projectile to be destroyed after being shot out
 			float destroyprojectile = 5f;

			// If v/Y button is pressed and the player is facing right and the player isn't already shooting, then the player will shoot a projectile to the right
			if(xboxp1_y == true && this.transform.eulerAngles == plyr.rightvector && shooting == false
				|| Input.GetKey("v") && this.transform.eulerAngles == plyr.rightvector && shooting == false) {

				shooting = true;

				// A transform that will instantiate an exsisting bullet to it's current position
 				Transform rbullet = (Transform)Instantiate(rightprojectile, transform.position, transform.rotation);

 				// After a while, the projectile will be destroyed
 				Destroy(rbullet.gameObject, destroyprojectile);

 			// If v/Y button is pressed and the player is facing left and the player isn't already shooting, then the player will shoot a projectile to the left
			} else if (xboxp1_y == true && this.transform.eulerAngles == plyr.leftvector && shooting == false
				|| Input.GetKey("v") && this.transform.eulerAngles == plyr.leftvector && shooting == false) {

				shooting = true;

				// A transform that will instantiate an exsisting bullet to it's current position
 				Transform lbullet = (Transform)Instantiate(leftprojectile, transform.position, transform.rotation);

 				// After a while, the projectile will be destroyed
 				Destroy(lbullet.gameObject, destroyprojectile);
			}

			// If the player is shooting, the shoot timer will start too
			if(shooting == true){
				shootcurrentframe++;
				anim.SetBool("Shooting", true);
				anim.SetBool("Falling", true);
			}

			// When the counter for the shoot is greater than one half of the shoot time, the shoot animation will finish
			if(shootcurrentframe > shoottime / 2) {
				anim.SetBool("Shooting", false);

				if(plyr.grounded == true){
					anim.SetFloat("Horizontal", 0);
					anim.SetBool("Falling", false);
				} else {
					anim.SetBool("Falling", true);
				}
			}

			// When the counter for the slam is greater than the slam time, the slam will finish and slamcurrentframe is reset
			if(shootcurrentframe > shoottime) {
				shootcurrentframe = 0;
				shooting = false;
			}
		}
	}
}
