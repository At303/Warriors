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
	void Start ()
    {
        // npc가 enable인지 아닌지 check할 변수.
        int check_npc_enable;
        check_npc_enable = PlayerPrefs.GetInt("npc1_enable", 0);
        print("check_npc_enable : " + check_npc_enable);
        if (check_npc_enable == 1)
        {
            // 이전의 저장되어있는 캐릭터 무기, 헬멧 , 망또를 불러와서 init 해야함.

            GameObject.Find("_NPC01_gameobj_intheboss").SetActive(true);                 // npc1 캐릭터 활성화.
                                                                                // npc Level 데이터를 가져온 후 해당 값으로 Data Setting.
            if (PlayerPrefs.HasKey("npc1_level"))
            {
                int get_npc_level = PlayerPrefs.GetInt("npc1_level");
                levelup_npc01_data_struct(get_npc_level);
            }

            init();
        }
        else
        {
            GameObject.Find("_NPC01_gameobj_intheboss").SetActive(false);                 // npc1 캐릭터 활성화.
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}

	public void init()
	{
        // NPC01 캐릭터 default값.
        character.Info.order = 0;
        character.Info.unit_part = "human-male";
        character.Info.unit_index = 2;

        // Boss Scene Loading시 weapon 체크해야 Error 발생하지 않음 
        // weapon enable값을 가져옴. 없으면 default값으로 0을 setting.
        if (PlayerPrefs.GetInt("npc1_weapon_enable", 0) == 1)
        {
            character.Info.main_weapon_part = PlayerPrefs.GetString("npc1_weapon_part", "");
            character.Info.main_weapon_index = PlayerPrefs.GetInt("npc1_weapon_index", 0);
        }

        if (PlayerPrefs.GetInt("npc1_armor_enable", 0) == 1)
        {
            character.Info.armor_part = PlayerPrefs.GetString("npc1_armor_part", "");
            character.Info.armor_index = PlayerPrefs.GetInt("npc1_armor_index", 0);
            character.Info.armor_color = PlayerPrefs.GetInt("npc1_armor_color", 0);            
        }

        if (PlayerPrefs.GetInt("npc1_wing_enable", 0) == 1)
        {
            character.Info.wing_part = PlayerPrefs.GetString("npc1_wing_part", "");
            character.Info.wing_index = PlayerPrefs.GetInt("npc1_wing_index", 0);
        }

        // 무기에 따라서 해당 값을 변경해주면될듯.
        NPC01_Boss_struct.attack_speed = 1f;

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

    public void levelup_npc01_data_struct(int Level)
    {

        // NPC01 데이터 초기화 및 레벨업시 적용되는 공식.
        NPC01_Boss_struct.Level = Level;
        NPC01_Boss_struct.damage = (ulong)(NPC01_Boss_struct.Level * 2) + 7;
        NPC01_Boss_struct.attack_speed = NPC01_Boss_struct.Level * 1f;       
    }


}
