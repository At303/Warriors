using UnityEngine;
using System.Collections;
using gamedata;
using System.Collections.Generic;

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
        public GameObject weapon_enable_gameobject;

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
        public GameObject bow_enable_gameobject;

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
        static int weapon_MAX = 0;

        // 처음 시작시 bow struct 초기화.
        public static Bow_struct[] bow_struct_object = new Bow_struct[25];
        static int bow_MAX = 0;

        // 처음 시작시 wing struct 초기화.
        public static Wing_struct[] wing_struct_object = new Wing_struct[20];

        // 처음 시작시 Armor struct 초기화.
        public static Armor_struct[] armor_struct_object = new Armor_struct[41];

        //Define a string to int dictionary in C#
        public static Dictionary<string, int> armorDIC = new Dictionary<string, int>();

        void amorDIC_Init()
        {
            armorDIC["steel-a00"] = 0;
            armorDIC["steel-a10"] = 1;
            armorDIC["steel-a20"] = 2;

            armorDIC["hood-a00"] = 3;
            armorDIC["hood-a01"] = 4;
            armorDIC["hood-a02"] = 5;
            armorDIC["hood-a03"] = 6;
            armorDIC["hood-a04"] = 7;
            armorDIC["hood-a10"] = 8;
            armorDIC["hood-a11"] = 9;
            armorDIC["hood-a12"] = 10;
            armorDIC["hood-a13"] = 11;
            armorDIC["hood-a14"] = 12;
            armorDIC["hood-a20"] = 13;
            armorDIC["hood-a21"] = 14;
            armorDIC["hood-a22"] = 15;
            armorDIC["hood-a23"] = 16;
            armorDIC["hood-a24"] = 17;

            armorDIC["robe-a00"] = 18;
            armorDIC["robe-a01"] = 19;
            armorDIC["robe-a02"] = 20;
            armorDIC["robe-a03"] = 21;
            armorDIC["robe-a04"] = 22;

            armorDIC["robe-a10"] = 23;
            armorDIC["robe-a11"] = 24;
            armorDIC["robe-a12"] = 25;
            armorDIC["robe-a13"] = 26;
            armorDIC["robe-a14"] = 27;

            armorDIC["uniform-a00"] = 28;
            armorDIC["uniform-a01"] = 29;
            armorDIC["uniform-a02"] = 30;
            armorDIC["uniform-a03"] = 31;
            armorDIC["uniform-a10"] = 32;
            armorDIC["uniform-a12"] = 33;
            armorDIC["uniform-a13"] = 34;

            armorDIC["ancient-b00"] = 35;
            armorDIC["ancient-b10"] = 36;
            armorDIC["ancient-b20"] = 37;
            armorDIC["mithril-a00"] = 38;
            armorDIC["mithril-a10"] = 39;
            armorDIC["mithril-a20"] = 40;
        }

        // Use this for initialization
        void Start()
        {
            // 보스씬 갔다가 다시 Main 씬왔을때 아래 변수들은 static이므로 0으로 resetting.
            bow_MAX = 0;
            weapon_MAX = 0;

            // armor Dictornary init.
            amorDIC_Init();

            // ************************************************************************  weapon init ************************************************************************ //

            // 무기 데이터 초기화.
            for (int i = 0; i < 25; i++)
            {
                // 처음 시작시에는 무기 lock sprite를 on 시키기 위해 check할 변수를 false시켜줌.
                // 나중에 아래 변수는 playerprefas로 가져와야함.
                string get_weapon_enable = "weapon" + i.ToString() + "_enable";
                weapon_struct_object[i].enable = PlayerPrefs.GetInt(get_weapon_enable, 1);

                // unlock sprite가 ON되어 있어도 그 밑에있는 버튼들이 클릭되어지는 것을 방지하기 위함.
                string weapon_status_enable = "_weapon" + i.ToString() + "_enable_obj";
                weapon_struct_object[i].weapon_enable_gameobject = GameObject.Find(weapon_status_enable);
                weapon_struct_object[i].weapon_enable_gameobject.SetActive(false);

                // 해당 무기 레벨을 setting해줌.
                string get_weapon_level = "weapon" + i.ToString() + "_level";
                weapon_struct_object[i].level = PlayerPrefs.GetInt(get_weapon_level, 1);

                if (weapon_struct_object[i].enable == 0)
                {
                    print(i.ToString() + "이 무기는 가지고 있음");
                    // 해당 무기를 가지고 있기 때문에 unlock_sprite를 false시켜줌.
                    string weapon_lock_sp = "_weapon" + i.ToString() + "_unlock_sprite";
                    GameObject.Find(weapon_lock_sp).SetActive(false);

                    //unlock sprite가 ON되어 있어도 그 밑에있는 버튼들이 클릭되어지는 것을 방지하기 위함.
                    weapon_struct_object[i].weapon_enable_gameobject.SetActive(true);
                    weapon_MAX++;

                    // 무기 레벨 up 버튼 GameObject Setting.
                    weapon_struct_object[i].lvup_button = GameObject.Find("_weapon" + i.ToString() + "_lvup_button");

                    // 가져온 무기의 레벨값으로 해당 무기 data struct에 setting.
                    weapon_data_struct_update(i, weapon_struct_object[i].level);
                    update_weapon_data_label(i);
                }


            }

            // ************************************************************************  bow init ************************************************************************ //

            // 활 데이터 초기화.
            for (int i = 0; i < 25; i++)
            {
                // 처음 시작시에는 무기 lock sprite를 on 시키기 위해 check할 변수를 false시켜줌.
                // 나중에 아래 변수는 playerprefas로 가져와야함.
                string get_bow_enable = "bow" + i.ToString() + "_enable";
                bow_struct_object[i].enable = PlayerPrefs.GetInt(get_bow_enable, 1);

                // unlock sprite가 ON되어 있어도 그 밑에있는 버튼들이 클릭되어지는 것을 방지하기 위함.
                string bow_status_enable = "_bow" + i.ToString() + "_enable_obj";
                bow_struct_object[i].bow_enable_gameobject = GameObject.Find(bow_status_enable);
                bow_struct_object[i].bow_enable_gameobject.SetActive(false);

                // 해당 무기 레벨을 setting해줌.
                string get_bow_level = "bow" + i.ToString() + "_level";
                bow_struct_object[i].level = PlayerPrefs.GetInt(get_bow_level, 1);

                if (bow_struct_object[i].enable == 0)
                {
                    print(i.ToString() + "이 활은 가지고 있음");
                    // 해당 무기를 가지고 있기 때문에 unlock_sprite를 false시켜줌.
                    string bow_lock_sp = "_bow" + i.ToString() + "_unlock_sprite";
                    GameObject.Find(bow_lock_sp).SetActive(false);

                    //unlock sprite가 ON되어 있어도 그 밑에있는 버튼들이 클릭되어지는 것을 방지하기 위함.
                    bow_struct_object[i].bow_enable_gameobject.SetActive(true);
                    bow_MAX++;

                    // 무기 레벨 up 버튼 GameObject Setting.
                    bow_struct_object[i].lvup_button = GameObject.Find("_bow" + i.ToString() + "_lvup_button");

                    // 가져온 무기의 레벨값으로 해당 무기 data struct에 setting.
                    bow_data_struct_update(i, bow_struct_object[i].level);
                    update_bow_data_label(i);

                }


            }

            // ************************************************************************  armor init ************************************************************************ //                     

            // Armor Button All disable except 0.
            for (int i = 1; i < 41; i++)
            {
                // 게임 시작시 모든 Armor 구매 버튼은 비활성화 시켜줌 아래 for문에 있는 함수에서 Local 변수를 보고 활성화 할지 결정.
                GameObject.Find("_armor" + i.ToString() + "_lvup_button").GetComponent<UIButton>().isEnabled = false;
            }

            // 아머 데이터 초기화.
            for (int i = 0; i < 41; i++)
            {
                // Armor 레벨 up 버튼 GameObject Setting.
                armor_struct_object[i].armor_buy_button = GameObject.Find("_armor" + i.ToString() + "_lvup_button");

                // unlock sprite가 있음에도 그 밑에 있는 버튼이 클릭 되어지는걸 방지하기 위해 밑에 있는  object들을 비활성화 시켜줌.
                armor_struct_object[i].armor_enable_gameobject = GameObject.Find("_armor" + i.ToString() + "_enable");
                armor_struct_object[i].armor_enable_gameobject.SetActive(false);


                Armor_data_struct_update(i);
            }

            // ************************************************************************  wing init ************************************************************************ //

            // Wing Button All disable.
            for (int i = 0; i < 20; i++)
            {
                // 게임 시작시 모든 Armor 구매 버튼은 비활성화 시켜줌 아래 for문에 있는 함수에서 Local 변수를 보고 활성화 할지 결정.
                GameObject.Find("_wing" + i.ToString() + "_lvup_button").GetComponent<UIButton>().isEnabled = false;
            }

            // wing gameobject 데이터 초기화.
            for (int i = 0; i < 20; i++)
            {
                // Armor 레벨 up 버튼 GameObject Setting.
                wing_struct_object[i].wing_buy_button = GameObject.Find("_wing" + i.ToString() + "_lvup_button");

                // unlock sprite가 있음에도 그 밑에 있는 버튼이 클릭 되어지는걸 방지하기 위해 밑에 있는  object들을 비활성화 시켜줌.
                wing_struct_object[i].wing_enable_gameobject = GameObject.Find("_wing" + i.ToString() + "_enable");
                wing_struct_object[i].wing_enable_gameobject.SetActive(false);
            }

            for (int i = 0; i < 20; i++)
            {
                Wing_data_struct_update(i);
            }

            check_wing_buttons_is_enable_or_not();

        }



        // ************************************************************************  Weapon Functions ************************************************************************ //

        public static void weapon_data_struct_update(int _weapon_index, int _level)
        {
            weapon_struct_object[_weapon_index].level = _level;

            weapon_struct_object[_weapon_index].damage = 0;
            // 데미지는 레벨에 따라서 누적.
            for (int i = 1; i < _level + 1; i++)
            {
                weapon_struct_object[_weapon_index].damage = weapon_struct_object[_weapon_index].damage + (ulong)((5 * (_weapon_index+1) * 10) * i);
            }

            // =ROUND((2000*1)*POWER(1.275,C3),0)+100000*C3
            weapon_struct_object[_weapon_index].upgrade_cost = (ulong)Mathf.Round((1000 * (Mathf.Pow(1.275f, _level)) + ((10000 *_weapon_index) + 5000*_level)));

            // 무기가 어떤 npc에 장착되어 있는지 Local변수를 가져옴.
            // NPC가 Weapon을 장착하고 있는 상태에서 Weapon Level up 시 update해줄 변수들.
            string get_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";

            switch (PlayerPrefs.GetInt(get_weapon_to_npc_str, 100))
            {

                case 1:
                    print("npc01 equip weapon 1");
                    NPC01_make.NPC01_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC01_make.NPC01_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC01_make.NPC01_struct.add_damage);
                    break;

                case 2:
                    print("npc02 equip weapon 1");

                    NPC02_make.NPC02_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC02_make.NPC02_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC02_make.NPC02_struct.add_damage);
                    break;

                case 3:
                    NPC03_make.NPC03_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC03_make.NPC03_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC03_make.NPC03_struct.add_damage);
                    break;

                case 7:
                    NPC07_make.NPC07_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC07_make.NPC07_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC07_make.NPC07_struct.add_damage);
                    break;

                case 8:
                    NPC08_make.NPC08_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC08_make.NPC08_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC08_make.NPC08_struct.add_damage);
                    break;

                case 9:
                    NPC09_make.NPC09_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC09_make.NPC09_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC09_make.NPC09_struct.add_damage);
                    break;
                default:
                    //print("해당 무기는 npc가 가지고 있지 않음.");
                    break;
            }

        }

        // 무기 레벨 UP && Data Update.
        public static void levelup_weapon_data_struct(int _weapon_index)
        {
            int _Level = weapon_struct_object[_weapon_index].level;
            // 무기 레벨업 공식.
            weapon_struct_object[_weapon_index].level = weapon_struct_object[_weapon_index].level + 1;

            // 데미지는 레벨에 따라서 누적.
            for (int i = 1; i < weapon_struct_object[_weapon_index].level + 1; i++)
            {
                weapon_struct_object[_weapon_index].damage = weapon_struct_object[_weapon_index].damage + (ulong)((5 * (_weapon_index + 1) * 10) * i);
            }

            // =ROUND((2000*1)*POWER(1.275,C3),0)+100000*C3
            weapon_struct_object[_weapon_index].upgrade_cost = (ulong)Mathf.Round((1000 * (Mathf.Pow(1.275f, weapon_struct_object[_weapon_index].level)) + ((10000 * _weapon_index) + 5000 * weapon_struct_object[_weapon_index].level)));

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
                    NPC01_make.NPC01_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC01_make.NPC01_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC01_make.NPC01_struct.add_damage);
                    break;

                case 2:
                    NPC02_make.NPC02_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC02_make.NPC02_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC02_make.NPC02_struct.add_damage);
                    break;

                case 3:
                    NPC03_make.NPC03_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC03_make.NPC03_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC03_make.NPC03_struct.add_damage);
                    break;

                case 7:
                    NPC07_make.NPC07_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC07_make.NPC07_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC07_make.NPC07_struct.add_damage);
                    break;

                case 8:
                    NPC08_make.NPC08_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC08_make.NPC08_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC08_make.NPC08_struct.add_damage);
                    break;

                case 9:
                    NPC09_make.NPC09_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC09_make.NPC09_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC09_make.NPC09_struct.add_damage);
                    break;

                default:
                    print("해당 무기는 npc가 가지고 있지 않음.");
                    break;

            }
        }

        // 무기 버튼 && 라벨 Update.
        public static void update_weapon_data_label(int _weapon_index)
        {
            string level_label = "_weapon" + _weapon_index.ToString() + "_level_label";
            string damage_label = "_weapon" + _weapon_index.ToString() + "_damage_label";
            string lvup_cost_label = "_weapon" + _weapon_index.ToString() + "_upgrade_cost_label";

            GameObject.Find(level_label).GetComponent<UILabel>().text = weapon_struct_object[_weapon_index].level.ToString();
            GameObject.Find(damage_label).GetComponent<UILabel>().text = GameData.int_to_label_format(weapon_struct_object[_weapon_index].damage);
            GameObject.Find(lvup_cost_label).GetComponent<UILabel>().text = GameData.int_to_label_format_won(weapon_struct_object[_weapon_index].upgrade_cost);
        }


        public static void equip_the_weapon(int _weapon_index, popup_window_button_mgr.NPC_INDEX _npc_index)
        {

            string set_weapon_to_npc_str;

            // NPC에 Damage 추가 && NPC Damage 추가 Label Update.
            switch (_npc_index)
            {
                case popup_window_button_mgr.NPC_INDEX.NPC01:
                    weapon_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC01;

                    // 무기가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_weapon_to_npc_str, 1);                                                    // 1 -> NPC01
                    PlayerPrefs.Save();

                    NPC01_make.NPC01_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC01_make.NPC01_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC01_make.NPC01_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC02:
                    weapon_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC02;

                    // 무기가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_weapon_to_npc_str, 2);                                                    // 2 -> NPC02
                    PlayerPrefs.Save();

                    NPC02_make.NPC02_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC02_make.NPC02_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC02_make.NPC02_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC03:
                    weapon_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC03;

                    // 무기가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_weapon_to_npc_str, 3);                                                    // 3 -> NPC03
                    PlayerPrefs.Save();

                    NPC03_make.NPC03_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC03_make.NPC03_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC03_make.NPC03_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC07:
                    weapon_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC07;

                    // 무기가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_weapon_to_npc_str, 7);                                                    // 7 -> NPC07
                    PlayerPrefs.Save();

                    NPC07_make.NPC07_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC07_make.NPC07_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC07_make.NPC07_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC08:
                    weapon_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC08;

                    // 무기가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_weapon_to_npc_str, 8);                                                    // 8 -> NPC08
                    PlayerPrefs.Save();

                    NPC08_make.NPC08_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC08_make.NPC08_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC08_make.NPC08_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC09:
                    weapon_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC09;

                    // 무기가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_weapon_to_npc_str = "weapon" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_weapon_to_npc_str, 9);                                                    // 9 -> NPC09
                    PlayerPrefs.Save();

                    NPC09_make.NPC09_struct.add_damage = weapon_struct_object[_weapon_index].damage;
                    NPC09_make.NPC09_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC09_make.NPC09_struct.add_damage);
                    break;
            }
        }



        // ************************************************************************  bow Functions ************************************************************************ //

        // 활 레벨 UP && Data Update.
        public static void bow_data_struct_update(int _weapon_index, int _level)
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
                    NPC04_make.NPC04_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC04_make.NPC04_struct.add_damage);
                    break;

                case 5:
                    NPC05_make.NPC05_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC05_make.NPC05_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC05_make.NPC05_struct.add_damage);
                    break;

                case 6:
                    NPC06_make.NPC06_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC06_make.NPC06_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC06_make.NPC06_struct.add_damage);
                    break;

                case 10:
                    NPC10_make.NPC10_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC10_make.NPC10_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC10_make.NPC10_struct.add_damage);
                    break;

                case 11:
                    NPC11_make.NPC11_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC11_make.NPC11_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC11_make.NPC11_struct.add_damage);
                    break;

                case 12:
                    NPC12_make.NPC12_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC12_make.NPC12_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC12_make.NPC12_struct.add_damage);
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
                    NPC04_make.NPC04_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC04_make.NPC04_struct.add_damage);
                    break;

                case 5:
                    NPC05_make.NPC05_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC05_make.NPC05_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC05_make.NPC05_struct.add_damage);
                    break;

                case 6:
                    NPC06_make.NPC06_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC06_make.NPC06_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC06_make.NPC06_struct.add_damage);
                    break;

                case 10:
                    NPC10_make.NPC10_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC10_make.NPC10_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC10_make.NPC10_struct.add_damage);
                    break;

                case 11:
                    NPC11_make.NPC11_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC11_make.NPC11_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC11_make.NPC11_struct.add_damage);
                    break;

                case 12:
                    NPC12_make.NPC12_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC12_make.NPC12_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC12_make.NPC12_struct.add_damage);
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
                    NPC04_make.NPC04_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC04_make.NPC04_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC05:
                    bow_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC05;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    set_bow_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_bow_to_npc_str, 5);
                    PlayerPrefs.Save();

                    NPC05_make.NPC05_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC05_make.NPC05_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC05_make.NPC05_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC06:
                    bow_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC06;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    set_bow_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_bow_to_npc_str, 6);
                    PlayerPrefs.Save();

                    NPC06_make.NPC06_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC06_make.NPC06_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC06_make.NPC06_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC10:
                    bow_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC10;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    set_bow_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_bow_to_npc_str, 10);
                    PlayerPrefs.Save();

                    NPC10_make.NPC10_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC10_make.NPC10_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC10_make.NPC10_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC11:
                    bow_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC11;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    set_bow_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_bow_to_npc_str, 11);
                    PlayerPrefs.Save();

                    NPC11_make.NPC11_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC11_make.NPC11_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC11_make.NPC11_struct.add_damage);
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC12:
                    bow_struct_object[_weapon_index].equiped_this_weapon_npc_index = popup_window_button_mgr.NPC_INDEX.NPC12;

                    // 무기 레벨업 시 무기 레벨 값을 Local에 저장.
                    set_bow_to_npc_str = "bow" + _weapon_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_bow_to_npc_str, 12);
                    PlayerPrefs.Save();

                    NPC12_make.NPC12_struct.add_damage = bow_struct_object[_weapon_index].damage;
                    NPC12_make.NPC12_struct.add_damage_label.GetComponent<UILabel>().text = "+ " + GameData.int_to_label_format(NPC12_make.NPC12_struct.add_damage);
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
            int check_armor_enable = PlayerPrefs.GetInt("wing_" + _wing_index.ToString() + "_enable", 0);
            if (check_armor_enable == 1)
            {
                // Armor is enable 해당 Armor status창 enable시켜줌.
                Wing_enable(_wing_index);
            }
            else
            {
                string lvup_cost_label = "_wing" + _wing_index.ToString() + "_upgrade_cost_label";
                GameObject.Find(lvup_cost_label).GetComponent<UILabel>().text = GameData.int_to_label_format(wing_struct_object[_wing_index].upgrade_cost);
            }

        }


        /// <summary>
        /// wing 레벨 UP && Data Update.
        /// </summary>
        /// <param name="_wing_index"></param>
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

        }

        /// <summary>
        /// 캐릭터 index와 wing index를 받아서 해당 캐릭터 attack speed를 변경해 줄 함수.
        /// </summary>
        /// <param name="_wing_index_skill"></param>
        /// <param name="_npc_inde"></param>
        public static void get_wing_skill_func(int _wing_index_skill, popup_window_button_mgr.NPC_INDEX _npc_inde)
        {

            // Wing index별 스킬 추가.
            // Wing index에 해당하는 스킬을 할당해줌.
            switch (_npc_inde)
            {
                case popup_window_button_mgr.NPC_INDEX.NPC01:
                    // 1번 wing 장착 후 gemstone획득량 10% UP.
                    float get_speed = get_wing_skill_speed(_wing_index_skill);
                    print("To change speed :: " + get_speed.ToString());
                    NPC01_make.NPC01_struct.attack_speed = get_speed;
                    break;

                case popup_window_button_mgr.NPC_INDEX.NPC02:
                    break;
                    // TO DO 
                    // 추가 wing 아이템 스킬 구현 해야함.
            }
        }

        /// <summary>
        /// wing index를 받아와서 해당하는 index에 따라서 캐릭터 attack speed를 변경해 줄 값을 return.
        /// </summary>
        /// <param name="_wing_index"></param>
        /// <returns></returns>
        public static float get_wing_skill_speed(int _wing_index)
        {
            float return_speed = 0f;

            switch (_wing_index)
            {
                case 0:
                    return_speed = 0.4f;
                    break;

                case 1:
                    return_speed = 1.9f;
                    break;

            }




            return return_speed;

        }

        // ************************************************************************  Armor Functions ************************************************************************ //



        /// Armor data init 함수.
        public static void Armor_data_struct_update(int _armor_index)
        {
            // Armor Data 능력치 부여 공식.
            //armor_struct_object[_armor_index].plus_gold = (ulong)(_armor_index * 2 + 2);
            armor_struct_object[_armor_index].upgrade_cost = (ulong)(Mathf.Round( (100 * (Mathf.Pow(2.715f,(_armor_index+1))))));

            // Armor가 enable 되어 있는지 확인. ( 0 : false, 1 : true)
            int check_armor_enable = PlayerPrefs.GetInt("armor_" + _armor_index.ToString() + "_enable", 0);
            if (check_armor_enable == 1)
            {
                // Armor is enable 해당 Armor status창 enable시켜줌.
                Armor_enable(_armor_index);

            }
            else
            {
                // 해당 armor는 아직 구입전 상태로 구매비용 label에 update해줘야 함. 
                string lvup_cost_label = "_armor" + _armor_index.ToString() + "_upgrade_cost_label";
                GameObject.Find(lvup_cost_label).GetComponent<UILabel>().text = GameData.int_to_label_format(armor_struct_object[_armor_index].upgrade_cost);
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
        }

        /// <summary>
        ///  캐릭터 init시 참조 함수 && 캐릭터 선택창 popup window시 호출 함수.
        /// </summary>
        /// <param name="_armor_index"></param>
        /// <param name="_npx_index"></param>
        public static void get_armor_skill_func(int _armor_index, int _npx_index)
        {
            print("_armor_index ::: " + _armor_index);
            string set_armor_to_npc_str;

            // Armor index별 스킬 추가.
            // Armor index에 해당하는 스킬을 할당해줌.
            switch (_armor_index)
            {
                case 0:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 1 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash1 gold 획득량 UP.
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent + 0.1f;
                    GameData.slash_struct_object[0].add_gold = (ulong)(GameData.slash_struct_object[0].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[0].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 "+ (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "진검베기 골드 획득량 10% 증가");
                    break;

                case 1:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash1 gold 획득량 UP.
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent + 0.1f;
                    GameData.slash_struct_object[1].add_gold = (ulong)(GameData.slash_struct_object[1].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[1].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "돌려베기 골드 획득량 10% 증가");
                    break;
                    
                case 2:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash1 gold 획득량 UP.
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent + 0.15f;
                    GameData.slash_struct_object[0].add_gold = (ulong)(GameData.slash_struct_object[0].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[0].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "진검베기 골드 획득량 15% 증가");
                    break;

                case 3:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash1 gold 획득량 UP.
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent + 0.15f;
                    GameData.slash_struct_object[1].add_gold = (ulong)(GameData.slash_struct_object[1].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[1].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "돌려베기 골드 획득량 15% 증가");
                    break;

                case 4:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[2].add_gold_percent = GameData.slash_struct_object[2].add_gold_percent + 0.15f;
                    GameData.slash_struct_object[2].add_gold = (ulong)(GameData.slash_struct_object[2].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[2].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[2].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[2].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "2연속베기 골드 획득량 15% 증가");
                    break;

                case 5:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent + 0.19f;
                    GameData.slash_struct_object[0].add_gold = (ulong)(GameData.slash_struct_object[0].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[0].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "진검베기 골드 획득량 19% 증가");
                    break;

                case 6:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent + 0.19f;
                    GameData.slash_struct_object[1].add_gold = (ulong)(GameData.slash_struct_object[1].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[1].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "돌려베기 골드 획득량 19% 증가");
                    break;

                case 7:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[2].add_gold_percent = GameData.slash_struct_object[2].add_gold_percent + 0.19f;
                    GameData.slash_struct_object[2].add_gold = (ulong)(GameData.slash_struct_object[2].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[2].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[2].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[2].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "2연속베기 골드 획득량 19% 증가");
                    break;

                case 8:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[3].add_gold_percent = GameData.slash_struct_object[3].add_gold_percent + 0.19f;
                    GameData.slash_struct_object[3].add_gold = (ulong)(GameData.slash_struct_object[3].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[3].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[3].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[3].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "위아래베기 골드 획득량 19% 증가");
                    break;

                case 9:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent + 0.25f;
                    GameData.slash_struct_object[0].add_gold = (ulong)(GameData.slash_struct_object[0].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[0].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "진검베기 골드 획득량 25% 증가");
                    break;

                case 10:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent + 0.25f;
                    GameData.slash_struct_object[1].add_gold = (ulong)(GameData.slash_struct_object[1].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[1].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "돌려베기 골드 획득량 25% 증가");
                    break;

                case 11:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[2].add_gold_percent = GameData.slash_struct_object[2].add_gold_percent + 0.25f;
                    GameData.slash_struct_object[2].add_gold = (ulong)(GameData.slash_struct_object[2].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[2].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[2].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[2].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "2연속베기 골드 획득량 25% 증가");
                    break;

                case 12:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[3].add_gold_percent = GameData.slash_struct_object[3].add_gold_percent + 0.25f;
                    GameData.slash_struct_object[3].add_gold = (ulong)(GameData.slash_struct_object[3].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[3].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[3].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[3].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "위아래베기 골드 획득량 25% 증가");
                    break;

                case 13:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[4].add_gold_percent = GameData.slash_struct_object[4].add_gold_percent + 0.25f;
                    GameData.slash_struct_object[4].add_gold = (ulong)(GameData.slash_struct_object[4].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[4].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[4].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[4].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "3연속베기 골드 획득량 25% 증가");
                    break;

                case 14:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent + 0.5f;
                    GameData.slash_struct_object[0].add_gold = (ulong)(GameData.slash_struct_object[0].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[0].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "진검베기 골드 획득량 50% 증가");
                    break;

                case 15:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent + 0.5f;
                    GameData.slash_struct_object[1].add_gold = (ulong)(GameData.slash_struct_object[1].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[1].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "돌려베기 골드 획득량 50% 증가");
                    break;

                case 16:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[2].add_gold_percent = GameData.slash_struct_object[2].add_gold_percent + 0.5f;
                    GameData.slash_struct_object[2].add_gold = (ulong)(GameData.slash_struct_object[2].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[2].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[2].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[2].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "2연속베기 골드 획득량 50% 증가");
                    break;

                case 17:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[3].add_gold_percent = GameData.slash_struct_object[3].add_gold_percent + 0.5f;
                    GameData.slash_struct_object[3].add_gold = (ulong)(GameData.slash_struct_object[3].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[3].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[3].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[3].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "위아래베기 골드 획득량 50% 증가");
                    break;

                case 18:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[4].add_gold_percent = GameData.slash_struct_object[4].add_gold_percent + 0.5f;
                    GameData.slash_struct_object[4].add_gold = (ulong)(GameData.slash_struct_object[4].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[4].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[4].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[4].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "3연속베기 골드 획득량 50% 증가");
                    break;

                case 19:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[5].add_gold_percent = GameData.slash_struct_object[5].add_gold_percent + 0.5f;
                    GameData.slash_struct_object[5].add_gold = (ulong)(GameData.slash_struct_object[5].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[5].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[5].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[5].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "번개베기 골드 획득량 50% 증가");
                    break;

                case 20:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[6].add_gold_percent = GameData.slash_struct_object[6].add_gold_percent + 0.5f;
                    GameData.slash_struct_object[6].add_gold = (ulong)(GameData.slash_struct_object[6].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[6].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[6].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[6].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "겹쳐베기 골드 획득량 50% 증가");
                    break;

                case 21:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[7].add_gold_percent = GameData.slash_struct_object[7].add_gold_percent + 0.5f;
                    GameData.slash_struct_object[7].add_gold = (ulong)(GameData.slash_struct_object[7].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[7].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[7].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[7].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "동전베기 골드 획득량 50% 증가");
                    break;

                case 22:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[8].add_gold_percent = GameData.slash_struct_object[8].add_gold_percent + 0.5f;
                    GameData.slash_struct_object[8].add_gold = (ulong)(GameData.slash_struct_object[8].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[8].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[8].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[8].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "전자베기 골드 획득량 50% 증가");
                    break;

                case 23:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[9].add_gold_percent = GameData.slash_struct_object[9].add_gold_percent + 0.5f;
                    GameData.slash_struct_object[9].add_gold = (ulong)(GameData.slash_struct_object[9].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[9].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[9].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[9].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "울버베기 골드 획득량 50% 증가");
                    break;

                case 24:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent + 1f;
                    GameData.slash_struct_object[0].add_gold = (ulong)(GameData.slash_struct_object[0].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[0].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "진검베기 골드 획득량 100% 증가");
                    break;

                case 25:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent + 1f;
                    GameData.slash_struct_object[1].add_gold = (ulong)(GameData.slash_struct_object[1].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[1].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "돌려베기 골드 획득량 100% 증가");
                    break;

                case 26:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[2].add_gold_percent = GameData.slash_struct_object[2].add_gold_percent + 1f;
                    GameData.slash_struct_object[2].add_gold = (ulong)(GameData.slash_struct_object[2].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[2].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[2].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[2].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "2연속베기 골드 획득량 100% 증가");
                    break;

                case 27:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[3].add_gold_percent = GameData.slash_struct_object[3].add_gold_percent + 1f;
                    GameData.slash_struct_object[3].add_gold = (ulong)(GameData.slash_struct_object[3].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[3].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[3].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[3].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "위아래베기 골드 획득량 100% 증가");
                    break;

                case 28:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[4].add_gold_percent = GameData.slash_struct_object[4].add_gold_percent + 1f;
                    GameData.slash_struct_object[4].add_gold = (ulong)(GameData.slash_struct_object[4].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[4].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[4].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[4].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "3연속베기 골드 획득량 100% 증가");
                    break;

                case 29:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[5].add_gold_percent = GameData.slash_struct_object[5].add_gold_percent + 1f;
                    GameData.slash_struct_object[5].add_gold = (ulong)(GameData.slash_struct_object[5].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[5].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[5].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[5].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "번개베기 골드 획득량 100% 증가");
                    break;


                case 30:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[6].add_gold_percent = GameData.slash_struct_object[6].add_gold_percent + 1f;
                    GameData.slash_struct_object[6].add_gold = (ulong)(GameData.slash_struct_object[6].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[6].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[6].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[6].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "겹쳐베기 골드 획득량 100% 증가");
                    break;

                case 31:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[7].add_gold_percent = GameData.slash_struct_object[7].add_gold_percent + 1f;
                    GameData.slash_struct_object[7].add_gold = (ulong)(GameData.slash_struct_object[7].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[7].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[7].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[7].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "동전베기 골드 획득량 100% 증가");
                    break;
                    
                case 32:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[8].add_gold_percent = GameData.slash_struct_object[8].add_gold_percent + 1f;
                    GameData.slash_struct_object[8].add_gold = (ulong)(GameData.slash_struct_object[8].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[8].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[8].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[8].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "전자베기 골드 획득량 100% 증가");
                    break;

                case 33:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    GameData.slash_struct_object[9].add_gold_percent = GameData.slash_struct_object[9].add_gold_percent + 1f;
                    GameData.slash_struct_object[9].add_gold = (ulong)(GameData.slash_struct_object[9].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[9].add_gold_percent);
                    // slash skill label update
                    GameData.slash_struct_object[9].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[9].add_gold_percent * 100).ToString() + "% 증가";
                    set_npc_skill_label(_npx_index, "울버베기 골드 획득량 100% 증가");
                    break;

                case 34:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    for(int i=0;i<10;i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent + 0.5f;
                        GameData.slash_struct_object[i].add_gold = (ulong)(GameData.slash_struct_object[i].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[i].add_gold_percent);
                        // slash skill label update
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    set_npc_skill_label(_npx_index, "모든베기 골드 획득량 50% 증가");
                    break;

                case 35:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent + 1f;
                        GameData.slash_struct_object[i].add_gold = (ulong)(GameData.slash_struct_object[i].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[i].add_gold_percent);
                        // slash skill label update
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    set_npc_skill_label(_npx_index, "모든베기 골드 획득량 100% 증가");

                    break;

                case 36:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent + 2f;
                        GameData.slash_struct_object[i].add_gold = (ulong)(GameData.slash_struct_object[i].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[i].add_gold_percent);
                        // slash skill label update
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    set_npc_skill_label(_npx_index, "모든베기 골드 획득량 200% 증가");

                    break;

                case 37:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent + 3f;
                        GameData.slash_struct_object[i].add_gold = (ulong)(GameData.slash_struct_object[i].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[i].add_gold_percent);
                        // slash skill label update
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    set_npc_skill_label(_npx_index, "모든베기 골드 획득량 300% 증가");
                    break;

                case 38:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent + 5f;
                        GameData.slash_struct_object[i].add_gold = (ulong)(GameData.slash_struct_object[i].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[i].add_gold_percent);
                        // slash skill label update
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    set_npc_skill_label(_npx_index, "모든베기 골드 획득량 500% 증가");
                    break;

                case 39:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent + 7f;
                        GameData.slash_struct_object[i].add_gold = (ulong)(GameData.slash_struct_object[i].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[i].add_gold_percent);
                        // slash skill label update
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    set_npc_skill_label(_npx_index, "모든베기 골드 획득량 700% 증가");
                    break;

                case 40:
                    // Armor가 어떤 npc에 장착 되어있는지 확인할 Local 변수
                    set_armor_to_npc_str = "armor" + _armor_index.ToString() + "_npc";
                    PlayerPrefs.SetInt(set_armor_to_npc_str, _npx_index);                                                    // _npx_index 0 -> NPC01
                    PlayerPrefs.Save();

                    // armor 장착 후 slash gold 획득량 UP.
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent + 10f;
                        GameData.slash_struct_object[i].add_gold = (ulong)(GameData.slash_struct_object[i].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[i].add_gold_percent);
                        // slash skill label update
                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    set_npc_skill_label(_npx_index, "모든베기 골드 획득량 1000% 증가");
                    break;

                default:
                    print("_armor_index error!!!!!");
                    break;
                    // To do.....
                    // 남은 armor 스킬 추가.


            }

        }

        /// <summary>
        /// Armor 장착 해제시 slash 추가 공격력 빠지게 할 함수.
        /// </summary>
        /// <param name="_armor_index"></param>
        /// <param name="_npx_index"></param>
        public static void reset_armor_skill_func(int _armor_index)
        {
            print("armor index ::: " + _armor_index);
            // Armor index에 해당하는 스킬을 없애줌.
            switch (_armor_index)
            {
                case 0:
                    print("slash_struct_object index ::: " + 0);

                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent - 0.1f;
                    GameData.slash_struct_object[0].add_gold = (ulong)(GameData.slash_struct_object[0].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[0].add_gold_percent);

                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 1:
                    print("slash_struct_object index ::: " + 1);

                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent - 0.1f;
                    GameData.slash_struct_object[1].add_gold = (ulong)(GameData.slash_struct_object[1].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[1].add_gold_percent);

                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 2:
                    print("slash_struct_object index ::: " + 2);

                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent - 0.15f;
                    GameData.slash_struct_object[0].add_gold = (ulong)(GameData.slash_struct_object[0].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[0].add_gold_percent);

                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 3:
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent - 0.15f;
                    GameData.slash_struct_object[1].add_gold = (ulong)(GameData.slash_struct_object[1].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[1].add_gold_percent);

                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 4:
                    GameData.slash_struct_object[2].add_gold_percent = GameData.slash_struct_object[2].add_gold_percent - 0.15f;
                    GameData.slash_struct_object[2].add_gold = (ulong)(GameData.slash_struct_object[2].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[2].add_gold_percent);

                    GameData.slash_struct_object[2].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[2].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 5:
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent - 0.19f;
                    GameData.slash_struct_object[0].add_gold = (ulong)(GameData.slash_struct_object[0].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[0].add_gold_percent);

                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 6:
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent - 0.19f;
                    GameData.slash_struct_object[1].add_gold = (ulong)(GameData.slash_struct_object[1].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[1].add_gold_percent);

                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 7:
                    GameData.slash_struct_object[2].add_gold_percent = GameData.slash_struct_object[2].add_gold_percent - 0.19f;
                    GameData.slash_struct_object[2].add_gold = (ulong)(GameData.slash_struct_object[2].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[2].add_gold_percent);

                    GameData.slash_struct_object[2].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[2].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 8:
                    GameData.slash_struct_object[3].add_gold_percent = GameData.slash_struct_object[3].add_gold_percent - 0.19f;
                    GameData.slash_struct_object[3].add_gold = (ulong)(GameData.slash_struct_object[3].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[3].add_gold_percent);

                    GameData.slash_struct_object[3].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[3].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 9:
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent - 0.25f;
                    GameData.slash_struct_object[0].add_gold = (ulong)(GameData.slash_struct_object[0].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[0].add_gold_percent);

                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 10:
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent - 0.25f;
                    GameData.slash_struct_object[1].add_gold = (ulong)(GameData.slash_struct_object[1].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[1].add_gold_percent);

                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 11:
                    GameData.slash_struct_object[2].add_gold_percent = GameData.slash_struct_object[2].add_gold_percent - 0.25f;
                    GameData.slash_struct_object[2].add_gold = (ulong)(GameData.slash_struct_object[2].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[2].add_gold_percent);

                    GameData.slash_struct_object[2].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[2].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 12:
                    GameData.slash_struct_object[3].add_gold_percent = GameData.slash_struct_object[3].add_gold_percent - 0.25f;
                    GameData.slash_struct_object[3].add_gold = (ulong)(GameData.slash_struct_object[3].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[3].add_gold_percent);

                    GameData.slash_struct_object[3].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[3].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 13:
                    GameData.slash_struct_object[4].add_gold_percent = GameData.slash_struct_object[4].add_gold_percent - 0.25f;
                    GameData.slash_struct_object[4].add_gold = (ulong)(GameData.slash_struct_object[4].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[4].add_gold_percent);

                    GameData.slash_struct_object[4].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[4].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 14:
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent - 0.5f;
                    GameData.slash_struct_object[0].add_gold = (ulong)(GameData.slash_struct_object[0].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[0].add_gold_percent);

                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 15:
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent - 0.5f;
                    GameData.slash_struct_object[1].add_gold = (ulong)(GameData.slash_struct_object[1].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[1].add_gold_percent);

                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 16:
                    GameData.slash_struct_object[2].add_gold_percent = GameData.slash_struct_object[2].add_gold_percent - 0.5f;
                    GameData.slash_struct_object[2].add_gold = (ulong)(GameData.slash_struct_object[2].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[2].add_gold_percent);

                    GameData.slash_struct_object[2].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[2].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 17:
                    GameData.slash_struct_object[3].add_gold_percent = GameData.slash_struct_object[3].add_gold_percent - 0.5f;
                    GameData.slash_struct_object[3].add_gold = (ulong)(GameData.slash_struct_object[3].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[3].add_gold_percent);

                    GameData.slash_struct_object[3].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[3].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 18:
                    GameData.slash_struct_object[4].add_gold_percent = GameData.slash_struct_object[4].add_gold_percent - 0.5f;
                    GameData.slash_struct_object[4].add_gold = (ulong)(GameData.slash_struct_object[4].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[4].add_gold_percent);

                    GameData.slash_struct_object[4].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[4].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 19:
                    GameData.slash_struct_object[5].add_gold_percent = GameData.slash_struct_object[5].add_gold_percent - 0.5f;
                    GameData.slash_struct_object[5].add_gold = (ulong)(GameData.slash_struct_object[5].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[5].add_gold_percent);

                    GameData.slash_struct_object[5].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[5].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 20:
                    GameData.slash_struct_object[6].add_gold_percent = GameData.slash_struct_object[6].add_gold_percent - 0.5f;
                    GameData.slash_struct_object[6].add_gold = (ulong)(GameData.slash_struct_object[6].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[6].add_gold_percent);

                    GameData.slash_struct_object[6].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[6].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 21:
                    GameData.slash_struct_object[7].add_gold_percent = GameData.slash_struct_object[7].add_gold_percent - 0.5f;
                    GameData.slash_struct_object[7].add_gold = (ulong)(GameData.slash_struct_object[7].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[7].add_gold_percent);

                    GameData.slash_struct_object[7].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[7].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 22:
                    GameData.slash_struct_object[8].add_gold_percent = GameData.slash_struct_object[8].add_gold_percent - 0.5f;
                    GameData.slash_struct_object[8].add_gold = (ulong)(GameData.slash_struct_object[8].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[8].add_gold_percent);

                    GameData.slash_struct_object[8].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[8].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 23:
                    GameData.slash_struct_object[9].add_gold_percent = GameData.slash_struct_object[9].add_gold_percent - 0.5f;
                    GameData.slash_struct_object[9].add_gold = (ulong)(GameData.slash_struct_object[9].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[9].add_gold_percent);

                    GameData.slash_struct_object[9].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[9].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 24:
                    GameData.slash_struct_object[0].add_gold_percent = GameData.slash_struct_object[0].add_gold_percent - 1f;
                    GameData.slash_struct_object[0].add_gold = (ulong)(GameData.slash_struct_object[0].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[0].add_gold_percent);

                    GameData.slash_struct_object[0].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[0].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 25:
                    GameData.slash_struct_object[1].add_gold_percent = GameData.slash_struct_object[1].add_gold_percent - 1f;
                    GameData.slash_struct_object[1].add_gold = (ulong)(GameData.slash_struct_object[1].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[1].add_gold_percent);

                    GameData.slash_struct_object[1].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[1].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 26:
                    GameData.slash_struct_object[2].add_gold_percent = GameData.slash_struct_object[2].add_gold_percent - 1f;
                    GameData.slash_struct_object[2].add_gold = (ulong)(GameData.slash_struct_object[2].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[2].add_gold_percent);

                    GameData.slash_struct_object[2].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[2].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 27:
                    GameData.slash_struct_object[3].add_gold_percent = GameData.slash_struct_object[3].add_gold_percent - 1f;
                    GameData.slash_struct_object[3].add_gold = (ulong)(GameData.slash_struct_object[3].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[3].add_gold_percent);

                    GameData.slash_struct_object[3].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[3].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 28:
                    GameData.slash_struct_object[4].add_gold_percent = GameData.slash_struct_object[4].add_gold_percent - 1f;
                    GameData.slash_struct_object[4].add_gold = (ulong)(GameData.slash_struct_object[4].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[4].add_gold_percent);

                    GameData.slash_struct_object[4].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[4].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 29:
                    GameData.slash_struct_object[5].add_gold_percent = GameData.slash_struct_object[5].add_gold_percent - 1f;
                    GameData.slash_struct_object[5].add_gold = (ulong)(GameData.slash_struct_object[5].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[5].add_gold_percent);

                    GameData.slash_struct_object[5].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[5].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 30:
                    GameData.slash_struct_object[6].add_gold_percent = GameData.slash_struct_object[6].add_gold_percent - 1f;
                    GameData.slash_struct_object[6].add_gold = (ulong)(GameData.slash_struct_object[6].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[6].add_gold_percent);

                    GameData.slash_struct_object[6].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[6].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 31:
                    GameData.slash_struct_object[7].add_gold_percent = GameData.slash_struct_object[7].add_gold_percent - 1f;
                    GameData.slash_struct_object[7].add_gold = (ulong)(GameData.slash_struct_object[7].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[7].add_gold_percent);

                    GameData.slash_struct_object[7].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[7].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 32:
                    GameData.slash_struct_object[8].add_gold_percent = GameData.slash_struct_object[8].add_gold_percent - 1f;
                    GameData.slash_struct_object[8].add_gold = (ulong)(GameData.slash_struct_object[8].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[8].add_gold_percent);

                    GameData.slash_struct_object[8].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[8].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 33:
                    GameData.slash_struct_object[9].add_gold_percent = GameData.slash_struct_object[9].add_gold_percent - 1f;
                    GameData.slash_struct_object[9].add_gold = (ulong)(GameData.slash_struct_object[9].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[9].add_gold_percent);

                    GameData.slash_struct_object[9].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[9].add_gold_percent * 100).ToString() + "% 증가";
                    break;

                case 34:
                    for(int i=0;i<10;i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent - 0.5f;
                        GameData.slash_struct_object[i].add_gold = (ulong)(GameData.slash_struct_object[i].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[i].add_gold_percent);

                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    break;

                case 35:
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent - 1f;
                        GameData.slash_struct_object[i].add_gold = (ulong)(GameData.slash_struct_object[i].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[i].add_gold_percent);

                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    break;

                case 36:
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent - 2f;
                        GameData.slash_struct_object[i].add_gold = (ulong)(GameData.slash_struct_object[i].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[i].add_gold_percent);

                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    break;

                case 37:
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent - 3f;
                        GameData.slash_struct_object[i].add_gold = (ulong)(GameData.slash_struct_object[i].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[i].add_gold_percent);

                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    break;

                case 38:
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent - 5f;
                        GameData.slash_struct_object[i].add_gold = (ulong)(GameData.slash_struct_object[i].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[i].add_gold_percent);

                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    break;

                case 39:
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent - 7f;
                        GameData.slash_struct_object[i].add_gold = (ulong)(GameData.slash_struct_object[i].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[i].add_gold_percent);

                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    break;

                case 40:
                    for (int i = 0; i < 10; i++)
                    {
                        GameData.slash_struct_object[i].add_gold_percent = GameData.slash_struct_object[i].add_gold_percent - 10f;
                        GameData.slash_struct_object[i].add_gold = (ulong)(GameData.slash_struct_object[i].add_gold + GameData.chest_struct.attacked_gold * GameData.slash_struct_object[i].add_gold_percent);

                        GameData.slash_struct_object[i].slash_bonus_label.GetComponent<UILabel>().text = "골드 획득량 " + (GameData.slash_struct_object[i].add_gold_percent * 100).ToString() + "% 증가";
                    }
                    break;
                default:
                    print("Armor index error!!!");
                    break;


            }
        }
        public static void set_npc_skill_label(int get_npc_index , string skill_str)
        {
            
            switch(get_npc_index)
            {

                case 0:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC01_make.NPC01_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 1:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC02_make.NPC02_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 2:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC03_make.NPC03_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 3:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC04_make.NPC04_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 4:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC05_make.NPC05_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 5:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC06_make.NPC06_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 6:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC07_make.NPC07_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 7:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC08_make.NPC08_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 8:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC09_make.NPC09_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 9:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC10_make.NPC10_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 10:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC11_make.NPC11_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
                case 11:
                    // NPC 캐릭터 스킬 Label 바꾸기.
                    NPC12_make.NPC12_struct.skill_label.GetComponent<UILabel>().text = skill_str;
                    break;
            }
        }

        // ************************************************************************  common Functions ************************************************************************ //

        //check whether upgrade buttons are possiable or not
        public static void check_weapon_buttons_is_enable_or_not()
        {
            // 무기 버튼 체크.
            for (int i = 0; i < weapon_MAX; i++)
            {
                if (GameData.coin_struct.gold >= weapon_struct_object[i].upgrade_cost)
                {
                    weapon_struct_object[i].lvup_button.GetComponent<UIButton>().isEnabled = true;
                }
                else
                {
                    weapon_struct_object[i].lvup_button.GetComponent<UIButton>().isEnabled = false;
                }
            }

            // 활 버튼 체크.
            for (int i = 0; i < bow_MAX; i++)
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
                    }
                    else if (equip_weapon_index == 1)
                    {
                        // weapon2 스킬 추가. < slash2에 Damage 추가. >
                    }
                    break;

                case "sword-a":
                    switch (equip_weapon_index)
                    {
                        case 0:
                            // weapon3 스킬 추가. < slash3에 Damage 추가. >
                            break;

                        case 1:
                            // weapon4 스킬 추가. < slash4에 Damage 추가. >
                            break;

                        case 2:
                            // weapon5 스킬 추가. < slash5에 Damage 추가. >
                            break;

                        case 3:

                            break;
                    }
                    break;

                // To Do....
                // 나머지 Bow 스킬 추가해야함.

                case "bow-a":
                    switch (equip_weapon_index)
                    {
                        case 0:
                            // weapon1 스킬 추가. < slash1에 Damage 추가. >
                            break;

                        case 1:
                            // weapon1 스킬 추가. < slash1에 Damage 추가. >
                            break;

                        case 2:
                            // weapon1 스킬 추가. < slash1에 Damage 추가. >
                            break;

                        case 3:
                            // weapon1 스킬 추가. < slash1에 Damage 추가. >
                            break;

                        case 4:
                            // weapon1 스킬 추가. < slash1에 Damage 추가. >
                            break;

                        case 5:
                            // weapon1 스킬 추가. < slash1에 Damage 추가. >
                            break;
                            // To Do....
                            // 나머지 Bow 스킬 추가해야함.
                    }
                    break;
            }
        }

        // 캐릭터 init시 해당 armor를 가지고 있으면 해당 skill을 부여해줌.
        public static void set_data_for_equip_armor(int armor_index,int npc_index)
        {
            print("armor_index  " + armor_index + "npc_index  " + npc_index);
            switch (armor_index)
            {
                case 0:
                    get_armor_skill_func(armor_index, npc_index);
                    break;

                case 1:
                    get_armor_skill_func(armor_index, npc_index);
                    break;

                case 2:
                    get_armor_skill_func(armor_index, npc_index);
                    break;

                case 3:
                    get_armor_skill_func(armor_index, npc_index);
                    break;

                case 4:
                    get_armor_skill_func(armor_index, npc_index);
                    break;

                case 5:
                    get_armor_skill_func(armor_index, npc_index);
                    break;


            }
        }

        // 캐릭터 init시 해당 wing을 가지고 있으면 해당 skill을 부여해줌.
        public static void set_data_for_equip_wing(string wing_type, int wing_index, popup_window_button_mgr.NPC_INDEX _npc_index)
        {
            switch (_npc_index)
            {
                case popup_window_button_mgr.NPC_INDEX.NPC01:
                    switch (wing_type)
                    {
                        case "cape-a":
                            switch (wing_index)
                            {
                                case 0:
                                // 1번 wing 장착 후 gemstone획득량 10% UP.
                                float get_speed = get_wing_skill_speed(0);
                                print("To change speed :: " + get_speed.ToString());
                                NPC01_make.NPC01_struct.attack_speed = get_speed;
                                break;
                            }
                            break;

                        case "wing-a":
                            switch (wing_index)
                            {
                                case 0:

                                    break;
                            }
                            break;
                            // To Do....
                            // 나머지 Armor 스킬 추가해야함.
                    }
                    break;
                case popup_window_button_mgr.NPC_INDEX.NPC02:

                    break;

            }
        }
    }
}
