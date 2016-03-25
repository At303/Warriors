using UnityEngine;
using System.Collections;
using gamedata;
using gamedata_weapon;

public class popup_window_button_mgr : MonoBehaviour {

    // 캐릭터 Index enum 값.
    public enum NPC_INDEX
    {
        NONE,
        NPC01,
        NPC02,
        NPC03,
        NPC04,
        NPC05,
        NPC06,
        NPC07,
        NPC08,
        NPC09,
        NPC10,
        NPC11,
        NPC12,
    }
    
    public string weapon
    {
        get { return "weapon"; }
    }
    public string clothes
    {
        get { return "clothes"; }
    }
    public string bow
    {
        get { return "bow"; }
    }
	public string wing
	{
		get { return "wing"; }
	}

    public NPC_INDEX npc01
    {
        get { return NPC_INDEX.NPC01; }
    }
    public NPC_INDEX npc02
    {
        get { return NPC_INDEX.NPC02; }
    }
    public NPC_INDEX npc03
    {
        get { return NPC_INDEX.NPC03; }
    }
    public NPC_INDEX npc04
    {
        get { return NPC_INDEX.NPC04; }
    }
    public NPC_INDEX npc05
    {
        get { return NPC_INDEX.NPC05; }
    }
    public NPC_INDEX npc06
    {
        get { return NPC_INDEX.NPC06; }
    }
    public NPC_INDEX npc07
    {
        get { return NPC_INDEX.NPC07; }
    }
    public NPC_INDEX npc08
    {
        get { return NPC_INDEX.NPC08; }
    }
    public NPC_INDEX npc09
    {
        get { return NPC_INDEX.NPC09; }
    }
    public NPC_INDEX npc10
    {
        get { return NPC_INDEX.NPC10; }
    }
    public NPC_INDEX npc11
    {
        get { return NPC_INDEX.NPC11; }
    }
    public NPC_INDEX npc12
    {
        get { return NPC_INDEX.NPC12; }
    }



    // 무기 선택을 위한 캐릭터 창 Close시키는 함수.
    public void Close_NPC_Sel_weapon_popup_Window()
    {
        GameData.weapon_sel_popup_window_obj.SetActive(false);
    }
    // 옷 선택을 위한 캐릭터 창 Close시키는 함수.
    public void Close_NPC_Sel_clothes_popup_Window()
    {
        GameData.clothes_sel_popup_window_obj.SetActive(false);
    }
    // 활무기 선택을 위한 캐릭터 창 Close시키는 함수.
    public void Close_NPC_Sel_bow_popup_Window()
    {
        GameData.bow_sel_popup_window_obj.SetActive(false);
    }
	// 날개 선택을 위한 캐릭터 창 Close시키는 함수.
	public void Close_NPC_Sel_wing_popup_Window()
	{
		GameData.wing_sel_popup_window_obj.SetActive(false);
	}


    // 어떤 NPC를 선택했는지 처리하기 위한 함수.
    public void Select_NPC(NPC_INDEX npc_index,string type)
    {
        // type에 따라서 실행.
        switch (type)
        {
        case "weapon":
            weapon_to_selected_NPC(npc_index, GameData.to_change_npc_struct.To_Change_Weapon_type, GameData.to_change_npc_struct.weapon_index);
            break;
        case "clothes":
            clothes_to_selected_NPC(npc_index, GameData.to_change_npc_struct.To_Change_Armor_type, GameData.to_change_npc_struct.armor_index, GameData.to_change_npc_struct.armor_color);
            break;
        case "bow":
            bow_to_selected_NPC(npc_index, GameData.to_change_npc_struct.To_Change_bow_type, GameData.to_change_npc_struct.bow_index);
            break;
        case "wing":
            wing_to_selected_NPC(npc_index, GameData.to_change_npc_struct.To_Change_wing_type, GameData.to_change_npc_struct.wing_index);
            break;
        } 
    }
   
