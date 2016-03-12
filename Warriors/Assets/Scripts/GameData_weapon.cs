using UnityEngine;
using System.Collections;


namespace gamedata_weapon
{
public class GameData_weapon : MonoBehaviour {


	// Weapon01 Struct
	public struct Weapon01_struct
	{
		public static int level;
		public static float damage;
		public static float upgrade_cost;
	}

	// Weapon02Struct
	public struct Weapon02_struct
	{
		public int level;
		public float damage;
		public float upgrade_cost;

	}

	// Use this for initialization
	void Start ()
	{
		// Weapon01 데이터 초기화 및 라벨 Update//
		levelup_weapon01_data_struct();
		update_weapon01_data_label();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void levelup_weapon01_data_struct()
	{
		Weapon01_struct.level = Weapon01_struct.level + 1;
		Weapon01_struct.damage = Weapon01_struct.level * 2 + 20f;
		Weapon01_struct.upgrade_cost = 130f + Weapon01_struct.level*2;

		// Weapon02 Enable.
		if(Weapon01_struct.level == 2)
		{
			//npc_gameobject.SetActive(true);
		}
	}
	
	void update_weapon01_data_label()
	{
		GameObject weapon01_lv_label = GameObject.Find ("_weapon01_level_label");
		GameObject weapon01_lvup_cost_label = GameObject.Find ("_weapon01_upgrade_cost_label");
		GameObject weapon01_damage_label = GameObject.Find ("_weapon01_damage_label");

		print ("weapon01 Weapon01_struct.level "+ Weapon01_struct.level);
		weapon01_lv_label.GetComponent<UILabel>().text = Weapon01_struct.level.ToString();
		weapon01_damage_label.GetComponent<UILabel>().text = Weapon01_struct.damage.ToString();
		weapon01_lvup_cost_label.GetComponent<UILabel>().text = Weapon01_struct.upgrade_cost.ToString();
	}
	
}

}
