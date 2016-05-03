﻿using UnityEngine;
using System.Collections;
using Devwin;
using gamedata;
using gamedata_weapon;

public class NPC12_make : MonoBehaviour, IAnimEventListener
{

    // NPC struct
    public struct NPC12_struct
    {
        // NPC Data. 
        public static bool enable;
        public static int Level;
        public static ulong damage;
        public static ulong add_damage;
        public static float attack_speed;
        public static float add_speed;
        public static ulong upgrade_cost;

        // NPC Label.
        public static GameObject gameobject;
        public static GameObject npc_enable;

        public static GameObject lv_label;
        public static GameObject lvup_cost_label;
        public static GameObject damage_label;
        public static GameObject add_damage_label;
        public static GameObject add_speed_label;
        public static GameObject unlock_sp;
        public static GameObject skill_label;

        // NPC Sprite.
        public static UISprite weapon_sp;
        public static UISprite clothes_sp;
        public static UISprite wing_sp;

        // NPC Button.
        public static GameObject lvup_btn;
    }

    public struct npc12_char
    {
        public static int weapon_enable;
        public static string weapon_part;
        public static int weapon_index;

        public static int armor_enable;
        public static string armor_type;
        public static int armor_index;
        public static int armor_color;

        public static int wing_enable;
        public static string wing_type;
        public static int wing_index;

    }


    // 화면에 보여지는 캐릭터 이미지.
    public DevCharacter character;

    // For 데미지 HUD Text.
    public GameObject NPC12_HUD;

    // NPC12 Struct 구조체 초기화 및 Gameobject 가져오기.
    void Awake()
    {
        // **************************************   NPC04 GameObject init    ************************************************ //
        NPC12_struct.gameobject = GameObject.Find("_NPC12_gameobj");                                             // NPC GameObject.    
        NPC12_struct.npc_enable = GameObject.Find("_npc12_enable");                                             // NPC02하위 요소들을 enable할지 말지 결정할 val.

        NPC12_struct.weapon_sp = GameObject.Find("_npc12_weapon_sprite").GetComponent<UISprite>();               // NPC 무기 icon Object.
        NPC12_struct.clothes_sp = GameObject.Find("_npc12_clothes_sprite").GetComponent<UISprite>();             // NPC 옷 icon Object.
        NPC12_struct.wing_sp = GameObject.Find("_npc12_wing_sprite").GetComponent<UISprite>();                   // NPC 날개 icon Object.

        NPC12_struct.unlock_sp = GameObject.Find("_npc12_locking_sprite");                   // NPC 날개 icon Object.
        NPC12_struct.lv_label = GameObject.Find("_npc12_level_label");
        NPC12_struct.lvup_cost_label = GameObject.Find("_npc12_lvup_cost_label");
        NPC12_struct.damage_label = GameObject.Find("_npc12_damage_label");
        NPC12_struct.add_damage_label = GameObject.Find("_npc12_damage_plus_label");
        NPC12_struct.add_speed_label = GameObject.Find("_npc12_speed_plus_label");
        NPC12_struct.add_speed_label.GetComponent<UILabel>().text = "+0%";

        NPC12_struct.skill_label = GameObject.Find("_npc12_skill_label");

        NPC12_struct.lvup_btn = GameObject.Find("_npc12_lvup_btn");
		NPC12_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = false;

        // Damage HUD Init.
        NPC12_HUD = GameObject.Find("12th_friend_HUD");
        // **************************************   NPC04 GameObject init    ************************************************ //

        // Init NPC01 Data && Update Label.
        //levelup_npc12_data_struct();
        //update_npc12_data_label();

    }

