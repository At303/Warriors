﻿using UnityEngine;
using System.Collections;
using Devwin;
using gamedata;

public class NPC05_make : MonoBehaviour, IAnimEventListener
{

    // NPC05 struct
    public struct NPC05_struct
    {
        // NPC02 Data. 
        public static bool enable;
        public static int Level;
        public static ulong damage;
        public static ulong add_damage;
        public static float attack_speed;
        public static float add_speed;
        public static ulong upgrade_cost;

        // NPC02 Label.
        public static GameObject gameobject;
        public static GameObject lv_label;
        public static GameObject lvup_cost_label;
        public static GameObject damage_label;
        public static GameObject add_damage_label;
        public static GameObject add_speed_label;
        public static GameObject unlock_sp;

        // NPC02 Sprite.
        public static UISprite weapon_sp;
        public static UISprite clothes_sp;
        public static UISprite wing_sp;

        // NPC02 Button.
        public static GameObject lvup_btn;
    }

    public struct npc05_char
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
    public GameObject NPC05_HUD;

    // NPC05 Struct 구조체 초기화 및 Gameobject 가져오기.
    void Awake()
    {
        // **************************************   NPC02 GameObject init    ************************************************ //
        NPC05_struct.gameobject = GameObject.Find("_NPC05_gameobj");                                       // NPC02 GameObject.    
        NPC05_struct.weapon_sp = GameObject.Find("_npc05_weapon_sprite").GetComponent<UISprite>();               // NPC02 무기 icon Object.
        NPC05_struct.clothes_sp = GameObject.Find("_npc05_clothes_sprite").GetComponent<UISprite>();             // NPC02 옷 icon Object.
        NPC05_struct.wing_sp = GameObject.Find("_npc05_wing_sprite").GetComponent<UISprite>();                   // NPC02 날개 icon Object.
        //npc_gameobject.SetActive(false);                    // 추후 모든 캐릭터가 잠깐 나올 수 있기때문에 로딩딜레이줘야함.

        NPC05_struct.unlock_sp = GameObject.Find("_npc05_locking_sprite");                   // NPC02 날개 icon Object.
        NPC05_struct.lv_label = GameObject.Find("_npc05_level_label");
        NPC05_struct.lvup_cost_label = GameObject.Find("_npc05_lvup_cost_label");
        NPC05_struct.damage_label = GameObject.Find("_npc05_damage_label");
        NPC05_struct.add_damage_label = GameObject.Find("_npc05_damage_plus_label");
        NPC05_struct.add_speed_label = GameObject.Find("_npc05_speed_plus_label");

        NPC05_struct.lvup_btn = GameObject.Find("_npc05_lvup_btn");
		NPC05_struct.lvup_btn.GetComponent<UIButton> ().isEnabled = false;

        // Damage HUD Init.
        NPC05_HUD = GameObject.Find("5th_friend_HUD");
        // **************************************   NPC02 GameObject init    ************************************************ //

        // Init NPC02 Data && Update Label.
        //levelup_npc05_data_struct();
        //update_npc05_data_label();

    }

    void Start()
    {
        // npc가 enable인지 아닌지 check할 변수.
        int check_npc_enable;
        check_npc_enable = PlayerPrefs.GetInt("npc5_enable", 0);

        if (check_npc_enable == 1)
        {
            // 이전의 저장되어있는 캐릭터 무기, 헬멧 , 망또를 불러와서 init 해야함.

            NPC05_struct.gameobject.SetActive(true);                 // npc5 캐릭터 활성화.
            init();
        }
        else
        {
            // 처음 NPC05 GameObject생성시 enable 변수는 False로 해줌.
            NPC05_struct.enable = false;            // boss Scene에서 사용할 변수.
            NPC05_struct.gameobject.SetActive(false);
        }

        // npc Level 데이터를 가져온 후 해당 값으로 Data Setting.
        if (PlayerPrefs.HasKey("npc5_level"))
        {
            int get_npc_level = PlayerPrefs.GetInt("npc5_level");
            levelup_npc05_data_struct(get_npc_level);
            update_npc05_data_label();
        }
        else
        {
            // npc를 처음 만드는 경우.
            int init_level = 1;
            levelup_npc05_data_struct(init_level);
            update_npc05_data_label();
        }
    }

