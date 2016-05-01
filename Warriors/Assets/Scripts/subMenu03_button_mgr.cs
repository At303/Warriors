using UnityEngine;
using System.Collections;
using gamedata_weapon;
using gamedata;

public class subMenu03_button_mgr : MonoBehaviour {

   // ************************************************************************  Weapon Functions ************************************************************************ //

	/// Weapon 레벨 업 버튼 클릭시 호출 함수. ( 버튼 클릭시 index 값을 paramater로 가져와서 해당 weapon구조체 list에 update )
    public void Clicked_weapon_Level_UP(int weapon_index)
	{
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - GameData_weapon.weapon_struct_object[weapon_index].upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel> ().text = GameData.int_to_label_format(GameData.coin_struct.gold);

        // 가져온 weapon index를 가지고 해당 weapon 구조체 리스트에 upgrade.
        GameData_weapon.levelup_weapon_data_struct(weapon_index);

        // update chest label
        GameData_weapon.update_weapon_data_label(weapon_index);

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_all_function_when_gold_changed();

	}

    /// Weapon 캐릭터 선택 창 클릭시 호출 함수.
    public void Clicked_weapon_select_NPC(string weapon_type, int weapon_index, int _equip_weapon_index)
    {
        // 바꿀 Weapon 정보 저장.
        GameData.to_change_npc_struct.To_Change_Weapon_type = weapon_type;
        GameData.to_change_npc_struct.weapon_index = weapon_index;

        print(" Clicked_weapon_select_NPC : "+weapon_type.ToString() + weapon_index.ToString());
        
		// 어떤 무기를 사용할 지 index Save.
		popup_window_button_mgr.equip_weapon_index = _equip_weapon_index;

        // NPC 선택 창 Popup Open.
        GameData.weapon_sel_popup_window_obj.SetActive(true);

    }


    // ************************************************************************  Clothes Functions ************************************************************************ //


    /// Function Name은 Level Up이지만, 이 함수는 게이머가 해당 Armor Pay 버튼을 클릭했을때 Call하는 함수.
	public void Clicked_Armor_Level_UP(int armor_index)
	{
		// pay the cost about chest level up
		GameData.coin_struct.gemstone = GameData.coin_struct.gemstone - GameData_weapon.armor_struct_object[armor_index].upgrade_cost;
		GameData.gemstone_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format(GameData.coin_struct.gemstone);

		// UI로부터 가져온 Armor_index를 가져오고, 해당 index Armor enable.
		GameData_weapon.Armor_enable(armor_index);
        print("Armor index : " + armor_index.ToString());

        // 해당 Armor enable 되도록 Local에 저장. ( 0 : false, 1 : true)
        PlayerPrefs.SetInt("armor_" + armor_index.ToString() + "_enable", 1);
        PlayerPrefs.Save();

        // 어떤 무기를 사용할 지 index Save.
        popup_window_button_mgr.equip_armor_index = armor_index;

        // Armor는 보석이므로 보석 check하는 함수 중에서도 armor메뉴가 활성화 상태이므로 armor만 check.
        GameData_weapon.check_armor_buttons_is_enable_or_not();

    }

    /// Clothes 캐릭터 선택 창 클릭시 호출 함수.
    public void Clicked_Armor_select_NPC(string armor_type, int armor_index, int armor_color)
    {

        // 바꿀 Clothes 정보 저장.
        GameData.to_change_npc_struct.To_Change_Armor_type = armor_type;
        GameData.to_change_npc_struct.armor_index = armor_index;
        GameData.to_change_npc_struct.armor_color = armor_color;

        // NPC 선택 창 Popup Open.
        GameData.clothes_sel_popup_window_obj.SetActive(true);
    }
    // ************************************************************************  bow Functions ************************************************************************ //

    public void Clicked_bow_Level_UP(int bow_index)
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - GameData_weapon.bow_struct_object[bow_index].upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format(GameData.coin_struct.gold);

        // ui 에서 가져온 weapon index를 가지고 해당 weapon 구조체 리스트에 upgrade.
        GameData_weapon.levelup_bow_data_struct(bow_index);

        // update chest label
        GameData_weapon.update_bow_data_label(bow_index);

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
        GM.check_all_function_when_gold_changed();

    }

    // Bow 캐릭터 선택 창 클릭시 호출 함수.
    public void Clicked_bow_select_NPC(int bow_index, int _equip_weapon_index)
    {

        // 버튼 클릭에 맞는 bow index를 가져오고 해당 index로 캐릭터 update.
        // 바꿀 Bow 정보 저장.
        GameData.to_change_npc_struct.To_Change_bow_type = "bow-a";
        GameData.to_change_npc_struct.bow_index = bow_index;

        // 어떤 무기를 사용할 지 index Save.
        popup_window_button_mgr.equip_weapon_index = _equip_weapon_index;

        // NPC 선택 창 Popup Open.
        GameData.bow_sel_popup_window_obj.SetActive(true);
    }

    // ************************************************************************  Wing Functions ************************************************************************ //

    /// Function Name은 Level Up이지만, 이 함수는 게이머가 해당 wing Pay 버튼을 클릭했을때 Call하는 함수.
    public void Clicked_wing_Level_UP(int wing_index)
    {
        // pay the cost about chest level up
        GameData.coin_struct.gemstone = GameData.coin_struct.gemstone - GameData_weapon.wing_struct_object[wing_index].upgrade_cost;
		GameData.gemstone_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format(GameData.coin_struct.gemstone);

		// UI로부터 가져온 Armor_index를 가져오고, 해당 index Armor enable.
		GameData_weapon.Wing_enable(wing_index);

        // 해당 wing enable 되도록 Local에 저장. ( 0 : false, 1 : true)
        PlayerPrefs.SetInt("wing_" + wing_index.ToString() + "_enable", 1);
        PlayerPrefs.Save();

        // 어떤 무기를 사용할 지 index Save.
        popup_window_button_mgr.equip_wing_index = wing_index;

        // Wing은 보석이므로 보석 check하는 함수 중에서도 wing메뉴가 활성화 상태이므로 wing만 check.
        GameData_weapon.check_wing_buttons_is_enable_or_not();

    }



    // wing 캐릭터 선택 창 클릭시 호출 함수.
    public void Clicked_wing_select_NPC(string wing_type, int wing_index)
	{

		// 버튼 클릭에 맞는 bow index를 가져오고 해당 index로 캐릭터 update.
		// 바꿀 Bow 정보 저장.
		GameData.to_change_npc_struct.To_Change_wing_type = wing_type;
		GameData.to_change_npc_struct.wing_index = wing_index;

        // NPC 선택 창 Popup Open.
        GameData.wing_sel_popup_window_obj.SetActive(true);
	}


}
