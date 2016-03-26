using UnityEngine;
using System.Collections;
using Devwin;
using gamedata;

public class NPC01_make_Boss : MonoBehaviour,IAnimEventListener{

	// NPC struct
	public struct NPC01_Boss_struct
	{
		// NPC01 Data. 
		public static bool enable;
		public static int Level;
		public static ulong damage;
		public static ulong add_damage;
		public static float attack_speed;
		public static float add_speed;
		public static ulong upgrade_cost;

	}

	// 화면에 보여지는 캐릭터 이미지.
	public DevCharacter character;         

	// For 데미지 HUD Text.
	private GameObject NPC01_HUD;

	// Use this for initialization
	void Start () {
		init ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void init()
	{
		// NPC01 캐릭터 이미지 초기화.
		character.Info.order = 0;
		character.Info.unit_part = "human-male";
		character.Info.unit_index = 2;

		if(NPC01_make.npc01_char.weapon_enable)
		{
			character.Info.main_weapon_part = NPC01_make.npc01_char.weapon_part;
			character.Info.main_weapon_index = NPC01_make.npc01_char.weapon_index;
		}
		if(NPC01_make.npc01_char.armor_enable)
		{
			character.Info.armor_part = NPC01_make.npc01_char.armor_type;
			character.Info.armor_index = NPC01_make.npc01_char.armor_index;
			character.Info.armor_color = NPC01_make.npc01_char.armor_color;
		}
		if(NPC01_make.npc01_char.wing_enable)
		{
			character.Info.wing_part = NPC01_make.npc01_char.wing_type;
			character.Info.wing_index = NPC01_make.npc01_char.wing_index;
		}


		NPC01_Boss_struct.attack_speed = 1f;

		// NPC01 캐릭터 enable 변수 True.
		NPC01_Boss_struct.enable = true;

		character.InitWithoutTextureBaking();

		// Add Attack event clip interface. ( NPC01이 공격 애니메이션 시 사용할 함수를 추가. )
		character.event_listener.Add(this);

		// attack animation coroutine about 2sec.
		StartCoroutine("npc_attack_func");
	}

	//  Coroutine   //
	// attack animation coroutine about 2sec.
	IEnumerator npc_attack_func()
	{
		yield return new WaitForSeconds(NPC01_Boss_struct.attack_speed);         		// 모든 NPC 공격 default속도는 1. attack. 무한반복.
		character.PlayAnimation("anim_melee_attack1", true);                         // NPC공격 animation 실행.

		StartCoroutine("npc_attack_func");
	}


	// Interface //
	// Interface about attacked. ( 캐릭터가 공격 애니메이션 이후 실행 할 함수. )
	public void OnAnimation_Hitting(int _index)
	{
		print ("hit the boss!!");
		/*
		// 보물상자 HP가 0이면 아래 코드 안타도록함.
		if (!opened_chest_box.enable_disable_chest_open)
		{
			// 혹시 다른 곳에서 동시에 opened sprite접근시 에러방지를 위해 enabled bool check
			if (GameData.chest_struct._HP <= 0)		
			{
				// 보물상자 false시키고 , open된 보물상자 enable
				GameData.chest_sprite.SetActive(false);
				opened_chest_box.enable_disable_chest_open = true;

				// 보물 상자 시간 설정.
				opened_chest_box.target_time = Time.time + 5.0f;
				GameData.chest_struct._HP = GameData.chest_struct.HP;
				GameData.chest_sprite.GetComponent<UIProgressBar>().value = GameData.chest_struct._HP;

				GameData.chest_opened_sprite.SetActive(true);
			}
			else {

				// Gold HUDText;;;;
				string get_coin_str = "+" + GameData.chest_struct.attacked_gold + "g";
				NPC01_HUD.GetComponent<HUDText>().Add(get_coin_str, Color.yellow, 0.5f);

				// Add touch coin to total_coin and update total coin label
				GameData.coin_struct.gold = GameData.coin_struct.gold + GameData.chest_struct.attacked_gold;
				GameData.gold_total_label.GetComponent<UILabel>().text = GameData.coin_struct.gold.ToString();

				// Chest box HP modify
				GameData.chest_struct._HP = GameData.chest_struct._HP - NPC01_Boss_struct.damage;
				float fHP = GameData.chest_struct._HP / GameData.chest_struct.HP;
				GameData.chest_sprite.GetComponent<UIProgressBar>().value = fHP;
			}

			// check upgrade buttons들을 활성화 할 지말지 .
			GM.check_all_function_when_gold_changed();
		}
		// Chest opened
		else
		{

			// Gemstone HUDText;;;;
			string get_gemstone_str = "+" + GameData.chest_struct.attacked_gemstone + "G";
			NPC01_HUD.GetComponent<HUDText>().Add(get_gemstone_str, Color.red, 0.5f);

			// Add gemstone while NPC attacking to chest.
			GameData.coin_struct.gemstone = GameData.coin_struct.gemstone + GameData.chest_struct.attacked_gemstone;
			GameData.gemstone_total_label.GetComponent<UILabel> ().text = GameData.int_to_label_format (GameData.coin_struct.gemstone);

			// check upgrade buttons들을 활성화 할 지말지 .
			GM.check_all_function_when_gold_changed();

		}
		*/
	}
	public void OnAnimation_AttackMove()
	{

	}
}
