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

	// Weapon01 레벨 업 버튼 클릭시 호출 함수.
	public void Clicked_weapon01_Level_UP()
	{
		

		// pay the cost about chest level up
		GameData.coin_struct.gold = GameData.coin_struct.gold - GameData_weapon.Weapon01_struct.upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel> ().text = GameData.coin_struct.gold.ToString ();


        // update chest_struct data
        GameData_weapon.levelup_weapon01_data_struct();

        // update chest label
        GameData_weapon.update_weapon01_data_label();

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();

	}

    // Weapon01 캐릭터 선택 창 클릭시 호출 함수.
    public void Clicked_weapon01_select_NPC()
    {
        // NPC 선택 창 Popup Open.
        GameData.weapon_sel_popup_window_obj.SetActive(true);

        // 바꿀 Weapon 정보 저장.
        GameData.to_change_npc_struct.To_Change_Weapon_type = "dagger-a";
        GameData.to_change_npc_struct.weapon_index = 0;
    }

    // Weapon02 캐릭터 선택 창 클릭시 호출 함수.
    public void Clicked_weapon02_select_NPC()
    {
        // NPC 선택 창 Popup Open.
        GameData.weapon_sel_popup_window_obj.SetActive(true);

        // 바꿀 Weapon 정보 저장.
        GameData.to_change_npc_struct.To_Change_Weapon_type = "dagger-a";
        GameData.to_change_npc_struct.weapon_index = 1;
    }




    // ************************************************************************  Clothes Functions ************************************************************************ //



    // Clothes01 캐릭터 선택 창 클릭시 호출 함수.
    public void Clicked_clothes01_select_NPC()
    {
        // NPC 선택 창 Popup Open.
        GameData.clothes_sel_popup_window_obj.SetActive(true);

        // 바꿀 Weapon 정보 저장.
        GameData.to_change_npc_struct.To_Change_Armor_type = "steel-a";
        GameData.to_change_npc_struct.armor_index = 0;
        GameData.to_change_npc_struct.armor_color = 0;

    }
    
}
