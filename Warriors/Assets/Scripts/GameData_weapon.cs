using UnityEngine;
using System.Collections;
using gamedata;

namespace gamedata_weapon
{

    // Weapon Struct
    public struct Weapon_struct
    {
        public int enable;
        public int level;
        public ulong damage;
        public ulong upgrade_cost;
        public string skill;
		public popup_window_button_mgr.NPC_INDEX equiped_this_weapon_npc_index;

		public GameObject lvup_button;

    }

    public struct Bow_struct
    {
        public int enable;
        public int level;
        public ulong damage;
        public ulong upgrade_cost;
        public string skill;
        public popup_window_button_mgr.NPC_INDEX equiped_this_weapon_npc_index;

        public GameObject lvup_button;

    }

    public struct Wing_struct
    {
        public int enable;
        public GameObject wing_enable_gameobject;
        public GameObject wing_buy_button;

        public ulong plus_gold;
        public ulong upgrade_cost;
        public string skill;

    }

	public struct Armor_struct
	{
		public int enable;      
        public GameObject armor_enable_gameobject;
        public GameObject armor_buy_button;

        public ulong plus_gold;
		public ulong upgrade_cost;
		public string skill;

	}

    public class GameData_weapon : MonoBehaviour
    {
        public static GameObject test_obj;

        public static bool check_toggle4_active = false;
        public static bool check_toggle6_active = false;

        // 처음 시작시 weapon struct 초기화.
        public static Weapon_struct[] weapon_struct_object = new Weapon_struct[25];

        // 처음 시작시 bow struct 초기화.
		public static Bow_struct[] bow_struct_object = new Bow_struct[25];

        // 처음 시작시 wing struct 초기화.
        public static Wing_struct[] wing_struct_object = new Wing_struct[20];

		// 처음 시작시 Armor struct 초기화.
		public static Armor_struct[] armor_struct_object = new Armor_struct[41];

