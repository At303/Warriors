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

// **************************************    GameObject data    ************************************************ //

		public static GameObject debug_label1;
		public static GameObject debug_label2;

		public static GameObject chest_sprite;
		public static GameObject chest_opened_sprite;

		public static GameObject slash_animation;
// ************************************************************************************************************* //


		// Use this for initialization
		void Start () {
			debug_label1 = GameObject.Find ("debug_label1");
			debug_label2 = GameObject.Find ("debug_label2");

			chest_sprite = GameObject.Find ("chest_sprite");
			chest_opened_sprite = GameObject.Find ("chest_opened_sprite");
			chest_opened_sprite.SetActive (false);
// **************************************    GameObject init    ************************************************ //
			chest_struct.HP = 100f;
			chest_struct._HP = 100f;

			touch_struct.damage = 10f;

		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}

}