// Inventory Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invscreen_cursor : MonoBehaviour {

	// Gets variables from the menu script
	public menu menuu;
	public menu pausecheck;

	// Co-ordinates for the inventory screen cursor
	public int ivtscreen_indexx = 0;
	public int ivtscreen_indexy = 0;

	private float ivtscreen_posx = Screen.width/5f;
	private float ivtscreen_posy = Screen.height/4f;


	// Inventory screen co-ordinates for cursor
	public int ivtscreen_minx = 0;
	public int ivtscreen_maxx = 5;
	public int ivtscreen_miny = 0;
	public int ivtscreen_maxy = 2;

	// Counter for the cursor on the inventory screen
	public bool ivtscreen_iscooldown;
    public int ivtscreen_cooldowntime;
    public int ivtscreen_cooldowncounter;

    // Texture for inventory screen cursor
	public Texture2D ivtscreencursor_texture;

	void Start () {
		// Sets the inventory screen's counter
		ivtscreen_iscooldown = false;
        ivtscreen_cooldowncounter = 0;
	}

	void OnGUI () {

		if(menuu.ivtscreen == true && pausecheck.paused == true){

			GUI.depth = 0;
			//GUI.DrawTexture(new Rect(Screen.width/20f, Screen.height/20f, Screen.width/1.1f, Screen.height/1.1f), ivtscreen_texture, ScaleMode.ScaleToFit, true);
			GUI.DrawTexture(new Rect(ivtscreen_posx, ivtscreen_posy, Screen.width/10f, Screen.height/10f), ivtscreencursor_texture, ScaleMode.ScaleToFit, true);

			// Use the TFGH keys to navigate the inventory screen
			if (Input.GetKey("f") && ivtscreen_iscooldown == false && ivtscreen_indexx > ivtscreen_minx){
				ivtscreen_posx -= Screen.width/10f;
				ivtscreen_indexx --;
				ivtscreen_iscooldown = true;
			}

			if (Input.GetKey("h") && ivtscreen_iscooldown == false && ivtscreen_indexx < ivtscreen_maxx){
				ivtscreen_posx += Screen.width/10f;
				ivtscreen_indexx ++;
				ivtscreen_iscooldown = true;
			}

			if (Input.GetKey("t") && ivtscreen_iscooldown == false && ivtscreen_indexy > ivtscreen_miny){
				ivtscreen_posy -= Screen.width/10f;
				ivtscreen_indexy --;
				ivtscreen_iscooldown = true;
			}

			if (Input.GetKey("g") && ivtscreen_iscooldown == false && ivtscreen_indexy < ivtscreen_maxy){
				ivtscreen_posy += Screen.width/10f;
				ivtscreen_indexy ++;
				ivtscreen_iscooldown = true;
			}
		}

		if (ivtscreen_iscooldown == true) {
           	ivtscreen_cooldowncounter++;
       	}

	  	if (ivtscreen_cooldowncounter >= ivtscreen_cooldowntime) {
            ivtscreen_iscooldown = false;
           	ivtscreen_cooldowncounter = 0;
        }

	}
}
