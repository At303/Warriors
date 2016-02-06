using UnityEngine;
using System.Collections;


public enum BUTTONID
{
	CHEST_UPGRADE_BUTTON,
	TOUCH_UPGRADE_BUTTON

}


public class data : MonoBehaviour {


	// **************************************    Game Button object    ************************************************ //

	public static GameObject chest_button;
	public static GameObject touch_button;

	// **************************************    GameObject data    ************************************************ //
	public static GameObject total_coin_Label;										// coin label
	public static GameObject check_touch_pos;										// coin label

	public static GameObject _chest_level_label;							// chest data label
	public static GameObject _now_chest_atcked_gold_label;					// chest data label
	public static GameObject _next_chest_atcked_gold_label;					// chest data label
	public static GameObject _now_chest_drop_gold_label;					// chest data label
	public static GameObject _next_chest_drop_gold_label;					// chest data label
	public static GameObject _chest_upgrade_cost_label;						// chest data label
	public static GameObject chest_sprite;									// chest data label
	public static GameObject opened_chest_sprite;							// chest data label
	public static GameObject chest_HP_bar_progress;							// chest HP bar
	public static GameObject opened_chest_HP_bar_progress;					// opened chest HP bar
	public static GameObject ChestBoxAnimator;								// chest animator


	//				**** touch data	****			//
	public static GameObject Touch_level_label;										// touch data
	public static GameObject _now_touch_damage_Label;								// touch data
	public static GameObject _next_touch_damage_Label;								// touch data
	public static GameObject _Touch_upgrade_cost_label;						// chest data label

	// **************************************    Game data Struct    ************************************************ //

	// Treasure Chest struct
	public struct coin_struct
	{
		public static float total;
		public static int touch;
		public static int click;


	}

	// Treasure Chest struct
	public struct chest_struct
	{
		public static int Level;
		public static float HP;
		public static float _HP;										// to save the current chest HP
		public static float drop_gold;
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


	// **************************************   	 Game function	    ************************************************ //
	void Start()
	{
		// **************************************    GameObject init    ************************************************ //
		chest_button = GameObject.Find ("chest_levelup_button");
		touch_button = GameObject.Find ("touch_levelup_button");

		check_touch_pos = GameObject.FindWithTag("check_touch");
		ChestBoxAnimator = GameObject.Find("chest_box_sprite");
		total_coin_Label = GameObject.Find("coinLABEL");
		chest_sprite = GameObject.Find ("chest_box_sprite");
		opened_chest_sprite = GameObject.Find ("chest_box_opened_sprite");

		chest_HP_bar_progress = GameObject.FindWithTag ("chest_HP_bar");
		opened_chest_HP_bar_progress = GameObject.FindWithTag ("opened_coin_chest_HP");
		opened_chest_sprite.SetActive (false);



		_chest_level_label = GameObject.Find ("chest_level_label");
		_now_chest_atcked_gold_label = GameObject.Find ("now_chest_atcked_gold_label");
		_next_chest_atcked_gold_label = GameObject.Find ("next_chest_atcked_gold_label");
		_now_chest_drop_gold_label = GameObject.Find ("now_chest_drop_gold_label");
		_next_chest_drop_gold_label = GameObject.Find ("next_chest_drop_gold_label");
		_chest_upgrade_cost_label = GameObject.Find ("chest_upgrade_cost_label");

		Touch_level_label = GameObject.Find ("now_touch_damage_Label");
		_now_touch_damage_Label = GameObject.Find ("now_touch_damage_Label");
		_next_touch_damage_Label = GameObject.Find ("next_touch_damage_Label");
		_Touch_upgrade_cost_label = GameObject.Find ("touch_button_leveup_label");


		// **************************************    coin data init     ************************************************ //
		coin_struct.total = 0;
		coin_struct.touch = 1;
		coin_struct.click = 1;

		// **************************************    Treasure Chest init     ************************************************ //
		chest_LevelUp_update();

		// **************************************      Touch struct init    ************************************************ //
		Touch_LevelUp_update();

	}


