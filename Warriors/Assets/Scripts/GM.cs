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
			print("slash : " + slash_animation_name);

			//If something was hit, the RaycastHit2D.collider will not be null.
			if (hit.collider != null && !(opened_chest_box.enable_disable_chest_open)) 
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
		}
	}


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

				// Random slash animation
				string slash_animation_name = "slash" + Random.Range(1,3).ToString();
				GameData.slash_animation = GameObject.Find (slash_animation_name);

				//If touch screen is on the fixed range, excute the code.
				if (hit.collider != null) 
				{
					// slash sprite enable
					GameData.slash_animation.GetComponent<Animator>().SetTrigger("enable");
					GameData.slash_animation.GetComponent<SpriteRenderer> ().enabled = true;

					// chest sprite animation enable
					GameData.chest_sprite.GetComponent<Animator>().SetTrigger("enable");

				}
			}
		}
	}
}
