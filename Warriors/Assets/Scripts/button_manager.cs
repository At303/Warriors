using UnityEngine;
using System.Collections;
using gamedata;
using UnityEngine.SceneManagement;

public class button_manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
    }
	
	// Update is called once per frame
	void Update () {
	
	}


	// 보물상자 Level UP Button클릭 시 호출 함수. 
	public void Clicked_Chest_Level_UP()
	{
		// pay the cost about chest level up
		GameData.coin_struct.gold = GameData.coin_struct.gold - GameData.chest_struct.upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel> ().text = GameData.coin_struct.gold.ToString ();

		// levelup chest_struct data
		GameData.levelup_chest_data_struct();

		// update chest label
		GameData.update_chest_data_label();

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();


	}

	//slash1 레벨 업 버튼 클릭시 호출 함수
	public void Clicked_slash1_Level_UP()
	{
		// pay the cost about chest level up
		GameData.coin_struct.gold = GameData.coin_struct.gold - GameData.slash1_struct.upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel> ().text = GameData.int_to_label_format (GameData.coin_struct.gold);

		// update chest_struct data
		GameData.levelup_slash1_data_struct();

		// update chest label
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

		// update chest_struct data
		GameData.levelup_slash2_data_struct();

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

		// update chest_struct data
		GameData.levelup_slash3_data_struct();

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

		// update chest_struct data
		GameData.levelup_slash4_data_struct();

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

		// update chest_struct data
		GameData.levelup_slash5_data_struct();

		// update chest label
		GameData.update_slash5_data_label();

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();

	}
	public void Clicked_boss_scene()
	{
       
        SceneManager.LoadScene ("warriors_boss");

    }

    public void toggle3_changed()
    {
        // NPC 선택 창 Popup Close.
        GameData.weapon_sel_popup_window_obj.SetActive(false);
    }

    public void toggle4_changed()
    {
        // NPC 선택 창 Popup Close.
        GameData.clothes_sel_popup_window_obj.SetActive(false);
    }

	public void toggle5_changed()
	{
		// NPC 선택 창 Popup Close.
		GameData.bow_sel_popup_window_obj.SetActive(false);
	}
	public void toggle6_changed()
	{
		// NPC 선택 창 Popup Close.
		GameData.wing_sel_popup_window_obj.SetActive(false);
	}

}
