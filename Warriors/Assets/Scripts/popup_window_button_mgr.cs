﻿using UnityEngine;
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
    
	public static int equip_weapon_index;
    public static int equip_armor_index;
    public static int equip_wing_index;

    public string weapon
    {
        get { return "weapon"; }
    }
    public string armor
    {
        get { return "armor"; }
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

    public void Close_boss_Sel_popup_Window()
    {
        // 터치 클릭 영역을 원상태로 복귀 시킴.
        GameObject.Find("Touch_Area").GetComponent<BoxCollider2D>().size = new Vector2(1085f, 1180f);
        GameObject.Find("Touch_Area").transform.position = new Vector2(0, 0);

        GameData.boss_sel_popup_window_obj.SetActive(false);
    }




    // 어떤 NPC를 선택했는지 처리하기 위한 함수.
    public void Select_NPC(NPC_INDEX npc_index,string type)
    {
        print(npc_index.ToString() + " type : " + type);
        // type에 따라서 실행.
        switch (type)
        {
        case "weapon":
            weapon_to_selected_NPC(npc_index, GameData.to_change_npc_struct.To_Change_Weapon_type, GameData.to_change_npc_struct.weapon_index);
            break;
        case "armor":
            clothes_to_selected_NPC(npc_index, GameData.to_change_npc_struct.To_Change_Armor_type, GameData.to_change_npc_struct.armor_index, GameData.to_change_npc_struct.armor_color);
            break;
        case "bow":
            bow_to_selected_NPC(npc_index, GameData.to_change_npc_struct.To_Change_bow_type, GameData.to_change_npc_struct.bow_index);
            break;
        case "wing":
            wing_to_selected_NPC(npc_index, GameData.to_change_npc_struct.To_Change_wing_type, GameData.to_change_npc_struct.wing_index);
            break;
		default:
			print ("type Error");
			break;
        } 
    }

    // 해당 NPC에게 선택한 Weapon을 장착하게 하는 함수.
    void weapon_to_selected_NPC(NPC_INDEX _npc_index, string _weapon_name, int _weapon_index)
    {
        bool enable_weapon_change = false;

        // example : dagger-a0
        print("weapon_to_selected_NPC : " + _weapon_name.ToString() + _weapon_index.ToString());

        // 선택한 캐릭터가 해당 무기를 가지고 있는지 check. 
        string npc_str = "npc" + ((int)_npc_index).ToString() + "_weapon_enable";

        if (PlayerPrefs.HasKey(npc_str))
        {
            print("캐릭터는 무기를 가지고 있으므로 동일한 무기인지 check.");

            //무기를 가지고 있다면 동일한 무기인지 check.
            string npc_select_weapon = _weapon_name + _weapon_index;
            string npc_has_weapon = PlayerPrefs.GetString("npc"+ ((int)_npc_index).ToString() + "_weapon_part") + PlayerPrefs.GetInt("npc"+ ((int)_npc_index).ToString() + "_weapon_index").ToString();
            if (string.Equals(npc_select_weapon, npc_has_weapon))
            {
                print("같은 무기 선택.");
                GameData.weapon_sel_popup_window_obj.SetActive(false);
                return;
            } else
            {
                print("다른 무기 선택하여 해당 무기 setting.");
                enable_weapon_change = true;
            }
        } else
        {
            print("캐릭터는 무기를 가지고 있지 않음.");
            enable_weapon_change = true;

            // 현재 장착하고 있는 npc는 해당 무기 해제.
            int unequiped_npc = PlayerPrefs.GetInt("weapon" + _weapon_index.ToString() + "_npc");
            switch (unequiped_npc)
            {
                case 1:
                    // Change the NPC01 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                    NPC01_make npc01 = NPC01_make.NPC01_struct.gameobject.GetComponent<NPC01_make>();

                    // Change the NPC01 Weapon01 icon Sprite.
                    NPC01_make.NPC01_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC01_make.NPC01_struct.weapon_sp.spriteName = "weapon_nothing";

                    // NPC01 캐릭터 weapon 이미지 바꾸기.
                    npc01.change_weapon(0, "");

                    // NPC01 캐릭터 damage에 weapon damage 추가.
                    NPC01_make.NPC01_struct.add_damage = 0;
                    NPC01_make.NPC01_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC01_make.NPC01_struct.add_damage);
                break;
                case 2:
                    // Change the NPC02 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                    NPC02_make npc02 = NPC02_make.NPC02_struct.gameobject.GetComponent<NPC02_make>();

                    // Change the NPC01 Weapon01 icon Sprite.
                    NPC02_make.NPC02_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC02_make.NPC02_struct.weapon_sp.spriteName = "weapon_nothing";

                    // NPC01 캐릭터 weapon 이미지 바꾸기.
                    npc02.change_weapon(0, "");

                    // NPC01 캐릭터 damage에 weapon damage 추가.
                    NPC02_make.NPC02_struct.add_damage = 0;
                    NPC02_make.NPC02_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC02_make.NPC02_struct.add_damage);
                    break;
                case 3:
                    // Change the NPC03 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                    NPC03_make npc03 = NPC03_make.NPC03_struct.gameobject.GetComponent<NPC03_make>();

                    // Change the NPC01 Weapon01 icon Sprite.
                    NPC03_make.NPC03_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC03_make.NPC03_struct.weapon_sp.spriteName = "weapon_nothing";

                    // NPC01 캐릭터 weapon 이미지 바꾸기.
                    npc03.change_weapon(0, "");

                    // NPC01 캐릭터 damage에 weapon damage 추가.
                    NPC03_make.NPC03_struct.add_damage = 0;
                    NPC03_make.NPC03_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC03_make.NPC03_struct.add_damage);
                    break;
                case 7:
                    // Change the NPC07 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                    NPC07_make npc07 = NPC07_make.NPC07_struct.gameobject.GetComponent<NPC07_make>();

                    // Change the NPC01 Weapon01 icon Sprite.
                    NPC07_make.NPC07_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC07_make.NPC07_struct.weapon_sp.spriteName = "weapon_nothing";

                    // NPC07 캐릭터 weapon 이미지 바꾸기.
                    npc07.change_weapon(0, "");

                    // NPC07 캐릭터 damage에 weapon damage 추가.
                    NPC07_make.NPC07_struct.add_damage = 0;
                    NPC07_make.NPC07_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC07_make.NPC07_struct.add_damage);
                    break;
                case 8:
                    // Change the NPC08 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                    NPC08_make npc08 = NPC08_make.NPC08_struct.gameobject.GetComponent<NPC08_make>();

                    // Change the NPC01 Weapon01 icon Sprite.
                    NPC08_make.NPC08_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC08_make.NPC08_struct.weapon_sp.spriteName = "weapon_nothing";

                    // NPC01 캐릭터 weapon 이미지 바꾸기.
                    npc08.change_weapon(0, "");

                    // NPC08 캐릭터 damage에 weapon damage 추가.
                    NPC08_make.NPC08_struct.add_damage = 0;
                    NPC08_make.NPC08_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC08_make.NPC08_struct.add_damage);
                    break;
                case 9:
                    // Change the NPC03 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                    NPC09_make npc09 = NPC09_make.NPC09_struct.gameobject.GetComponent<NPC09_make>();

                    // Change the NPC01 Weapon01 icon Sprite.
                    NPC09_make.NPC09_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC09_make.NPC09_struct.weapon_sp.spriteName = "weapon_nothing";

                    // NPC01 캐릭터 weapon 이미지 바꾸기.
                    npc09.change_weapon(0, "");

                    // NPC01 캐릭터 damage에 weapon damage 추가.
                    NPC09_make.NPC09_struct.add_damage = 0;
                    NPC09_make.NPC09_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC09_make.NPC09_struct.add_damage);
                    break;
            }

        }

        //무기를 가지고 있지 않으면 그냥 setting.
        if (enable_weapon_change)
        {
            print("해당 캐릭터는 무기를 가지고 있지 않음.");

            // npc index에 따라서 실행.
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

                    // NPC01 캐릭터 damage에 weapon damage 추가.
                    GameData_weapon.equip_the_weapon(equip_weapon_index, NPC_INDEX.NPC01);
                    break;

                case NPC_INDEX.NPC02:
                    // Change the NPC02 Character Sprite.
                    NPC02_make npc02 = NPC02_make.NPC02_struct.gameobject.GetComponent<NPC02_make>();

                    // Change the NPC02 Weapon01 icon Sprite.
                    NPC02_make.NPC02_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC02_make.NPC02_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_Weapon_type + GameData.to_change_npc_struct.weapon_index.ToString();

                    // NPC02 캐릭터 이미지 바꾸기.
                    npc02.change_weapon(_weapon_index, _weapon_name);

                    // NPC02 캐릭터 damage에 weapon damage 추가.
                    GameData_weapon.equip_the_weapon(equip_weapon_index, NPC_INDEX.NPC02);
                    break;

                case NPC_INDEX.NPC03:
                    // Change the NPC03 Character Sprite.
                    NPC03_make npc03 = NPC03_make.NPC03_struct.gameobject.GetComponent<NPC03_make>();

                    // Change the NPC03 Weapon icon Sprite.
                    NPC03_make.NPC03_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC03_make.NPC03_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_Weapon_type + GameData.to_change_npc_struct.weapon_index.ToString();

                    // NPC03 캐릭터 이미지 바꾸기.
                    npc03.change_weapon(_weapon_index, _weapon_name);

                    // NPC03 캐릭터 damage에 weapon damage 추가.
                    GameData_weapon.equip_the_weapon(equip_weapon_index, NPC_INDEX.NPC03);
                    break;

                case NPC_INDEX.NPC07:
                    // Change the NPC07 Character Sprite.
                    NPC07_make npc07 = NPC07_make.NPC07_struct.gameobject.GetComponent<NPC07_make>();

                    // Change the NPC03 Weapon icon Sprite.
                    NPC07_make.NPC07_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC07_make.NPC07_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_Weapon_type + GameData.to_change_npc_struct.weapon_index.ToString();

                    // NPC07 캐릭터 이미지 바꾸기.
                    npc07.change_weapon(_weapon_index, _weapon_name);

                    // NPC07 캐릭터 damage에 weapon damage 추가.
                    GameData_weapon.equip_the_weapon(equip_weapon_index, NPC_INDEX.NPC07);
                    break;

                case NPC_INDEX.NPC08:
                    // Change the NPC08 Character Sprite.
                    NPC08_make npc08 = NPC08_make.NPC08_struct.gameobject.GetComponent<NPC08_make>();

                    // Change the NPC08 Weapon icon Sprite.
                    NPC08_make.NPC08_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC08_make.NPC08_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_Weapon_type + GameData.to_change_npc_struct.weapon_index.ToString();

                    // NPC08 캐릭터 이미지 바꾸기.
                    npc08.change_weapon(_weapon_index, _weapon_name);

                    // NPC08 캐릭터 damage에 weapon damage 추가.
                    GameData_weapon.equip_the_weapon(equip_weapon_index, NPC_INDEX.NPC08);
                    break;

                case NPC_INDEX.NPC09:
                    // Change the NPC09 Character Sprite.
                    NPC09_make npc09 = NPC09_make.NPC09_struct.gameobject.GetComponent<NPC09_make>();

                    // Change the NPC09 Weapon icon Sprite.
                    NPC09_make.NPC09_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC09_make.NPC09_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_Weapon_type + GameData.to_change_npc_struct.weapon_index.ToString();

                    // NPC09 캐릭터 이미지 바꾸기.
                    npc09.change_weapon(_weapon_index, _weapon_name);

                    // NPC09 캐릭터 damage에 weapon damage 추가.
                    GameData_weapon.equip_the_weapon(equip_weapon_index, NPC_INDEX.NPC09);
                    break;
                default:
                    print("Can`t find NPC index");
                    break;
            }
        }
        // NPC선택 후 popUp window 비활성화.
        GameData.weapon_sel_popup_window_obj.SetActive(false);
    }

    void bow_to_selected_NPC(NPC_INDEX _npc_index, string _weapon_name, int _weapon_index)
    {

        bool enable_weapon_change = false;

        // example : dagger-a0
        print("weapon_to_selected_NPC : " + _weapon_name.ToString() + _weapon_index.ToString());

        // 선택한 캐릭터가 해당 무기를 가지고 있는지 check. 
        string npc_str = "npc" + ((int)_npc_index).ToString() + "_weapon_enable";

        if (PlayerPrefs.HasKey(npc_str))
        {
            print("캐릭터는 무기를 가지고 있으므로 동일한 무기인지 check.");

            //무기를 가지고 있다면 동일한 무기인지 check.
            string npc_select_weapon = _weapon_name + _weapon_index;
            string npc_has_weapon = PlayerPrefs.GetString("npc"+ ((int)_npc_index).ToString() + "_weapon_part") + PlayerPrefs.GetInt("npc"+ ((int)_npc_index).ToString() + "_weapon_index").ToString();
            if (string.Equals(npc_select_weapon, npc_has_weapon))
            {
                print("같은 무기 선택.");
                GameData.weapon_sel_popup_window_obj.SetActive(false);
                return;
            }
            else
            {
                print("다른 무기 선택하여 해당 무기 setting.");
                enable_weapon_change = true;
            }
        }
        else
        {
            print("캐릭터는 무기를 가지고 있지 않음.");
            enable_weapon_change = true;

        }

        if (enable_weapon_change)
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
                    NPC04_make.NPC04_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_bow_type + GameData.to_change_npc_struct.bow_index.ToString();

                    // NPC04 캐릭터 damage에 첫번째 weapon damage 추가.
                    print("to change sprite : " + NPC04_make.NPC04_struct.weapon_sp.spriteName.ToString());
                    GameData_weapon.equip_the_bow(equip_weapon_index, NPC_INDEX.NPC04);

                    // NPC04 캐릭터 bow 이미지 바꾸기.
                    npc04.change_weapon(_weapon_index, _weapon_name);
                    break;

                case NPC_INDEX.NPC05:

                    // Change the NPC05 Character Sprite.
                    NPC05_make npc05 = NPC05_make.NPC05_struct.gameobject.GetComponent<NPC05_make>();

                    // Change the NPC05 Weapon01 icon Sprite.
                    NPC05_make.NPC05_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC05_make.NPC05_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_bow_type + GameData.to_change_npc_struct.bow_index.ToString();

                    // NPC05 캐릭터 damage에 첫번째 weapon damage 추가.
                    GameData_weapon.equip_the_bow(equip_weapon_index, NPC_INDEX.NPC05);

                    // NPC02 캐릭터 이미지 바꾸기.
                    npc05.change_weapon(_weapon_index, _weapon_name);
                    break;

                case NPC_INDEX.NPC06:
                    // Change the NPC06 Character Sprite.
                    NPC06_make npc06 = NPC06_make.NPC06_struct.gameobject.GetComponent<NPC06_make>();

                    // Change the NPC03 Weapon icon Sprite.
                    NPC06_make.NPC06_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC06_make.NPC06_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_bow_type + GameData.to_change_npc_struct.bow_index.ToString();

                    // NPC06 캐릭터 damage에 첫번째 weapon damage 추가.
                    GameData_weapon.equip_the_bow(equip_weapon_index, NPC_INDEX.NPC06);

                    // NPC03 캐릭터 이미지 바꾸기.
                    npc06.change_weapon(_weapon_index, _weapon_name);
                    break;

                case NPC_INDEX.NPC10:
                    // Change the NPC10 Character Sprite.
                    NPC10_make npc10 = NPC10_make.NPC10_struct.gameobject.GetComponent<NPC10_make>();

                    // Change the NPC10 Weapon icon Sprite.
                    NPC10_make.NPC10_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC10_make.NPC10_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_bow_type + GameData.to_change_npc_struct.bow_index.ToString();

                    // NPC10 캐릭터 damage에 첫번째 weapon damage 추가.
                    GameData_weapon.equip_the_bow(equip_weapon_index, NPC_INDEX.NPC10);

                    // NPC07 캐릭터 이미지 바꾸기.
                    npc10.change_weapon(_weapon_index, _weapon_name);
                    break;

                case NPC_INDEX.NPC11:
                    // Change the NPC11 Character Sprite.
                    NPC11_make npc11 = NPC11_make.NPC11_struct.gameobject.GetComponent<NPC11_make>();

                    // Change the NPC11 Weapon icon Sprite.
                    NPC11_make.NPC11_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC11_make.NPC11_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_bow_type + GameData.to_change_npc_struct.bow_index.ToString();

                    // NPC11 캐릭터 damage에 첫번째 weapon damage 추가.
                    GameData_weapon.equip_the_bow(equip_weapon_index, NPC_INDEX.NPC11);

                    // NPC11 캐릭터 이미지 바꾸기.
                    npc11.change_weapon(_weapon_index, _weapon_name);
                    break;

                case NPC_INDEX.NPC12:
                    // Change the NPC12 Character Sprite.
                    NPC12_make npc12 = NPC12_make.NPC12_struct.gameobject.GetComponent<NPC12_make>();

                    // Change the NPC12 Weapon icon Sprite.
                    NPC12_make.NPC12_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC12_make.NPC12_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_bow_type + GameData.to_change_npc_struct.bow_index.ToString();

                    // NPC12 캐릭터 damage에 첫번째 weapon damage 추가.
                    GameData_weapon.equip_the_bow(equip_weapon_index, NPC_INDEX.NPC12);

                    // NPC12 캐릭터 이미지 바꾸기.
                    npc12.change_weapon(_weapon_index, _weapon_name);
                    break;
                default:
                    print("Can`t find NPC index");
                    break;
            }
        }
        // NPC선택 후 popUp window 비활성화.
        GameData.bow_sel_popup_window_obj.SetActive(false);
    }

    // 해당 NPC에게 선택한 Armor를 장착하게 하는 함수.
    void clothes_to_selected_NPC(NPC_INDEX _npc_index, string _armor_type, int _armor_index, int _armor_color)
    {

        bool enable_armor_change = false;

        // 선택한 캐릭터가 해당 무기를 가지고 있는지 check. 
        string npc_str = "npc" + ((int)_npc_index).ToString() + "_armor_enable";
        int get_npc_armor_index = PlayerPrefs.GetInt(npc_str);

        // 현재 장착하고 있는 Armor index 가져오기.
        int toequip_armor_index = GameData_weapon.armorDIC[_armor_type + _armor_index.ToString() + _armor_color.ToString()];
        string npc_select_armor = _armor_type + _armor_index + _armor_color;
        string npc_has_armor = PlayerPrefs.GetString("npc" + ((int)_npc_index).ToString() + "_armor_part") + PlayerPrefs.GetInt("npc" + ((int)_npc_index).ToString() + "_armor_index").ToString() + PlayerPrefs.GetInt("npc" + ((int)_npc_index).ToString() + "_armor_color").ToString();

        if (get_npc_armor_index == 1)
        {
            print("캐릭터는 Armor를 가지고 있으므로 동일한 무기인지 check.");

            //무기를 가지고 있다면 동일한 무기인지 check.
            if (string.Equals(npc_select_armor, npc_has_armor))
            {
                print("같은 Armor 선택.");
                GameData.clothes_sel_popup_window_obj.SetActive(false);
                return;
            }
            else
            {
                print("다른 Armor 선택하여 해당 무기 setting.");
                enable_armor_change = true;
                unequiped_armor_npc(npc_has_armor);
            }
        }
        else
        {
            print("캐릭터는 무기를 가지고 있지 않음.");
            enable_armor_change = true;
            unequiped_armor_npc(npc_select_armor);
        }

        if (enable_armor_change)
        {
            // npc0x에 따라서 실행.
            switch (_npc_index)
            {

                case NPC_INDEX.NPC01:
                    // Change the NPC01 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                    NPC01_make npc01 = NPC01_make.NPC01_struct.gameobject.GetComponent<NPC01_make>();

                    // Change the NPC01 Clothes icon Sprite.
                    NPC01_make.NPC01_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC01_make.NPC01_struct.clothes_sp.spriteName = _armor_type + _armor_index.ToString() + _armor_color.ToString();

                    // NPC01 캐릭터 coin획득량에 armor skill 추가.
                    GameData_weapon.get_armor_skill_func(toequip_armor_index, (int)_npc_index-1);
           
                    // NPC01 캐릭터 clothes 이미지 바꾸기.
                    npc01.change_clothes(_armor_index, _armor_color, _armor_type);
                    break;

                case NPC_INDEX.NPC02:
                    // Change the NPC02 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                    NPC02_make npc02 = NPC02_make.NPC02_struct.gameobject.GetComponent<NPC02_make>();

                    // Change the NPC02 Clothes icon Sprite.
                    NPC02_make.NPC02_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC02_make.NPC02_struct.clothes_sp.spriteName = _armor_type + _armor_index.ToString() + _armor_color.ToString();

                    // NPC01 캐릭터 coin획득량에 armor skill 추가.
                    GameData_weapon.get_armor_skill_func(toequip_armor_index, (int)_npc_index-1);

                    // NPC02 캐릭터 clothes 이미지 바꾸기.
                    npc02.change_clothes(_armor_index, _armor_color, _armor_type);
                    break;

                case NPC_INDEX.NPC03:
                    // Change the NPC03 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                    NPC03_make npc03 = NPC03_make.NPC03_struct.gameobject.GetComponent<NPC03_make>();

                    // Change the NPC03 Clothes icon Sprite.
                    NPC03_make.NPC03_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC03_make.NPC03_struct.clothes_sp.spriteName = _armor_type + _armor_index.ToString() + _armor_color.ToString();

                    // NPC03 캐릭터 coin획득량에 armor skill 추가.
                    GameData_weapon.get_armor_skill_func(toequip_armor_index, (int)_npc_index-1);

                    // NPC03 캐릭터 clothes 이미지 바꾸기.
                    npc03.change_clothes(_armor_index, _armor_color, _armor_type);
                    break;

                case NPC_INDEX.NPC04:
                    // Change the NPC04 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                    NPC04_make npc04 = NPC04_make.NPC04_struct.gameobject.GetComponent<NPC04_make>();

                    // Change the NPC04 Clothes icon Sprite.
                    NPC04_make.NPC04_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC04_make.NPC04_struct.clothes_sp.spriteName = _armor_type + _armor_index.ToString() + _armor_color.ToString();

                    // NPC04 캐릭터 coin획득량에 armor skill 추가.
                    GameData_weapon.get_armor_skill_func(toequip_armor_index, (int)_npc_index-1);

                    // NPC04 캐릭터 clothes 이미지 바꾸기.
                    npc04.change_clothes(_armor_index, _armor_color, _armor_type);
                    break;

                case NPC_INDEX.NPC05:
                    // Change the NPC05 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                    NPC05_make npc05 = NPC05_make.NPC05_struct.gameobject.GetComponent<NPC05_make>();

                    // Change the NPC05 Clothes icon Sprite.
                    NPC05_make.NPC05_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC05_make.NPC05_struct.clothes_sp.spriteName = _armor_type + _armor_index.ToString() + _armor_color.ToString();

                    // NPC05 캐릭터 coin획득량에 armor skill 추가.
                    GameData_weapon.get_armor_skill_func(toequip_armor_index, (int)_npc_index-1);

                    // NPC05 캐릭터 clothes 이미지 바꾸기.
                    npc05.change_clothes(_armor_index, _armor_color, _armor_type);
                    break;

                case NPC_INDEX.NPC06:
                    print("npc06 enable" + _npc_index);
                    // Change the NPC06 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                    NPC06_make npc06 = NPC06_make.NPC06_struct.gameobject.GetComponent<NPC06_make>();

                    // Change the NPC06 Clothes icon Sprite.
                    NPC06_make.NPC06_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC06_make.NPC06_struct.clothes_sp.spriteName = _armor_type + _armor_index.ToString() + _armor_color.ToString();

                    // NPC06 캐릭터 coin획득량에 armor skill 추가.
                    GameData_weapon.get_armor_skill_func(toequip_armor_index, (int)_npc_index-1);

                    // NPC06 캐릭터 clothes 이미지 바꾸기.
                    npc06.change_clothes(_armor_index, _armor_color, _armor_type);
                    break;

                case NPC_INDEX.NPC07:
                    // Change the NPC07 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                    NPC07_make npc07 = NPC07_make.NPC07_struct.gameobject.GetComponent<NPC07_make>();

                    // Change the NPC07 Clothes icon Sprite.
                    NPC07_make.NPC07_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC07_make.NPC07_struct.clothes_sp.spriteName = _armor_type + _armor_index.ToString() + _armor_color.ToString();

                    // NPC07 캐릭터 coin획득량에 armor skill 추가.
                    GameData_weapon.get_armor_skill_func(toequip_armor_index, (int)_npc_index-1);

                    // NPC07 캐릭터 clothes 이미지 바꾸기.
                    npc07.change_clothes(_armor_index, _armor_color, _armor_type);
                    break;

                case NPC_INDEX.NPC08:
                    // Change the NPC08 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                    NPC08_make npc08 = NPC08_make.NPC08_struct.gameobject.GetComponent<NPC08_make>();

                    // Change the NPC08 Clothes icon Sprite.
                    NPC08_make.NPC08_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC08_make.NPC08_struct.clothes_sp.spriteName = _armor_type + _armor_index.ToString() + _armor_color.ToString();

                    // NPC08 캐릭터 coin획득량에 armor skill 추가.
                    GameData_weapon.get_armor_skill_func(toequip_armor_index, (int)_npc_index-1);

                    // NPC08 캐릭터 clothes 이미지 바꾸기.
                    npc08.change_clothes(_armor_index, _armor_color, _armor_type);
                    break;

                case NPC_INDEX.NPC09:
                    // Change the NPC09 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                    NPC09_make npc09 = NPC09_make.NPC09_struct.gameobject.GetComponent<NPC09_make>();

                    // Change the NPC09 Clothes icon Sprite.
                    NPC09_make.NPC09_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC09_make.NPC09_struct.clothes_sp.spriteName = _armor_type + _armor_index.ToString() + _armor_color.ToString();

                    // NPC09 캐릭터 coin획득량에 armor skill 추가.
                    GameData_weapon.get_armor_skill_func(toequip_armor_index, (int)_npc_index-1);

                    // NPC09 캐릭터 clothes 이미지 바꾸기.
                    npc09.change_clothes(_armor_index, _armor_color, _armor_type);
                    break;

                case NPC_INDEX.NPC10:
                    // Change the NPC10 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                    NPC10_make npc10 = NPC10_make.NPC10_struct.gameobject.GetComponent<NPC10_make>();

                    // Change the NPC10 Clothes icon Sprite.
                    NPC10_make.NPC10_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC10_make.NPC10_struct.clothes_sp.spriteName = _armor_type + _armor_index.ToString() + _armor_color.ToString();

                    // NPC10 캐릭터 coin획득량에 armor skill 추가.
                    GameData_weapon.get_armor_skill_func(toequip_armor_index, (int)_npc_index-1);

                    // NPC10 캐릭터 clothes 이미지 바꾸기.
                    npc10.change_clothes(_armor_index, _armor_color, _armor_type);
                    break;

                case NPC_INDEX.NPC11:
                    // Change the NPC11 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                    NPC11_make npc11 = NPC11_make.NPC11_struct.gameobject.GetComponent<NPC11_make>();

                    // Change the NPC11 Clothes icon Sprite.
                    NPC11_make.NPC11_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC11_make.NPC11_struct.clothes_sp.spriteName = _armor_type + _armor_index.ToString() + _armor_color.ToString();

                    // NPC11 캐릭터 coin획득량에 armor skill 추가.
                    GameData_weapon.get_armor_skill_func(toequip_armor_index, (int)_npc_index-1);

                    // NPC11 캐릭터 clothes 이미지 바꾸기.
                    npc11.change_clothes(_armor_index, _armor_color, _armor_type);
                    break;

                case NPC_INDEX.NPC12:
                    // Change the NPC12 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                    NPC12_make npc12 = NPC12_make.NPC12_struct.gameobject.GetComponent<NPC12_make>();

                    // Change the NPC12 Clothes icon Sprite.
                    NPC12_make.NPC12_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    NPC12_make.NPC12_struct.clothes_sp.spriteName = _armor_type + _armor_index.ToString() + _armor_color.ToString();

                    // NPC12 캐릭터 coin획득량에 armor skill 추가.
                    GameData_weapon.get_armor_skill_func(toequip_armor_index, (int)_npc_index-1);

                    // NPC12 캐릭터 clothes 이미지 바꾸기.
                    npc12.change_clothes(_armor_index, _armor_color, _armor_type);
                    break;
                default:
                    print("Can`t find NPC index");
                    break;

            }
        }
        // NPC선택 후 popUp window 비활성화.
		GameData.clothes_sel_popup_window_obj.SetActive(false);

    }

    void unequiped_armor_npc(string _armor)
    {
        //******   현재 장착하고 있는 npc는 해당 무기 해제.  ******//

        // 현재 장착하고 있는 Armor index 가져오기.
        int equiped_armor_index = GameData_weapon.armorDIC[_armor];
        int unequiped_npc = PlayerPrefs.GetInt("armor" + equiped_armor_index.ToString() + "_npc", 100);

        print("_armor ::: " + _armor);
        print("equiped_armor_index ::: " + equiped_armor_index);
        print("unequiped_npc ::: " + unequiped_npc);

        string reset_npc_str = "";
        switch (unequiped_npc)
        {
            case 0:
                // Change the NPC01 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                NPC01_make npc01 = NPC01_make.NPC01_struct.gameobject.GetComponent<NPC01_make>();

                // Change the NPC01 Weapon01 icon Sprite.
                NPC01_make.NPC01_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC01_make.NPC01_struct.clothes_sp.spriteName = "weapon_nothing";

                // NPC01 캐릭터 armor 이미지 바꾸기.
                npc01.change_clothes(0, 0, "");

                // 해당 npc armor enable Loca변수를 0으로 disable시켜줌.
                reset_npc_str = "npc" + ((int)unequiped_npc + 1).ToString() + "_armor_enable";
                PlayerPrefs.SetInt(reset_npc_str, 0);
                PlayerPrefs.Save();

                // NPC01 캐릭터 damage에 베기 추가 공격력 reset.
                GameData_weapon.reset_armor_skill_func(equiped_armor_index);
                NPC01_make.NPC01_struct.skill_label.GetComponent<UILabel>().text = "없음";
                break;

            case 1:
                // Change the NPC02 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                NPC02_make npc02 = NPC02_make.NPC02_struct.gameobject.GetComponent<NPC02_make>();

                // Change the NPC02 Weapon02 icon Sprite.
                NPC02_make.NPC02_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC02_make.NPC02_struct.clothes_sp.spriteName = "weapon_nothing";

                // NPC02 캐릭터 armor 이미지 바꾸기.
                npc02.change_clothes(0, 0, "");

                // 해당 npc armor enable Loca변수를 0으로 disable시켜줌.
                reset_npc_str = "npc" + ((int)unequiped_npc + 1).ToString() + "_armor_enable";
                PlayerPrefs.SetInt(reset_npc_str, 0);
                PlayerPrefs.Save();

                // NPC02 캐릭터 damage에 베기 추가 공격력 reset.
                GameData_weapon.reset_armor_skill_func(equiped_armor_index);
                NPC02_make.NPC02_struct.skill_label.GetComponent<UILabel>().text = "없음";
                break;

            case 2:
                // Change the NPC Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                NPC03_make npc03 = NPC03_make.NPC03_struct.gameobject.GetComponent<NPC03_make>();

                // Change the NPC Weapon03 icon Sprite.
                NPC03_make.NPC03_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC03_make.NPC03_struct.clothes_sp.spriteName = "weapon_nothing";

                // NPC 캐릭터 armor 이미지 바꾸기.
                npc03.change_clothes(0, 0, "");

                // 해당 npc armor enable Loca변수를 0으로 disable시켜줌.
                reset_npc_str = "npc" + ((int)unequiped_npc + 1).ToString() + "_armor_enable";
                PlayerPrefs.SetInt(reset_npc_str, 0);
                PlayerPrefs.Save();

                // NPC01 캐릭터 damage에 베기 추가 공격력 reset.
                GameData_weapon.reset_armor_skill_func(equiped_armor_index);
                NPC03_make.NPC03_struct.skill_label.GetComponent<UILabel>().text = "없음";
                break;

            case 3:
                // Change the NPC Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                NPC04_make npc04 = NPC04_make.NPC04_struct.gameobject.GetComponent<NPC04_make>();

                // Change the NPC Weapon03 icon Sprite.
                NPC04_make.NPC04_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC04_make.NPC04_struct.clothes_sp.spriteName = "weapon_nothing";

                // NPC 캐릭터 armor 이미지 바꾸기.
                npc04.change_clothes(0, 0, "");

                // 해당 npc armor enable Loca변수를 0으로 disable시켜줌.
                reset_npc_str = "npc" + ((int)unequiped_npc + 1).ToString() + "_armor_enable";
                PlayerPrefs.SetInt(reset_npc_str, 0);
                PlayerPrefs.Save();

                // NPC01 캐릭터 damage에 베기 추가 공격력 reset.
                GameData_weapon.reset_armor_skill_func(equiped_armor_index);
                NPC04_make.NPC04_struct.skill_label.GetComponent<UILabel>().text = "없음";
                break;

            case 4:
                // Change the NPC Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                NPC05_make npc05 = NPC05_make.NPC05_struct.gameobject.GetComponent<NPC05_make>();

                // Change the NPC Weapon icon Sprite.
                NPC05_make.NPC05_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC05_make.NPC05_struct.clothes_sp.spriteName = "weapon_nothing";

                // NPC 캐릭터 armor 이미지 바꾸기.
                npc05.change_clothes(0, 0, "");

                // 해당 npc armor enable Loca변수를 0으로 disable시켜줌.
                reset_npc_str = "npc" + ((int)unequiped_npc + 1).ToString() + "_armor_enable";
                PlayerPrefs.SetInt(reset_npc_str, 0);
                PlayerPrefs.Save();

                // NPC01 캐릭터 damage에 베기 추가 공격력 reset.
                GameData_weapon.reset_armor_skill_func(equiped_armor_index);
                NPC05_make.NPC05_struct.skill_label.GetComponent<UILabel>().text = "없음";
                break;

            case 5:
                // Change the NPC Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                NPC06_make npc06 = NPC06_make.NPC06_struct.gameobject.GetComponent<NPC06_make>();

                // Change the NPC Weapon icon Sprite.
                NPC06_make.NPC06_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC06_make.NPC06_struct.clothes_sp.spriteName = "weapon_nothing";

                // NPC 캐릭터 armor 이미지 바꾸기.
                npc06.change_clothes(0, 0, "");

                // 해당 npc armor enable Loca변수를 0으로 disable시켜줌.
                reset_npc_str = "npc" + ((int)unequiped_npc + 1).ToString() + "_armor_enable";
                PlayerPrefs.SetInt(reset_npc_str, 0);
                PlayerPrefs.Save();

                // NPC01 캐릭터 damage에 베기 추가 공격력 reset.
                GameData_weapon.reset_armor_skill_func(equiped_armor_index);
                NPC06_make.NPC06_struct.skill_label.GetComponent<UILabel>().text = "없음";
                break;

            case 6:
                // Change the NPC Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                NPC07_make npc07 = NPC06_make.NPC06_struct.gameobject.GetComponent<NPC07_make>();

                // Change the NPC Weapon icon Sprite.
                NPC07_make.NPC07_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC07_make.NPC07_struct.clothes_sp.spriteName = "weapon_nothing";

                // NPC 캐릭터 armor 이미지 바꾸기.
                npc07.change_clothes(0, 0, "");

                // 해당 npc armor enable Loca변수를 0으로 disable시켜줌.
                reset_npc_str = "npc" + ((int)unequiped_npc + 1).ToString() + "_armor_enable";
                PlayerPrefs.SetInt(reset_npc_str, 0);
                PlayerPrefs.Save();

                // NPC01 캐릭터 damage에 베기 추가 공격력 reset.
                GameData_weapon.reset_armor_skill_func(equiped_armor_index);
                NPC07_make.NPC07_struct.skill_label.GetComponent<UILabel>().text = "없음";
                break;

            case 7:
                // Change the NPC Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                NPC08_make npc08 = NPC08_make.NPC08_struct.gameobject.GetComponent<NPC08_make>();

                // Change the NPC Weapon icon Sprite.
                NPC08_make.NPC08_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC08_make.NPC08_struct.clothes_sp.spriteName = "weapon_nothing";

                // NPC 캐릭터 armor 이미지 바꾸기.
                npc08.change_clothes(0, 0, "");

                // 해당 npc armor enable Loca변수를 0으로 disable시켜줌.
                reset_npc_str = "npc" + ((int)unequiped_npc + 1).ToString() + "_armor_enable";
                PlayerPrefs.SetInt(reset_npc_str, 0);
                PlayerPrefs.Save();

                // NPC01 캐릭터 damage에 베기 추가 공격력 reset.
                GameData_weapon.reset_armor_skill_func(equiped_armor_index);
                NPC08_make.NPC08_struct.skill_label.GetComponent<UILabel>().text = "없음";
                break;

            case 8:
                // Change the NPC Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                NPC09_make npc09 = NPC09_make.NPC09_struct.gameobject.GetComponent<NPC09_make>();

                // Change the NPC Weapon icon Sprite.
                NPC09_make.NPC09_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC09_make.NPC09_struct.clothes_sp.spriteName = "weapon_nothing";

                // NPC 캐릭터 armor 이미지 바꾸기.
                npc09.change_clothes(0, 0, "");

                // 해당 npc armor enable Loca변수를 0으로 disable시켜줌.
                reset_npc_str = "npc" + ((int)unequiped_npc + 1).ToString() + "_armor_enable";
                PlayerPrefs.SetInt(reset_npc_str, 0);
                PlayerPrefs.Save();

                // NPC01 캐릭터 damage에 베기 추가 공격력 reset.
                GameData_weapon.reset_armor_skill_func(equiped_armor_index);
                NPC09_make.NPC09_struct.skill_label.GetComponent<UILabel>().text = "없음";
                break;

            case 9:
                // Change the NPC Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                NPC10_make npc10 = NPC10_make.NPC10_struct.gameobject.GetComponent<NPC10_make>();

                // Change the NPC Weapon icon Sprite.
                NPC10_make.NPC10_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC10_make.NPC10_struct.clothes_sp.spriteName = "weapon_nothing";

                // NPC 캐릭터 armor 이미지 바꾸기.
                npc10.change_clothes(0, 0, "");

                // 해당 npc armor enable Loca변수를 0으로 disable시켜줌.
                reset_npc_str = "npc" + ((int)unequiped_npc + 1).ToString() + "_armor_enable";
                PlayerPrefs.SetInt(reset_npc_str, 0);
                PlayerPrefs.Save();

                // NPC01 캐릭터 damage에 베기 추가 공격력 reset.
                GameData_weapon.reset_armor_skill_func(equiped_armor_index);
                NPC10_make.NPC10_struct.skill_label.GetComponent<UILabel>().text = "없음";
                break;

            case 10:
                // Change the NPC Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                NPC11_make npc11 = NPC11_make.NPC11_struct.gameobject.GetComponent<NPC11_make>();

                // Change the NPC Weapon icon Sprite.
                NPC11_make.NPC11_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC11_make.NPC11_struct.clothes_sp.spriteName = "weapon_nothing";

                // NPC 캐릭터 armor 이미지 바꾸기.
                npc11.change_clothes(0, 0, "");

                // 해당 npc armor enable Loca변수를 0으로 disable시켜줌.
                reset_npc_str = "npc" + ((int)unequiped_npc + 1).ToString() + "_armor_enable";
                PlayerPrefs.SetInt(reset_npc_str, 0);
                PlayerPrefs.Save();

                // NPC01 캐릭터 damage에 베기 추가 공격력 reset.
                GameData_weapon.reset_armor_skill_func(equiped_armor_index);
                NPC11_make.NPC11_struct.skill_label.GetComponent<UILabel>().text = "없음";
                break;

            case 11:
                // Change the NPC Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                NPC12_make npc12 = NPC12_make.NPC12_struct.gameobject.GetComponent<NPC12_make>();

                // Change the NPC Weapon icon Sprite.
                NPC12_make.NPC12_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC12_make.NPC12_struct.clothes_sp.spriteName = "weapon_nothing";

                // NPC 캐릭터 armor 이미지 바꾸기.
                npc12.change_clothes(0, 0, "");

                // 해당 npc armor enable Loca변수를 0으로 disable시켜줌.
                reset_npc_str = "npc" + ((int)unequiped_npc + 1).ToString() + "_armor_enable";
                PlayerPrefs.SetInt(reset_npc_str, 0);
                PlayerPrefs.Save();

                // NPC01 캐릭터 damage에 베기 추가 공격력 reset.
                GameData_weapon.reset_armor_skill_func(equiped_armor_index);
                NPC12_make.NPC12_struct.skill_label.GetComponent<UILabel>().text = "없음";
                break;

            default:
                print("NPC Index Error!!!");
                break;
        }
    }

	// 해당 NPC에게 선택한 Wing을 장착하게 하는 함수.
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

            // NPC1 캐릭터 coin획득량에 armor skill 추가.
            GameData_weapon.get_wing_skill_func(equip_weapon_index, NPC_INDEX.NPC01);

            // NPC01 캐릭터 wing 이미지 바꾸기.
            npc01.change_wing(_wing_index, _wing_type);

			break;

        case NPC_INDEX.NPC02:
            // Change the NPC02 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
            NPC02_make npc02 = NPC02_make.NPC02_struct.gameobject.GetComponent<NPC02_make>();

            // Change the NPC02 Clothes icon Sprite.
            NPC02_make.NPC02_struct.wing_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC02_make.NPC02_struct.wing_sp.spriteName = GameData.to_change_npc_struct.To_Change_wing_type + GameData.to_change_npc_struct.wing_index.ToString();

            // NPC02 캐릭터 coin획득량에 armor skill 추가.
            GameData_weapon.get_wing_skill_func(equip_weapon_index, NPC_INDEX.NPC02);

            // NPC02 캐릭터 wing 이미지 바꾸기.
            npc02.change_wing(_wing_index, _wing_type);

            break;

        case NPC_INDEX.NPC03:
            // Change the NPC03 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
            NPC03_make npc03 = NPC03_make.NPC03_struct.gameobject.GetComponent<NPC03_make>();

            // Change the NPC03 Clothes icon Sprite.
            NPC03_make.NPC03_struct.wing_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC03_make.NPC03_struct.wing_sp.spriteName = GameData.to_change_npc_struct.To_Change_wing_type + GameData.to_change_npc_struct.wing_index.ToString();

            // NPC03 캐릭터 coin획득량에 armor skill 추가.
            GameData_weapon.get_wing_skill_func(equip_weapon_index, NPC_INDEX.NPC03);

            // NPC03 캐릭터 wing 이미지 바꾸기.
            npc03.change_wing(_wing_index, _wing_type);

            break;

        case NPC_INDEX.NPC04:
            // Change the NPC04 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
            NPC04_make npc04 = NPC04_make.NPC04_struct.gameobject.GetComponent<NPC04_make>();

            // Change the NPC04 Clothes icon Sprite.
            NPC04_make.NPC04_struct.wing_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC04_make.NPC04_struct.wing_sp.spriteName = GameData.to_change_npc_struct.To_Change_wing_type + GameData.to_change_npc_struct.wing_index.ToString();

            // NPC04 캐릭터 coin획득량에 armor skill 추가.
            GameData_weapon.get_wing_skill_func(equip_weapon_index, NPC_INDEX.NPC04);

            // NPC04 캐릭터 wing 이미지 바꾸기.
            npc04.change_wing(_wing_index, _wing_type);

            break;

        case NPC_INDEX.NPC05:
            // Change the NPC05 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
            NPC05_make npc05 = NPC05_make.NPC05_struct.gameobject.GetComponent<NPC05_make>();

            // Change the NPC05 Clothes icon Sprite.
            NPC05_make.NPC05_struct.wing_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC05_make.NPC05_struct.wing_sp.spriteName = GameData.to_change_npc_struct.To_Change_wing_type + GameData.to_change_npc_struct.wing_index.ToString();

            // NPC05 캐릭터 coin획득량에 armor skill 추가.
            GameData_weapon.get_wing_skill_func(equip_weapon_index, NPC_INDEX.NPC05);

            // NPC05 캐릭터 wing 이미지 바꾸기.
            npc05.change_wing(_wing_index, _wing_type);

            break;

        case NPC_INDEX.NPC06:
            // Change the NPC06 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
            NPC06_make npc06 = NPC06_make.NPC06_struct.gameobject.GetComponent<NPC06_make>();

            // Change the NPC06 Clothes icon Sprite.
            NPC06_make.NPC06_struct.wing_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC06_make.NPC06_struct.wing_sp.spriteName = GameData.to_change_npc_struct.To_Change_wing_type + GameData.to_change_npc_struct.wing_index.ToString();

            // NPC06 캐릭터 coin획득량에 armor skill 추가.
            GameData_weapon.get_wing_skill_func(equip_weapon_index, NPC_INDEX.NPC06);

            // NPC06 캐릭터 wing 이미지 바꾸기.
            npc06.change_wing(_wing_index, _wing_type);

            break;

        case NPC_INDEX.NPC07:
            // Change the NPC07 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
            NPC07_make npc07 = NPC07_make.NPC07_struct.gameobject.GetComponent<NPC07_make>();

            // Change the NPC07 Clothes icon Sprite.
            NPC07_make.NPC07_struct.wing_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC07_make.NPC07_struct.wing_sp.spriteName = GameData.to_change_npc_struct.To_Change_wing_type + GameData.to_change_npc_struct.wing_index.ToString();

            // NPC07 캐릭터 coin획득량에 armor skill 추가.
            GameData_weapon.get_wing_skill_func(equip_weapon_index, NPC_INDEX.NPC07);

            // NPC07 캐릭터 wing 이미지 바꾸기.
            npc07.change_wing(_wing_index, _wing_type);

            break;

        case NPC_INDEX.NPC08:
            // Change the NPC08 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
            NPC08_make npc08 = NPC08_make.NPC08_struct.gameobject.GetComponent<NPC08_make>();

            // Change the NPC08 Clothes icon Sprite.
            NPC08_make.NPC08_struct.wing_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC08_make.NPC08_struct.wing_sp.spriteName = GameData.to_change_npc_struct.To_Change_wing_type + GameData.to_change_npc_struct.wing_index.ToString();

            // NPC08 캐릭터 coin획득량에 armor skill 추가.
            GameData_weapon.get_wing_skill_func(equip_weapon_index, NPC_INDEX.NPC08);

            // NPC08 캐릭터 wing 이미지 바꾸기.
            npc08.change_wing(_wing_index, _wing_type);

            break;

        case NPC_INDEX.NPC09:
            // Change the NPC09 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
            NPC09_make npc09 = NPC09_make.NPC09_struct.gameobject.GetComponent<NPC09_make>();

            // Change the NPC09 Clothes icon Sprite.
            NPC09_make.NPC09_struct.wing_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC09_make.NPC09_struct.wing_sp.spriteName = GameData.to_change_npc_struct.To_Change_wing_type + GameData.to_change_npc_struct.wing_index.ToString();

            // NPC09 캐릭터 coin획득량에 armor skill 추가.
            GameData_weapon.get_wing_skill_func(equip_weapon_index, NPC_INDEX.NPC09);

            // NPC09 캐릭터 wing 이미지 바꾸기.
            npc09.change_wing(_wing_index, _wing_type);

            break;

        case NPC_INDEX.NPC10:
            // Change the NPC10 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
            NPC10_make npc10 = NPC10_make.NPC10_struct.gameobject.GetComponent<NPC10_make>();

            // Change the NPC10 Clothes icon Sprite.
            NPC10_make.NPC10_struct.wing_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC10_make.NPC10_struct.wing_sp.spriteName = GameData.to_change_npc_struct.To_Change_wing_type + GameData.to_change_npc_struct.wing_index.ToString();

            // NPC10 캐릭터 coin획득량에 armor skill 추가.
            GameData_weapon.get_wing_skill_func(equip_weapon_index, NPC_INDEX.NPC10);

            // NPC10 캐릭터 wing 이미지 바꾸기.
            npc10.change_wing(_wing_index, _wing_type);

            break;

        case NPC_INDEX.NPC11:
            // Change the NPC11 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
            NPC11_make npc11 = NPC11_make.NPC11_struct.gameobject.GetComponent<NPC11_make>();

            // Change the NPC11 Clothes icon Sprite.
            NPC11_make.NPC11_struct.wing_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC11_make.NPC11_struct.wing_sp.spriteName = GameData.to_change_npc_struct.To_Change_wing_type + GameData.to_change_npc_struct.wing_index.ToString();

            // NPC11 캐릭터 coin획득량에 armor skill 추가.
            GameData_weapon.get_wing_skill_func(equip_weapon_index, NPC_INDEX.NPC11);

            // NPC11 캐릭터 wing 이미지 바꾸기.
            npc11.change_wing(_wing_index, _wing_type);

            break;

        case NPC_INDEX.NPC12:
            // Change the NPC12 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
            NPC12_make npc12 = NPC12_make.NPC12_struct.gameobject.GetComponent<NPC12_make>();

            // Change the NPC12 Clothes icon Sprite.
            NPC12_make.NPC12_struct.wing_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC12_make.NPC12_struct.wing_sp.spriteName = GameData.to_change_npc_struct.To_Change_wing_type + GameData.to_change_npc_struct.wing_index.ToString();

            // NPC012 캐릭터 coin획득량에 armor skill 추가.
            GameData_weapon.get_wing_skill_func(equip_weapon_index, NPC_INDEX.NPC12);

            // NPC12 캐릭터 wing 이미지 바꾸기.
            npc12.change_wing(_wing_index, _wing_type);

            break;

        default:
            print("Can`t find NPC index");
            break;               
        }

		// NPC선택 후 popUp window 비활성화.
		GameData.wing_sel_popup_window_obj.SetActive(false);

	}
   
   
}