    // Use this for initialization
    void Start()
    {
        // npc가 enable인지 아닌지 check할 변수.
        int check_npc_enable;
        check_npc_enable = PlayerPrefs.GetInt("npc12_enable", 0);

        if (check_npc_enable == 1)
        {
            // 이전의 저장되어있는 캐릭터 무기, 헬멧 , 망또를 불러와서 init 해야함.

            NPC12_struct.gameobject.SetActive(true);                 // npc 캐릭터 활성화.
            init();
        }
        else
        {
            // 처음 NPC05 GameObject생성시 enable 변수는 False로 해줌.
            NPC12_struct.enable = false;            // boss Scene에서 사용할 변수.

            NPC12_struct.npc_enable.SetActive(false);   // npc 하위 변수들 비활성화. ( 해당 npc가 enable이 아닌데도 버튼이 눌려지는 현상을 해결하기 위함. )
            NPC12_struct.gameobject.SetActive(false);
        }

        // npc Level 데이터를 가져온 후 해당 값으로 Data Setting.
        if (PlayerPrefs.HasKey("npc12_level"))
        {
            int get_npc_level = PlayerPrefs.GetInt("npc12_level");
            levelup_npc12_data_struct(get_npc_level);
            update_npc12_data_label();
        }
        else
        {
            // npc를 처음 만드는 경우.
            int init_level = 1;
            levelup_npc12_data_struct(init_level);
            update_npc12_data_label();
        }

        int check_npc_level = PlayerPrefs.GetInt("npc11_level", 0);
        if (check_npc_level > 2)
        {
            NPC12_struct.npc_enable.SetActive(true);
            NPC12_struct.unlock_sp.SetActive(false);                  // npc 아이템 캐릭터창 unlock 풀어주기
        }
    }


    // Use this for initialization
    public void init () {
        character.Info.order = 1;
        character.Info.unit_part = "troll";
        //character.Info.main_weapon_part = "bow-a";
        //character.Info.main_weapon_index = 0;
        character.Info.sub_weapon_part = "arrow-a";

        // NPC 속도 1로 초기화.
        NPC12_struct.attack_speed = 1f;

        // NPC04 캐릭터 enable 변수 True.
        NPC12_struct.enable = true;

        // Boss Scene Loading시 weapon 체크해야 Error 발생하지 않음 
        // weapon enable값을 가져옴. 없으면 default값으로 0을 setting.
        npc12_char.weapon_enable = PlayerPrefs.GetInt("npc12_weapon_enable", 0);
        if (npc12_char.weapon_enable == 1)
        {
            character.Info.main_weapon_part = PlayerPrefs.GetString("npc12_weapon_part", "");
            character.Info.main_weapon_index = PlayerPrefs.GetInt("npc12_weapon_index", 0);

            // 현재 장착하고 있는 무기의 스킬 Setting.
            GameData_weapon.set_data_for_equip_weapon(character.Info.main_weapon_part, character.Info.main_weapon_index);

            // Change the NPC01 Weapon01 icon Sprite.
            // 무기 장착 메뉴에서 무기의 type과 index를 to_change 구조체에 미리 저장해두고 여기서 가져와서 해당 무기 장착 sprite로 바꿔줌.
            NPC12_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC12_struct.weapon_sp.spriteName = character.Info.main_weapon_part + character.Info.main_weapon_index.ToString();

        }

        npc12_char.armor_enable = PlayerPrefs.GetInt("npc12_armor_enable", 0);
        if (npc12_char.armor_enable == 1)
        {
            character.Info.armor_part = PlayerPrefs.GetString("npc12_armor_part", "");
            character.Info.armor_index = PlayerPrefs.GetInt("npc12_armor_index", 0);
            character.Info.armor_color = PlayerPrefs.GetInt("npc12_armor_color", 0);

            // 현재 장착하고 있는 Armor 스킬 Setting.
            int someValue = GameData_weapon.armorDIC[character.Info.armor_part + character.Info.armor_index + character.Info.armor_color];
            GameData_weapon.get_armor_skill_func(someValue, 11);

            // Change the NPC05 Clothes icon Sprite.
            NPC12_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC12_struct.clothes_sp.spriteName = character.Info.armor_part + character.Info.armor_index.ToString() + character.Info.armor_color.ToString();

        }

        npc12_char.wing_enable = PlayerPrefs.GetInt("npc12_wing_enable", 0);
        if (npc12_char.wing_enable == 1)
        {
            character.Info.wing_part = PlayerPrefs.GetString("npc12_wing_part", "");
            character.Info.wing_index = PlayerPrefs.GetInt("npc12_wing_index", 0);

            //현재 장착하고 있는 Wing 스킬 Setting.
            int equip_wing_index = GameData_weapon.wingDIC[character.Info.wing_part + character.Info.wing_index];
            print("npc12이 현재 장착하고 있는 wing index : " + equip_wing_index);
            GameData_weapon.get_wing_skill_func(equip_wing_index, popup_window_button_mgr.NPC_INDEX.NPC12);

            // Change the NPC Clothes icon Sprite.
            NPC12_struct.wing_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC12_struct.wing_sp.spriteName = character.Info.wing_part + character.Info.wing_index.ToString();

        }

        character.InitWithoutTextureBaking();

        // Add Attack event clip interface.
        character.event_listener.Add(this);

        // attack animation coroutine about 2sec.
        StartCoroutine("npc_attack_func");
    }
    //  Coroutine   //
    // attack animation coroutine about 2sec.
    IEnumerator npc_attack_func()
    {
        yield return new WaitForSeconds(NPC12_struct.attack_speed);                                     // 모든 NPC 공격 default속도는 3. attack. 무한반복.
        character.PlayAnimation("anim_bow_shoot", true);                         // NPC공격 animation 실행.

        StartCoroutine("npc_attack_func");
    }

