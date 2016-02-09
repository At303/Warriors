using UnityEngine;
using System.Collections;



namespace gamedata 
{
	public class GameData : MonoBehaviour {

// **************************************    Game data Struct    ************************************************ //

		// Treasure Chest struct
		public struct coin_struct
		{
			public static float total;
		}

		// Treasure Chest struct
		public struct chest_struct
		{
			public static int Level;
			public static float HP;
			public static float _HP;										// to save the current chest HP
			//public static float drop_gold;
			public static float attacked_gold;
			public static float upgrade_cost;
		}

		// Touch struct
		public struct touch_struct
		{
			public static int Level;
			public static float damage;
			public static float upgrade_cost;
		}

// **************************************    GameObject data    ************************************************ //

		public static GameObject debug_label2;

		// label object
		public static GameObject coin_total_label;
		public static GameObject chest_lvup_cost_label;
		public static GameObject chest_lv_label;
		public static GameObject chest_dropgold_current_label;
		public static GameObject chest_dropgold_after_label;

		public static GameObject touch_lv_label;
		public static GameObject touch_lvup_cost_label;
		public static GameObject touch_damage_current_label;
		public static GameObject touch_damage_after_label;

		// sprite object
		public static GameObject chest_sprite;
		public static GameObject chest_opened_sprite;

		// HUD object
		public static GameObject chest_HUDText_control;

		// animation object
		public static GameObject slash_animation;

		// button Object
		public static GameObject chest_lvup_btn;
		public static GameObject touch_lvup_btn;


// ************************************************************************************************************* //


		// Use this for initialization
		void Start () {
			debug_label2 = GameObject.Find ("debug_label2");

			coin_total_label = GameObject.Find ("coin_total_label");

			chest_sprite = GameObject.Find ("chest_sprite");
			chest_HUDText_control = GameObject.Find ("chest_HUDText");
			chest_opened_sprite = GameObject.Find ("chest_opened_sprite");
			chest_opened_sprite.SetActive (false);

			chest_lvup_btn = GameObject.Find ("chest_levelup_btn");
			chest_lv_label = GameObject.Find ("_chest_lv_label");
			chest_lvup_cost_label = GameObject.Find ("_chest_levelup_cost_label");
			chest_dropgold_current_label = GameObject.Find ("_chest_dropgold_current_label");
			chest_dropgold_after_label = GameObject.Find ("_chest_dropgold_after_label");

			touch_lvup_btn = GameObject.Find ("_touch_levelup_btn");
			touch_lv_label = GameObject.Find ("_touch_lv_label");
			touch_lvup_cost_label = GameObject.Find ("_touch_levelup_cost_label");
			touch_damage_current_label = GameObject.Find ("_touch_damage_current_label");
			touch_damage_after_label = GameObject.Find ("_touch_damage_after_label");

			chest_lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			touch_lvup_btn.GetComponent<UIButton> ().isEnabled = false;
// **************************************    GameObject init    ************************************************ //
			coin_struct.total = 0f;

			// chest init //
			update_chest_data_struct();
			update_chest_data_label ();

			// touch init //
			update_touch_data_struct();
			update_touch_data_label();

			// check whether all buttons is enable or not //
			check_lvup_button_is_enable_or_not();

		}
		
		// Update is called once per frame
		void Update () {
		
		}

		// Update Chest button all labels
		public static void update_chest_data_label()
		{
			chest_lvup_cost_label.GetComponent<UILabel> ().text = chest_struct.upgrade_cost.ToString ();
			chest_lv_label.GetComponent<UILabel> ().text = chest_struct.Level.ToString ();

			chest_dropgold_current_label.GetComponent<UILabel>().text = chest_struct.attacked_gold.ToString ();
			chest_dropgold_after_label.GetComponent<UILabel> ().text = (chest_struct.attacked_gold + 1).ToString ();
		}

		// Update Chest data
		public static void update_chest_data_struct()
		{
			chest_struct.Level = chest_struct.Level + 1;
			chest_struct.HP = chest_struct.HP  + 100f ;
			chest_struct._HP = chest_struct._HP  + 100f;
			chest_struct.attacked_gold = (float)chest_struct.Level;
			chest_struct.upgrade_cost = chest_struct.upgrade_cost + 100f;
			//update_chest_data_label ();

		}

		// Update touch button all labels
		public static void update_touch_data_label()
		{
			touch_lv_label.GetComponent<UILabel> ().text = touch_struct.Level.ToString ();
			touch_lvup_cost_label.GetComponent<UILabel> ().text = touch_struct.upgrade_cost.ToString ();

			touch_damage_current_label.GetComponent<UILabel>().text = touch_struct.damage.ToString ();
			touch_damage_after_label.GetComponent<UILabel> ().text = (touch_struct.damage + 1).ToString ();
		}

		// Update touch data
		public static void update_touch_data_struct()
		{
			touch_struct.Level = touch_struct.Level + 1;
			touch_struct.damage = touch_struct.damage + 1;
			touch_struct.upgrade_cost = touch_struct.upgrade_cost + 100;

		}


		//check whether upgrade buttons are possiable or not
		public static void check_lvup_button_is_enable_or_not()
		{
			if (coin_struct.total >= chest_struct.upgrade_cost) {
				chest_lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else 
			{
				chest_lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}

			if (coin_struct.total >= touch_struct.upgrade_cost) {
				touch_lvup_btn.GetComponent<UIButton> ().isEnabled = true;
			} else 
			{
				touch_lvup_btn.GetComponent<UIButton> ().isEnabled = false;
			}
		}
	}

}