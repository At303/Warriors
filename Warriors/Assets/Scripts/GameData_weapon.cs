using UnityEngine;
using System.Collections;
using gamedata;

namespace gamedata_weapon
{

    // Weapon Struct
    public struct Weapon_struct
    {
        public bool enable;
        public int level;
        public ulong damage;
        public ulong upgrade_cost;
        public string skill;

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

            // Next Weapon Enable.
            if (weapon_struct_object[_weapon_index].level == 2)
            {
                //npc_gameobject.SetActive(true);
            }
        }

        // 무기 버튼 && 라벨 Update.
        public static  void update_weapon_data_label(int _weapon_index)
        {
            string level_label = "_weapon" + _weapon_index.ToString() + "_level_label";
            string damage_label = "_weapon" + _weapon_index.ToString() + "_damage_label";
            string lvup_cost_label = "_weapon" + _weapon_index.ToString() + "_upgrade_cost_label";
            string skill_label = "_weapon" + _weapon_index.ToString() + "_skill_label";

            GameObject.Find(level_label).GetComponent<UILabel>().text = weapon_struct_object[_weapon_index].level.ToString();
            GameObject.Find(damage_label).GetComponent<UILabel>().text = GameData.int_to_label_format(weapon_struct_object[_weapon_index].damage);
            GameObject.Find(lvup_cost_label).GetComponent<UILabel>().text = GameData.int_to_label_format(weapon_struct_object[_weapon_index].upgrade_cost);
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

            GameObject.Find(level_label).GetComponent<UILabel>().text = weapon_struct_object[_weapon_index].level.ToString();
            GameObject.Find(damage_label).GetComponent<UILabel>().text = GameData.int_to_label_format(weapon_struct_object[_weapon_index].damage);
            GameObject.Find(lvup_cost_label).GetComponent<UILabel>().text = GameData.int_to_label_format(weapon_struct_object[_weapon_index].upgrade_cost);
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
        public void check_weapon_buttons_is_enable_or_not()
        {
            // 무기 버튼 체크.
            for (int i = 0; i < 3; i++)
            {
                if (GameData.coin_struct.gold >= weapon_struct_object[i].upgrade_cost)
                {
                    string weapon_lvup_btn = "_weapon" + i.ToString() + "_lvup_button";
                    GameObject.Find(weapon_lvup_btn).GetComponent<UIButton>().isEnabled = true;
                }
                else
                {
                    string weapon_lvup_btn = "_weapon" + i.ToString() + "_lvup_button";
                    GameObject.Find(weapon_lvup_btn).GetComponent<UIButton>().isEnabled = false;
                }
            }
        }
    }
}
