// Projectile Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

	public float xdirection;	// The speed the object will travel at along the x axis, edit it in the Inspector
	public float ydirection;	// The speed the object will travel at along the y axis, edit it in the Inspector
	public float zdirection;	// The speed the object will travel at along the z axis, edit it in the Inspector
 	
 	void Update() {

    	// By adding speed to the enemy's x position, the enemy will move either left or right
     	transform.position = new Vector3(transform.position.x + xdirection * Time.deltaTime,
     									 transform.position.y + ydirection * Time.deltaTime,
     									 transform.position.z + zdirection * Time.deltaTime); 
    }

 	void OnTriggerStay2D(Collider2D col) {
		
		// Checks if player's hitbox is inside an enemy while it's attacking, the enemy will take damage
		if(col.gameObject.tag == "Enm" && col.gameObject.GetComponent<enemy>().invincible == false) {
			col.gameObject.GetComponent<enemy>().health -= 1;
			col.gameObject.GetComponent<enemy>().invincible = true;
		}
	}
}