    // Use this for initialization
    public void init () 
	{
        character.Info.order = 1;
        character.Info.unit_part = "darkelf-male";
        character.Info.unit_index = 8;
        character.Info.main_weapon_part = "bow-a";
        character.Info.main_weapon_index = 0;
        character.Info.sub_weapon_part = "arrow-a";
        character.Info.sub_weapon_index = 0;

        // Boss Scene Loading시 weapon 체크해야 Error 발생하지 않음 
        // weapon enable값을 가져옴. 없으면 default값으로 0을 setting.
        npc05_char.weapon_enable = PlayerPrefs.GetInt("npc5_weapon_enable", 0);
        if (npc05_char.weapon_enable == 1)
        {
            character.Info.main_weapon_part = PlayerPrefs.GetString("npc5_weapon_part", "");
            character.Info.main_weapon_index = PlayerPrefs.GetInt("npc5_weapon_index", 0);

            // Change the NPC01 Weapon01 icon Sprite.
            // 무기 장착 메뉴에서 무기의 type과 index를 to_change 구조체에 미리 저장해두고 여기서 가져와서 해당 무기 장착 sprite로 바꿔줌.
            NPC05_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC05_struct.weapon_sp.spriteName = character.Info.main_weapon_part + character.Info.main_weapon_index.ToString();

        }

        npc05_char.armor_enable = PlayerPrefs.GetInt("npc5_armor_enable", 0);
        if (npc05_char.armor_enable == 1)
        {
            character.Info.armor_part = PlayerPrefs.GetString("npc5_armor_part", "");
            character.Info.armor_index = PlayerPrefs.GetInt("npc5_armor_index", 0);
            character.Info.armor_color = PlayerPrefs.GetInt("npc5_armor_color", 0);

            // Change the NPC05 Clothes icon Sprite.
            NPC05_struct.clothes_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC05_struct.clothes_sp.spriteName = character.Info.armor_part + character.Info.armor_index.ToString();

        }

        npc05_char.wing_enable = PlayerPrefs.GetInt("npc5_wing_enable", 0);
        if (npc05_char.wing_enable == 1)
        {
            character.Info.wing_part = PlayerPrefs.GetString("npc5_wing_part", "");
            character.Info.wing_index = PlayerPrefs.GetInt("npc5_wing_index", 0);

            // Change the NPC Clothes icon Sprite.
            NPC05_struct.wing_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
            NPC05_struct.wing_sp.spriteName = character.Info.wing_part + character.Info.wing_index.ToString();

        }

        // NPC 속도 1로 초기화.
        NPC05_struct.attack_speed = 1f;

        // NPC05 캐릭터 enable 변수 True.
        NPC05_struct.enable = true;

        // Init Character Texture.
        character.InitWithoutTextureBaking ();

        // Add Attack event clip interface.
        character.event_listener.Add(this);

        // attack animation coroutine about 2sec.
        StartCoroutine("npc_attack_func");
	}

