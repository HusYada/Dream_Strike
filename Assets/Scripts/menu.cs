// Menu Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour {

	public abtscreen abt;			// A script variable to access variables from the abtscreen script

	// Public Variables
	public bool paused = false;		// Checks if the game is paused
	public bool ivtscreen = true;	// Checks if the game has the inventory screen up
	public bool abtscreen = false;	// Checks if the game has the ability screen up
	public bool mapscreen = false;	// Checks if the game has the map screen up

	// Counter for switching through menu screens so you don't zip past them at the speed of light
	public bool menu_iscooldown;
    public int menu_cooldowntime;
    public int menu_cooldowncounter;

    // Textures for menu screens
	public Texture2D ivtscreen_texture;
	public Texture2D abtscreen_texture;
	public Texture2D mapscreen_texture;
	// End of Public Variables

	void Start () {

		// Sets the menu's counter
        menu_iscooldown = false;
        menu_cooldowncounter = 0;
	}

	void Update() {

		bool xboxp1_start = Input.GetButtonDown("XBOXP1_START");

		// If the return key/Start button is pressed, the game will switch from a paused or unpaused state
		if(Input.GetKeyDown(KeyCode.Return) || xboxp1_start == true) {
       		
       		paused = !paused;

       		// If the game is paused and the "Pause" ability is equipped, then time will not move
        	if(paused == true) {

        		if(abt.eqpdpause == true) {
        			Time.timeScale = 0;
        		}

        	// Otherwise time will move as normal
        	} else {
        		Time.timeScale = 1;
        	}

        	// If the "Pause" ability is unequipped then time will always move
        	if(abt.eqpdpause == false) {
        		Time.timeScale = 1;
        	}
    	}
	}

	void OnGUI() {

		// A variable set to the Xbox 360/Xbox One controller's LB button to see if it's been pressed
		bool xboxp1_lb = Input.GetButton("XBOXP1_LB");
		
		// A variable set to the Xbox 360/Xbox One controller's RB button to see if it's been pressed
		bool xboxp1_rb = Input.GetButton("XBOXP1_RB");

		// If the game is paused, it will bring up the menu
		if(paused == true) {

			// The a and d keys/LB and RB buttons will switch the menu screen depending on what the menu screen is
			if(ivtscreen == true){

				GUI.depth = 4;
				GUI.DrawTexture(new Rect(Screen.width/20f, Screen.height/20f, Screen.width/1.1f, Screen.height/1.1f), ivtscreen_texture, ScaleMode.ScaleToFit, true);
				if ((Input.GetKey("a") || xboxp1_lb == true) && menu_iscooldown == false){
					ivtscreen = false;
					abtscreen = true;
					menu_iscooldown = true;
				}
				if ((Input.GetKey("d") || xboxp1_rb == true) && menu_iscooldown == false){
					ivtscreen = false;
					mapscreen = true;
					menu_iscooldown = true;
				}
			} else if (abtscreen == true){
				GUI.depth = 4;
				GUI.DrawTexture(new Rect(Screen.width/20f, Screen.height/20f, Screen.width/1.1f, Screen.height/1.1f), abtscreen_texture, ScaleMode.ScaleToFit, true);
				if ((Input.GetKey("a") || xboxp1_lb == true) && menu_iscooldown == false){
					abtscreen = false;
					mapscreen = true;
					menu_iscooldown = true;
				}
				if ((Input.GetKey("d") || xboxp1_rb == true) && menu_iscooldown == false){
					abtscreen = false;
					ivtscreen = true;
					menu_iscooldown = true;
				}
			} else if(mapscreen == true){
				GUI.depth = 4;
				GUI.DrawTexture(new Rect(Screen.width/20f, Screen.height/20f, Screen.width/1.1f, Screen.height/1.1f), mapscreen_texture, ScaleMode.ScaleToFit, true);
				if ((Input.GetKey("a") || xboxp1_lb == true) && menu_iscooldown == false){
					mapscreen = false;
					ivtscreen = true;
					menu_iscooldown = true;
				}
				if ((Input.GetKey("d") || xboxp1_rb == true) && menu_iscooldown == false){
					mapscreen = false;
					abtscreen = true;
					menu_iscooldown = true;
				}
			}
		}

		// If the menu screen has changed, a counter will start
		if (menu_iscooldown == true) {
           	menu_cooldowncounter++;
       	}

       	// If the menu counter is equal to its time, the menu screen can be changed again
	  	if (menu_cooldowncounter >= menu_cooldowntime) {
            menu_iscooldown = false;
           	menu_cooldowncounter = 0;
        }
	}
}