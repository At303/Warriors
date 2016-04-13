using UnityEngine;
using System.Collections;
using gamedata;
using UnityEngine.SceneManagement;
using System;
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
	public void Clicked_slash1_Level_UP()
	{
        // 현재 가지고 있는 골드에서 slash1 upgrade cost만큼 빼주고 Gold Label에 update.
        GameData.coin_struct.gold = GameData.coin_struct.gold - GameData.slash1_struct.upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel> ().text = GameData.int_to_label_format (GameData.coin_struct.gold);

        // slash1 레벨 1 증가 시키고 해당 값으로 slash 구조체에 Data Setting.
        GameData.slash1_struct.Level++;
        GameData.slash1_data_struct_levelup(GameData.slash1_struct.Level);

        // slash1 레벨 1 증가 시킨 값을 Local Data에 저장.
        PlayerPrefs.SetInt("slash1_level", GameData.slash1_struct.Level);
        PlayerPrefs.Save();

        // Update된 slash1 데이터를 slash1 Label에 모두 Update.
        GameData.update_slash1_data_label();

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();

           

    }

	//slash2 레벨 업 버튼 클릭시 호출 함수
	public void Clicked_slash2_Level_UP()
	{
		// pay the cost about chest level up
		GameData.coin_struct.gold = GameData.coin_struct.gold - GameData.slash2_struct.upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel> ().text = GameData.int_to_label_format (GameData.coin_struct.gold);


        // slash2 레벨 1 증가 시키고 해당 값으로 slash 구조체에 Data Setting.
        GameData.slash2_struct.Level++;
        GameData.slash2_data_struct_levelup(GameData.slash2_struct.Level);

        // slash2 레벨 1 증가 시킨 값을 Local Data에 저장.
        PlayerPrefs.SetInt("slash2_level", GameData.slash2_struct.Level);
        PlayerPrefs.Save();

        // update chest label
        GameData.update_slash2_data_label();

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();

       

    }

	//slash3 레벨 업 버튼 클릭시 호출 함수
	public void Clicked_slash3_Level_UP()
	{
		// pay the cost about chest level up
		GameData.coin_struct.gold = GameData.coin_struct.gold - GameData.slash3_struct.upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel> ().text = GameData.int_to_label_format (GameData.coin_struct.gold);

        // slash3 레벨 1 증가 시키고 해당 값으로 slash 구조체에 Data Setting.
        GameData.slash3_struct.Level++;
        GameData.slash2_data_struct_levelup(GameData.slash3_struct.Level);

        // slash3 레벨 1 증가 시킨 값을 Local Data에 저장.
        PlayerPrefs.SetInt("slash3_level", GameData.slash3_struct.Level);
        PlayerPrefs.Save();

        // update chest label
        GameData.update_slash3_data_label();

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();

	}

	//slash4 레벨 업 버튼 클릭시 호출 함수
	public void Clicked_slash4_Level_UP()
	{
		// pay the cost about chest level up
		GameData.coin_struct.gold = GameData.coin_struct.gold - GameData.slash4_struct.upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel> ().text = GameData.int_to_label_format (GameData.coin_struct.gold);

        // slash4 레벨 1 증가 시키고 해당 값으로 slash 구조체에 Data Setting.
        GameData.slash4_struct.Level++;
        GameData.slash4_data_struct_update(GameData.slash4_struct.Level);

        // slash4 레벨 1 증가 시킨 값을 Local Data에 저장.
        PlayerPrefs.SetInt("slash4_level", GameData.slash4_struct.Level);
        PlayerPrefs.Save();

        // update chest label
        GameData.update_slash4_data_label();

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();

	}

	//slash5 레벨 업 버튼 클릭시 호출 함수
	public void Clicked_slash5_Level_UP()
	{
		// pay the cost about chest level up
		GameData.coin_struct.gold = GameData.coin_struct.gold - GameData.slash5_struct.upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel> ().text = GameData.int_to_label_format (GameData.coin_struct.gold);

        // slash5 레벨 1 증가 시키고 해당 값으로 slash 구조체에 Data Setting.
        GameData.slash5_struct.Level++;
        GameData.slash5_data_struct_update(GameData.slash5_struct.Level);

        // slash5 레벨 1 증가 시킨 값을 Local Data에 저장.
        PlayerPrefs.SetInt("slash5_level", GameData.slash5_struct.Level);
        PlayerPrefs.Save();

        // update chest label
        GameData.update_slash5_data_label();

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

    public void Clicked_setting_button()
    {
         PlayerPrefs.DeleteAll();

        // Setting popup window 띄워줌.
        setting_popup_enable_or_not = !setting_popup_enable_or_not;
        GameData.setting_popup_window_obj.SetActive(setting_popup_enable_or_not);
        if(setting_popup_enable_or_not)
        {
            // 터치 클릭 영역을 boss menu만큼 감소 시킴.
            GameObject.Find("Touch_Area").GetComponent<BoxCollider2D>().size = new Vector2(1085f, 1100f);
            //GameObject.Find("Touch_Area").transform.position = new Vector2(0, 0);
        }else
        {
            // 터치 클릭 영역을 원상태로 복귀 시킴.
            GameObject.Find("Touch_Area").GetComponent<BoxCollider2D>().size = new Vector2(1085f, 1280f);
            //GameObject.Find("Touch_Area").transform.position = new Vector2(0, 0);
        }

    }

    public void toggle3_changed()
    {
        print("toggle3_open");
        // NPC 선택 창 Popup Close.
        GameData.weapon_sel_popup_window_obj.SetActive(false);
    }

    public void toggle4_changed()
    {
        print("toggle4_open");
        // armor 메뉴가 open되어 있으므로 보석량과 gemstone을 비교하여 enable할지 말지 결정.
        GameData_weapon.check_armor_buttons_is_enable_or_not();

        // NPC 선택 창 Popup Close.
        GameData.clothes_sel_popup_window_obj.SetActive(false);
    }

	public void toggle5_changed()
	{
        print("toggle5_open");

        // NPC 선택 창 Popup Close.
        GameData.bow_sel_popup_window_obj.SetActive(false);
	}
	public void toggle6_changed()
	{
        print("toggle6_open");
        // wing 메뉴가 open되어 있으므로 보석량과 gemstone을 비교하여 enable할지 말지 결정.
        GameData_weapon.check_wing_buttons_is_enable_or_not();

        // NPC 선택 창 Popup Close.
        GameData.wing_sel_popup_window_obj.SetActive(false);
	}

}