    //  Coroutine   //
    IEnumerator npc_attack_func()
    {

        yield return new WaitForSeconds(NPC05_struct.attack_speed);                                     // 모든 NPC 공격 default속도는 3. attack. 무한반복.
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
                NPC05_HUD.GetComponent<HUDText>().Add(get_coin_str, Color.yellow, 0.5f);

                // Add touch coin to total_coin and update total coin label
                GameData.coin_struct.gold = GameData.coin_struct.gold + GameData.chest_struct.attacked_gold;
                GameData.gold_total_label.GetComponent<UILabel>().text = GameData.int_to_label_format(GameData.coin_struct.gold);

                // Chest box HP modify
				GameData.chest_struct._HP = GameData.chest_struct._HP - (NPC05_struct.damage + NPC05_struct.add_damage);
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
            NPC05_HUD.GetComponent<HUDText>().Add(get_gemstone_str, Color.red, 0.5f);

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

    // ********************************************************			NPC05 init functions 					******************************************************** //

    // NPC 데이터 초기화. ( NPC05 레벨업 버튼 클릭 시 실행할 함수. )
    public void levelup_npc05_data_struct(int Level)
    { 

        // NPC 데이터 초기화 및 레벨업시 적용되는 공식.
        NPC05_struct.Level =Level;
		NPC05_struct.damage = (ulong)(NPC05_struct.Level * 2 + 7);
        NPC05_struct.attack_speed = NPC05_struct.Level * 1f;
        NPC05_struct.upgrade_cost = (ulong)(30 + NPC05_struct.Level * 2);

        // NPC05 레벨이 20 이상이면 NPC05 캐릭터 구입할 수 있음.
        if (NPC05_struct.Level == 3)
        {
            // NPC05 Level up 캐릭터 창 Enable 시켜줌. ( 단, 아직은 NPC05 캐릭터는 화면에 안보여짐. )
            NPC06_make.NPC06_struct.unlock_sp.SetActive(false);
        }
    }

    // NPC04 라벨 && Level up cost 버튼 Update.
    public void update_npc05_data_label()
    {
        NPC05_struct.lv_label.GetComponent<UILabel>().text = NPC05_struct.Level.ToString();
        NPC05_struct.lvup_cost_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC05_struct.upgrade_cost);
        NPC05_struct.damage_label.GetComponent<UILabel>().text = GameData.int_to_label_format(NPC05_struct.damage);
    }

    // ********************************************************			NPC05 init functions 					******************************************************** //

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
        npc05_char.weapon_enable = 1;
        npc05_char.weapon_part = weapon_name;
        npc05_char.weapon_index = weapon_index;

        // Local에 npc1 weapon 이미지 저장.
        PlayerPrefs.SetInt("npc5_weapon_enable", npc05_char.weapon_enable);
        PlayerPrefs.SetString("npc5_weapon_part", npc05_char.weapon_part);
        PlayerPrefs.SetInt("npc5_weapon_index", npc05_char.weapon_index);
        PlayerPrefs.Save();

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

        // Boss Scene Load시 사용할 character image;
        npc05_char.armor_enable = 1;
        npc05_char.armor_type = clothes_type;
        npc05_char.armor_index = index;
        npc05_char.armor_color = color;

        // Local에 npc1 armor 이미지 저장.
        PlayerPrefs.SetInt("npc5_armor_enable", npc05_char.armor_enable);
        PlayerPrefs.SetString("npc5_armor_part", npc05_char.armor_type);
        PlayerPrefs.SetInt("npc5_armor_index", npc05_char.armor_index);
        PlayerPrefs.SetInt("npc5_armor_color", npc05_char.armor_color);
        PlayerPrefs.Save();

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

        // Boss Scene Load시 사용할 character image;
        npc05_char.wing_enable = 1;
        npc05_char.wing_type = wing_type;
        npc05_char.wing_index = index;

        // Local에 npc1 weapon 이미지 저장.
        PlayerPrefs.SetInt("npc5_wing_enable", npc05_char.wing_enable);
        PlayerPrefs.SetString("npc5_wing_part", npc05_char.wing_type);
        PlayerPrefs.SetInt("npc5_wing_index", npc05_char.wing_index);
        PlayerPrefs.Save();

        // 바뀐 정보로 Update.
        character.InitWithoutTextureBaking();

        // 캐릭터 Enable.
        this.gameObject.SetActive(true);

        // Coroutine으로 일정 초간격으로 해당 함수 실행. ( Attack Animation 실행. )
        StartCoroutine("npc_attack_func");
    }
}
