// Camera Bounds Script for Dream Strike
// Reference - George Games, 12 Dec 2015. Metroidvania Camera Boundaries Unity Tutorial. [online video] Available at: https://www.youtube.com/watch?v=3qfbJ-JSrOc [Accessed at 30 September 2017].
// Helpful source for getting the camera set up

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerabounds : MonoBehaviour {

	public  GameObject boundary; 			// The camera boundary
	private Transform player; 				// The player's position
	private BoxCollider2D boundarychecker; 	// The collider for the boundary checker


	void Start () {
		// Getting components
		player = GameObject.FindGameObjectWithTag("Plyr").GetComponent<Transform>();
		boundarychecker = GetComponent<BoxCollider2D>();
	}
	
	void Update () {

		// If the player is within a boundary, then it is the active bound that the camera will look at
		if(boundarychecker.bounds.min.x < player.position.x && player.position.x < boundarychecker.bounds.max.x &&
		   boundarychecker.bounds.min.y < player.position.y && player.position.y < boundarychecker.bounds.max.y) {
			boundary.SetActive(true);
		} else {
			boundary.SetActive(false);
		}
	}
}