     // 해당 NPC에게 선택한 Weapon을 장착하게 하는 함수.
     void weapon_to_selected_NPC(NPC_INDEX _npc_index,string _weapon_name, int _weapon_index)
    {
        // npc0x에 따라서 실행.
        switch (_npc_index)
        {

            case NPC_INDEX.NPC01:
                // Change the NPC01 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                NPC01_make npc01 = NPC01_make.NPC01_struct.gameobject.GetComponent<NPC01_make>();

                // Change the NPC01 Weapon01 icon Sprite.
                // 무기 장착 메뉴에서 무기의 type과 index를 to_change 구조체에 미리 저장해두고 여기서 가져와서 해당 무기 장착 sprite로 바꿔줌.
                NPC01_make.NPC01_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC01_make.NPC01_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_Weapon_type + GameData.to_change_npc_struct.weapon_index.ToString();

                // NPC01 캐릭터 weapon 이미지 바꾸기.
                npc01.change_weapon(_weapon_index, _weapon_name);
                break;

            case NPC_INDEX.NPC02:
                // Change the NPC02 Character Sprite.
                NPC02_make npc02 = NPC02_make.NPC02_struct.gameobject.GetComponent<NPC02_make>();

                // Change the NPC02 Weapon01 icon Sprite.
                NPC02_make.NPC02_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC02_make.NPC02_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_Weapon_type + GameData.to_change_npc_struct.weapon_index.ToString();

                // NPC02 캐릭터 이미지 바꾸기.
                npc02.change_weapon(_weapon_index, _weapon_name);
                break;

            case NPC_INDEX.NPC03:
                // Change the NPC03 Character Sprite.
                NPC03_make npc03 = NPC03_make.NPC03_struct.gameobject.GetComponent<NPC03_make>();

                // Change the NPC03 Weapon icon Sprite.
                NPC03_make.NPC03_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC03_make.NPC03_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_Weapon_type + GameData.to_change_npc_struct.weapon_index.ToString();

                // NPC03 캐릭터 이미지 바꾸기.
                npc03.change_weapon(_weapon_index, _weapon_name);
                break;

            case NPC_INDEX.NPC07:
                // Change the NPC07 Character Sprite.
                NPC07_make npc07 = NPC07_make.NPC07_struct.gameobject.GetComponent<NPC07_make>();

                // Change the NPC03 Weapon icon Sprite.
                NPC07_make.NPC07_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC07_make.NPC07_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_Weapon_type + GameData.to_change_npc_struct.weapon_index.ToString();

                // NPC07 캐릭터 이미지 바꾸기.
                npc07.change_weapon(_weapon_index, _weapon_name);
                break;

            case NPC_INDEX.NPC08:
                // Change the NPC08 Character Sprite.
                NPC08_make npc08 = NPC08_make.NPC08_struct.gameobject.GetComponent<NPC08_make>();

                // Change the NPC08 Weapon icon Sprite.
                NPC08_make.NPC08_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC08_make.NPC08_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_Weapon_type + GameData.to_change_npc_struct.weapon_index.ToString();

                // NPC08 캐릭터 이미지 바꾸기.
                npc08.change_weapon(_weapon_index, _weapon_name);
                break;

            case NPC_INDEX.NPC09:
                // Change the NPC09 Character Sprite.
                NPC09_make npc09 = NPC09_make.NPC09_struct.gameobject.GetComponent<NPC09_make>();

                // Change the NPC09 Weapon icon Sprite.
                NPC09_make.NPC09_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC09_make.NPC09_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_Weapon_type + GameData.to_change_npc_struct.weapon_index.ToString();

                // NPC09 캐릭터 이미지 바꾸기.
                npc09.change_weapon(_weapon_index, _weapon_name);
                break;
        }
        // NPC선택 후 popUp window 비활성화.
        GameData.weapon_sel_popup_window_obj.SetActive(false);
    }

    void bow_to_selected_NPC(NPC_INDEX _npc_index, string _weapon_name, int _weapon_index)
    {
        // npc0x에 따라서 실행.
        switch (_npc_index)
        {

            case NPC_INDEX.NPC04:

                // Change the NPC04 Character Sprite. ( 다른 스크립트 함수 실행할 때 object 받아와야함. )
                NPC04_make npc04 = NPC04_make.NPC04_struct.gameobject.GetComponent<NPC04_make>();

                // Change the NPC04 Weapon04 icon Sprite.
                // 무기 장착 메뉴에서 무기의 type과 index를 to_change 구조체에 미리 저장해두고 여기서 가져와서 해당 무기 장착 sprite로 바꿔줌.
                NPC04_make.NPC04_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC04_make.NPC04_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_Weapon_type + GameData.to_change_npc_struct.weapon_index.ToString();

                // NPC04 캐릭터 bow 이미지 바꾸기.
                npc04.change_weapon(_weapon_index, _weapon_name);
                break;

            case NPC_INDEX.NPC05:

                print("change the 05 bow");
                // Change the NPC05 Character Sprite.
                NPC05_make npc05 = NPC05_make.NPC05_struct.gameobject.GetComponent<NPC05_make>();

                // Change the NPC05 Weapon01 icon Sprite.
                NPC05_make.NPC05_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC05_make.NPC05_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_Weapon_type + GameData.to_change_npc_struct.weapon_index.ToString();

                // NPC02 캐릭터 이미지 바꾸기.
                npc05.change_weapon(_weapon_index, _weapon_name);
                break;

            case NPC_INDEX.NPC06:
                // Change the NPC06 Character Sprite.
                NPC06_make npc06 = NPC06_make.NPC06_struct.gameobject.GetComponent<NPC06_make>();

                // Change the NPC03 Weapon icon Sprite.
                NPC06_make.NPC06_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC06_make.NPC06_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_Weapon_type + GameData.to_change_npc_struct.weapon_index.ToString();

                // NPC03 캐릭터 이미지 바꾸기.
                npc06.change_weapon(_weapon_index, _weapon_name);
                break;

            case NPC_INDEX.NPC10:
                // Change the NPC10 Character Sprite.
                NPC10_make npc10 = NPC10_make.NPC10_struct.gameobject.GetComponent<NPC10_make>();

                // Change the NPC10 Weapon icon Sprite.
                NPC10_make.NPC10_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC10_make.NPC10_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_Weapon_type + GameData.to_change_npc_struct.weapon_index.ToString();

                // NPC07 캐릭터 이미지 바꾸기.
                npc10.change_weapon(_weapon_index, _weapon_name);
                break;

            case NPC_INDEX.NPC11:
                // Change the NPC11 Character Sprite.
                NPC11_make npc11 = NPC11_make.NPC11_struct.gameobject.GetComponent<NPC11_make>();

                // Change the NPC11 Weapon icon Sprite.
                NPC11_make.NPC11_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC11_make.NPC11_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_Weapon_type + GameData.to_change_npc_struct.weapon_index.ToString();

                // NPC11 캐릭터 이미지 바꾸기.
                npc11.change_weapon(_weapon_index, _weapon_name);
                break;

            case NPC_INDEX.NPC12:
                // Change the NPC12 Character Sprite.
                NPC12_make npc12 = NPC12_make.NPC12_struct.gameobject.GetComponent<NPC12_make>();

                // Change the NPC12 Weapon icon Sprite.
                NPC12_make.NPC12_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC12_make.NPC12_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_Weapon_type + GameData.to_change_npc_struct.weapon_index.ToString();

                // NPC12 캐릭터 이미지 바꾸기.
                npc12.change_weapon(_weapon_index, _weapon_name);
                break;
        }

        // NPC선택 후 popUp window 비활성화.
        GameData.bow_sel_popup_window_obj.SetActive(false);
    }

