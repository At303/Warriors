using UnityEngine;
using System.Collections;



namespace gamedata 
{
	// Touch Slash Type enum value.
    public enum SLASH_TYPE
    {
        NONE,
        SLASH1,
        SLASH2,
        SLASH3,
        SLASH4,
        SLASH5,
    }

    public class GameData : MonoBehaviour {

        // **************************************    Game data Struct    ************************************************ //

        // Coin Struct
        public struct coin_struct
		{
			public static float gold;
			public static float gemstone;
		}

        // Boss Monster Struct
        public struct boss_monster_struct
		{
			public static float HP;
			public static float _HP;
		}

		// Treasure Chest struct
		public struct chest_struct
		{
			public static int Level;
			public static float HP;
			public static float _HP;										// to save the current chest HP
			//public static float drop_gold;
			public static float attacked_gold;
			public static float attacked_gemstone;
			public static float upgrade_cost;
		}

        public static int number_of_slash;

		// slash1 struct
		public struct slash1_struct
		{
			public static int Level;
			public static float damage;
			public static float upgrade_cost;
		}

		// slash2 struct
		public struct slash2_struct
		{
			public static int Level;
			public static float damage;
			public static float upgrade_cost;
		}

		// slash3 struct
		public struct slash3_struct
		{
			public static int Level;
			public static float damage;
			public static float upgrade_cost;
		}

		// slash4 struct
		public struct slash4_struct
		{
			public static int Level;
			public static float damage;
			public static float upgrade_cost;
		}

		// slash5 struct
		public struct slash5_struct
		{
			public static int Level;
			public static float damage;
			public static float upgrade_cost;
		}

        
        // 캐릭터 무기 바꿀 시 사용하는 구조체.
        public struct to_change_weapon_struct
        {
            public static int weapon_index;
            public static string To_Change_Weapon_Name;
        }
        // **************************************    GameObject data    ************************************************ //

        public static GameObject debug_label2;

        // Popup Window object
        public static GameObject weapon_sel_popup_window_obj;

        // label object
        public static GameObject gold_total_label;					// gold total label
		public static GameObject gemstone_total_label;				// gemstone total label

		// chest && slashes object
		public static GameObject chest_lv_label;
		public static GameObject chest_dropgold_current_label;
		public static GameObject chest_dropgold_after_label;
		public static GameObject chest_lvup_cost_label;

		public static GameObject slash1_lv_label;
		public static GameObject slash1_lvup_cost_label;
		public static GameObject slash1_damage_current_label;
		public static GameObject slash1_damage_after_label;

		public static GameObject slash2_locking_sprite;
		public static GameObject slash2_lv_label;
		public static GameObject slash2_lvup_cost_label;
		public static GameObject slash2_damage_current_label;
		public static GameObject slash2_damage_after_label;

		public static GameObject slash3_locking_sprite;
		public static GameObject slash3_lv_label;
		public static GameObject slash3_lvup_cost_label;
		public static GameObject slash3_damage_current_label;
		public static GameObject slash3_damage_after_label;

		public static GameObject slash4_locking_sprite;
		public static GameObject slash4_lv_label;
		public static GameObject slash4_lvup_cost_label;
		public static GameObject slash4_damage_current_label;
		public static GameObject slash4_damage_after_label;

		public static GameObject slash5_locking_sprite;
		public static GameObject slash5_lv_label;
		public static GameObject slash5_lvup_cost_label;
		public static GameObject slash5_damage_current_label;
		public static GameObject slash5_damage_after_label;



        // boss object
        public static GameObject boss_hp_value;

		// sprite object
		public static GameObject chest_sprite;
		public static GameObject chest_opened_sprite;

		// HUD object
		public static GameObject chest_HUDText_control;

		// animation object
		public static GameObject slash_animation;

		// button Object
		public static GameObject chest_lvup_btn;
		public static GameObject slash1_lvup_btn;
		public static GameObject slash2_lvup_btn;
		public static GameObject slash3_lvup_btn;
		public static GameObject slash4_lvup_btn;
		public static GameObject slash5_lvup_btn;



