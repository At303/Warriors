using UnityEngine;
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

		// levelup chest_struct data
		GameData.levelup_chest_data_struct();

		// update chest label
		GameData.update_chest_data_label();

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GameData.check_lvup_button_is_enable_or_not();


	}

	//slash1 레벨 업 버튼 클릭시 호출 함수
	public void Clicked_slash1_Level_UP()
	{
		// pay the cost about chest level up
		GameData.coin_struct.total = GameData.coin_struct.total - GameData.slash1_struct.upgrade_cost;
		GameData.coin_total_label.GetComponent<UILabel> ().text = GameData.coin_struct.total.ToString ();

		// update chest_struct data
		GameData.levelup_slash1_data_struct();

		// update chest label
		GameData.update_slash1_data_label();

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GameData.check_lvup_button_is_enable_or_not();

		//slash1레벨이 10이상 되면 slash2 메뉴 enable.
		if (GameData.slash1_struct.Level > 5) 
		{
			GameData.slash2_locking_sprite.SetActive (false);
		}
	}


// ------------------------------------------------------------------------------------------------------------------------------------------------//
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