	// chest data init and update func
	public static void chest_LevelUp_update()
	{
		// Level
		chest_struct.Level = chest_struct.Level + 1;
		_chest_level_label.GetComponent<UILabel> ().text = chest_struct.Level.ToString ();

		// HP
		chest_struct.HP = Mathf.Round(Mathf.Pow((float)chest_struct.Level,2.0f) - (Mathf.Pow (2.0f, (-13.0f*(float)chest_struct.Level))) + 50.0f); 
		chest_struct._HP = chest_struct.HP;

		// attackd gold
		float temp_variable = Mathf.Round((-1.0f*0.0011f*Mathf.Pow((float)chest_struct.Level,2.0f)) + 0.445f*(float)chest_struct.Level + 1.1912f);

		chest_struct.attacked_gold = temp_variable;
		_now_chest_atcked_gold_label.GetComponent<UILabel> ().text = string.Format("{0:#,###}", chest_struct.attacked_gold);

		temp_variable = Mathf.Round((-1.0f*0.0011f*Mathf.Pow((float)(chest_struct.Level+1),2.0f)) + 0.445f*(float)(chest_struct.Level+1) + 1.1912f);
		_next_chest_atcked_gold_label.GetComponent<UILabel> ().text = string.Format("{0:#,###}", temp_variable);

		// drop gold
		temp_variable = Mathf.Round ((-0.0066f*Mathf.Pow((float)chest_struct.Level,2.0f))+0.5959f*(float)chest_struct.Level + 9.4912f);
		chest_struct.drop_gold = temp_variable;
		_now_chest_drop_gold_label.GetComponent<UILabel> ().text = string.Format("{0:#,###}", chest_struct.drop_gold);

		temp_variable = Mathf.Round ((-0.0066f*Mathf.Pow((float)chest_struct.Level+1,2.0f))+0.5959f*(float)chest_struct.Level+1 + 9.4912f);
		_next_chest_drop_gold_label.GetComponent<UILabel> ().text = string.Format("{0:#,###}", temp_variable);

		// upgrade cost
		temp_variable =Mathf.Round(Mathf.Pow((float)chest_struct.Level,2.0f) - (Mathf.Pow (2.0f, (-3.0f*(float)chest_struct.Level))) + 30.0f);
		chest_struct.upgrade_cost = temp_variable;
		_chest_upgrade_cost_label.GetComponent<UILabel> ().text = string.Format("{0:#,###}", chest_struct.upgrade_cost);

		// check chest upgrade button On or Off
		check_button_On_Off_All ();

	}


	// chest data init and update func
	public static void Touch_LevelUp_update()
	{
		// Level
		touch_struct.Level = touch_struct.Level + 1;
		Touch_level_label.GetComponent<UILabel> ().text = touch_struct.Level.ToString ();

		// Damage
		float temp_variable = Mathf.Round(touch_struct.Level * Mathf.Pow(1.004f, (float)touch_struct.Level)); 
		touch_struct.damage = temp_variable; 	//=Level*(1.05)^Level
		_now_touch_damage_Label.GetComponent<UILabel> ().text = touch_struct.damage.ToString ();
		temp_variable = Mathf.Round((float)touch_struct.Level+1 * Mathf.Pow(1.004f, (float)touch_struct.Level+1)); 
		_next_touch_damage_Label.GetComponent<UILabel> ().text = temp_variable.ToString ();

		// upgrade cost
		touch_struct.upgrade_cost = Mathf.Round(50*Mathf.Pow(1.175f,(float)chest_struct.Level));	//10*(1.075)^Level
		_Touch_upgrade_cost_label.GetComponent<UILabel>().text = touch_struct.upgrade_cost.ToString();

		// check chest upgrade button On or Off
		check_button_On_Off_All ();
	}

	// Check All Upgrade Button On Off
	public static void check_button_On_Off_All()
	{
		if (coin_struct.total >= chest_struct.upgrade_cost) {
			chest_button.GetComponent<UIButton> ().isEnabled = true;
		} else {
			chest_button.GetComponent<UIButton> ().isEnabled = false;
		}

		if (coin_struct.total >= touch_struct.upgrade_cost) {
			touch_button.GetComponent<UIButton> ().isEnabled = true;
		} else {
			touch_button.GetComponent<UIButton> ().isEnabled = false;
		}

	}




}