    // Interface //
    // Interface about attacked. ( 캐릭터가 공격 애니메이션 이후 실행 할 함수. )
    public void OnAnimation_Hitting(int _index)
    {
        if (GameData.sound_on_off)
        {
            // 활 캐릭터이므로 활 사운드 enable시켜줌.
            GameData.npc_arrow_sound_object.GetComponent<AudioSource>().Play(0);
        }


        // 보물상자 공격시 보물상자가 공격당하는 애니메이션 enable
        GameData.chest_animator.GetComponent<Animator>().SetTrigger("attacked");
            
        // Gold HUDText;;;;
        string get_coin_str = "+" + GameData.chest_struct.attacked_gold + "원";
        NPC12_HUD.GetComponent<HUDText>().Add(get_coin_str, Color.yellow, 0.5f);

        // Add touch coin to total_coin and update total coin label
        GameData.coin_struct.gold = GameData.coin_struct.gold + GameData.chest_struct.attacked_gold;
        GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format_only_total(GameData.coin_struct.gold);

        // Chest box HP modify
		GameData.chest_struct._HP = GameData.chest_struct._HP - (NPC12_struct.damage + NPC12_struct.add_damage);
        float fHP = GameData.chest_struct._HP / GameData.chest_struct.HP;
        GameData.chest_sprite.GetComponent<UIProgressBar>().value = fHP;

        // check upgrade buttons들을 활성화 할 지말지 .
        GM.check_all_function_when_gold_changed();
      

    }
    public void OnAnimation_AttackMove()
    {

    }

    // ********************************************************			NPC04 init functions 					******************************************************** //

    // NPC 데이터 초기화. ( NPC04 레벨업 버튼 클릭 시 실행할 함수. )
    public void levelup_npc12_data_struct(int Level)
    {
        // NPC 데이터 초기화 및 레벨업시 적용되는 공식.
        NPC12_struct.Level = Level;
        // 캐릭터 공격력도 누적.
        NPC12_struct.damage = 0;

        for (int i = 1; i < Level + 1; i++)
        {
            NPC12_struct.damage = NPC12_struct.damage + (ulong)(960 * Mathf.Pow(1.275f, i) + 10);
        }

        // =POWER(1.325,A2)*10000
        NPC12_struct.upgrade_cost = (ulong)Mathf.Round(Mathf.Pow(1.325f, Level) * 5000000000);

    }

