using UnityEngine;
using System.Collections;
using gamedata;
using UnityEngine.SceneManagement;

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

		if (slash_control_2.get_object_name () == "prefabs0") {
			slash_control_2.destory_object ();	// Destory Object in the square box
			slash_prefabs_2.swap_prefabs_and_make_new ();		// move Object in the array and make new Object

			// Decrease boss HP
			GameData.boss_monster_struct._HP = GameData.boss_monster_struct._HP - GameData.slash1_struct.damage;
			float fHP = GameData.boss_monster_struct._HP / GameData.boss_monster_struct.HP;
			GameData.boss_hp_value.GetComponent<UIProgressBar> ().value = fHP;

			//slash에 해당하는 atack image enable
			string slash_animation_name = "slash1";
			GameData.slash_animation = GameObject.Find (slash_animation_name);

			// slash sprite enable
			GameData.slash_animation.GetComponent<Animator>().SetTrigger("enable");
			GameData.slash_animation.GetComponent<SpriteRenderer> ().enabled = true;

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

			//slash에 해당하는 atack image enable
			string slash_animation_name = "slash2";
			GameData.slash_animation = GameObject.Find (slash_animation_name);

			// slash sprite enable
			GameData.slash_animation.GetComponent<Animator>().SetTrigger("enable");
			GameData.slash_animation.GetComponent<SpriteRenderer> ().enabled = true;

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

			// Decrease boss HP
			GameData.boss_monster_struct._HP = GameData.boss_monster_struct._HP - GameData.slash1_struct.damage;
			float fHP = GameData.boss_monster_struct._HP / GameData.boss_monster_struct.HP;
			GameData.boss_hp_value.GetComponent<UIProgressBar> ().value = fHP;

			//slash에 해당하는 atack image enable
			string slash_animation_name = "slash3";
			GameData.slash_animation = GameObject.Find (slash_animation_name);

			// slash sprite enable
			GameData.slash_animation.GetComponent<Animator>().SetTrigger("enable");
			GameData.slash_animation.GetComponent<SpriteRenderer> ().enabled = true;

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

			// Decrease boss HP
			GameData.boss_monster_struct._HP = GameData.boss_monster_struct._HP - GameData.slash1_struct.damage;
			float fHP = GameData.boss_monster_struct._HP / GameData.boss_monster_struct.HP;
			GameData.boss_hp_value.GetComponent<UIProgressBar> ().value = fHP;

			//slash에 해당하는 atack image enable
			string slash_animation_name = "slash4";
			GameData.slash_animation = GameObject.Find (slash_animation_name);

			// slash sprite enable
			GameData.slash_animation.GetComponent<Animator>().SetTrigger("enable");
			GameData.slash_animation.GetComponent<SpriteRenderer> ().enabled = true;
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

			// Decrease boss HP
			GameData.boss_monster_struct._HP = GameData.boss_monster_struct._HP - GameData.slash1_struct.damage;
			float fHP = GameData.boss_monster_struct._HP / GameData.boss_monster_struct.HP;
			GameData.boss_hp_value.GetComponent<UIProgressBar> ().value = fHP;

			//slash에 해당하는 atack image enable
			string slash_animation_name = "slash5";
			GameData.slash_animation = GameObject.Find (slash_animation_name);

			// slash sprite enable
			GameData.slash_animation.GetComponent<Animator>().SetTrigger("enable");
			GameData.slash_animation.GetComponent<SpriteRenderer> ().enabled = true;

		} else 
		{
			print ("fail 1");
		}

	}

	public void return_back_button()
	{
		SceneManager.LoadScene ("warriors");

	}


}
