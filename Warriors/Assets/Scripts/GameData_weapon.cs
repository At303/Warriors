using UnityEngine;
using System.Collections;
using gamedata;

namespace gamedata_weapon
{
    public class GameData_weapon : MonoBehaviour
    {


        // Weapon01 Struct
        public struct Weapon01_struct
        {
            public static bool enable;
            public static int level;
            public static float damage;
            public static float upgrade_cost;

            //////////////////// GameObject //////////////////////////
            public static GameObject weapon01_lv_label;
            public static GameObject weapon01_lvup_cost_label;
            public static GameObject weapon01_damage_label;
            public static GameObject weapon01_levelup_button;

        }

        // Weapon02 Struct
        public struct Weapon02_struct
        {
            public int level;
            public float damage;
            public float upgrade_cost;

        }

        // Use this for initialization
        void Start()
        {
            // Weapon01 데이터 초기화 및 라벨 Update//
            levelup_weapon01_data_struct();
            update_weapon01_data_label();
        }

        // Update is called once per frame
        void Update()
        {

        }

        // 무기01 레벨 UP && Data Update.
        public static void levelup_weapon01_data_struct()
        {
            Weapon01_struct.level = Weapon01_struct.level + 1;
            Weapon01_struct.damage = Weapon01_struct.level * 2 + 20f;
            Weapon01_struct.upgrade_cost = 130f + Weapon01_struct.level * 2;

            // Weapon02 Enable.
            if (Weapon01_struct.level == 2)
            {
                //npc_gameobject.SetActive(true);
            }
        }

        // 무기01 버튼 && 라벨 Update.
        public static void update_weapon01_data_label()
        {
            Weapon01_struct.weapon01_lv_label = GameObject.Find("_weapon01_level_label");
            Weapon01_struct.weapon01_lvup_cost_label = GameObject.Find("_weapon01_upgrade_cost_label");
            Weapon01_struct.weapon01_damage_label = GameObject.Find("_weapon01_damage_label");
            Weapon01_struct.weapon01_levelup_button = GameObject.Find("_weapon01_lvup_button");

            Weapon01_struct.weapon01_lv_label.GetComponent<UILabel>().text = Weapon01_struct.level.ToString();
            Weapon01_struct.weapon01_lvup_cost_label.GetComponent<UILabel>().text = Weapon01_struct.upgrade_cost.ToString();
            Weapon01_struct.weapon01_damage_label.GetComponent<UILabel>().text = Weapon01_struct.damage.ToString();
        }

        //check whether upgrade buttons are possiable or not
        public static void check_weapon_buttons_is_enable_or_not()
        {
            // 무기01 버튼 체크.
            if (GameData.coin_struct.gold >= Weapon01_struct.upgrade_cost)
            {
                Weapon01_struct.weapon01_levelup_button.GetComponent<UIButton>().isEnabled = true;
            }
            else
            {
                Weapon01_struct.weapon01_levelup_button.GetComponent<UIButton>().isEnabled = false;
            }
        }
    }
}
