using UnityEngine;
using System.Collections;
using gamedata;

public class button_manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void Clicked_Chest_Level_UP()
	{
		print ("clicked");

		// pay the cost about chest level up
		GameData.coin_struct.total = GameData.coin_struct.total - GameData.chest_struct.upgrade_cost;
		GameData.coin_total_label.GetComponent<UILabel> ().text = GameData.coin_struct.total.ToString ();

		// update chest_struct data
		GameData.update_chest_data_struct();

		// update chest label
		GameData.update_chest_data_label();

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GM.check_lvup_button_is_enable_or_not();



	}


}
