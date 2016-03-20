﻿using UnityEngine;
using System.Collections;
using Devwin;
using gamedata;

// Interface사용을 위해 IAnimEventListener 추가.
public class NPC04_make : MonoBehaviour, IAnimEventListener
{

    // NPC04 struct
    public struct NPC04_struct
    {
        // NPC04 Data. 
        public static bool enable;
        public static int Level;
        public static ulong damage;
        public static ulong add_damage;
        public static float attack_speed;
        public static float add_speed;
        public static ulong upgrade_cost;

        // NPC04 Label.
        public static GameObject gameobject;
        public static GameObject lv_label;
        public static GameObject lvup_cost_label;
        public static GameObject damage_label;
        public static GameObject add_damage_label;
        public static GameObject add_speed_label;
        public static GameObject unlock_sp;

        // NPC04 Sprite.
        public static UISprite weapon_sp;
        public static UISprite clothes_sp;
        public static UISprite wing_sp;

        // NPC04 Button.
        public static GameObject lvup_btn;
    }

    // 화면에 보여지는 캐릭터 이미지.
    public DevCharacter character;
    // For 데미지 HUD Text.
    public GameObject NPC04_HUD;

    // NPC04 Struct 구조체 초기화 및 Gameobject 가져오기.
    void Awake()
    {
        // **************************************   NPC04 GameObject init    ************************************************ //
        NPC04_struct.gameobject = GameObject.Find("_NPC04_gameobj");                                             // NPC GameObject.    
        NPC04_struct.weapon_sp = GameObject.Find("_npc04_weapon_sprite").GetComponent<UISprite>();               // NPC 무기 icon Object.
        NPC04_struct.clothes_sp = GameObject.Find("_npc04_clothes_sprite").GetComponent<UISprite>();             // NPC 옷 icon Object.
        NPC04_struct.wing_sp = GameObject.Find("_npc04_wing_sprite").GetComponent<UISprite>();                   // NPC 날개 icon Object.
        //npc_gameobject.SetActive(false);                    // 추후 모든 캐릭터가 잠깐 나올 수 있기때문에 로딩딜레이줘야함.

        NPC04_struct.unlock_sp = GameObject.Find("_npc04_locking_sprite");                   // NPC 날개 icon Object.
        NPC04_struct.lv_label = GameObject.Find("_npc04_level_label");
        NPC04_struct.lvup_cost_label = GameObject.Find("_npc04_lvup_cost_label");
        NPC04_struct.damage_label = GameObject.Find("_npc04_damage_label");
        NPC04_struct.add_damage_label = GameObject.Find("_npc04_damage_plus_label");
        NPC04_struct.add_speed_label = GameObject.Find("_npc04_speed_plus_label");

        NPC04_struct.lvup_btn = GameObject.Find("_npc04_lvup_btn");

        // Damage HUD Init.
        NPC04_HUD = GameObject.Find("4th_friend_HUD");
        // **************************************   NPC04 GameObject init    ************************************************ //

        // Init NPC01 Data && Update Label.
        levelup_npc04_data_struct();
        update_npc04_data_label();

    }

    // Use this for initialization
    void Start()
    {
        init();
        // 처음 NPC04 GameObject생성시 enable 변수는 False로 해줌.
       // NPC04_struct.enable = false;
      //  NPC04_struct.gameobject.SetActive(false);
    }

    // Use this for initialization
    public void init () 
	{
        // NPC 캐릭터 이미지 초기화.
        character.Info.order = 1;
		character.Info.unit_part = "elf-male";
		character.Info.unit_index = 4;
        character.Info.main_weapon_part = "bow-a";
        character.Info.main_weapon_index = 0;
        character.Info.sub_weapon_part = "arrow-a";
        character.Info.sub_weapon_index = 0;

        // NPC 속도 1로 초기화.
        NPC04_struct.attack_speed = 3f;

        // NPC04 캐릭터 enable 변수 True.
        NPC04_struct.enable = true;

        character.InitWithoutTextureBaking ();

        // Add Attack event clip interface.
        character.event_listener.Add(this);

        // attack animation coroutine about 2sec.
        StartCoroutine("npc_attack_func");
	}

    //  Coroutine   //
    // attack animation coroutine about 2sec.
    IEnumerator npc_attack_func()
    {
        yield return new WaitForSeconds(NPC04_struct.attack_speed);                                     // 모든 NPC 공격 default속도는 3. attack. 무한반복.
        character.PlayAnimation("anim_bow_shoot", true);                         // NPC공격 animation 실행.

        StartCoroutine("npc_attack_func");
    }

