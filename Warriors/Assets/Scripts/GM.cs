using UnityEngine;
using System.Collections;
using gamedata;
using gamedata_weapon;

public class GM : MonoBehaviour {


	// Get a gap of two touch
	float before_touch = 0.0f;
	float current_touch = 0.0f;
	float touch_deltatime = 0.0f;
	int slash_index = 1;
	// Use this for initialization
	void Start () {

	}


	// Update is called once per frame
	void Update () 
	{
        if (Input.GetMouseButtonDown(0))
        {
            {

                //Get the mouse position on the screen and send a raycast into the game world from that position.
                Vector2 worldPoint = UICamera.mainCamera.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
                               
                //If touch is on the fixed range, excute the code.
                if (hit.collider != null && !(opened_chest_box.enable_disable_chest_open))
                {
                    // Test HUDText;;;;
                    string get_coin_str = "+" + GameData.chest_struct.attacked_gold + "g";
                    GameData.chest_HUDText_control.GetComponent<HUDText>().Add(get_coin_str, Color.yellow, -0.8f);

                    // Add touch coin to total_coin and update total coin label
					GameData.coin_struct.gold = GameData.coin_struct.gold + GameData.chest_struct.attacked_gold;
					GameData.gold_total_label.GetComponent<UILabel>().text = GameData.coin_struct.gold.ToString();

                    // if chest HP is under 0, reset chest HP.
                    if (GameData.chest_struct._HP <= 0)
                    {
						print ("open chest");
                        // 보물상자 false시키고 , open된 보물상자 enable
                        GameData.chest_sprite.SetActive(false);
                        opened_chest_box.enable_disable_chest_open = true;

                        opened_chest_box.target_time = Time.time + 5.0f;
                        GameData.chest_struct._HP = GameData.chest_struct.HP;
                        GameData.chest_sprite.GetComponent<UIProgressBar>().value = GameData.chest_struct._HP;

                        GameData.chest_opened_sprite.SetActive(true);
                    }
                    else
                    {
                        // Random touch slash animation
                        int slash_index = Random.Range(1, GameData.number_of_slash);
                        string slash_animation_name = "slash" + slash_index.ToString();
                        GameData.slash_animation = GameObject.Find(slash_animation_name);

                        // slash sprite enable
                        GameData.slash_animation.GetComponent<Animator>().SetTrigger("enable");
                        GameData.slash_animation.GetComponent<SpriteRenderer>().enabled = true;

                        // Chest box HP modify
                        float fHP;
                        switch ((SLASH_TYPE)slash_index)
                        {
                            case SLASH_TYPE.SLASH1:
                                //print("slash1");
                                //print(GameData.slash1_struct.damage + "-> GameData.slash1_struct.damage");
                                GameData.chest_struct._HP = GameData.chest_struct._HP - GameData.slash1_struct.damage;
                                fHP = GameData.chest_struct._HP / GameData.chest_struct.HP;
                                GameData.chest_sprite.GetComponent<UIProgressBar>().value = fHP;
                                break;
                            case SLASH_TYPE.SLASH2:
                                // print("slash2");
                                // print(GameData.slash2_struct.damage+ "-> GameData.slash2_struct.damage");
                                GameData.chest_struct._HP = GameData.chest_struct._HP - GameData.slash2_struct.damage;
                                fHP = GameData.chest_struct._HP / GameData.chest_struct.HP;
                                GameData.chest_sprite.GetComponent<UIProgressBar>().value = fHP;
                                break;
                        }
                        
                    }
                    // check upgrade buttons들을 활성화 할 지말지 .
                    check_all_function_when_gold_changed();                          


                }
				// opened chest is enable.
                else if (hit.collider != null)      
                {
                    // only touched in the collision area //

					// Gemstone HUDText;;;;
					string get_coin_str = "+" + GameData.chest_struct.attacked_gemstone + "G";
					GameData.chest_HUDText_control.GetComponent<HUDText>().Add(get_coin_str, Color.red, -0.8f);

                    // slash sprite enable
                    GameData.slash_animation.GetComponent<Animator>().SetTrigger("enable");
                    GameData.slash_animation.GetComponent<SpriteRenderer>().enabled = true;

                    // (Fever TIME) X2 Add touch coin to total_coin and update total coin label
					GameData.coin_struct.gemstone = GameData.coin_struct.gemstone + GameData.chest_struct.attacked_gemstone;
					GameData.gemstone_total_label.GetComponent<UILabel>().text = GameData.coin_struct.gemstone.ToString();

                    // check upgrade buttons들을 활성화 할 지말지 .
                    check_all_function_when_gold_changed();
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

				// Random touch slash animation
				//int slash_index = Random.Range(1,GameData.number_of_slash);
				if (slash_index == GameData.number_of_slash) 
				{
					slash_index = 1;
				}
				string slash_animation_name = "slash" + slash_index.ToString ();
				GameData.slash_animation = GameObject.Find (slash_animation_name);
				slash_index++;

				//If touch is on the fixed range, excute the code.
				if (hit.collider != null  && !(opened_chest_box.enable_disable_chest_open)) 
				{
					
					// slash sprite enable
					GameData.slash_animation.GetComponent<Animator>().SetTrigger("enable");
					GameData.slash_animation.GetComponent<SpriteRenderer> ().enabled = true;

					// Test HUDText;;;;
					string get_coin_str = "+" + GameData.chest_struct.attacked_gold + "g" ;
					GameData.chest_HUDText_control.GetComponent<HUDText> ().Add (get_coin_str, Color.yellow, -0.8f);

					// Add touch coin to total_coin and update total coin label
					GameData.coin_struct.gold = GameData.coin_struct.gold + GameData.chest_struct.attacked_gold;
					GameData.gold_total_label.GetComponent<UILabel> ().text = GameData.coin_struct.gold.ToString ();

					// if chest HP is under 0, reset chest HP.
					if (GameData.chest_struct._HP <= 0) {
						
						//마지막 chest animatino은 opened_chest_sprite이후 상자 크기가 변하는 bug를 방지하기 위해 animation event로 처리
						//if (animation_evt_manager.enable_chest_animation) 
						GameData.chest_sprite.GetComponent<Animator> ().SetTrigger ("end_enable");

					} else 
					{
						// Chest box HP modify
						GameData.chest_struct._HP = GameData.chest_struct._HP - GameData.slash1_struct.damage;
						float fHP = GameData.chest_struct._HP / GameData.chest_struct.HP;
						GameData.chest_sprite.GetComponent<UIProgressBar> ().value = fHP;

						// touch 사이의 차이에 따라서 상자 animation speed control.
						before_touch = current_touch; 
						current_touch = Time.time;
						touch_deltatime = current_touch - before_touch;
						//GameData.debug_label2.GetComponent<UILabel> ().text = touch_deltatime.ToString ();

						//coin box attack animation 
						if (touch_deltatime < 0.17) {
							GameData.chest_sprite.GetComponent<Animator> ().SetFloat ("speed", touch_deltatime);
						} else {
							GameData.chest_sprite.GetComponent<Animator> ().SetFloat ("speed", touch_deltatime);
						}

						// chest sprite animation enable
						if (animation_evt_manager.enable_chest_animation) 
						{
							GameData.chest_sprite.GetComponent<Animator> ().SetTrigger ("enable");
						} else 
						{
						}
		
					}
                    // check upgrade buttons들을 활성화 할 지말지 .
                    check_all_function_when_gold_changed();

				}
				else if (hit.collider != null) 		// opened chest is enable.
				{
					// only touched in the collision area //

					// Gemstone HUDText;;;;
					string get_coin_str = "+" + GameData.chest_struct.attacked_gemstone + "G";
					GameData.chest_HUDText_control.GetComponent<HUDText>().Add(get_coin_str, Color.red, -0.8f);

					// slash sprite enable
					GameData.slash_animation.GetComponent<Animator>().SetTrigger("enable");
					GameData.slash_animation.GetComponent<SpriteRenderer>().enabled = true;

					// (Fever TIME) X2 Add touch coin to total_coin and update total coin label
					GameData.coin_struct.gemstone = GameData.coin_struct.gemstone + GameData.chest_struct.attacked_gemstone;
					GameData.gemstone_total_label.GetComponent<UILabel>().text = GameData.coin_struct.gemstone.ToString();

                    // check upgrade buttons들을 활성화 할 지말지 .
                    check_all_function_when_gold_changed();
				}
			}
		}
	}



	// 골드획득량 변경시 check해야할 모든 함수 불르기
	public static void check_all_function_when_gold_changed()
	{
		// check upgrade buttons들을 활성화 할 지말지 .
		GameData.check_lvup_button_is_enable_or_not ();                  // check slash && npc
        //GameData_weapon.check_weapon_buttons_is_enable_or_not();         // check weapon 

    }
    // 보석획득량 변경시 check해야할 모든 함수 불르기
    public static void check_all_function_when_gems_changed()
    {
       
    }


}
