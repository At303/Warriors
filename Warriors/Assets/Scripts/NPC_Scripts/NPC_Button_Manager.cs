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

    public void Clicked_npc04_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC04_make.NPC04_struct.upgrade_cost;
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format(GameData.coin_struct.gold);

        // NPC 함수를 쓰기 위해 Object 가져옴. 
        NPC04_make npc04 = NPC04_make.NPC04_struct.gameobject.GetComponent<NPC04_make>();

        // update NPC 데이터.
        npc04.levelup_npc04_data_struct();

        // update NPC label Update.
        npc04.update_npc04_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
        GameData.check_lvup_button_is_enable_or_not();
    }

    public void Clicked_npc05_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC05_make.NPC05_struct.upgrade_cost;
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format(GameData.coin_struct.gold);

        // NPC 함수를 쓰기 위해 Object 가져옴. 
        NPC05_make npc05 = NPC05_make.NPC05_struct.gameobject.GetComponent<NPC05_make>();

        // update NPC 데이터.
        npc05.levelup_npc05_data_struct();

        // update NPC label Update.
        npc05.update_npc05_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
        GameData.check_lvup_button_is_enable_or_not();
    }

    public void Clicked_npc06_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC06_make.NPC06_struct.upgrade_cost;
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format(GameData.coin_struct.gold);

        // NPC 함수를 쓰기 위해 Object 가져옴. 
        NPC06_make npc06 = NPC06_make.NPC06_struct.gameobject.GetComponent<NPC06_make>();

        // update NPC 데이터.
        npc06.levelup_npc06_data_struct();

        // update NPC label Update.
        npc06.update_npc06_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
        GameData.check_lvup_button_is_enable_or_not();
    }

    public void Clicked_npc07_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC07_make.NPC07_struct.upgrade_cost;
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format(GameData.coin_struct.gold);

        // NPC 함수를 쓰기 위해 Object 가져옴. 
        NPC07_make npc07 = NPC07_make.NPC07_struct.gameobject.GetComponent<NPC07_make>();

        // update NPC 데이터.
        npc07.levelup_npc07_data_struct();

        // update NPC label Update.
        npc07.update_npc07_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
        GameData.check_lvup_button_is_enable_or_not();
    }

    public void Clicked_npc08_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC08_make.NPC08_struct.upgrade_cost;
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format(GameData.coin_struct.gold);

        // NPC 함수를 쓰기 위해 Object 가져옴. 
        NPC08_make npc08 = NPC08_make.NPC08_struct.gameobject.GetComponent<NPC08_make>();

        // update NPC 데이터.
        npc08.levelup_npc08_data_struct();

        // update NPC label Update.
        npc08.update_npc08_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
        GameData.check_lvup_button_is_enable_or_not();
    }

    public void Clicked_npc09_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC09_make.NPC09_struct.upgrade_cost;
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format(GameData.coin_struct.gold);

        // NPC 함수를 쓰기 위해 Object 가져옴. 
        NPC09_make npc09 = NPC08_make.NPC08_struct.gameobject.GetComponent<NPC09_make>();

        // update NPC 데이터.
        npc09.levelup_npc09_data_struct();

        // update NPC label Update.
        npc09.update_npc09_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
        GameData.check_lvup_button_is_enable_or_not();
    }

    public void Clicked_npc10_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC10_make.NPC10_struct.upgrade_cost;
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format(GameData.coin_struct.gold);

        // NPC 함수를 쓰기 위해 Object 가져옴. 
        NPC10_make npc10 = NPC10_make.NPC10_struct.gameobject.GetComponent<NPC10_make>();

        // update NPC 데이터.
        npc10.levelup_npc10_data_struct();

        // update NPC label Update.
        npc10.update_npc10_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
        GameData.check_lvup_button_is_enable_or_not();
    }

    public void Clicked_npc11_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC11_make.NPC11_struct.upgrade_cost;
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format(GameData.coin_struct.gold);

        // NPC 함수를 쓰기 위해 Object 가져옴. 
        NPC11_make npc11 = NPC11_make.NPC11_struct.gameobject.GetComponent<NPC11_make>();

        // update NPC 데이터.
        npc11.levelup_npc11_data_struct();

        // update NPC label Update.
        npc11.update_npc11_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
        GameData.check_lvup_button_is_enable_or_not();
    }

    public void Clicked_npc12_Level_UP()
    {
        // pay the cost about chest level up
        GameData.coin_struct.gold = GameData.coin_struct.gold - NPC12_make.NPC12_struct.upgrade_cost;
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format(GameData.coin_struct.gold);

        // NPC 함수를 쓰기 위해 Object 가져옴. 
        NPC12_make npc12 = NPC12_make.NPC12_struct.gameobject.GetComponent<NPC12_make>();

        // update NPC 데이터.
        npc12.levelup_npc12_data_struct();

        // update NPC label Update.
        npc12.update_npc12_data_label();

        // 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
        GameData.check_lvup_button_is_enable_or_not();
    }


}
