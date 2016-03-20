using UnityEngine;
using System.Collections;
using gamedata_weapon;
using gamedata;

public class subMenu03_button_mgr : MonoBehaviour {



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// ************************************************************************  Weapon Functions ************************************************************************ //

	// Weapon01 레벨 업 버튼 클릭시 호출 함수.
	public void Clicked_weapon01_Level_UP()
	{
		

		// pay the cost about chest level up
		//GameData.coin_struct.gold = GameData.coin_struct.gold - GameData_weapon.Weapon01_struct.upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel> ().text = GameData.coin_struct.gold.ToString ();


        // update chest_struct data
        GameData_weapon.levelup_weapon01_data_struct();

        // update chest label
        GameData_weapon.update_weapon01_data_label();

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();

	}

    // Weapon 캐릭터 선택 창 클릭시 호출 함수.
    public void Clicked_weapon_select_NPC(string weapon_type, int weapon_index)
    {
        // 바꿀 Weapon 정보 저장.
        GameData.to_change_npc_struct.To_Change_Weapon_type = weapon_type;
        GameData.to_change_npc_struct.weapon_index = weapon_index;

        // NPC 선택 창 Popup Open.
        GameData.weapon_sel_popup_window_obj.SetActive(true);

    }


    // ************************************************************************  Clothes Functions ************************************************************************ //

    // Clothes 캐릭터 선택 창 클릭시 호출 함수.
    public void Clicked_clothes_select_NPC(string armor_type, int armor_index, int armor_color)
    {

        // 바꿀 Clothes 정보 저장.
        GameData.to_change_npc_struct.To_Change_Armor_type = armor_type;
        GameData.to_change_npc_struct.armor_index = armor_index;
        GameData.to_change_npc_struct.armor_color = armor_color;

        // NPC 선택 창 Popup Open.
        GameData.clothes_sel_popup_window_obj.SetActive(true);
    }
    // ************************************************************************  bow Functions ************************************************************************ //

    // Bow 캐릭터 선택 창 클릭시 호출 함수.
    public void Clicked_bow_select_NPC(int bow_index)
    {

        // 버튼 클릭에 맞는 bow index를 가져오고 해당 index로 캐릭터 update.
        // 바꿀 Bow 정보 저장.
        GameData.to_change_npc_struct.To_Change_bow_type = "bow-a";
        GameData.to_change_npc_struct.bow_index = bow_index;


        // NPC 선택 창 Popup Open.
        GameData.bow_sel_popup_window_obj.SetActive(true);
    }

	// ************************************************************************  Wing Functions ************************************************************************ //

	// wing 캐릭터 선택 창 클릭시 호출 함수.
	public void Clicked_wing_select_NPC(string wing_type, int wing_index)
	{

		// 버튼 클릭에 맞는 bow index를 가져오고 해당 index로 캐릭터 update.
		// 바꿀 Bow 정보 저장.
		GameData.to_change_npc_struct.To_Change_bow_type = wing_type;
		GameData.to_change_npc_struct.bow_index = wing_index;


		// NPC 선택 창 Popup Open.
		GameData.wing_sel_popup_window_obj.SetActive(true);
	}


}
