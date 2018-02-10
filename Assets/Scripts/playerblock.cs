// Player Block Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerblock : MonoBehaviour {

	public player plyr;				// A script variable to access variables from the player script
	public playershoot shoot;		// A script variable to access variables from the playershoot script
	public abtscreen abt;			// A script variable to access variables from the abtscreen script
	public Transform blockblock;	// The block to use, edit it in the Inspector
	
	void Update () {

		// A variable set to the control stick's vertical axis
		float vmove = Input.GetAxis("Vertical");
		
		// A variable set to the Xbox 360/Xbox One controller's B button to see if it's been pressed
		bool xboxp1_b = Input.GetButton("XBOXP1_B");
		
		// The time it will take for the block to be destroyed after being shot out
		float destroyblock = 5f;

		// If up/control stick is held up and x/B button is pressed and the player is facing either left or right and the player isn't already shooting and the "Mayonasie" ability is equipped, then the player will create a block on either side
		if((Input.GetKey("up") || vmove >= 1.0f) && (Input.GetKey("x") || xboxp1_b == true) && this.transform.eulerAngles == plyr.rightvector && shoot.shooting == false && abt.eqpdmayonaise == true
			|| (Input.GetKey("up") || vmove >= 1.0f) && (Input.GetKey("x") || xboxp1_b == true) && this.transform.eulerAngles == plyr.leftvector && shoot.shooting == false && abt.eqpdmayonaise == true) {

			shoot.shooting = true;

			// A transform that will instantiate an exsisting block to it's current position
 			Transform block = (Transform)Instantiate(blockblock, transform.position, transform.rotation);

 			// After a while, the block will be destroyed
 			Destroy(block.gameObject, destroyblock);
		}
	}
}