        // Use this for initialization
        void Awake()
        {

            // ************************************************************************  weapon init ************************************************************************ //

            // 무기 데이터 초기화.
            for (int i = 0; i < 25; i++)
            {
                // 처음 시작시에는 무기 lock sprite를 on 시키기 위해 check할 변수를 false시켜줌.
                // 나중에 아래 변수는 playerprefas로 가져와야함.
                string get_weapon_enable = "weapon" + i.ToString() + "_enable";
                weapon_struct_object[i].enable = PlayerPrefs.GetInt(get_weapon_enable, 1);

                // 해당 무기 레벨을 setting해줌.
                string get_weapon_level = "weapon" + i.ToString() + "_level";
                weapon_struct_object[i].level = PlayerPrefs.GetInt(get_weapon_level, 1);

                if (weapon_struct_object[i].enable == 0)
                {
                    print(i.ToString() + "이 무기는 가지고 있음");
                    // 해당 무기를 가지고 있기 때문에 unlock_sprite를 false시켜줌.
                    string weapon_lock_sp = "_weapon" + i.ToString() + "_unlock_sprite";
                    GameObject.Find(weapon_lock_sp).SetActive(false);     
                }

                // 무기 레벨 up 버튼 GameObject Setting.
                weapon_struct_object[i].lvup_button = GameObject.Find("_weapon" + i.ToString() + "_lvup_button");

                // 가져온 무기의 레벨값으로 해당 무기 data struct에 setting.
                weapon_data_struct_update(i,weapon_struct_object[i].level);
                update_weapon_data_label(i);
            }

            // ************************************************************************  bow init ************************************************************************ //

            // 활 데이터 초기화.
            for (int i = 0; i < 25; i++)
            {
                // 처음 시작시에는 무기 lock sprite를 on 시키기 위해 check할 변수를 false시켜줌.
                // 나중에 아래 변수는 playerprefas로 가져와야함.
                string get_bow_enable = "bow" + i.ToString() + "_enable";
                bow_struct_object[i].enable = PlayerPrefs.GetInt(get_bow_enable, 1);

                // 해당 무기 레벨을 setting해줌.
                string get_bow_level = "bow" + i.ToString() + "_level";
                bow_struct_object[i].level = PlayerPrefs.GetInt(get_bow_level, 1);

                if (bow_struct_object[i].enable == 0)
                {
                    print(i.ToString() + "이 활은 가지고 있음");
                    // 해당 무기를 가지고 있기 때문에 unlock_sprite를 false시켜줌.
                    string bow_lock_sp = "_bow" + i.ToString() + "_unlock_sprite";
                    GameObject.Find(bow_lock_sp).SetActive(false);
                }

                // 무기 레벨 up 버튼 GameObject Setting.
                bow_struct_object[i].lvup_button = GameObject.Find("_bow" + i.ToString() + "_lvup_button");

                // 가져온 무기의 레벨값으로 해당 무기 data struct에 setting.
                bow_data_struct_update(i, bow_struct_object[i].level);
                update_bow_data_label(i);
            }

            // ************************************************************************  armor init ************************************************************************ //                     

            // Armor Button All disable except 0.
            for(int i=1; i < 41; i++)
            {
                // 게임 시작시 모든 Armor 구매 버튼은 비활성화 시켜줌 아래 for문에 있는 함수에서 Local 변수를 보고 활성화 할지 결정.
                GameObject.Find("_armor" + i.ToString() +"_lvup_button").GetComponent<UIButton>().isEnabled = false;
            }
            
            // 아머 데이터 초기화.
			for (int i = 0; i < 41; i++)
			{
                // Armor 레벨 up 버튼 GameObject Setting.
                armor_struct_object[i].armor_buy_button = GameObject.Find("_armor" + i.ToString() + "_lvup_button");

                // unlock sprite가 있음에도 그 밑에 있는 버튼이 클릭 되어지는걸 방지하기 위해 밑에 있는  object들을 비활성화 시켜줌.
                armor_struct_object[i].armor_enable_gameobject = GameObject.Find("_armor" + i.ToString() +"_enable");
                armor_struct_object[i].armor_enable_gameobject.SetActive(false);
                
				Armor_data_struct_update(i);
				update_armor_data_label(i);
			}
            
            // ************************************************************************  wing init ************************************************************************ //

            // Wing Button All disable except 0.
            for(int i=1; i < 20; i++)
            {
                // 게임 시작시 모든 Armor 구매 버튼은 비활성화 시켜줌 아래 for문에 있는 함수에서 Local 변수를 보고 활성화 할지 결정.
                GameObject.Find("_wing" + i.ToString() +"_lvup_button").GetComponent<UIButton>().isEnabled = false;
            }            
            
            // 망토 데이터 초기화.
            for (int i = 0; i < 20; i++)
            {
                // Armor 레벨 up 버튼 GameObject Setting.
                wing_struct_object[i].wing_buy_button = GameObject.Find("_wing" + i.ToString() + "_lvup_button");

                // unlock sprite가 있음에도 그 밑에 있는 버튼이 클릭 되어지는걸 방지하기 위해 밑에 있는  object들을 비활성화 시켜줌.
                wing_struct_object[i].wing_enable_gameobject = GameObject.Find("_wing" + i.ToString() +"_enable");
                wing_struct_object[i].wing_enable_gameobject.SetActive(false);
                
				Wing_data_struct_update(i);
				update_wing_data_label(i);
            }

           
            
        }


        // ************************************************************************  Weapon Functions ************************************************************************ //

        public static void weapon_data_struct_update(int _weapon_index,int _level)
        {
            weapon_struct_object[_weapon_index].level = _level;
            weapon_struct_object[_weapon_index].damage = (ulong)(_level * 2 + 2);
            weapon_struct_object[_weapon_index].upgrade_cost = (ulong)(30 + _level * 2);

            // 무기가 어떤 npc에 장착되어 있는지 Local변수를 가져옴.
            // NPC가 Weapon을 장착하고 있는 상태에서 Weapon Level up 시 update해줄 변수들.
            string get_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";
            switch (PlayerPrefs.GetInt(get_weapon_to_npc_str, 100))
            {

                case 1:
                    NPC01_make.NPC01_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC01_make.NPC01_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC01_make.NPC01_struct.add_damage);
                    break;

                case 2:
                    NPC02_make.NPC02_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC02_make.NPC02_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC02_make.NPC02_struct.add_damage);
                    break;

                case 3:
                    NPC03_make.NPC03_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC03_make.NPC03_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC03_make.NPC03_struct.add_damage);
                    break;

