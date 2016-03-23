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

    public struct bow_struct
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
        public static bow_struct[] bow_struct_object = new bow_struct[35];

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
            weapon_struct_object[_weapon_index].level = weapon_struct_object[_weapon_index].level + 1;
            weapon_struct_object[_weapon_index].damage = (ulong)(weapon_struct_object[_weapon_index].level * 2 + 2);
            weapon_struct_object[_weapon_index].upgrade_cost = (ulong)(30 + weapon_struct_object[_weapon_index].level * 2);

            // Next Weapon Enable.
            if (weapon_struct_object[_weapon_index].level == 2)
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