    // NPC04 라벨 && Level up cost 버튼 Update.
    public void update_npc12_data_label()
    {
        NPC12_struct.lv_label.GetComponent<UILabel>().text = NPC12_struct.Level.ToString();
        NPC12_struct.lvup_cost_label.GetComponent<UILabel>().text = GameData.int_to_label_format_won(NPC12_struct.upgrade_cost);
        NPC12_struct.damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC12_struct.damage);
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

        // Boss Scene Load시 사용할 character image;
        npc12_char.weapon_enable = 1;
        npc12_char.weapon_part = weapon_name;
        npc12_char.weapon_index = weapon_index;

        // Local에 npc1 weapon 이미지 저장.
        PlayerPrefs.SetInt("npc12_weapon_enable", npc12_char.weapon_enable);
        PlayerPrefs.SetString("npc12_weapon_part", npc12_char.weapon_part);
        PlayerPrefs.SetInt("npc12_weapon_index", npc12_char.weapon_index);

        PlayerPrefs.Save();
        // 바뀐 정보로 Update.
        character.InitWithoutTextureBaking();

        // 캐릭터 Enable.
        this.gameObject.SetActive(true);

        // Coroutine으로 일정 초간격으로 해당 함수 실행. ( Attack Animation 실행. )
        StartCoroutine("npc_attack_func");
    }

    // Change the clothes.
    public void change_clothes(int enable, int index, int color, string clothes_type)
    {
        // 캐릭터 False.
        this.gameObject.SetActive(false);

        character.Info.armor_part = clothes_type;
        character.Info.armor_index = index;
        character.Info.armor_color = color;

        // Boss Scene Load시 사용할 character image;
        npc12_char.armor_enable = enable;
        npc12_char.armor_type = clothes_type;
        npc12_char.armor_index = index;
        npc12_char.armor_color = color;

        // Local에 npc1 armor 이미지 저장.
        PlayerPrefs.SetInt("npc12_armor_enable", npc12_char.armor_enable);
        PlayerPrefs.SetString("npc12_armor_part", npc12_char.armor_type);
        PlayerPrefs.SetInt("npc12_armor_index", npc12_char.armor_index);
        PlayerPrefs.SetInt("npc12_armor_color", npc12_char.armor_color);
        PlayerPrefs.Save();

        // 바뀐 정보로 Update.
        character.InitWithoutTextureBaking();

        // 캐릭터 Enable.
        this.gameObject.SetActive(true);

        // Coroutine으로 일정 초간격으로 해당 함수 실행. ( Attack Animation 실행. )
        StartCoroutine("npc_attack_func");
    }

    // wing the clothes.
    public void change_wing(int enable,int index, string wing_type)
    {
        // 캐릭터 False.
        this.gameObject.SetActive(false);

        character.Info.wing_part = wing_type;
        character.Info.wing_index = index;

        // Boss Scene Load시 사용할 character image;
        npc12_char.wing_enable = enable;
        npc12_char.wing_type = wing_type;
        npc12_char.wing_index = index;

        // Local에 npc1 weapon 이미지 저장.
        PlayerPrefs.SetInt("npc12_wing_enable", npc12_char.wing_enable);
        PlayerPrefs.SetString("npc12_wing_part", npc12_char.wing_type);
        PlayerPrefs.SetInt("npc12_wing_index", npc12_char.wing_index);
        PlayerPrefs.Save();

        // 바뀐 정보로 Update.
        character.InitWithoutTextureBaking();

        // 캐릭터 Enable.
        this.gameObject.SetActive(true);

        // Coroutine으로 일정 초간격으로 해당 함수 실행. ( Attack Animation 실행. )
        StartCoroutine("npc_attack_func");
    }
    public void change_color(Color ToChangeColor)
    {

        character.SetColor(ToChangeColor);
    }
    public void change_attack_speed(float speed)
    {
        NPC12_struct.attack_speed = 1 * speed;
    }
    public void reset_attack_speed()
    {
        NPC12_struct.attack_speed = 1;
    }
}
