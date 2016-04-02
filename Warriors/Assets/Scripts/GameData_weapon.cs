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
        public bool enable;
        public int level;
        public ulong damage;
        public ulong upgrade_cost;
        public string skill;

    }

    public struct Wing_struct
    {
        public bool enable;
        public int level;
        public ulong damage;
        public ulong upgrade_cost;
        public string skill;

    }

	public struct Armor_struct
	{
		public bool enable;
		public int level;
		public ulong damage;
		public ulong upgrade_cost;
		public string skill;

	}

    public class GameData_weapon : MonoBehaviour
    {
        public static GameObject test_obj;

        // 처음 시작시 weapon struct 초기화.
        public static Weapon_struct[] weapon_struct_object = new Weapon_struct[35];

        // 처음 시작시 bow struct 초기화.
		public static Bow_struct[] bow_struct_object = new Bow_struct[35];

        // 처음 시작시 wing struct 초기화.
        public static Wing_struct[] wing_struct_object = new Wing_struct[35];

		// 처음 시작시 Armor struct 초기화.
		public static Armor_struct[] armor_struct_object = new Armor_struct[35];

        // Use this for initialization
        void Start()
        {

            // 무기 데이터 초기화.
            for (int i = 0; i < 4; i++)
            {
                // 처음 시작시에는 무기 lock sprite를 on 시키기 위해 check할 변수를 false시켜줌.
                // 나중에 아래 변수는 playerprefas로 가져와야함.
                string get_weapon_enable = "weapon" + i.ToString() + "_enable";
                weapon_struct_object[i].enable = PlayerPrefs.GetInt(get_weapon_enable, 1);

                if(weapon_struct_object[i].enable == 0)
                {
                    string weapon_lock_sp = "_weapon" + i.ToString() + "_unlock_sprite";
                    GameObject.Find(weapon_lock_sp).SetActive(false);
                }
                
                levelup_weapon_data_struct(i);
                update_weapon_data_label(i);
            }

            // 활 데이터 초기화.
            for (int i = 0; i < 2; i++)
            {
                levelup_bow_data_struct(i);
                update_bow_data_label(i);
            }

            // 망토 데이터 초기화.
            for (int i = 0; i < 1; i++)
            {
                levelup_wing_data_struct(i);
                update_wing_data_label(i);
            }

			// 아머 데이터 초기화.
			for (int i = 0; i < 1; i++)
			{
				levelup_wing_data_struct(i);
				update_wing_data_label(i);
			}

        }


        // ************************************************************************  Weapon Functions ************************************************************************ //

        // 무기 레벨 UP && Data Update.
        public static void levelup_weapon_data_struct(int _weapon_index)
        {

            weapon_struct_object[_weapon_index].level = weapon_struct_object[_weapon_index].level + 1;
            weapon_struct_object[_weapon_index].damage = (ulong)(weapon_struct_object[_weapon_index].level*2 +2);
            weapon_struct_object[_weapon_index].upgrade_cost = (ulong)(30 + weapon_struct_object[_weapon_index].level * 2);

			weapon_struct_object [_weapon_index].lvup_button = GameObject.Find ("_weapon"+_weapon_index.ToString()+"_lvup_button");


			// NPC가 Weapon을 장착하고 있는 상태에서 Weapon Level up 시 update해줄 변수들.
			switch (weapon_struct_object [_weapon_index].equiped_this_weapon_npc_index) 
			{
				case popup_window_button_mgr.NPC_INDEX.NPC01:
				NPC01_make.NPC01_struct.add_damage = weapon_struct_object [_weapon_index].damage;
				NPC01_make.NPC01_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC01_make.NPC01_struct.add_damage);
				break;
		
				case popup_window_button_mgr.NPC_INDEX.NPC02:
				NPC02_make.NPC02_struct.add_damage = weapon_struct_object [_weapon_index].damage;
				NPC02_make.NPC02_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC02_make.NPC02_struct.add_damage);
				break;

				case popup_window_button_mgr.NPC_INDEX.NPC03:
				NPC03_make.NPC03_struct.add_damage = weapon_struct_object [_weapon_index].damage;
				NPC03_make.NPC03_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC03_make.NPC03_struct.add_damage);
				break;

				case popup_window_button_mgr.NPC_INDEX.NPC07:
				NPC07_make.NPC07_struct.add_damage = weapon_struct_object [_weapon_index].damage;
				NPC07_make.NPC07_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC07_make.NPC07_struct.add_damage);
				break;

				case popup_window_button_mgr.NPC_INDEX.NPC08:
				NPC08_make.NPC08_struct.add_damage = weapon_struct_object [_weapon_index].damage;
				NPC08_make.NPC08_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC08_make.NPC08_struct.add_damage);
				break;

				case popup_window_button_mgr.NPC_INDEX.NPC09:
				NPC09_make.NPC09_struct.add_damage = weapon_struct_object [_weapon_index].damage;
				NPC09_make.NPC09_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC09_make.NPC09_struct.add_damage);
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

            // NPC에 Damage 추가 && NPC Damage 추가 Label Update.
            switch(_npc_index)
            {
			case popup_window_button_mgr.NPC_INDEX.NPC01:
					weapon_struct_object [_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC01;

					NPC01_make.NPC01_struct.add_damage = weapon_struct_object [_weapon_index].damage;
				    NPC01_make.NPC01_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC01_make.NPC01_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC02:
					weapon_struct_object [_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC02;

					NPC02_make.NPC02_struct.add_damage = weapon_struct_object [_weapon_index].damage;
					NPC02_make.NPC02_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC02_make.NPC02_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC03:
					weapon_struct_object [_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC03;
					
					NPC03_make.NPC03_struct.add_damage = weapon_struct_object [_weapon_index].damage;
					NPC03_make.NPC03_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC03_make.NPC03_struct.add_damage);
                    break;
				case popup_window_button_mgr.NPC_INDEX.NPC07:
					weapon_struct_object [_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC07;
					
					NPC07_make.NPC07_struct.add_damage = weapon_struct_object [_weapon_index].damage;
					NPC07_make.NPC07_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC07_make.NPC07_struct.add_damage);
					break;
				case popup_window_button_mgr.NPC_INDEX.NPC08:
					weapon_struct_object [_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC08;
					
					NPC08_make.NPC08_struct.add_damage = weapon_struct_object [_weapon_index].damage;
					NPC08_make.NPC08_struct.add_damage_label.GetComponent<UILabel>().text =  GameData.int_to_label_format (NPC08_make.NPC08_struct.add_damage);
					break;
				case popup_window_button_mgr.NPC_INDEX.NPC09:
					weapon_struct_object [_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC09;
					
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
        public static void levelup_bow_data_struct(int _weapon_index)
        {
            bow_struct_object[_weapon_index].level = bow_struct_object[_weapon_index].level + 1;
            bow_struct_object[_weapon_index].damage = (ulong)(bow_struct_object[_weapon_index].level * 2 + 2);
            bow_struct_object[_weapon_index].upgrade_cost = (ulong)(30 + bow_struct_object[_weapon_index].level * 2);

            // Next Weapon Enable.
            if (bow_struct_object[_weapon_index].level == 2)
            {
                //npc_gameobject.SetActive(true);
            }
        }

        // 활 버튼 && 라벨 Update.
        public static void update_bow_data_label(int _weapon_index)
        {
            string level_label = "_bow" + _weapon_index.ToString() + "_level_label";
            string damage_label = "_bow" + _weapon_index.ToString() + "_damage_label";
            string lvup_cost_label = "_bow" + _weapon_index.ToString() + "_upgrade_cost_label";
            string skill_label = "_bow" + _weapon_index.ToString() + "_skill_label";

            GameObject.Find(level_label).GetComponent<UILabel>().text = weapon_struct_object[_weapon_index].level.ToString();
            GameObject.Find(damage_label).GetComponent<UILabel>().text = GameData.int_to_label_format(weapon_struct_object[_weapon_index].damage);
            GameObject.Find(lvup_cost_label).GetComponent<UILabel>().text = GameData.int_to_label_format(weapon_struct_object[_weapon_index].upgrade_cost);
        }

        // ************************************************************************  wing Functions ************************************************************************ //

        // wing 레벨 UP && Data Update.
        public static void levelup_wing_data_struct(int _wing_index)
        {
            wing_struct_object[_wing_index].level = wing_struct_object[_wing_index].level + 1;
            wing_struct_object[_wing_index].damage = (ulong)(wing_struct_object[_wing_index].level * 2 + 2);
            wing_struct_object[_wing_index].upgrade_cost = (ulong)(30 + wing_struct_object[_wing_index].level * 2);

            // Next Weapon Enable.
            if (wing_struct_object[_wing_index].level == 2)
            {
                //npc_gameobject.SetActive(true);
            }
        }

        // wing 버튼 && 라벨 Update.
        public static void update_wing_data_label(int _weapon_index)
        {
            string level_label = "_wing" + _weapon_index.ToString() + "_level_label";
            string damage_label = "_wing" + _weapon_index.ToString() + "_damage_label";
            string lvup_cost_label = "_wing" + _weapon_index.ToString() + "_upgrade_cost_label";
            string skill_label = "_wing" + _weapon_index.ToString() + "_skill_label";

            //GameObject.Find(level_label).GetComponent<UILabel>().text = weapon_struct_object[_weapon_index].level.ToString();
           // GameObject.Find(damage_label).GetComponent<UILabel>().text = GameData.int_to_label_format(weapon_struct_object[_weapon_index].damage);
           // GameObject.Find(lvup_cost_label).GetComponent<UILabel>().text = GameData.int_to_label_format(weapon_struct_object[_weapon_index].upgrade_cost);
        }

		// ************************************************************************  Armor Functions ************************************************************************ //

		// Armor 레벨 UP && Data Update.
		public static void levelup_armor_data_struct(int _armor_index)
		{
			armor_struct_object[_armor_index].level = armor_struct_object[_armor_index].level + 1;
			armor_struct_object[_armor_index].damage = (ulong)(armor_struct_object[_armor_index].level * 2 + 2);
			armor_struct_object[_armor_index].upgrade_cost = (ulong)(30 + armor_struct_object[_armor_index].level * 2);

			// Next Armor Enable.
			if (wing_struct_object[_armor_index].level == 2)
			{
				//npc_gameobject.SetActive(true);
			}
		}

		// Armor 버튼 && 라벨 Update.
		public static void update_armor_data_label(int _armor_index)
		{
			string level_label = "_armor" + _armor_index.ToString() + "_level_label";
			string damage_label = "_armor" + _armor_index.ToString() + "_damage_label";
			string lvup_cost_label = "_armor" + _armor_index.ToString() + "_upgrade_cost_label";
			string skill_label = "_armor" + _armor_index.ToString() + "_skill_label";

			GameObject.Find(level_label).GetComponent<UILabel>().text = armor_struct_object[_armor_index].level.ToString();
			GameObject.Find(damage_label).GetComponent<UILabel>().text = GameData.int_to_label_format(armor_struct_object[_armor_index].damage);
			GameObject.Find(lvup_cost_label).GetComponent<UILabel>().text = GameData.int_to_label_format(armor_struct_object[_armor_index].upgrade_cost);
		}

        // ************************************************************************  common Functions ************************************************************************ //

        //check whether upgrade buttons are possiable or not
        public static void check_weapon_buttons_is_enable_or_not()
        {
            // 무기 버튼 체크.
            for (int i = 0; i < 4; i++)
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
