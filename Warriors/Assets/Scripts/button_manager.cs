﻿using UnityEngine;
using gamedata;
using gamedata_weapon;

public class button_manager : MonoBehaviour {

    // Setting 버튼 클릭 시 true , 다시 클릭 시 false.
    bool setting_popup_enable_or_not = false;

	// Use this for initialization
	void Start () {
		
    }
	
	// Update is called once per frame
	void Update () {
	
	}


	// 보물상자 Level UP Button클릭 시 호출 함수. 
	public void Clicked_Chest_Level_UP()
	{
		// 현재 가지고 있는 골드에서 보물상자 upgrade cost만큼 빼주고 Gold Label에 update.
		GameData.coin_struct.gold = GameData.coin_struct.gold - GameData.chest_struct.upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel> ().text = GameData.coin_struct.gold.ToString ();

        // 보물상자 레벨 1 증가 시키고 해당 값으로 보물상자 구조체에 Data Setting.
        GameData.chest_struct.Level++;
        GameData.levelup_chest_data_struct(GameData.chest_struct.Level);

        // 보물상자 레벨 1 증가 시킨 값을 Local Data에 저장.
        PlayerPrefs.SetInt("chest_level", GameData.chest_struct.Level);
        PlayerPrefs.Save();

		// Update된 보물상자 데이터를 보물상자 Label에 모두 Update.
		GameData.update_chest_data_label();

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();


	}

	//slash1 레벨 업 버튼 클릭시 호출 함수
	public void Clicked_slash_Level_UP(int _slash_index)
	{
        // 현재 가지고 있는 골드에서 slash upgrade cost만큼 빼주고 Gold Label에 update.
        GameData.coin_struct.gold = GameData.coin_struct.gold - GameData.slash_struct_object[_slash_index].upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel> ().text = GameData.int_to_label_format (GameData.coin_struct.gold);

        // slash 레벨 1 증가 시키고 해당 값으로 slash 구조체에 Data Setting.
        GameData.slash_struct_object[_slash_index].Level++;
        GameData.slash_data_struct_levelup(_slash_index , GameData.slash_struct_object[_slash_index].Level);

        // slash 레벨 1 증가 시킨 값을 Local Data에 저장.
        string To_levelup_slash = "slash"+ _slash_index.ToString() + "_level";
        PlayerPrefs.SetInt(To_levelup_slash, GameData.slash_struct_object[_slash_index].Level);
        PlayerPrefs.Save();

        // Update된 slash 데이터를 slash Label에 모두 Update.
        GameData.update_slash_data_label(_slash_index);

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();      

    }

	public void Clicked_boss_scene()
	{
        // 터치 클릭 영역을 boss menu만큼 감소 시킴.
        GameObject.Find("Touch_Area").GetComponent<BoxCollider2D>().size = new Vector2(1085f, 890f);
        GameObject.Find("Touch_Area").transform.position = new Vector2(0, -0.2f);


        // 처음 게임 시작시 check button 함수를 부르지 않고 popup되었을때만 call하기 위한 변수.
        select_boss_popup.check_popup_window = true;
        // Boss 선택 창 Popup Open.
        GameData.boss_sel_popup_window_obj.SetActive(true);
        //SceneManager.LoadScene ("warriors_boss");

    }

    public void Clicked_AdsPlay_button()
    {
        // 유니티 광고를 불러오기 위한 코드.
        unity_ads unityADs = unity_ads.ads_object.GetComponent<unity_ads>();
        unityADs.ShowRewardedAd();
        print("get the coin!@!@!@!@");



    }