        // ************************************************************************************************************* //


        // Use this for initialization
		void Awake () {
			debug_label2 = GameObject.Find ("debug_label2");

            print("set popup");
            weapon_sel_popup_window_obj = GameObject.Find("_select_npc_popup_window");

            gold_total_label = GameObject.Find ("_gold_total_label");
			gemstone_total_label = GameObject.Find ("_gemstone_total_label");
				
			chest_sprite = GameObject.Find ("chest_sprite");
			chest_HUDText_control = GameObject.Find ("chest_HUDText");
			chest_opened_sprite = GameObject.Find ("chest_opened_sprite");
			chest_opened_sprite.SetActive (false);

			chest_lvup_btn = GameObject.Find ("chest_levelup_btn");
			chest_lv_label = GameObject.Find ("_chest_lv_label");
			chest_lvup_cost_label = GameObject.Find ("_chest_levelup_cost_label");
			chest_dropgold_current_label = GameObject.Find ("_chest_dropgold_current_label");
			chest_dropgold_after_label = GameObject.Find ("_chest_dropgold_after_label");

			slash1_lvup_btn = GameObject.Find ("_slash1_levelup_btn");
			slash1_lv_label = GameObject.Find ("_slash1_lv_label");
			slash1_lvup_cost_label = GameObject.Find ("_slash1_levelup_cost_label");
			slash1_damage_current_label = GameObject.Find ("_slash1_damage_current_label");
			slash1_damage_after_label = GameObject.Find ("_slash1_damage_after_label");

			slash2_locking_sprite = GameObject.Find ("_slash2_locking_sprite");
			slash2_lvup_btn = GameObject.Find ("_slash2_levelup_btn");
			slash2_lv_label = GameObject.Find ("_slash2_lv_label");
			slash2_lvup_cost_label = GameObject.Find ("_slash2_levelup_cost_label");
			slash2_damage_current_label = GameObject.Find ("_slash2_damage_current_label");
			slash2_damage_after_label = GameObject.Find ("_slash2_damage_after_label");

			slash3_locking_sprite = GameObject.Find ("_slash3_locking_sprite");
			slash3_lvup_btn = GameObject.Find ("_slash3_levelup_btn");
			slash3_lv_label = GameObject.Find ("_slash3_lv_label");
			slash3_lvup_cost_label = GameObject.Find ("_slash3_levelup_cost_label");
			slash3_damage_current_label = GameObject.Find ("_slash3_damage_current_label");
			slash3_damage_after_label = GameObject.Find ("_slash3_damage_after_label");

			slash4_locking_sprite = GameObject.Find ("_slash4_locking_sprite");
			slash4_lvup_btn = GameObject.Find ("_slash4_levelup_btn");
			slash4_lv_label = GameObject.Find ("_slash4_lv_label");
			slash4_lvup_cost_label = GameObject.Find ("_slash4_levelup_cost_label");
			slash4_damage_current_label = GameObject.Find ("_slash4_damage_current_label");
			slash4_damage_after_label = GameObject.Find ("_slash4_damage_after_label");

			slash5_locking_sprite = GameObject.Find ("_slash5_locking_sprite");
			slash5_lvup_btn = GameObject.Find ("_slash5_levelup_btn");
			slash5_lv_label = GameObject.Find ("_slash5_lv_label");
			slash5_lvup_cost_label = GameObject.Find ("_slash5_levelup_cost_label");
			slash5_damage_current_label = GameObject.Find ("_slash5_damage_current_label");
			slash5_damage_after_label = GameObject.Find ("_slash5_damage_after_label");

           

            // **************************************   BOSS GameObject init    ************************************************ //
            boss_hp_value = GameObject.Find ("Boss_Sprite");

			chest_lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			slash1_lvup_btn.GetComponent<UIButton> ().isEnabled = false;

            // **************************************    GameObject init    ************************************************ //
            // Total Gold && gemstone 초기화.
			coin_struct.gold = 0f;
			coin_struct.gemstone = 0f;

            // Touch Slash 개수 초기화.
            number_of_slash = 2;

            // chest init and update label //
            levelup_chest_data_struct();
			update_chest_data_label ();

			// slash1 init and update label//
			levelup_slash1_data_struct();
			update_slash1_data_label();

			// slash2 init and update label//
			levelup_slash2_data_struct();
			update_slash2_data_label();

			// slash3 init and update label//
			levelup_slash3_data_struct();
			update_slash3_data_label();

			// slash4 init and update label//
			levelup_slash4_data_struct();
			update_slash4_data_label();

			// slash5 init and update label//
			levelup_slash5_data_struct();
			update_slash5_data_label();

            // check whether all buttons is enable or not //
            check_lvup_button_is_enable_or_not();

        }
		