    // Interface //
    // Interface about attacked. ( 캐릭터가 공격 애니메이션 이후 실행 할 함수. )
    public void OnAnimation_Hitting(int _index)
    {
        // 보물상자 HP가 0이면 아래 코드 안타도록함.
        if (!opened_chest_box.enable_disable_chest_open)
        {
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
                NPC04_HUD.GetComponent<HUDText>().Add(get_coin_str, Color.yellow, 0.5f);

                // Add touch coin to total_coin and update total coin label
                GameData.coin_struct.gold = GameData.coin_struct.gold + GameData.chest_struct.attacked_gold;
                GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format(GameData.coin_struct.gold);

                // Chest box HP modify
                GameData.chest_struct._HP = GameData.chest_struct._HP - NPC04_struct.damage;
                float fHP = GameData.chest_struct._HP / GameData.chest_struct.HP;
                GameData.chest_sprite.GetComponent<UIProgressBar>().value = fHP;
            }

            // check upgrade buttons들을 활성화 할 지말지 .
            GM.check_all_function_when_gold_changed();
        }
        // 열린 보물상자 Sprite enable시키고, GOLD가 아닌 GEMSTONE을 얻을 수 있도록 함.
        else
        {
            // Gemstone HUDText;;;;
            string get_gemstone_str = "+" + GameData.chest_struct.attacked_gemstone + "G";
            NPC04_HUD.GetComponent<HUDText>().Add(get_gemstone_str, Color.red, 0.5f);

            // Add gemstone while NPC attacking to chest.
            GameData.coin_struct.gemstone = GameData.coin_struct.gemstone + GameData.chest_struct.attacked_gemstone;
            GameData.gemstone_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format(GameData.coin_struct.gemstone);

            // check upgrade buttons들을 활성화 할 지말지 .
            GM.check_all_function_when_gold_changed();

        }

    }
    public void OnAnimation_AttackMove()
    {

    }

    // ********************************************************			NPC04 init functions 					******************************************************** //

    // NPC 데이터 초기화. ( NPC04 레벨업 버튼 클릭 시 실행할 함수. )
    public void levelup_npc04_data_struct()
    {
        if (NPC04_struct.Level == 1)
        {
            // 맨 처음 NPC 레벨업 버튼 클릭시에는 해당 캐릭터가 disable되어 있으므로 Enable시켜줌.
            NPC04_struct.gameobject.SetActive(true);
            init();
        }

        // NPC 데이터 초기화 및 레벨업시 적용되는 공식.
        NPC04_struct.Level = NPC04_struct.Level + 1;
        NPC04_struct.damage = (ulong)(NPC04_struct.Level * 2 + 7);
        NPC04_struct.attack_speed = NPC04_struct.Level * 1f;
        NPC04_struct.upgrade_cost = (ulong)(30 + NPC04_struct.Level * 2);

        // NPC04 레벨이 20 이상이면 NPC04 캐릭터 구입할 수 있음.
        if (NPC04_struct.Level == 3)
        {
            // NPC04 Level up 캐릭터 창 Enable 시켜줌. ( 단, 아직은 NPC04 캐릭터는 화면에 안보여짐. )
            //NPC04_make.NPC04_struct.unlock_sp.SetActive(false);
        }
    }

    // NPC04 라벨 && Level up cost 버튼 Update.
    public void update_npc04_data_label()
    {
        NPC04_struct.lv_label.GetComponent<UILabel>().text = NPC04_struct.Level.ToString();
        NPC04_struct.lvup_cost_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC04_struct.upgrade_cost);
        NPC04_struct.damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC04_struct.damage);
    }

    // ********************************************************			NPC04 init functions 					******************************************************** //

    // ********************************************************			Image change functions 					******************************************************** //

    // Change the Weapon.
    public void change_weapon(int weapon_index, string weapon_name)
    {
        // 캐릭터 이미지 변화시 잠시 캐릭터 이미지 저장할 Reference 생성.
        // CharacterData _character = new CharacterData();
        // 기존에 가지고 있는 캐릭터 정보를 Reference에 copy.      
        // character.Info.Copy(_character);

        // 캐릭터 False.
        this.gameObject.SetActive(false);

        character.Info.main_weapon_part = weapon_name;
        character.Info.main_weapon_index = weapon_index;

        // 바뀐 정보로 Update.
        character.InitWithoutTextureBaking();

        // 캐릭터 Enable.
        this.gameObject.SetActive(true);

        // Coroutine으로 일정 초간격으로 해당 함수 실행. ( Attack Animation 실행. )
        StartCoroutine("npc_attack_func");
    }

    // Change the clothes.
    public void change_clothes(int index, int color, string clothes_type)
    {
        // 캐릭터 False.
        this.gameObject.SetActive(false);

        character.Info.armor_part = clothes_type;
        character.Info.armor_index = index;
        character.Info.armor_color = color;

        // 바뀐 정보로 Update.
        character.InitWithoutTextureBaking();

        // 캐릭터 Enable.
        this.gameObject.SetActive(true);

        // Coroutine으로 일정 초간격으로 해당 함수 실행. ( Attack Animation 실행. )
        StartCoroutine("npc_attack_func");
    }

    // wing the clothes.
    public void change_wing(int index, string wing_type)
    {
        // 캐릭터 False.
        this.gameObject.SetActive(false);

        character.Info.wing_part = wing_type;
        character.Info.wing_index = index;

        // 바뀐 정보로 Update.
        character.InitWithoutTextureBaking();

        // 캐릭터 Enable.
        this.gameObject.SetActive(true);

        // Coroutine으로 일정 초간격으로 해당 함수 실행. ( Attack Animation 실행. )
        StartCoroutine("npc_attack_func");
    }

}