    // 해당 NPC에게 선택한 Clothes를 장착하게 하는 함수.
    void clothes_to_selected_NPC(NPC_INDEX _npc_index, string _armor_type, int _armor_index, int _armor_color)
    {
        // npc0x에 따라서 실행.
        switch (_npc_index)
        {

            case NPC_INDEX.NPC01:
                // Change the NPC01 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                NPC01_make npc01 = NPC01_make.NPC01_struct.gameobject.GetComponent<NPC01_make>();

                // Change the NPC01 Clothes icon Sprite.
                NPC01_make.NPC01_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC01_make.NPC01_struct.clothes_sp.spriteName = GameData.to_change_npc_struct.To_Change_Armor_type + GameData.to_change_npc_struct.armor_index.ToString();

                // NPC01 캐릭터 clothes 이미지 바꾸기.
			npc01.change_clothes(_armor_index, _armor_color, _armor_type);

                break;
            case NPC_INDEX.NPC02:
                // Change the NPC02 Character Sprite.
                NPC02_make npc02 = NPC02_make.NPC02_struct.gameobject.GetComponent<NPC02_make>();

                // Change the NPC02 Weapon01 icon Sprite.
                NPC02_make.NPC02_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC02_make.NPC02_struct.clothes_sp.spriteName = "weapon01_icon";

                // NPC02 캐릭터 이미지 바꾸기.

                break;
        }

        // NPC선택 후 popUp window 비활성화.
		GameData.clothes_sel_popup_window_obj.SetActive(false);

    }

	// 해당 NPC에게 선택한 Clothes를 장착하게 하는 함수.
	void wing_to_selected_NPC(NPC_INDEX _npc_index, string _wing_type, int _wing_index)
	{
		// npc0x에 따라서 실행.
		switch (_npc_index)
		{

		case NPC_INDEX.NPC01:
			// Change the NPC01 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
			NPC01_make npc01 = NPC01_make.NPC01_struct.gameobject.GetComponent<NPC01_make>();
            
			// Change the NPC01 Clothes icon Sprite.
			NPC01_make.NPC01_struct.wing_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
			NPC01_make.NPC01_struct.wing_sp.spriteName = GameData.to_change_npc_struct.To_Change_wing_type + GameData.to_change_npc_struct.wing_index.ToString();

            // NPC01 캐릭터 wing 이미지 바꾸기.
			npc01.change_wing(_wing_index, _wing_type);

			break;

        case NPC_INDEX.NPC02:
            // Change the NPC02 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
            NPC02_make npc02 = NPC02_make.NPC02_struct.gameobject.GetComponent<NPC02_make>();

            // Change the NPC02 Clothes icon Sprite.
            NPC02_make.NPC02_struct.wing_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC02_make.NPC02_struct.wing_sp.spriteName = GameData.to_change_npc_struct.To_Change_wing_type + GameData.to_change_npc_struct.wing_index.ToString();

            // NPC02 캐릭터 wing 이미지 바꾸기.
            npc02.change_wing(_wing_index, _wing_type);

            break;

            // To Do.
            // NPC별로 image setting 처리 추가해야함.
        }

		// NPC선택 후 popUp window 비활성화.
		GameData.wing_sel_popup_window_obj.SetActive(false);

	}
   
}
