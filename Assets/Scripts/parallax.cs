using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour {

	public playermovement move;		// A script variable to access variables from the playermovement script
	public abtscreen abt;			// A script variable to access variables from the abtscreen script
	public menu menuu;				// A script variable to access variables from the menu script
	public float parallaxspeed;		// The speed of the parallax scroll, edit it in the Inspector
	
	void Update () {

		// A variable set to the control stick's axis
		float hmove = Input.GetAxis("Horizontal");

		// If left is pressed/control stick is pushed left, the background will scroll left
		if ((Input.GetKey("left") || hmove < -0.1f) && abt.eqpdwalkleft == true && menuu.paused == false && move.canwalkleft == true) {

				transform.Translate (new Vector3 (0.5f, 0.0f, 0.0f) * parallaxspeed * -1 * Time.deltaTime);

		// Or if right is pressed/control stick is pushed right, the background will scroll right
		} else if ((Input.GetKey("right") || hmove > 0.1f) && abt.eqpdwalkright == true && menuu.paused == false && move.canwalkright == true) {

				transform.Translate (new Vector3 (0.5f, 0.0f, 0.0f) * parallaxspeed * Time.deltaTime);
		}
	}
}
