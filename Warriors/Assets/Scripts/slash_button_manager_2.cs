using UnityEngine;
using System.Collections;
using gamedata;

public class slash_button_manager_2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//GameData.slash1_struct.damage = 10f;
		//GameData.slash2_struct.damage = 20f;
		GameData.boss_monster_struct._HP = 100f;
		GameData.boss_monster_struct.HP = 100f;
		GameData.boss_hp_value = GameObject.Find ("Boss_Sprite");

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Clicked_slash1_button()
	{
		print ("damage 1  : "+GameData.slash1_struct.damage);
		print ("damage 2  : "+GameData.slash2_struct.damage);
		print ("damage 3  : "+GameData.slash3_struct.damage);


		if (slash_control_2.get_object_name () == "prefabs0") {
			slash_control_2.destory_object ();	// Destory Object in the square box
			slash_prefabs_2.swap_prefabs_and_make_new ();		// move Object in the array and make new Object

			// Decrease boss HP
			GameData.boss_monster_struct._HP = GameData.boss_monster_struct._HP - GameData.slash1_struct.damage;
			float fHP = GameData.boss_monster_struct._HP / GameData.boss_monster_struct.HP;
			GameData.boss_hp_value.GetComponent<UIProgressBar> ().value = fHP;


		} else 
		{
			print ("fail");
		}
	}

	public void Clicked_slash2_button()
	{
		print ("slash2 clicked");
		if (slash_control_2.get_object_name () == "prefabs1") {
			slash_control_2.destory_object ();	// Destory Object in the square box
			slash_prefabs_2.swap_prefabs_and_make_new ();		// move Object in the array and make new Object

			// Decrease boss HP
			GameData.boss_monster_struct._HP = GameData.boss_monster_struct._HP - GameData.slash2_struct.damage;
			float fHP = GameData.boss_monster_struct._HP / GameData.boss_monster_struct.HP;
			GameData.boss_hp_value.GetComponent<UIProgressBar> ().value = fHP;



		} else 
		{
			print ("fail 1");
		}

	}

	public void Clicked_slash3_button()
	{
		print ("slash3 clicked");
		if (slash_control_2.get_object_name () == "prefabs2") {
			slash_control_2.destory_object ();	// Destory Object in the square box
			slash_prefabs_2.swap_prefabs_and_make_new ();		// move Object in the array and make new Object

		} else 
		{
			print ("fail 1");
		}

	}

	public void Clicked_slash4_button()
	{
		print ("slash4 clicked");
		if (slash_control_2.get_object_name () == "prefabs3") {
			slash_control_2.destory_object ();	// Destory Object in the square box
			slash_prefabs_2.swap_prefabs_and_make_new ();		// move Object in the array and make new Object

		} else 
		{
			print ("fail 1");
		}

	}

	public void Clicked_slash5_button()
	{
		print ("slash5 clicked");
		if (slash_control_2.get_object_name () == "prefabs4") {
			slash_control_2.destory_object ();	// Destory Object in the square box
			slash_prefabs_2.swap_prefabs_and_make_new ();		// move Object in the array and make new Object

		} else 
		{
			print ("fail 1");
		}

	}

}
