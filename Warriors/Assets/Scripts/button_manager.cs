﻿using UnityEngine;
using System.Collections;
using gamedata;
using UnityEngine.SceneManagement;

public class button_manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void Clicked_Chest_Level_UP()
	{
		// pay the cost about chest level up
		GameData.coin_struct.total = GameData.coin_struct.total - GameData.chest_struct.upgrade_cost;
		GameData.coin_total_label.GetComponent<UILabel> ().text = GameData.coin_struct.total.ToString ();

		// update chest_struct data
		GameData.update_chest_data_struct();

		// update chest label
		GameData.update_chest_data_label();

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GameData.check_lvup_button_is_enable_or_not();



	}
	public void Clicked_touch_Level_UP()
	{
		// pay the cost about chest level up
		GameData.coin_struct.total = GameData.coin_struct.total - GameData.touch_struct.upgrade_cost;
		GameData.coin_total_label.GetComponent<UILabel> ().text = GameData.coin_struct.total.ToString ();

		// update chest_struct data
		GameData.update_touch_data_struct();

		// update chest label
		GameData.update_touch_data_label();

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GameData.check_lvup_button_is_enable_or_not();
	}

	public void Clicked_human_Level_UP()
	{
		print ("human lvup");
		Human.human_struct.gameobject.SetActive (true);
		Human.upgrade_human_data ();
		Human.update_human_data_label ();

	}

	public void Clicked_boss_scene()
	{
		SceneManager.LoadScene ("warriors_boss");

	}
		
}
