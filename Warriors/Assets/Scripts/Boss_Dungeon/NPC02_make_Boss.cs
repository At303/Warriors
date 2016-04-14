﻿using UnityEngine;
using System.Collections;
using Devwin;
using gamedata;

public class NPC02_make_Boss : MonoBehaviour, IAnimEventListener
{

    // NPC struct
    public struct NPC02_Boss_struct
    {
        // NPC02 Data. 
        public static bool enable;
        public static int Level;
        public static ulong damage;
        public static ulong add_damage;
        public static float attack_speed;
        public static float add_speed;
        public static ulong upgrade_cost;

    }
    float fHP;

    // 화면에 보여지는 캐릭터 이미지.
    public DevCharacter character;

    // 보스 CountDown이 끝났는지 체크할 변수.
    private bool check_count_down;

    // Use this for initialization
    void Start ()
    {
        // count down이 끝나고 npc animation실행하게 할 변수
        check_count_down = true;

        // npc가 enable인지 아닌지 check할 변수.
        int check_npc_enable;
        check_npc_enable = PlayerPrefs.GetInt("npc2_enable", 0);
        if (check_npc_enable == 1)
        {
            // 이전의 저장되어있는 캐릭터 무기, 헬멧 , 망또를 불러와서 init 해야함. 
            GameObject.Find("_NPC02_gameobj_intheboss").SetActive(true);                 // npc 캐릭터 활성화.
                                                                                         // npc Level 데이터를 가져온 후 해당 값으로 Data Setting.
            if (PlayerPrefs.HasKey("npc2_level"))
            {
                int get_npc_level = PlayerPrefs.GetInt("npc2_level");
                levelup_npc02_data_struct(get_npc_level);
            }

            init();
        }
        else
        {
            GameObject.Find("_NPC02_gameobj_intheboss").SetActive(false);                 // npc2 캐릭터 비활성화.
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        // Count Down이 완료 되면 NPC가 공격 시작.
        if (check_count_down && Boss_make.start_boss_kill)
        {
            // attack animation coroutine about 2sec.
            StartCoroutine("npc_attack_func");
            check_count_down = false;
        }

        // 다른 곳에서 보스를 죽이면 보스가 죽엇는지 변수를 체크하여 coroutine stop시킴.
        if (!Boss_make.start_boss_kill)
        {
            StopCoroutine("npc_attack_func");
        }
    }

    public void init()
    {
        // NPC01 캐릭터 default값.
        character.Info.order = 1;
        character.Info.unit_part = "human-female";
        character.Info.unit_index = 8;

        // Boss Scene Loading시 weapon 체크해야 Error 발생하지 않음 
        // weapon enable값을 가져옴. 없으면 default값으로 0을 setting.
        if (PlayerPrefs.GetInt("npc2_weapon_enable", 0) == 1)
        {
            character.Info.main_weapon_part = PlayerPrefs.GetString("npc2_weapon_part", "");
            character.Info.main_weapon_index = PlayerPrefs.GetInt("npc2_weapon_index", 0);
        }

        if (PlayerPrefs.GetInt("npc2_armor_enable", 0) == 1)
        {
            character.Info.armor_part = PlayerPrefs.GetString("npc2_armor_part", "");
            character.Info.armor_index = PlayerPrefs.GetInt("npc2_armor_index", 0);
            character.Info.armor_color = PlayerPrefs.GetInt("npc2_armor_color", 0);
        }

        if (PlayerPrefs.GetInt("npc2_wing_enable", 0) == 1)
        {
            character.Info.wing_part = PlayerPrefs.GetString("npc2_wing_part", "");
            character.Info.wing_index = PlayerPrefs.GetInt("npc2_wing_index", 0);
        }

        // NPC가 가지고있는 데이터를 setting해줌.
        NPC02_Boss_struct.damage = NPC02_make.NPC02_struct.damage;
        NPC02_Boss_struct.add_damage = NPC02_make.NPC02_struct.add_damage;

        // 무기에 따라서 해당 값을 변경해주면될듯.
        NPC02_Boss_struct.attack_speed = 1f;

        character.InitWithoutTextureBaking();

        // Add Attack event clip interface. ( NPC02이 공격 애니메이션 시 사용할 함수를 추가. )
        character.event_listener.Add(this);
    }

    //  Coroutine   //
    // attack animation coroutine about 2sec.
    IEnumerator npc_attack_func()
    {
        yield return new WaitForSeconds(NPC02_Boss_struct.attack_speed);             // 모든 NPC 공격 default속도는 1. attack. 무한반복.
        character.PlayAnimation("anim_melee_attack1", true);                         // NPC공격 animation 실행.

        StartCoroutine("npc_attack_func");

    }

    // Interface //
    // Interface about attacked. ( 캐릭터가 공격 애니메이션 이후 실행 할 함수. )
    public void OnAnimation_Hitting(int _index)
    {
        print("kill the boss HP : " + GM_Boss.boss_hp.ToString());

        // 
        if (GM_Boss.boss_hp > 0)
        {

            // Damage HUDText.
            string get_coin_str = "-" + (NPC02_Boss_struct.damage + NPC02_Boss_struct.add_damage).ToString();
            GM_Boss.slash_HUD.GetComponent<HUDText>().Add(get_coin_str, Color.red, 0.5f);

            // Chest box HP modify.
            GM_Boss.boss_hp = GM_Boss.boss_hp - (NPC02_Boss_struct.damage + NPC02_Boss_struct.add_damage);
            fHP = GM_Boss.boss_hp / GM_Boss._boss_hp;
            GameObject.Find("Boss_Object").GetComponent<UIProgressBar>().value = fHP;
        }
        else
        {
            print("kill the boss HP : " + GM_Boss.boss_hp.ToString());

            // Boss kill하였으므로 NPC Animation Stop.
            StopCoroutine("npc_attack_func");

            // Boss Kill Timer false.
            Boss_make.start_boss_kill = false;

            // Get Item popup window 오브젝트가 보스씬 실행시 처음 한번 활성화 되므로 bool변수로 control해줘야 함.
            boss_popup_window.enable_item_popup = true;

            // Get Item popup window 띄워줌.
            GM_Boss.getitem_window.SetActive(true);
        }


    }
    public void OnAnimation_AttackMove()
    {

    }

    /// NPC02 처음 init시 현재저장되어 있는 NPC Level에 맞게 값을 설정해줄 Function.
    public void levelup_npc02_data_struct(int Level)
    {

        // NPC02 데이터 초기화 및 레벨업시 적용되는 공식.
        NPC02_Boss_struct.Level = Level;
        NPC02_Boss_struct.damage = (ulong)(NPC02_Boss_struct.Level * 2) + 7;
        NPC02_Boss_struct.attack_speed = NPC02_Boss_struct.Level * 1f;
    }

}