		// Update is called once per frame
		void Update () {
		
		}

		// **************			chest function 					************** //

		// **************  Update Chest button all labels
		public static void update_chest_data_label()
		{
			chest_lv_label.GetComponent<UILabel> ().text = chest_struct.Level.ToString ();

			chest_dropgold_current_label.GetComponent<UILabel>().text = chest_struct.attacked_gold.ToString ();
			chest_dropgold_after_label.GetComponent<UILabel> ().text = (chest_struct.attacked_gold+1).ToString ();
			chest_lvup_cost_label.GetComponent<UILabel> ().text = chest_struct.upgrade_cost.ToString ();

		}

		// Update Chest data
		public static void levelup_chest_data_struct()
		{
			chest_struct.Level = chest_struct.Level + 1;
			chest_struct.HP = 200f + (chest_struct.Level * 50);
			chest_struct._HP = 200f + (chest_struct.Level * 50);
            chest_struct.attacked_gold = (float)chest_struct.Level;
			chest_struct.attacked_gemstone = (float)chest_struct.Level;
            chest_struct.upgrade_cost = chest_struct.Level * 100f;

        }

		// **************			slash1 function 					************** //

		// Update slash1 button all labels
		public static void update_slash1_data_label()
		{
			slash1_lv_label.GetComponent<UILabel> ().text = slash1_struct.Level.ToString ();
			slash1_lvup_cost_label.GetComponent<UILabel> ().text = slash1_struct.upgrade_cost.ToString ();

			slash1_damage_current_label.GetComponent<UILabel>().text = slash1_struct.damage.ToString ();
			slash1_damage_after_label.GetComponent<UILabel> ().text = (slash1_struct.damage + 1).ToString ();
		}

		// Levelup slash1 struct data
		public static void levelup_slash1_data_struct()
		{
			slash1_struct.Level = slash1_struct.Level + 1;
			slash1_struct.damage = slash1_struct.Level;
			slash1_struct.upgrade_cost = 10f + (slash1_struct.Level*5);

            // 다음 slash UnLock.
            if(slash1_struct.Level == 2)
            {
                print("unlock slash2");
                slash2_locking_sprite.SetActive(false);                 // Slash2 Object 활성화.
                number_of_slash++;                                    // Slash2 Object 활성화.
            }
		}

		// **************			slash2 function 					************** //

		// Update slash2 button all labels
		public static void update_slash2_data_label()
		{
			slash2_lv_label.GetComponent<UILabel> ().text = slash2_struct.Level.ToString ();
			slash2_lvup_cost_label.GetComponent<UILabel> ().text = slash2_struct.upgrade_cost.ToString ();

			slash2_damage_current_label.GetComponent<UILabel>().text = slash2_struct.damage.ToString ();
			slash2_damage_after_label.GetComponent<UILabel> ().text = (10 + ((slash2_struct.Level+1) * 3)).ToString ();
		}

		// Levelup slash2 struct data
		public static void levelup_slash2_data_struct()
		{
			slash2_struct.Level = slash2_struct.Level + 1;
			slash2_struct.damage = 10 + (slash2_struct.Level*3);
			slash2_struct.upgrade_cost = 300f + (slash1_struct.Level * 55);

            // 다음 slash UnLock.
            if (slash2_struct.Level == 20)
            {
                print("unlock slash3");
                slash3_locking_sprite.SetActive(false);
                number_of_slash++;
            }
        }