    public void Clicked_Ads_button()
    {
        // 유니티 광고를 불러오기 위한 코드.
        //unity_ads unityADs = unity_ads.ads_object.GetComponent<unity_ads>();
        //unityADs.ShowRewardedAd();
        GameData.Ads_popup_window.SetActive(true);
        GameData.ads_icon_clicked.SetActive(true);

        // TEMP CODE>>>>>>
        PlayerPrefs.DeleteAll();
    }
    public void Clicked_Ads_window_close_button()
    {
        // 유니티 광고를 불러오기 위한 코드.
        //unity_ads unityADs = unity_ads.ads_object.GetComponent<unity_ads>();
        //unityADs.ShowRewardedAd();
        GameData.Ads_popup_window.SetActive(false);
        GameData.ads_icon_clicked.SetActive(false);

    }
    public void Clicked_sound_on_off()
    {

        GameData.sound_on_off = !GameData.sound_on_off;
        if (GameData.sound_on_off)
        {
            PlayerPrefs.SetString("sound_on_off","ON");
            PlayerPrefs.Save();
            GameData.sound_on_object.SetActive(true);
            GameData.sound_off_object.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetString("sound_on_off", "OFF");
            PlayerPrefs.Save();
            GameData.sound_on_object.SetActive(false);
            GameData.sound_off_object.SetActive(true);
        }
    }

    public void Clicked_quit_yes_button()
    {
        Application.Quit();
    }
    public void Clicked_quit_no_button()
    {
        GameData.quit_popup_window.SetActive(false);
    }

 public void toggle1_changed()
    {
        {
            GameData.menu1_clicked = true;
            GameData.menu2_clicked = false;
            GameData.menu3_clicked = false;
            GameData.menu4_clicked = false;
            GameData.menu5_clicked = false;
            GameData.menu6_clicked = false;
        }

        // NPC 선택 창 Popup Close.
    }
    
     public void toggle2_changed()
    {
        {
            GameData.menu1_clicked = false;
            GameData.menu2_clicked = true;
            GameData.menu3_clicked = false;
            GameData.menu4_clicked = false;
            GameData.menu5_clicked = false;
            GameData.menu6_clicked = false;
        }

    }
    
     public void toggle3_changed()
    {
        {
            GameData.menu1_clicked = false;
            GameData.menu2_clicked = false;
            GameData.menu3_clicked = true;
            GameData.menu4_clicked = false;
            GameData.menu5_clicked = false;
            GameData.menu6_clicked = false;
        }

        GameData_weapon.check_weapon_buttons_is_enable_or_not();

        GameData.weapon_sel_popup_window_obj.SetActive(false);
    }

    public void toggle4_changed()
    {
        {
            GameData.menu1_clicked = false;
            GameData.menu2_clicked = false;
            GameData.menu3_clicked = false;
            GameData.menu4_clicked = true;
            GameData.menu5_clicked = false;
            GameData.menu6_clicked = false;
        }
        // armor 메뉴가 open되어 있으므로 보석량과 gemstone을 비교하여 enable할지 말지 결정.
        GameData_weapon.check_armor_buttons_is_enable_or_not();

        // NPC 선택 창 Popup Close.
        GameData.clothes_sel_popup_window_obj.SetActive(false);
    }

	public void toggle5_changed()
	{
        {
            GameData.menu1_clicked = false;
            GameData.menu2_clicked = false;
            GameData.menu3_clicked = false;
            GameData.menu4_clicked = false;
            GameData.menu5_clicked = true;
            GameData.menu6_clicked = false;
        }
        // NPC 선택 창 Popup Close.
        GameData.bow_sel_popup_window_obj.SetActive(false);
	}
	public void toggle6_changed()
	{
        {
            GameData.menu1_clicked = false;
            GameData.menu2_clicked = false;
            GameData.menu3_clicked = false;
            GameData.menu4_clicked = false;
            GameData.menu5_clicked = false;
            GameData.menu6_clicked = true;
        }
        // wing 메뉴가 open되어 있으므로 보석량과 gemstone을 비교하여 enable할지 말지 결정.
        GameData_weapon.check_wing_buttons_is_enable_or_not();

        // NPC 선택 창 Popup Close.
        GameData.wing_sel_popup_window_obj.SetActive(false);
	}

}
