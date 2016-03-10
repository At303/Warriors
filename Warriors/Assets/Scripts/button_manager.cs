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

	}


// ------------------------------------------------------------------------------------------------------------------------------------------------//
	public void Clicked_npc01_Level_UP()
	{
        // pay the cost about chest level up
        GameData.coin_struct.total = GameData.coin_struct.total - GameData.NPC01_struct.upgrade_cost;
        GameData.coin_total_label.GetComponent<UILabel>().text = GameData.coin_struct.total.ToString();

        // update chest_struct data
        GameData.levelup_npc01_data_struct();

        // update chest label
        GameData.update_npc01_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
        GameData.check_lvup_button_is_enable_or_not();

    }

	public void Clicked_boss_scene()
	{
       
        SceneManager.LoadScene ("warriors_boss");

    }

}