		// **************			slash3 function 					************** //

		// Update slash3 button all labels
		public static void update_slash3_data_label()
		{
			slash3_lv_label.GetComponent<UILabel> ().text = slash3_struct.Level.ToString ();
			slash3_lvup_cost_label.GetComponent<UILabel> ().text = slash3_struct.upgrade_cost.ToString ();

			slash3_damage_current_label.GetComponent<UILabel>().text = slash3_struct.damage.ToString ();
			slash3_damage_after_label.GetComponent<UILabel> ().text = (slash3_struct.damage + 1).ToString ();
		}

		// Levelup slash3 struct data
		public static void levelup_slash3_data_struct()
		{
			slash3_struct.Level = slash3_struct.Level + 1;
			slash3_struct.damage = slash3_struct.damage + 1;
			slash3_struct.upgrade_cost = slash3_struct.upgrade_cost + 30;

		}

		// **************			slash4 function 					************** //

		// Update slash4 button all labels
		public static void update_slash4_data_label()
		{
			slash4_lv_label.GetComponent<UILabel> ().text = slash4_struct.Level.ToString ();
			slash4_lvup_cost_label.GetComponent<UILabel> ().text = slash4_struct.upgrade_cost.ToString ();

			slash4_damage_current_label.GetComponent<UILabel>().text = slash4_struct.damage.ToString ();
			slash4_damage_after_label.GetComponent<UILabel> ().text = (slash4_struct.damage + 1).ToString ();
		}

		// Levelup slash2 struct data
		public static void levelup_slash4_data_struct()
		{
			slash4_struct.Level = slash4_struct.Level + 1;
			slash4_struct.damage = slash4_struct.damage + 1;
			slash4_struct.upgrade_cost = slash4_struct.upgrade_cost + 40;

		}

		// **************			slash5 function 					************** //

		// Update slash5 button all labels
		public static void update_slash5_data_label()
		{
			slash5_lv_label.GetComponent<UILabel> ().text = slash5_struct.Level.ToString ();
			slash5_lvup_cost_label.GetComponent<UILabel> ().text = slash5_struct.upgrade_cost.ToString ();

			slash5_damage_current_label.GetComponent<UILabel>().text = slash5_struct.damage.ToString ();
			slash5_damage_after_label.GetComponent<UILabel> ().text = (slash5_struct.damage + 1).ToString ();
		}

		// Levelup slash5 struct data
		public static void levelup_slash5_data_struct()
		{
			slash5_struct.Level = slash5_struct.Level + 1;
			slash5_struct.damage = slash5_struct.damage + 1;
			slash5_struct.upgrade_cost = slash5_struct.upgrade_cost + 50;

		}

      

        
        // ********************************************************			etc.. functions 					******************************************************** //

        //check whether upgrade buttons are possiable or not
        public static void check_lvup_button_is_enable_or_not()
		{
			// 보물상자 버튼 체크.
			if (coin_struct.gold >= chest_struct.upgrade_cost) {
				chest_lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else 
			{
				chest_lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}

			// slash1 button check
			if (coin_struct.gold >= slash1_struct.upgrade_cost) {
				slash1_lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else 
			{
				slash1_lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}

			// slash2 button check
			if (coin_struct.gold >= slash2_struct.upgrade_cost) {
				slash2_lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else 
			{
				slash2_lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}

            // NPC01 button check
            if (coin_struct.gold >= NPC01_make.NPC01_struct.upgrade_cost)
            {
                NPC01_make.NPC01_struct.npc01_lvup_btn.GetComponent<UIButton>().isEnabled = true;
            }
            else
            {
                NPC01_make.NPC01_struct.npc01_lvup_btn.GetComponent<UIButton>().isEnabled = false;
            }


        }
	}

}