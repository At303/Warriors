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
			public static ulong gold;
			public static ulong gemstone;
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
			public static ulong Level;
			public static float HP;
			public static float _HP;										// to save the current chest HP
			//public static float drop_gold;
			public static ulong attacked_gold;
			public static ulong attacked_plus_gold;

			public static ulong attacked_gemstone;
			public static ulong upgrade_cost;
		}

        public static int number_of_slash;

		// slash1 struct
		public struct slash1_struct
		{
			public static ulong Level;
			public static ulong damage;
			public static ulong add_damage;
			public static ulong upgrade_cost;
		}

		// slash2 struct
		public struct slash2_struct
		{
			public static int Level;
			public static ulong damage;
			public static ulong add_damage;
			public static ulong upgrade_cost;
		}

		// slash3 struct
		public struct slash3_struct
		{
			public static int Level;
			public static ulong damage;
			public static ulong add_damage;
			public static ulong upgrade_cost;
		}

		// slash4 struct
		public struct slash4_struct
		{
			public static int Level;
			public static ulong damage;
			public static ulong add_damage;
			public static ulong upgrade_cost;
		}

		// slash5 struct
		public struct slash5_struct
		{
			public static int Level;
			public static ulong damage;
			public static ulong add_damage;
			public static ulong upgrade_cost;
		}

        
        // 캐릭터 무기 바꿀 시 사용하는 구조체.
        public struct to_change_npc_struct
        {
            public static int weapon_index;
            public static string To_Change_Weapon_type;
            public static int armor_index;
            public static int armor_color;
            public static string To_Change_Armor_type;
            public static int bow_index;
            public static string To_Change_bow_type;
			public static int wing_index;
			public static string To_Change_wing_type;

        }
        // **************************************    GameObject data    ************************************************ //

        public static GameObject debug_label2;

        // Popup Window object
        public static GameObject weapon_sel_popup_window_obj;
        public static GameObject clothes_sel_popup_window_obj;
        public static GameObject bow_sel_popup_window_obj;
		public static GameObject wing_sel_popup_window_obj;


        // label object
        public static GameObject gold_total_label;					// gold total label
		public static GameObject gemstone_total_label;				// gemstone total label

		// chest && slashes object
		public static GameObject chest_lv_label;
		public static GameObject chest_dropgold_label;
		public static GameObject chest_dropgold_plus_label;
		public static GameObject chest_lvup_cost_label;

		public static GameObject slash1_lv_label;
		public static GameObject slash1_lvup_cost_label;
		public static GameObject slash1_damage_label;
		public static GameObject slash1_damage_plus_label;

		public static GameObject slash2_locking_sprite;
		public static GameObject slash2_lv_label;
		public static GameObject slash2_lvup_cost_label;
		public static GameObject slash2_damage_label;
		public static GameObject slash2_damage_plus_label;

		public static GameObject slash3_locking_sprite;
		public static GameObject slash3_lv_label;
		public static GameObject slash3_lvup_cost_label;
		public static GameObject slash3_damage_label;
		public static GameObject slash3_damage_plus_label;

		public static GameObject slash4_locking_sprite;
		public static GameObject slash4_lv_label;
		public static GameObject slash4_lvup_cost_label;
		public static GameObject slash4_damage_label;
		public static GameObject slash4_damage_plus_label;

		public static GameObject slash5_locking_sprite;
		public static GameObject slash5_lv_label;
		public static GameObject slash5_lvup_cost_label;
		public static GameObject slash5_damage_label;
		public static GameObject slash5_damage_plus_label;



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

            weapon_sel_popup_window_obj = GameObject.Find("_select_npc_weapon_popup_window");
            clothes_sel_popup_window_obj = GameObject.Find("_select_npc_clothes_popup_window");
            bow_sel_popup_window_obj = GameObject.Find("_select_npc_bow_popup_window");
			wing_sel_popup_window_obj = GameObject.Find ("_select_npc_wing_popup_window");

            gold_total_label = GameObject.Find ("_gold_total_label");
			gemstone_total_label = GameObject.Find ("_gemstone_total_label");
				
			chest_sprite = GameObject.Find ("chest_sprite");
			chest_HUDText_control = GameObject.Find ("chest_HUDText");
			chest_opened_sprite = GameObject.Find ("chest_opened_sprite");
			chest_opened_sprite.SetActive (false);

			chest_lvup_btn = GameObject.Find ("chest_levelup_btn");
			chest_lv_label = GameObject.Find ("_chest_lv_label");
			chest_lvup_cost_label = GameObject.Find ("_chest_levelup_cost_label");
			chest_dropgold_label = GameObject.Find ("_chest_dropgold_label");
			chest_dropgold_plus_label = GameObject.Find ("_chest_dropgold_plus_label");

			slash1_lvup_btn = GameObject.Find ("_slash1_levelup_btn");
			slash1_lv_label = GameObject.Find ("_slash1_lv_label");
			slash1_lvup_cost_label = GameObject.Find ("_slash1_levelup_cost_label");
			slash1_damage_label = GameObject.Find ("_slash1_damage_label");
			slash1_damage_plus_label = GameObject.Find ("_slash1_damage_plus_label");

			slash2_locking_sprite = GameObject.Find ("_slash2_locking_sprite");
			slash2_lvup_btn = GameObject.Find ("_slash2_levelup_btn");
			slash2_lv_label = GameObject.Find ("_slash2_lv_label");
			slash2_lvup_cost_label = GameObject.Find ("_slash2_levelup_cost_label");
			slash2_damage_label = GameObject.Find ("_slash2_damage_label");
			slash2_damage_plus_label = GameObject.Find ("_slash2_damage_plus_label");

			slash3_locking_sprite = GameObject.Find ("_slash3_locking_sprite");
			slash3_lvup_btn = GameObject.Find ("_slash3_levelup_btn");
			slash3_lv_label = GameObject.Find ("_slash3_lv_label");
			slash3_lvup_cost_label = GameObject.Find ("_slash3_levelup_cost_label");
			slash3_damage_label = GameObject.Find ("_slash3_damage_label");
			slash3_damage_plus_label = GameObject.Find ("_slash3_damage_plus_label");

			slash4_locking_sprite = GameObject.Find ("_slash4_locking_sprite");
			slash4_lvup_btn = GameObject.Find ("_slash4_levelup_btn");
			slash4_lv_label = GameObject.Find ("_slash4_lv_label");
			slash4_lvup_cost_label = GameObject.Find ("_slash4_levelup_cost_label");
			slash4_damage_label = GameObject.Find ("_slash4_damage_label");
			slash4_damage_plus_label = GameObject.Find ("_slash4_damage_plus_label");

			slash5_locking_sprite = GameObject.Find ("_slash5_locking_sprite");
			slash5_lvup_btn = GameObject.Find ("_slash5_levelup_btn");
			slash5_lv_label = GameObject.Find ("_slash5_lv_label");
			slash5_lvup_cost_label = GameObject.Find ("_slash5_levelup_cost_label");
			slash5_damage_label = GameObject.Find ("_slash5_damage_label");
			slash5_damage_plus_label = GameObject.Find ("_slash5_damage_plus_label");

           

            // **************************************   BOSS GameObject init    ************************************************ //
            boss_hp_value = GameObject.Find ("Boss_Sprite");

			chest_lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			slash1_lvup_btn.GetComponent<UIButton> ().isEnabled = false;

            // **************************************    GameObject init    ************************************************ //
            // Total Gold && gemstone 초기화.
			coin_struct.gold = 0;
			coin_struct.gemstone = 0;

            // Touch Slash 개수 초기화.
            number_of_slash = 2;

            // chest init and update label //
			chest_struct.attacked_plus_gold = 0;
            levelup_chest_data_struct();
			update_chest_data_label ();

			// slash1 init and update label//
			slash1_struct.add_damage = 0;
			levelup_slash1_data_struct();
			update_slash1_data_label();

			// slash2 init and update label//
			slash2_struct.add_damage = 0;
			levelup_slash2_data_struct();
			update_slash2_data_label();

			// slash3 init and update label//
			slash3_struct.add_damage = 0;
			levelup_slash3_data_struct();
			update_slash3_data_label();

			// slash4 init and update label//
			slash4_struct.add_damage = 0;
			levelup_slash4_data_struct();
			update_slash4_data_label();

			// slash5 init and update label//
			slash5_struct.add_damage = 0;
			levelup_slash5_data_struct();
			update_slash5_data_label();

            // check whether all buttons is enable or not //
           // check_lvup_button_is_enable_or_not();


        }
		
		// Update is called once per frame
		void Update () {
		
		}

		// **************			chest function 					************** //

		// **************  Update Chest button all labels
		public static void update_chest_data_label()
		{
			chest_lv_label.GetComponent<UILabel> ().text = chest_struct.Level.ToString ();

			chest_dropgold_label.GetComponent<UILabel> ().text = int_to_label_format (chest_struct.attacked_gold);
			chest_dropgold_plus_label.GetComponent<UILabel> ().text = int_to_label_format(chest_struct.attacked_plus_gold);
			chest_lvup_cost_label.GetComponent<UILabel> ().text = int_to_label_format (chest_struct.upgrade_cost);

		}

		// Update Chest data
		public static void levelup_chest_data_struct()
		{
			chest_struct.Level = chest_struct.Level + 1;
			chest_struct.HP = 600f + (chest_struct.Level * 50);
			chest_struct._HP = 600f + (chest_struct.Level * 50);

            chest_struct.attacked_gold = chest_struct.Level;
			chest_struct.attacked_gemstone = chest_struct.Level;
            chest_struct.upgrade_cost = chest_struct.Level * 100;

        }

		// **************			slash1 function 					************** //

		// Update slash1 button all labels
		public static void update_slash1_data_label()
		{
			slash1_lv_label.GetComponent<UILabel> ().text = slash1_struct.Level.ToString ();
			slash1_lvup_cost_label.GetComponent<UILabel> ().text = int_to_label_format (slash1_struct.upgrade_cost);

			slash1_damage_label.GetComponent<UILabel> ().text = int_to_label_format (slash1_struct.damage);
			slash1_damage_plus_label.GetComponent<UILabel> ().text = int_to_label_format (slash1_struct.add_damage);
		}

		// Levelup slash1 struct data
		public static void levelup_slash1_data_struct()
		{
			slash1_struct.Level = slash1_struct.Level + 1;
			slash1_struct.damage = slash1_struct.Level;
			slash1_struct.upgrade_cost = 10 + (slash1_struct.Level*5);

            // 다음 slash UnLock.
            if(slash1_struct.Level == 3)
            {
                slash2_locking_sprite.SetActive(false);                 // Slash2 Object 활성화.
            }
		}

		// **************			slash2 function 					************** //

		// Update slash2 button all labels
		public static void update_slash2_data_label()
		{
			slash2_lv_label.GetComponent<UILabel> ().text = slash2_struct.Level.ToString ();
			slash2_lvup_cost_label.GetComponent<UILabel> ().text = int_to_label_format (slash2_struct.upgrade_cost);

			slash2_damage_label.GetComponent<UILabel> ().text = int_to_label_format (slash2_struct.damage);
			slash2_damage_plus_label.GetComponent<UILabel> ().text = int_to_label_format (slash2_struct.add_damage);
		}

		// Levelup slash2 struct data
		public static void levelup_slash2_data_struct()
		{
			// slash Image UnLock.
			if (slash2_struct.Level == 1)
			{
				number_of_slash++;                                    // Slash 레벨 업시 slash 이미지 추가.
			}

			slash2_struct.Level = slash2_struct.Level + 1;
			slash2_struct.damage = 10UL + (ulong)(slash2_struct.Level*3);
			slash2_struct.upgrade_cost = 10 + (slash1_struct.Level * 5);

            // 다음 slash UnLock.
            if (slash2_struct.Level == 3)
            {
                slash3_locking_sprite.SetActive(false);
            }
        }

		// **************			slash3 function 					************** //

		// Update slash3 button all labels
		public static void update_slash3_data_label()
		{
			slash3_lv_label.GetComponent<UILabel> ().text = slash3_struct.Level.ToString ();
			slash3_lvup_cost_label.GetComponent<UILabel> ().text = int_to_label_format (slash3_struct.upgrade_cost);

			slash3_damage_label.GetComponent<UILabel> ().text = int_to_label_format (slash3_struct.damage);
			slash3_damage_plus_label.GetComponent<UILabel> ().text = int_to_label_format (slash3_struct.add_damage);
		}

		// Levelup slash3 struct data
		public static void levelup_slash3_data_struct()
		{
			// slash Image UnLock.
			if (slash3_struct.Level == 1)
			{
				number_of_slash++;                                    // Slash 레벨 업시 slash 이미지 추가.
			}

			slash3_struct.Level = slash3_struct.Level + 1;
			slash3_struct.damage = slash3_struct.damage + 1;
			slash3_struct.upgrade_cost = slash3_struct.upgrade_cost + 30;

			// 다음 slash UnLock.
			if (slash3_struct.Level == 3)
			{
				slash4_locking_sprite.SetActive(false);
			}
		}

		// **************			slash4 function 					************** //

		// Update slash4 button all labels
		public static void update_slash4_data_label()
		{
			slash4_lv_label.GetComponent<UILabel> ().text = slash4_struct.Level.ToString ();
			slash4_lvup_cost_label.GetComponent<UILabel> ().text = int_to_label_format (slash3_struct.upgrade_cost);

			slash4_damage_label.GetComponent<UILabel> ().text = int_to_label_format (slash4_struct.damage);
			slash4_damage_plus_label.GetComponent<UILabel> ().text = int_to_label_format (slash3_struct.add_damage);
		}

		// Levelup slash2 struct data
		public static void levelup_slash4_data_struct()
		{
			// slash Image UnLock.
			if (slash4_struct.Level == 1)
			{
				number_of_slash++;                                    // Slash 레벨 업시 slash 이미지 추가.
			}

			slash4_struct.Level = slash4_struct.Level + 1;
			slash4_struct.damage = slash4_struct.damage + 1;
			slash4_struct.upgrade_cost = slash4_struct.upgrade_cost + 40;

			// 다음 slash UnLock.
			if (slash4_struct.Level == 3)
			{
				slash4_locking_sprite.SetActive(false);
			}

		}

		// **************			slash5 function 					************** //

		// Update slash5 button all labels
		public static void update_slash5_data_label()
		{
			slash5_lv_label.GetComponent<UILabel> ().text = slash5_struct.Level.ToString ();
			slash5_lvup_cost_label.GetComponent<UILabel> ().text = int_to_label_format (slash1_struct.upgrade_cost);

			slash5_damage_label.GetComponent<UILabel> ().text = int_to_label_format (slash5_struct.damage);
			slash5_damage_plus_label.GetComponent<UILabel> ().text = int_to_label_format (slash5_struct.add_damage);
		}

		// Levelup slash5 struct data
		public static void levelup_slash5_data_struct()
		{
			// slash Image UnLock.
			if (slash5_struct.Level == 1)
			{
				number_of_slash++;                                    // Slash 레벨 업시 slash 이미지 추가.
			}

			slash5_struct.Level = slash5_struct.Level + 1;
			slash5_struct.damage = slash5_struct.damage + 1;
			slash5_struct.upgrade_cost = slash5_struct.upgrade_cost + 50;

		}

      

        
        // ********************************************************			etc.. functions 					******************************************************** //

        //check whether upgrade buttons are possiable or not
        public static void check_lvup_button_is_enable_or_not()
		{/*
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

			// slash3 button check
			if (coin_struct.gold >= slash3_struct.upgrade_cost) {
				slash3_lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else 
			{
				slash3_lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}

			// slash4 button check
			if (coin_struct.gold >= slash4_struct.upgrade_cost) {
				slash4_lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else 
			{
				slash4_lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}

			// slash5 button check
			if (coin_struct.gold >= slash5_struct.upgrade_cost) {
				slash5_lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else 
			{
				slash5_lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}

            // NPC01 button check
            if (coin_struct.gold >= NPC01_make.NPC01_struct.upgrade_cost)
            {
                NPC01_make.NPC01_struct.lvup_btn.GetComponent<UIButton>().isEnabled = true;
            }
            else
            {
                NPC01_make.NPC01_struct.lvup_btn.GetComponent<UIButton>().isEnabled = false;
            }

            // NPC02 button check
            if (coin_struct.gold >= NPC02_make.NPC02_struct.upgrade_cost)
            {
                NPC02_make.NPC02_struct.lvup_btn.GetComponent<UIButton>().isEnabled = true;
            }
            else
            {
                NPC02_make.NPC02_struct.lvup_btn.GetComponent<UIButton>().isEnabled = false;
            }

            // NPC03 button check
            if (coin_struct.gold >= NPC03_make.NPC03_struct.upgrade_cost)
            {
                NPC03_make.NPC03_struct.lvup_btn.GetComponent<UIButton>().isEnabled = true;
            }
            else
            {
                NPC03_make.NPC03_struct.lvup_btn.GetComponent<UIButton>().isEnabled = false;
            }

            // NPC04 button check
            if (coin_struct.gold >= NPC04_make.NPC04_struct.upgrade_cost)
            {
                NPC04_make.NPC04_struct.lvup_btn.GetComponent<UIButton>().isEnabled = true;
            }
            else
            {
                NPC04_make.NPC04_struct.lvup_btn.GetComponent<UIButton>().isEnabled = false;
            }

            // NPC05 button check
            if (coin_struct.gold >= NPC05_make.NPC05_struct.upgrade_cost)
            {
                NPC05_make.NPC05_struct.lvup_btn.GetComponent<UIButton>().isEnabled = true;
            }
            else
            {
                NPC05_make.NPC05_struct.lvup_btn.GetComponent<UIButton>().isEnabled = false;
            }

            // NPC06 button check
            if (coin_struct.gold >= NPC06_make.NPC06_struct.upgrade_cost)
            {
                NPC06_make.NPC06_struct.lvup_btn.GetComponent<UIButton>().isEnabled = true;
            }
            else
            {
                NPC06_make.NPC06_struct.lvup_btn.GetComponent<UIButton>().isEnabled = false;
            }

            // NPC07 button check
            if (coin_struct.gold >= NPC07_make.NPC07_struct.upgrade_cost)
            {
                NPC07_make.NPC07_struct.lvup_btn.GetComponent<UIButton>().isEnabled = true;
            }
            else
            {
                NPC07_make.NPC07_struct.lvup_btn.GetComponent<UIButton>().isEnabled = false;
            }

            // NPC08 button check
            if (coin_struct.gold >= NPC08_make.NPC08_struct.upgrade_cost)
            {
                NPC08_make.NPC08_struct.lvup_btn.GetComponent<UIButton>().isEnabled = true;
            }
            else
            {
                NPC08_make.NPC08_struct.lvup_btn.GetComponent<UIButton>().isEnabled = false;
            }

            // NPC09 button check
            if (coin_struct.gold >= NPC09_make.NPC09_struct.upgrade_cost)
            {
                NPC09_make.NPC09_struct.lvup_btn.GetComponent<UIButton>().isEnabled = true;
            }
            else
            {
                NPC09_make.NPC09_struct.lvup_btn.GetComponent<UIButton>().isEnabled = false;
            }

            // NPC10 button check
            if (coin_struct.gold >= NPC10_make.NPC10_struct.upgrade_cost)
            {
                NPC10_make.NPC10_struct.lvup_btn.GetComponent<UIButton>().isEnabled = true;
            }
            else
            {
                NPC10_make.NPC10_struct.lvup_btn.GetComponent<UIButton>().isEnabled = false;
            }

            // NPC11 button check
            if (coin_struct.gold >= NPC11_make.NPC11_struct.upgrade_cost)
            {
                NPC11_make.NPC11_struct.lvup_btn.GetComponent<UIButton>().isEnabled = true;
            }
            else
            {
                NPC11_make.NPC11_struct.lvup_btn.GetComponent<UIButton>().isEnabled = false;
            }

            // NPC12 button check
            if (coin_struct.gold >= NPC12_make.NPC12_struct.upgrade_cost)
            {
                NPC12_make.NPC12_struct.lvup_btn.GetComponent<UIButton>().isEnabled = true;
            }
            else
            {
                NPC12_make.NPC12_struct.lvup_btn.GetComponent<UIButton>().isEnabled = false;
            }

            */
        }

		public static string int_to_label_format(ulong _number)
		{
			string _return_label = "";
			int i = 0;
			ulong remainder = 0;
			ulong[] temp_number = new ulong[10];

			for(;i < 10 ;i++)
			{
				temp_number [i] = _number % 1000;
				remainder = _number/1000;
				_number = remainder;

				if (remainder == 0)
					break;
			}

			if (i == 0) {
				_return_label = temp_number [0].ToString ();
			} else if (i == 1) {
				_return_label = temp_number [1].ToString () + "." + temp_number [0].ToString () + "K";
			} else if (i == 2) {
				_return_label = temp_number [2].ToString () + "." + temp_number [1].ToString () + "M";
			} else if (i == 3) {
				_return_label = temp_number [3].ToString () + "." + temp_number [2].ToString () + "G";
			} else if (i == 4) {
				_return_label = temp_number [4].ToString () + "." + temp_number [3].ToString () + "T";
			}else if (i == 5) {
				_return_label = temp_number [5].ToString () + "." + temp_number [4].ToString () + "P";
			}else if (i == 6) {
				_return_label = temp_number [6].ToString () + "." + temp_number [5].ToString () + "E";
			}else if (i == 7) {
				_return_label = temp_number [7].ToString () + "." + temp_number [6].ToString () + "Z";
			}else if (i == 8) {
				_return_label = temp_number [8].ToString () + "." + temp_number [7].ToString () + "Y";
			}

			return _return_label;
		}


	}





}