// Ability Screen Script for Dream Strike

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abtscreen : MonoBehaviour {

	// Public Script Variables	
	public menu menuu;
	public player plyr;
	public playermovement move;
	public playerjump jumpp;
	public playerattack attackk;
	public playerslam slam;
	public playershoot shoot;
	public playerblock block;
	public player bigjumpornah;
	// End of Public Script Variables	

	// Public Variables
	// Co-ordinates for the inventory screen cursor
	public int abtscreen_indexx = 0;
	public int abtscreen_indexy = 0;

	// Checks if the player has the ability
	public bool hasbigjump = false;
    public bool hascyberslam = true;
    public bool haspeashoot = true;
    public bool hasmayonaise = true;

    //Checks if the player has the ability equipped
    public bool eqpdwalkleft = true;
    public bool eqpdwalkright = true;
    public bool eqpdjump = true;
    public bool eqpdattack = true;
    public bool eqpdhealthbar = true;
    public bool eqpdwallet = true;
	//public bool eqpddance = false;
	public bool eqpdmap = true;
	public bool eqpdpause = true;
    public bool eqpdbigjump = false;
    public bool eqpdcyberslam = false;
    public bool eqpdpeashoot = false;
    public bool eqpdmayonaise = false;

    // Textures for ability screen
	public Texture2D abtscreencursor_texture;
	public Texture2D placeholder_texture;
	public Texture2D bigjump;
	public Texture2D bigjumpselected;
	public Texture2D runmore;
	public Texture2D runmoreselected;
	public Texture2D walkleft;
	public Texture2D walkright;
	public Texture2D jump;
	public Texture2D attack;
	public Texture2D healthbar;
	public Texture2D wallet;
	public Texture2D pause;
	public Texture2D map;
	public Texture2D cyberslam;
	public Texture2D peashoot;
	public Texture2D mayonaise;

	// Font style for the ability screen
	public GUIStyle abtscreen_font; 
	// End of Public Variables

	// Private Variables
	private float abtscreen_posx = Screen.width/6.5f;
	private float abtscreen_posy = Screen.height/6f;

	// Inventory screen co-ordinates for cursor
	private int abtscreen_minx = 0;
	private int abtscreen_maxx = 3;
	private int abtscreen_miny = 0;
	private int abtscreen_maxy = 9;

	// A counter for the ability screen cursor and the scroll rect
	private bool abtscreen_iscooldown;
	private int abtscreen_cooldowncounter; 
    private int abtscreen_cooldowntime = 20; 

    // Checks if the player has the ability
    private bool haswalkleft = true;
    private bool haswalkright = true;
    private bool hasjump = true;
    private bool hasattack = true;
    private bool hashealthbar = true;
    private bool haswallet = true;
	//private bool hasdance = false;
	private bool hasmap = true;
	private bool haspause = true;
	// End of Private Variables

	
	void Start () {

		// Sets the ability screen's counter
		abtscreen_iscooldown = false;
		//abtscreenscroll_iscooldown = false;
        abtscreen_cooldowncounter = 0;
	}

	void Update () {

		// A variable set to the Xbox 360/Xbox One controller's A button to see if it's been pressed
		bool xboxp1_a = Input.GetButtonDown("XBOXP1_A");
		// A variable set to the Xbox 360/Xbox One controller's B button to see if it's been pressed
		bool xboxp1_b = Input.GetButtonDown("XBOXP1_B");

	// If the game is paused, the ability screen will check which abilities are equipped depending on if the player has it and the ability cursor is hovering over it, adding or subtracting AP is it's equipped or not
	if(menuu.paused == true) {

		if(haswalkleft == true && abtscreen_indexx == 0 && abtscreen_indexy == 0) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdwalkleft == false && plyr.apcurrent + 3 <= plyr.apmax) {
				plyr.apcurrent += 3;
				eqpdwalkleft = true;
			}

			if((Input.GetKeyDown("x") || xboxp1_b == true) && eqpdwalkleft == true) {
				plyr.apcurrent -= 3;
				eqpdwalkleft = false;
			}
		}

		if(haswalkright == true && abtscreen_indexx == 1 && abtscreen_indexy == 0) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdwalkright == false && plyr.apcurrent + 3 <= plyr.apmax) {
				plyr.apcurrent += 3;
				eqpdwalkright = true;
			}

			if((Input.GetKeyDown("x") || xboxp1_b == true) && eqpdwalkright == true) {
				plyr.apcurrent -= 3;
				eqpdwalkright = false;
			}
		}

		if(hasjump == true && abtscreen_indexx == 2 && abtscreen_indexy == 0) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdjump == false && plyr.apcurrent + 3 <= plyr.apmax) {
				plyr.apcurrent += 3;
				eqpdjump = true;
			}

			if((Input.GetKeyDown("x") || xboxp1_b == true) && eqpdjump == true) {
				plyr.apcurrent -= 3;
				eqpdjump = false;
			}
		}

		if(hasattack == true && abtscreen_indexx == 3 && abtscreen_indexy == 0) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdattack == false && plyr.apcurrent + 3 <= plyr.apmax) {
				plyr.apcurrent += 3;
				eqpdattack = true;
			}

			if((Input.GetKeyDown("x") || xboxp1_b == true) && eqpdattack == true) {
				plyr.apcurrent -= 3;
				eqpdattack = false;
			}
		}

		if(hashealthbar == true && abtscreen_indexx == 0 && abtscreen_indexy == 1) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdhealthbar == false && plyr.apcurrent + 5 <= plyr.apmax) {
				plyr.apcurrent += 5;
				eqpdhealthbar = true;
			}

			if((Input.GetKeyDown("x") || xboxp1_b == true) && eqpdhealthbar == true) {
				plyr.apcurrent -= 5;
				eqpdhealthbar = false;
			}
		}

		if(haswallet == true && abtscreen_indexx == 1 && abtscreen_indexy == 1) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdwallet == false && plyr.apcurrent + 1 <= plyr.apmax) {
				plyr.apcurrent += 1;
				eqpdwallet = true;
			}

			if((Input.GetKeyDown("x") || xboxp1_b == true) && eqpdwallet == true) {
				plyr.apcurrent -= 1;
				eqpdwallet = false;
			}
		}

		if(haspause == true && abtscreen_indexx == 2 && abtscreen_indexy == 1) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdpause == false && plyr.apcurrent + 1 <= plyr.apmax) {
				plyr.apcurrent += 1;
				eqpdpause = true;
			}

			if((Input.GetKeyDown("x") || xboxp1_b == true) && eqpdpause == true) {
				plyr.apcurrent -= 1;
				eqpdpause = false;
			}
		}

		if(hasmap == true && abtscreen_indexx == 3 && abtscreen_indexy == 1) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdmap == false && plyr.apcurrent + 0 <= plyr.apmax) {
				plyr.apcurrent += 0;
				eqpdmap = true;
			}

			if((Input.GetKeyDown("x") || xboxp1_b == true) && eqpdmap == true) {
				plyr.apcurrent -= 0;
				eqpdmap = false;
			}
		}

		if(hascyberslam == true && abtscreen_indexx == 0 && abtscreen_indexy == 2) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdcyberslam == false && plyr.apcurrent + 1 <= plyr.apmax) {
				plyr.apcurrent += 1;
				eqpdcyberslam = true;
			}

			if((Input.GetKeyDown("x") || xboxp1_b == true) && eqpdcyberslam == true) {
				plyr.apcurrent -= 1;
				eqpdcyberslam = false;
			}
		}

		if(haspeashoot == true && abtscreen_indexx == 1 && abtscreen_indexy == 2) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdpeashoot == false && plyr.apcurrent + 1 <= plyr.apmax) {
				plyr.apcurrent += 1;
				eqpdpeashoot = true;
			}

			if((Input.GetKeyDown("x") || xboxp1_b == true) && eqpdpeashoot == true) {
				plyr.apcurrent -= 1;
				eqpdpeashoot = false;
			}
		}

		if(hasmayonaise == true && abtscreen_indexx == 3 && abtscreen_indexy == 2) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdmayonaise == false && plyr.apcurrent + 1 <= plyr.apmax) {
				plyr.apcurrent += 1;
				eqpdmayonaise = true;
			}

			if((Input.GetKeyDown("x") || xboxp1_b == true) && eqpdmayonaise == true) {
				plyr.apcurrent -= 1;
				eqpdmayonaise = false;
			}
		}
	  }				
	}

	// GUI Elements are ordered with the lowest in front and vice versa
	void OnGUI () {

		// A variable set to the control stick's horizontal axis
		float hmove = Input.GetAxis("Horizontal");
		// A variable set to the control stick's vertical axis
		float vmove = Input.GetAxis("Vertical");

		// If the menu is on the ability screen and the game is paused, the cursor on the ability screen can be moved
		if(menuu.abtscreen == true && menuu.paused == true){

			// Movement for the cursor on ability list
			if ((Input.GetKey("left") || hmove < -0.1f) && abtscreen_iscooldown == false && abtscreen_indexx > abtscreen_minx){
				abtscreen_posx -= Screen.width/5.7f;
				abtscreen_indexx --;
				abtscreen_iscooldown = true;
			} else if ((Input.GetKey("right") || hmove > 0.1f) && abtscreen_iscooldown == false && abtscreen_indexx < abtscreen_maxx){
				abtscreen_posx += Screen.width/5.7f;
				abtscreen_indexx ++;
				abtscreen_iscooldown = true;
			}

			if ((Input.GetKey("up") || vmove > 0.1f) && abtscreen_iscooldown == false && abtscreen_indexy > abtscreen_miny){
				abtscreen_posy -= Screen.height/15f;
				abtscreen_indexy --;
				abtscreen_iscooldown = true;
				
			} else if ((Input.GetKey("down") || vmove < -0.1f) && abtscreen_iscooldown == false && abtscreen_indexy < abtscreen_maxy){
				abtscreen_posy += Screen.height/15f;
				abtscreen_indexy ++;
				abtscreen_iscooldown = true;
			}

			// The cursor graphic
        	GUI.DrawTexture(new Rect(abtscreen_posx, abtscreen_posy, Screen.width/6f, Screen.height/15f), abtscreencursor_texture, ScaleMode.StretchToFill);

        	// Number of ability points used and how many left
        	GUI.Label(new Rect(Screen.width/1.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), plyr.apcurrent.ToString() + " / " + plyr.apmax.ToString(), abtscreen_font);

        	// The ability list, if the player has the ability is will appear on the ability screen along with a description and cost
        	if(haswalkleft == true) {
        		GUI.DrawTexture(new Rect(Screen.width/6.5f, Screen.height/6f, Screen.width/6f, Screen.height/16f), walkleft, ScaleMode.StretchToFill);

        		if(abtscreen_indexx == 0 && abtscreen_indexy == 0) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "Press <- to walk left", abtscreen_font);
					GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Move the joystick left to walk left", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "3", abtscreen_font);
				}
        	}

        	if(haswalkright == true) {
        		GUI.DrawTexture(new Rect(Screen.width/3.04f, Screen.height/6f, Screen.width/6f, Screen.height/16f), walkright, ScaleMode.StretchToFill);

        		if(abtscreen_indexx == 1 && abtscreen_indexy == 0) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "walkrigh", abtscreen_font);
					GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Hello World", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "3", abtscreen_font);
				}
        	}

        	if(hasjump == true) {
        		GUI.DrawTexture(new Rect(Screen.width/1.98f, Screen.height/6f, Screen.width/6f, Screen.height/16f), jump, ScaleMode.StretchToFill);

        		if(abtscreen_indexx == 2 && abtscreen_indexy == 0) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "pjumpoo", abtscreen_font);
					GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Hello World", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "3", abtscreen_font);
				}
        	}

        	if(hasattack == true) {
        		GUI.DrawTexture(new Rect(Screen.width/1.47f, Screen.height/6f, Screen.width/6f, Screen.height/16f), attack, ScaleMode.StretchToFill);

        		if(abtscreen_indexx == 3 && abtscreen_indexy == 0) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "pattaco", abtscreen_font);
					GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Hello World", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "3", abtscreen_font);
				}
        	}

        	if(hashealthbar == true) {
        		GUI.DrawTexture(new Rect(Screen.width/6.5f, Screen.height/6f + Screen.height/15 * 1, Screen.width/6f, Screen.height/16f), healthbar, ScaleMode.StretchToFill);

        		if(abtscreen_indexx == 0 && abtscreen_indexy == 1) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "phealthoto", abtscreen_font);
					GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Hello World", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "5", abtscreen_font);
				}
        	}

        	if(haswallet == true) {
        		GUI.DrawTexture(new Rect(Screen.width/3.04f, Screen.height/6f + Screen.height/15 * 1, Screen.width/6f, Screen.height/16f), wallet, ScaleMode.StretchToFill);

        		if(abtscreen_indexx == 1 && abtscreen_indexy == 1) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "wallet", abtscreen_font);
					GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Hello World", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "1", abtscreen_font);
				}
        	}

        	if(haspause == true) {
        		GUI.DrawTexture(new Rect(Screen.width/1.98f, Screen.height/6f + Screen.height/15 * 1, Screen.width/6f, Screen.height/16f), pause, ScaleMode.StretchToFill);

        		if(abtscreen_indexx == 2 && abtscreen_indexy == 1) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "pauseo", abtscreen_font);
					GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Hello World", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "1", abtscreen_font);
				}
        	}

        	if(hasmap == true) {
        		GUI.DrawTexture(new Rect(Screen.width/1.47f, Screen.height/6f + Screen.height/15 * 1, Screen.width/6f, Screen.height/16f), map, ScaleMode.StretchToFill);

        		if(abtscreen_indexx == 3 && abtscreen_indexy == 1) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "mapo", abtscreen_font);
					GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Hello World", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "0", abtscreen_font);
				}
        	}

        	if(hascyberslam == true) {
        		GUI.DrawTexture(new Rect(Screen.width/6.5f, Screen.height/6f + Screen.height/15 * 2, Screen.width/6f, Screen.height/16f), cyberslam, ScaleMode.StretchToFill);

        		if(abtscreen_indexx == 0 && abtscreen_indexy == 2) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "cyber", abtscreen_font);
					GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Hello World", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "1", abtscreen_font);
				}
			}   

        	if(haspeashoot == true) {

        		GUI.DrawTexture(new Rect(Screen.width/3.04f, Screen.height/6f + Screen.height/15 * 2, Screen.width/6f, Screen.height/16f), peashoot, ScaleMode.StretchToFill);

        		if(abtscreen_indexx == 1 && abtscreen_indexy == 2) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "pea shooto", abtscreen_font);
					GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Hello World", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "1", abtscreen_font);
				}
        	}

        	if(hasmayonaise == true) {
        		GUI.DrawTexture(new Rect(Screen.width/1.47f, Screen.height/6f + Screen.height/15 * 2, Screen.width/6f, Screen.height/16f), mayonaise, ScaleMode.StretchToFill);

        		if(abtscreen_indexx == 3 && abtscreen_indexy == 2) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "mayo", abtscreen_font);
					GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Hello World", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "1", abtscreen_font);
				}
        	}

        	// A variable for the fontsize that changes depending on the screen size
        	int fontscale = Convert.ToInt32(40.0f * Screen.width/1920.0f);

        	// Setting the font size to the new interger
        	abtscreen_font.fontSize = fontscale;

		}

		// If the ability screen cursor moved, a counter will start
		if (abtscreen_iscooldown == true) {
           	abtscreen_cooldowncounter++;
       	}

       	// If the ability screen counter is equal to its time, the ability screen cursor can be move again
	  	if (abtscreen_cooldowncounter >= abtscreen_cooldowntime) {
            abtscreen_iscooldown = false;
           	abtscreen_cooldowncounter = 0;
        }
	}
}
