using UnityEngine;
using System.Collections;


public class Human : MonoBehaviour {


	public struct human_struct
	{
		public static GameObject gameobject;
		public static GameObject level_label;
		public static GameObject damage_label;
		public static GameObject upgrade_cost_label;
		public static int Level;
		public static float damage;
		public static float upgrade_cost;
	}

	// Use this for initialization
	void Start () {
		init_human_data ();
		update_human_data_label ();
		human_struct.gameobject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	
	}

	void OnTriggerEnter2D(Collider2D coll) 
	{
		print("human attack");
		//GM.attacked_chest ();

	}

	void init_human_data()
	{
		human_struct.gameobject = this.gameObject;
		human_struct.level_label = GameObject.Find ("_human_level_label");
		human_struct.damage_label = GameObject.Find ("_human_damage_label");
		human_struct.upgrade_cost_label = GameObject.Find ("_human_lvup_cost_label");
		human_struct.Level = 1;
		human_struct.damage = 1;
		human_struct.upgrade_cost = 1000;

	}

	public static void upgrade_human_data()
	{
		human_struct.Level = human_struct.Level + 1;
		human_struct.damage = human_struct.damage + 1;
		human_struct.upgrade_cost = human_struct.upgrade_cost + 100;

	}

	public static void update_human_data_label()
	{
		
		human_struct.level_label.GetComponent<UILabel> ().text = human_struct.Level.ToString ();
		human_struct.damage_label.GetComponent<UILabel> ().text = human_struct.damage.ToString ();
		human_struct.upgrade_cost_label.GetComponent<UILabel> ().text = human_struct.upgrade_cost.ToString ();

	}
}
