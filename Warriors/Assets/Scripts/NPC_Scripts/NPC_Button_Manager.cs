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
		GameData.gold_total_label.GetComponent<UILabel> ().text = GameData.int_to_label_format (GameData.coin_struct.gold);

		// NPC01 함수를 쓰기 위해 Object 가져옴. 
        NPC01_make npc01 = NPC01_make.NPC01_struct.gameobject.GetComponent<NPC01_make>();

        // update NPC01 데이터.
        npc01.levelup_npc01_data_struct();

        // update NPC01 label Update.
        npc01.update_npc01_data_label();

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GameData.check_lvup_button_is_enable_or_not();
	}

    public void Clicked_npc02_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC02_make.NPC02_struct.upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel> ().text = GameData.int_to_label_format (GameData.coin_struct.gold);

		// NPC03 함수를 쓰기 위해 Object 가져옴. 
        NPC02_make npc02 = NPC02_make.NPC02_struct.gameobject.GetComponent<NPC02_make>();

        // update NPC02 데이터.
        npc02.levelup_npc02_data_struct();

        // update NPC02 label Update.
        npc02.update_npc02_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
        GameData.check_lvup_button_is_enable_or_not();
    }

    public void Clicked_npc03_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC03_make.NPC03_struct.upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format(GameData.coin_struct.gold);

		// NPC02 함수를 쓰기 위해 Object 가져옴. 
        NPC03_make npc03 = NPC03_make.NPC03_struct.gameobject.GetComponent<NPC03_make>();

        // update NPC03 데이터.
        npc03.levelup_npc03_data_struct();

        // update NPC03 label Update.
        npc03.update_npc03_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
        GameData.check_lvup_button_is_enable_or_not();
    }

}
