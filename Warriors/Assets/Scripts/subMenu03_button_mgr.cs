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
		GameData.levelup_slash1_data_struct();

		// update chest label
		GameData.update_slash1_data_label();

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GameData.check_lvup_button_is_enable_or_not();

	}

    // Weapon01 캐릭터 선택 창 클릭시 호출 함수.
    public void Clicked_weapon01_select_NPC()
    {
        // NPC 선택 창 Popup 닫기.
        GameData.weapon_sel_popup_window_obj.SetActive(true);

        // 바꿀 Weapon 정보 저장.
        GameData.to_change_weapon_struct.To_Change_Weapon_Name = "dagger-a";
        GameData.to_change_weapon_struct.weapon_index = 0;
    }

}
