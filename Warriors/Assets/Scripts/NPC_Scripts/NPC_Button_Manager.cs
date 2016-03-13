using UnityEngine;
using System.Collections;
using gamedata;
using UnityEngine.SceneManagement;

public class NPC_Button_Manager : MonoBehaviour {


	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// ------------------------------------------------------------------------------------------------------------------------------------------------//
	public void Clicked_npc01_Level_UP()
	{
		// pay the cost about chest level up
		GameData.coin_struct.gold = GameData.coin_struct.gold - NPC01_make.NPC01_struct.upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel>().text = GameData.coin_struct.gold.ToString();

        // update chest_struct data
        NPC01_make.levelup_npc01_data_struct();

        // update chest label
        NPC01_make.update_npc01_data_label();

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GameData.check_lvup_button_is_enable_or_not();


	}
}