                case 7:
                    NPC07_make.NPC07_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC07_make.NPC07_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC07_make.NPC07_struct.add_damage);
                    break;

                case 8:
                    NPC08_make.NPC08_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC08_make.NPC08_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC08_make.NPC08_struct.add_damage);
                    break;

                case 9:
                    NPC09_make.NPC09_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC09_make.NPC09_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC09_make.NPC09_struct.add_damage);
                    break;
                default:
                    //print("해당 무기는 npc가 가지고 있지 않음.");
                    break;
            }

        }

        // 무기 레벨 UP && Data Update.
        public static void levelup_weapon_data_struct(int _weapon_index)
        {
  
            // 무기 레벨업 공식.
            weapon_struct_object[_weapon_index].level = weapon_struct_object[_weapon_index].level + 1;
            weapon_struct_object[_weapon_index].damage = (ulong)(weapon_struct_object[_weapon_index].level*2 +2);
            weapon_struct_object[_weapon_index].upgrade_cost = (ulong)(30 + weapon_struct_object[_weapon_index].level * 2);

            // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
            string set_weapon_level_str = "weapon" + _weapon_index.ToString() + "_level";
            PlayerPrefs.SetInt(set_weapon_level_str, weapon_struct_object[_weapon_index].level);
            PlayerPrefs.Save();

            // 무기가 어떤 npc에 장착되어 있는지 Local변수를 가져옴.
            // NPC가 Weapon을 장착하고 있는 상태에서 Weapon Level up 시 update해줄 변수들.
            string get_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";
            switch (PlayerPrefs.GetInt(get_weapon_to_npc_str, 100)) 
			{
				case 1:
				    NPC01_make.NPC01_struct.add_damage = weapon_struct_object [_weapon_index].damage;
				    NPC01_make.NPC01_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC01_make.NPC01_struct.add_damage);
				    break;
		
				case 2:
				    NPC02_make.NPC02_struct.add_damage = weapon_struct_object [_weapon_index].damage;
				    NPC02_make.NPC02_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC02_make.NPC02_struct.add_damage);
				    break;

				case 3:
				    NPC03_make.NPC03_struct.add_damage = weapon_struct_object [_weapon_index].damage;
				    NPC03_make.NPC03_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC03_make.NPC03_struct.add_damage);
				    break;

				case 7:
				    NPC07_make.NPC07_struct.add_damage = weapon_struct_object [_weapon_index].damage;
				    NPC07_make.NPC07_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC07_make.NPC07_struct.add_damage);
				    break;

				case 8:
				    NPC08_make.NPC08_struct.add_damage = weapon_struct_object [_weapon_index].damage;
				    NPC08_make.NPC08_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC08_make.NPC08_struct.add_damage);
				    break;

				case 9:
				    NPC09_make.NPC09_struct.add_damage = weapon_struct_object [_weapon_index].damage;
				    NPC09_make.NPC09_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC09_make.NPC09_struct.add_damage);
				    break;

                default:
                    print("해당 무기는 npc가 가지고 있지 않음.");
                    break;

			}
        }

        // 무기 버튼 && 라벨 Update.
        public static  void update_weapon_data_label(int _weapon_index)
        {
            string level_label = "_weapon" + _weapon_index.ToString() + "_level_label";
            string damage_label = "_weapon" + _weapon_index.ToString() + "_damage_label";
            string lvup_cost_label = "_weapon" + _weapon_index.ToString() + "_upgrade_cost_label";

            GameObject.Find(level_label).GetComponent<UILabel>().text = weapon_struct_object[_weapon_index].level.ToString();
            GameObject.Find(damage_label).GetComponent<UILabel>().text = GameData.int_to_label_format(weapon_struct_object[_weapon_index].damage);
            GameObject.Find(lvup_cost_label).GetComponent<UILabel>().text = GameData.int_to_label_format(weapon_struct_object[_weapon_index].upgrade_cost);
        }


        public static void equip_the_weapon(int _weapon_index, popup_window_button_mgr.NPC_INDEX _npc_index)
        {
			// 무기 change, reset the before add damage.
			GameData.slash1_struct.add_damage = 0;
			GameData.slash2_struct.add_damage = 0;
			GameData.slash3_struct.add_damage = 0;
			GameData.slash4_struct.add_damage = 0;
			GameData.slash5_struct.add_damage = 0;

            string set_weapon_to_npc_str;
            // NPC에 Damage 추가 && NPC Damage 추가 Label Update.
            switch (_npc_index)
            {
			case popup_window_button_mgr.NPC_INDEX.NPC01:
					weapon_struct_object [_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC01;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    print("To save weapon index :" + _weapon_index.ToString());
                    set_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_weapon_to_npc_str, 1);                                                    // 1 -> NPC01
                    PlayerPrefs.Save();

                    NPC01_make.NPC01_struct.add_damage = weapon_struct_object [_weapon_index].damage;
				    NPC01_make.NPC01_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC01_make.NPC01_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC02:
					weapon_struct_object [_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC02;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    print("To save weapon index :" + _weapon_index.ToString());
                    set_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_weapon_to_npc_str, 2);                                                    // 2 -> NPC02
                    PlayerPrefs.Save();

                    NPC02_make.NPC02_struct.add_damage = weapon_struct_object [_weapon_index].damage;
					NPC02_make.NPC02_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC02_make.NPC02_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC03:
					weapon_struct_object [_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC03;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    print("To save weapon index :" + _weapon_index.ToString());
                    set_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_weapon_to_npc_str, 3);                                                    // 3 -> NPC03
                    PlayerPrefs.Save();

                    NPC03_make.NPC03_struct.add_damage = weapon_struct_object [_weapon_index].damage;
					NPC03_make.NPC03_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC03_make.NPC03_struct.add_damage);
                    break;
				case popup_window_button_mgr.NPC_INDEX.NPC07:
					weapon_struct_object [_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC07;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    print("To save weapon index :" + _weapon_index.ToString());
                    set_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_weapon_to_npc_str, 7);                                                    // 7 -> NPC07
                    PlayerPrefs.Save();

                    NPC07_make.NPC07_struct.add_damage = weapon_struct_object [_weapon_index].damage;
					NPC07_make.NPC07_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC07_make.NPC07_struct.add_damage);
					break;
				case popup_window_button_mgr.NPC_INDEX.NPC08:
					weapon_struct_object [_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC08;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    print("To save weapon index :" + _weapon_index.ToString());
                    set_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_weapon_to_npc_str, 8);                                                    // 8 -> NPC08
                    PlayerPrefs.Save();

                    NPC08_make.NPC08_struct.add_damage = weapon_struct_object [_weapon_index].damage;
					NPC08_make.NPC08_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC08_make.NPC08_struct.add_damage);
					break;
				case popup_window_button_mgr.NPC_INDEX.NPC09:
					weapon_struct_object [_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC09;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    print("To save weapon index :" + _weapon_index.ToString());
                    set_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_weapon_to_npc_str, 9);                                                    // 9 -> NPC09
                    PlayerPrefs.Save();

                    NPC09_make.NPC09_struct.add_damage = weapon_struct_object [_weapon_index].damage;
					NPC09_make.NPC09_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC09_make.NPC09_struct.add_damage);
					break;
            }

			// weapon별 스킬 추가.
            switch(_weapon_index)
            {
				case 0:
                    // weapon1 스킬 추가. < slash1에 Damage 추가. >
                    GameData.slash1_struct.add_damage = 100;
					GameData.slash1_damage_plus_label.GetComponent<UILabel>().text = GameData.int_to_label_format (GameData.slash1_struct.add_damage);
                    break;
                case 1:
					// weapon2 스킬 추가. < slash2에 Damage 추가. >
					GameData.slash2_struct.add_damage = 100;
					GameData.slash2_damage_plus_label.GetComponent<UILabel>().text = GameData.int_to_label_format (GameData.slash2_struct.add_damage);
					break;
				case 2:
					// weapon3 스킬 추가. < slash3에 Damage 추가. >
					GameData.slash3_struct.add_damage = 100;
					GameData.slash3_damage_plus_label.GetComponent<UILabel>().text = GameData.int_to_label_format (GameData.slash3_struct.add_damage);
					break;
				case 3:
					// weapon4 스킬 추가. < slash4에 Damage 추가. >
					GameData.slash4_struct.add_damage = 100;
					GameData.slash4_damage_plus_label.GetComponent<UILabel>().text = GameData.int_to_label_format (GameData.slash4_struct.add_damage);
					break;
				case 4:
					// weapon5 스킬 추가. < slash5에 Damage 추가. >
					GameData.slash5_struct.add_damage = 100;
					GameData.slash5_damage_plus_label.GetComponent<UILabel>().text = GameData.int_to_label_format (GameData.slash5_struct.add_damage);
					break;

            }

        }
        // ************************************************************************  bow Functions ************************************************************************ //

        // 활 레벨 UP && Data Update.
        public static void bow_data_struct_update(int _weapon_index,int _level)
        {
            // 활 레벨 공식.
            bow_struct_object[_weapon_index].level = _level;
            bow_struct_object[_weapon_index].damage = (ulong)(_level * 2 + 2);
            bow_struct_object[_weapon_index].upgrade_cost = (ulong)(30 + _level * 3);

            // 무기가 어떤 npc에 장착되어 있는지 Local변수를 가져옴.
            // NPC가 Weapon을 장착하고 있는 상태에서 Weapon Level up 시 update해줄 변수들.
            string get_weapon_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
            switch (PlayerPrefs.GetInt(get_weapon_to_npc_str, 100))
            {

                case 4:
                    NPC04_make.NPC04_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC04_make.NPC04_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC04_make.NPC04_struct.add_damage);
                    break;

                case 5:
                    NPC05_make.NPC05_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC05_make.NPC05_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC05_make.NPC05_struct.add_damage);
                    break;

                case 6:
                    NPC06_make.NPC06_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC06_make.NPC06_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC06_make.NPC06_struct.add_damage);
                    break;

                case 10:
                    NPC10_make.NPC10_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC10_make.NPC10_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC10_make.NPC10_struct.add_damage);
                    break;

                case 11:
                    NPC11_make.NPC11_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC11_make.NPC11_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC11_make.NPC11_struct.add_damage);
                    break;

                case 12:
                    NPC12_make.NPC12_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC12_make.NPC12_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC12_make.NPC12_struct.add_damage);
                    break;
                default:
                    //print("해당 무기는 npc가 가지고 있지 않음.");
                    break;
            }
        }

        // 무기 레벨 UP && Data Update.
        public static void levelup_bow_data_struct(int _weapon_index)
        {
            // 무기 레벨업 공식.
            bow_struct_object[_weapon_index].level = bow_struct_object[_weapon_index].level + 1;
            bow_struct_object[_weapon_index].damage = (ulong)(bow_struct_object[_weapon_index].level * 2 + 2);
            bow_struct_object[_weapon_index].upgrade_cost = (ulong)(30 + bow_struct_object[_weapon_index].level * 2);

            // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
            string set_bow_level_str = "bow" + _weapon_index.ToString() + "_level";
            PlayerPrefs.SetInt(set_bow_level_str, bow_struct_object[_weapon_index].level);
            PlayerPrefs.Save();

            // 무기가 어떤 npc에 장착되어 있는지 Local변수를 가져옴.
            // NPC가 Weapon을 장착하고 있는 상태에서 Weapon Level up 시 update해줄 변수들.
            string get_bow_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
            switch (PlayerPrefs.GetInt(get_bow_to_npc_str, 100))
            {
                case 4:
                    NPC04_make.NPC04_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC04_make.NPC04_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC04_make.NPC04_struct.add_damage);
                    break;

                case 5:
                    NPC05_make.NPC05_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC05_make.NPC05_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC05_make.NPC05_struct.add_damage);
                    break;

                case 6:
                    NPC06_make.NPC06_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC06_make.NPC06_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC06_make.NPC06_struct.add_damage);
                    break;

                case 10:
                    NPC10_make.NPC10_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC10_make.NPC10_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC10_make.NPC10_struct.add_damage);
                    break;

                case 11:
                    NPC11_make.NPC11_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC11_make.NPC11_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC11_make.NPC11_struct.add_damage);
                    break;

                case 12:
                    NPC12_make.NPC12_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC12_make.NPC12_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC12_make.NPC12_struct.add_damage);
                    break;

                default:
                    print("해당 무기는 npc가 가지고 있지 않음.");
                    break;

            }
        }

        public static void equip_the_bow(int _weapon_index, popup_window_button_mgr.NPC_INDEX _npc_index)
        {
          

            string set_bow_to_npc_str;
            // NPC에 Damage 추가 && NPC Damage 추가 Label Update.
            switch (_npc_index)
            {
                case popup_window_button_mgr.NPC_INDEX.NPC04:
                    bow_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC04;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    set_bow_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_bow_to_npc_str, 4);                                                    
                    PlayerPrefs.Save();

                    NPC04_make.NPC04_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC04_make.NPC04_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC04_make.NPC04_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC05:
                    bow_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC05;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    set_bow_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_bow_to_npc_str, 5);                                                   
                    PlayerPrefs.Save();

                    NPC05_make.NPC05_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC05_make.NPC05_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC05_make.NPC05_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC06:
                    bow_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC06;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    set_bow_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_bow_to_npc_str, 6);                                                   
                    PlayerPrefs.Save();

                    NPC06_make.NPC06_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC06_make.NPC06_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC06_make.NPC06_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC10:
                    bow_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC10;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    set_bow_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_bow_to_npc_str,10);
                    PlayerPrefs.Save();

                    NPC10_make.NPC10_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC10_make.NPC10_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC10_make.NPC10_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC11:
                    bow_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC11;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    set_bow_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_bow_to_npc_str, 11);                                                   
                    PlayerPrefs.Save();

                    NPC11_make.NPC11_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC11_make.NPC11_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC11_make.NPC11_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC12:
                    bow_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC12;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    set_bow_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_bow_to_npc_str, 12);                                                  
                    PlayerPrefs.Save();

                    NPC12_make.NPC12_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC12_make.NPC12_struct.add_damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC12_make.NPC12_struct.add_damage);
                    break;
            }

            // bow별 스킬 추가.
            switch (_weapon_index)
            {
                case 0:
                    // bow1 스킬 추가.
                    break;
                case 1:
                    // bow2 스킬 추가. 
                    break;
                case 2:
                    // bow3 스킬 추가.
                    break;
                case 3:
                    // bow4 스킬 추가.
                    break;
                case 4:
                    // bow5 스킬 추가. 
                    break;

            }

        }

        // 활 버튼 && 라벨 Update.
        public static void update_bow_data_label(int _weapon_index)
        {
            string level_label = "_bow" + _weapon_index.ToString() + "_level_label";
            string damage_label = "_bow" + _weapon_index.ToString() + "_damage_label";
            string lvup_cost_label = "_bow" + _weapon_index.ToString() + "_upgrade_cost_label";
            string skill_label = "_bow" + _weapon_index.ToString() + "_skill_label";

            GameObject.Find(level_label).GetComponent<UILabel>().text = bow_struct_object[_weapon_index].level.ToString();
            GameObject.Find(damage_label).GetComponent<UILabel>().text = GameData.int_to_label_format(bow_struct_object[_weapon_index].damage);
            GameObject.Find(lvup_cost_label).GetComponent<UILabel>().text = GameData.int_to_label_format(bow_struct_object[_weapon_index].upgrade_cost);
        }

        // ************************************************************************  wing Functions ************************************************************************ //

        /// Wing data init 함수.
		public static void Wing_data_struct_update(int _wing_index)
		{
            // Wing Data 능력치 부여 공식.
			wing_struct_object[_wing_index].plus_gold = (ulong)(_wing_index * 2 + 2);
			wing_struct_object[_wing_index].upgrade_cost = (ulong)(30 + _wing_index * 2);

			// Wing is enable 되어 있는지 확인. ( 0 : false, 1 : true)
            int check_armor_enable = PlayerPrefs.GetInt("wing_"+_wing_index.ToString()+"_enable",0);
			if (check_armor_enable == 1)
			{
                // Armor is enable 해당 Armor status창 enable시켜줌.
				Wing_enable(_wing_index);
                
                // Next Armor 구매 버튼 활성화. 왜나하면 현재 Armor를 유저가 구매했기 때문에 Next Armor를 활성화 시켜줌.
                GameObject.Find("_wing" + (_wing_index + 1).ToString() +"lvup_button").GetComponent<UIButton>().isEnabled = true;
			}
		}


        // wing 레벨 UP && Data Update.
        public static void Wing_enable(int _wing_index)
        {
             // unlock되어 있는 wing object enable시킴.
            wing_struct_object[_wing_index].wing_enable_gameobject.SetActive(true);
            
             // Wing 구매시 Wing enable상태를 Local에 저장. ( 0 : false, 1 : true)
            string set_wing_enable_str = "wing" + _wing_index.ToString() + "_enable";
            PlayerPrefs.SetInt(set_wing_enable_str, 1);
            PlayerPrefs.Save(); 
            
            // unlock sprite 제거해줌.
            string unlock_armor_sprite = "_wing" + _wing_index.ToString() + "_unlock_sprite";
            GameObject.Find(unlock_armor_sprite).SetActive(false);  

            // Next wing 구매 버튼 활성화. 왜나하면 현재 wing를 유저가 구매했기 때문에 Next wing을 활성화 시켜줌.
            // check 다음 wing 구매할만큼의 보석을 가지고 있는지.
            if(GameData.coin_struct.gemstone > wing_struct_object[_wing_index+1].upgrade_cost)
            {
                GameObject.Find("_wing" + (_wing_index + 1).ToString() + "_lvup_button").GetComponent<UIButton>().isEnabled = true;
            }

        }

        // wing 버튼 && 라벨 Update.
        public static void update_wing_data_label(int _weapon_index)
        {
            string lvup_cost_label = "_wing" + _weapon_index.ToString() + "_upgrade_cost_label";
            GameObject.Find(lvup_cost_label).GetComponent<UILabel>().text = GameData.int_to_label_format(weapon_struct_object[_weapon_index].upgrade_cost);
        }

		// ************************************************************************  Armor Functions ************************************************************************ //



		/// Armor data init 함수.
		public static void Armor_data_struct_update(int _armor_index)
		{
            // Armor Data 능력치 부여 공식.
			armor_struct_object[_armor_index].plus_gold = (ulong)(_armor_index * 2 + 2);
			armor_struct_object[_armor_index].upgrade_cost = (ulong)(30 + _armor_index * 2);

			// Armor가 enable 되어 있는지 확인. ( 0 : false, 1 : true)
            int check_armor_enable = PlayerPrefs.GetInt("armor_"+_armor_index.ToString()+"_enable",0);
			if (check_armor_enable == 1)
			{
                // Armor is enable 해당 Armor status창 enable시켜줌.
				Armor_enable(_armor_index);
                
                // Next Armor 구매 버튼 활성화. 왜나하면 현재 Armor를 유저가 구매했기 때문에 Next Armor를 활성화 시켜줌.
                GameObject.Find("_armor" + (_armor_index + 1).ToString() +"lvup_button").GetComponent<UIButton>().isEnabled = true;
			}
		}
        
        /// Armor index를 가져와서 해당 Armor status창 enable 시켜줄 함수.
        public static void Armor_enable(int _armor_index)
        {
            // unlock되어 있는 armor object enable시킴.
            armor_struct_object[_armor_index].armor_enable_gameobject.SetActive(true);
            
             // Armor 구매시 Armor enable상태를 Local에 저장. ( 0 : false, 1 : true)
            string set_armor_enable_str = "armor" + _armor_index.ToString() + "_enable";
            PlayerPrefs.SetInt(set_armor_enable_str, 1);
            PlayerPrefs.Save(); 
            
            // unlock sprite 제거해줌.
            string unlock_armor_sprite = "_armor" + _armor_index.ToString() + "_unlock_sprite";
            GameObject.Find(unlock_armor_sprite).SetActive(false);

            // Next Armor 구매 버튼 활성화. 왜나하면 현재 Armor를 유저가 구매했기 때문에 Next Armor를 활성화 시켜줌.
            // check 다음 wing 구매할만큼의 보석을 가지고 있는지.
            if (GameData.coin_struct.gemstone > armor_struct_object[_armor_index + 1].upgrade_cost)
            {
                GameObject.Find("_armor" + (_armor_index + 1).ToString() + "_lvup_button").GetComponent<UIButton>().isEnabled = true;
            }

        }

		/// Armor 버튼 && 라벨 Update.
		public static void update_armor_data_label(int _armor_index)
		{
			string lvup_cost_label = "_armor" + _armor_index.ToString() + "_upgrade_cost_label";
			GameObject.Find(lvup_cost_label).GetComponent<UILabel>().text = GameData.int_to_label_format(armor_struct_object[_armor_index].upgrade_cost);
		}

        // ************************************************************************  common Functions ************************************************************************ //

        //check whether upgrade buttons are possiable or not
        public static void check_weapon_buttons_is_enable_or_not()
        {
            // 무기 버튼 체크.
            for (int i = 0; i < 25; i++)
            {
                if (GameData.coin_struct.gold >= weapon_struct_object[i].upgrade_cost)
                {
					weapon_struct_object [i].lvup_button.GetComponent<UIButton> ().isEnabled = true;
                }
                else
                {
					weapon_struct_object [i].lvup_button.GetComponent<UIButton> ().isEnabled = false;
                }
            }

            // 활 버튼 체크.
            for (int i = 0; i < 25; i++)
            {
                if (GameData.coin_struct.gold >= bow_struct_object[i].upgrade_cost)
                {
                    bow_struct_object[i].lvup_button.GetComponent<UIButton>().isEnabled = true;
                }
                else
                {
                    bow_struct_object[i].lvup_button.GetComponent<UIButton>().isEnabled = false;
                }
            }
        }

        public static void check_armor_buttons_is_enable_or_not()
        {
            // Armor 버튼 체크.
            for (int i = 0; i < 41; i++)
            {
                if (GameData.coin_struct.gemstone >= armor_struct_object[i].upgrade_cost)
                {
                    armor_struct_object[i].armor_buy_button.GetComponent<UIButton>().isEnabled = true;
                }
                else
                {
                    armor_struct_object[i].armor_buy_button.GetComponent<UIButton>().isEnabled = false;
                }
            }
        }

        public static void check_wing_buttons_is_enable_or_not()
        {
            // Armor 버튼 체크.
            for (int i = 0; i < 20; i++)
            {
                if (GameData.coin_struct.gemstone >= wing_struct_object[i].upgrade_cost)
                {
                    wing_struct_object[i].wing_buy_button.GetComponent<UIButton>().isEnabled = true;
                }
                else
                {
                    wing_struct_object[i].wing_buy_button.GetComponent<UIButton>().isEnabled = false;
                }
            }
        }

        public static void set_data_for_equip_weapon(string weapon_type, int equip_weapon_index)
		{
			switch (weapon_type) 
			{

			case "dagger-a":
				if (equip_weapon_index == 0) 
				{
					// weapon1 스킬 추가. < slash1에 Damage 추가. >
					GameData.slash1_struct.add_damage = 100;
					GameData.slash1_damage_plus_label.GetComponent<UILabel>().text = GameData.int_to_label_format (GameData.slash1_struct.add_damage);
				} else if (equip_weapon_index == 1) 
				{
					// weapon2 스킬 추가. < slash2에 Damage 추가. >
					GameData.slash2_struct.add_damage = 100;
					GameData.slash2_damage_plus_label.GetComponent<UILabel>().text = GameData.int_to_label_format (GameData.slash2_struct.add_damage);
				}
				break;

			case "sword-a":
				switch (equip_weapon_index) 
				{
					case 0:
					// weapon3 스킬 추가. < slash3에 Damage 추가. >
					GameData.slash3_struct.add_damage = 100;
					GameData.slash3_damage_plus_label.GetComponent<UILabel>().text = GameData.int_to_label_format (GameData.slash3_struct.add_damage);
					break;

					case 1:
					// weapon4 스킬 추가. < slash4에 Damage 추가. >
					GameData.slash4_struct.add_damage = 100;
					GameData.slash3_damage_plus_label.GetComponent<UILabel>().text = GameData.int_to_label_format (GameData.slash4_struct.add_damage);
					break;

					case 2:
					// weapon5 스킬 추가. < slash5에 Damage 추가. >
					GameData.slash5_struct.add_damage = 100;
					GameData.slash3_damage_plus_label.GetComponent<UILabel>().text = GameData.int_to_label_format (GameData.slash5_struct.add_damage);
					break;

					case 3:
					
					break;
				}
				break;
			}
		}
    }
}
