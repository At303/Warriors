using UnityEngine;
using System.Collections;
using gamedata_weapon;
using gamedata;

public class subMenu03_button_mgr : MonoBehaviour {



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//weapon01 레벨 업 버튼 클릭시 호출 함수
	public void Clicked_weapon01_Level_UP()
	{
		// Change the NPC01 Character Sprite.
		GameObject otherGameObject = GameObject.Find ("_NPC01_gameobj");
		NPC01_make npc01_make = otherGameObject.GetComponent<NPC01_make>();

		// Change the NPC01 Weapon01 icon Sprite.
		GameData.NPC01_struct.weapon_sp.atlas = Resources.Load<UIAtlas> ("BackgroundAtlas");
		GameData.NPC01_struct.weapon_sp.spriteName = "weapon01_icon";

		// For test code...........
		npc01_make.change_weapon (0);

		// pay the cost about chest level up
		GameData.coin_struct.gold = GameData.coin_struct.gold - GameData_weapon.Weapon01_struct.upgrade_cost;
		GameData.gold_total_label.GetComponent<UILabel> ().text = GameData.coin_struct.gold.ToString ();

		// update chest_struct data
		GameData.levelup_slash1_data_struct();

		// update chest label
		GameData.update_slash1_data_label();

		// 이 함수에서 데이터 전부 세팅 및 버튼 On Off 체크.  
		GameData.check_lvup_button_is_enable_or_not();

	}

}
