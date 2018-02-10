	// Enemy Script for Dream Strike

	using UnityEngine;
	using System.Collections;
	
	public class enemy : MonoBehaviour {

		public abtscreen bigjumpornah;			// Checks if the "Big Jump" ability is unlocked

    	public int health; 						// The number of hits an enemy can take
    	public int invincible_cooldowntime; 	// The cooldown on the enemy's invincibility when hurt
    	public int invincible_cooldowncounter; 	// The counter for the invincibility cooldown
    	public int dead_cooldowntime; 			// The amount of time the enemy stays on the screen when dead
    	public int dead_cooldowncounter;		// The counter for the enemy's death

    	public bool dead; 						// Checks if the enemy is dead
    	public bool invincible; 				// Checks if the enemy is invincible
   		

		// Sets the invinsibility and death counters to 0
		void Start () {
        	invincible = false;
        	invincible_cooldowncounter = 0;
        	dead_cooldowncounter = 0;
		}
		
		void FixedUpdate() {

			// If the enemy is invicible, an invincible counter will start
			if (invincible == true) {
            	invincible_cooldowncounter++;
        	}

        	// If the invincible counter reaches the cooldown time, the enemy is no longer invincible and the counter is reset
        	if (invincible_cooldowncounter >= invincible_cooldowntime) {
            	invincible = false;
            	invincible_cooldowncounter = 0;
        	}

        	// If the enemy's health is equal or less than 0, the enemy is dead
        	if (health <= 0) {
            	dead = true;
        	}

        	// If the enemy is dead, a death counter will start and the player will gain the "Big Jump" ability
        	if (dead == true) {
            	dead_cooldowncounter++;
            	bigjumpornah.hasbigjump = true;
        	}

        	// When the death counter is finished, the gameobject is destroyed 
        	if (dead_cooldowncounter >= dead_cooldowntime) {
            	Destroy(gameObject);
        	}
		}
}