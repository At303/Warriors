using UnityEngine;
using System.Collections;
using gamedata;

public class GM : MonoBehaviour {


	// Get a gap of two touch
	float before_touch = 0.0f;
	float current_touch = 0.0f;
	float touch_deltatime = 0.0f;


	// Use this for initialization
	void Start () {

	}
	/*

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			//Get the mouse position on the screen and send a raycast into the game world from that position.
			Vector2 worldPoint = UICamera.mainCamera.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero);

			// Random slash animation
			string slash_animation_name = "slash" + Random.Range(1,3).ToString();
			GameData.slash_animation = GameObject.Find (slash_animation_name);

			//If something was hit, the RaycastHit2D.collider will not be null.
			if (hit.collider != null && !(opened_chest_box.enable_disable_chest_open)) {
				// slash sprite enable
				GameData.slash_animation.GetComponent<Animator> ().SetTrigger ("enable");
				GameData.slash_animation.GetComponent<SpriteRenderer> ().enabled = true;

				// Chest box HP modify
				GameData.chest_struct._HP = GameData.chest_struct._HP - GameData.touch_struct.damage;
				float fHP = GameData.chest_struct._HP / GameData.chest_struct.HP;
				GameData.chest_sprite.GetComponent<UIProgressBar> ().value = fHP;

				// touch 사이의 차이에 따라서 상자 animation speed control.
				before_touch = current_touch; 
				current_touch = Time.time;
				touch_deltatime = current_touch - before_touch;
				GameData.debug_label2.GetComponent<UILabel> ().text = touch_deltatime.ToString ();

				//coin box attack animation 
				if (touch_deltatime < 0.17) {
					GameData.chest_sprite.GetComponent<Animator> ().SetFloat ("speed", touch_deltatime);
				} else {
					GameData.chest_sprite.GetComponent<Animator> ().SetFloat ("speed", touch_deltatime);
				}
				// chest sprite animation enable
				GameData.chest_sprite.GetComponent<Animator> ().SetTrigger ("enable");


				// if chest HP is under 0, reset chest HP.
				if (GameData.chest_struct._HP <= 0) {
					// 보물상자 false시키고 , open된 보물상자 enable
					GameData.chest_sprite.SetActive (false);
					opened_chest_box.enable_disable_chest_open = true;

					opened_chest_box.target_time = Time.time + 5.0f;
					GameData.chest_struct._HP = GameData.chest_struct.HP;
					GameData.chest_sprite.GetComponent<UIProgressBar> ().value = GameData.chest_struct._HP;
	
					GameData.chest_opened_sprite.SetActive (true);
				}


				// Test HUDText;;;;
				string get_coin_str = "+" + GameData.chest_struct.attacked_gold ;
				GameData.chest_HUDText_control.GetComponent<HUDText> ().Add (get_coin_str, Color.yellow, -0.8f);

			} 
			else if (hit.collider != null) 
			{
				// only touchedd in the collision area //

				// slash sprite enable
				GameData.slash_animation.GetComponent<Animator> ().SetTrigger ("enable");
				GameData.slash_animation.GetComponent<SpriteRenderer> ().enabled = true;


			}
		}
	}

	*/
	void FixedUpdate()
	{
		// Single touch
		if (Input.touchCount > 0) 
		{
			Touch touch1 = Input.GetTouch (0);				// first touch

			// if Touch is On
			if (touch1.phase == TouchPhase.Began) 
			{
				//Get the mouse position on the screen and send a raycast into the game world from that position.
				Vector2 worldPoint = UICamera.mainCamera.ScreenToWorldPoint(Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast(worldPoint,Vector2.zero);

				// Random touch slash animation
				string slash_animation_name = "slash" + Random.Range(1,3).ToString();
				GameData.slash_animation = GameObject.Find (slash_animation_name);

				//If touch is on the fixed range, excute the code.
				if (hit.collider != null  && !(opened_chest_box.enable_disable_chest_open)) 
				{
					// slash sprite enable
					GameData.slash_animation.GetComponent<Animator>().SetTrigger("enable");
					GameData.slash_animation.GetComponent<SpriteRenderer> ().enabled = true;

					// Chest box HP modify
					GameData.chest_struct._HP = GameData.chest_struct._HP - GameData.touch_struct.damage;
					float fHP = GameData.chest_struct._HP / GameData.chest_struct.HP;
					GameData.chest_sprite.GetComponent<UIProgressBar> ().value = fHP;

					// touch 사이의 차이에 따라서 상자 animation speed control.
					before_touch = current_touch; 
					current_touch = Time.time;
					touch_deltatime = current_touch - before_touch;
					GameData.debug_label2.GetComponent<UILabel> ().text = touch_deltatime.ToString ();

					//coin box attack animation 
					if (touch_deltatime < 0.17) {
						GameData.chest_sprite.GetComponent<Animator> ().SetFloat ("speed", touch_deltatime);
					} else {
						GameData.chest_sprite.GetComponent<Animator> ().SetFloat ("speed", touch_deltatime);
					}
					// chest sprite animation enable
					GameData.chest_sprite.GetComponent<Animator>().SetTrigger("enable");

					// Test HUDText;;;;
					string get_coin_str = "+" + GameData.chest_struct.attacked_gold ;
					GameData.chest_HUDText_control.GetComponent<HUDText> ().Add (get_coin_str, Color.yellow, -0.8f);

					// Add touch coin to total_coin and update total coin label
					GameData.coin_struct.total = GameData.coin_struct.total + GameData.chest_struct.attacked_gold;
					GameData.coin_tatal_label.GetComponent<UILabel> ().text = GameData.coin_struct.total.ToString ();

					// if chest HP is under 0, reset chest HP.
					if (GameData.chest_struct._HP <= 0) 
					{
						// 보물상자 false시키고 , open된 보물상자 enable
						GameData.chest_sprite.SetActive (false);
						opened_chest_box.enable_disable_chest_open = true;

						opened_chest_box.target_time = Time.time + 5.0f;
						GameData.chest_struct._HP = GameData.chest_struct.HP;
						GameData.chest_sprite.GetComponent<UIProgressBar> ().value = GameData.chest_struct._HP;

						GameData.chest_opened_sprite.SetActive (true);
					}
				}
				else if (hit.collider != null) 		// opened chest is enable.
				{
					// only touched in the collision area //

					// slash sprite enable
					GameData.slash_animation.GetComponent<Animator> ().SetTrigger ("enable");
					GameData.slash_animation.GetComponent<SpriteRenderer> ().enabled = true;

					// (Fever TIME) X2 Add touch coin to total_coin and update total coin label
					GameData.coin_struct.total = GameData.coin_struct.total + (GameData.chest_struct.attacked_gold*2);
					GameData.coin_tatal_label.GetComponent<UILabel> ().text = GameData.coin_struct.total.ToString ();

					// Test HUDText;;;;
					string get_coin_str = "+" + (GameData.chest_struct.attacked_gold*2) ;
					GameData.chest_HUDText_control.GetComponent<HUDText> ().Add (get_coin_str, Color.yellow, -0.8f);

				}
			}
		}
	}
}
