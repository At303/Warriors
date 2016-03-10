using UnityEngine;
using System.Collections;
using gamedata;

public class NPC01_manager : MonoBehaviour {

    public GameObject NPC01_HUD;



    // Use this for initialization
    void Start () {
        NPC01_HUD = GameObject.Find("NPC01_HUD");


    }

    // Update is called once per frame
    void Update () {
	
	}

   

    void npc_attack_animation_event_func()
    {
        // 보물상자 HP가 0이면 아래 코드 안타도록함.
        if (!opened_chest_box.enable_disable_chest_open)
        {
            if (GameData.chest_struct._HP <= 0)
            {
                // 보물상자 false시키고 , open된 보물상자 enable
                GameData.chest_sprite.SetActive(false);
                opened_chest_box.enable_disable_chest_open = true;

                opened_chest_box.target_time = Time.time + 5.0f;
                GameData.chest_struct._HP = GameData.chest_struct.HP;
                GameData.chest_sprite.GetComponent<UIProgressBar>().value = GameData.chest_struct._HP;

                GameData.chest_opened_sprite.SetActive(true);
            }
            else
            {
                // Test HUDText;;;;
                string get_coin_str = "+" + GameData.chest_struct.attacked_gold + " GOLD";
                NPC01_HUD.GetComponent<HUDText>().Add(get_coin_str, Color.yellow, 0.5f);

                // Add touch coin to total_coin and update total coin label
                GameData.coin_struct.total = GameData.coin_struct.total + GameData.chest_struct.attacked_gold;
                GameData.coin_total_label.GetComponent<UILabel>().text = GameData.coin_struct.total.ToString();

                // Chest box HP modify
                GameData.chest_struct._HP = GameData.chest_struct._HP - GameData.NPC01_struct.damage;
                float fHP = GameData.chest_struct._HP / GameData.chest_struct.HP;
                GameData.chest_sprite.GetComponent<UIProgressBar>().value = fHP;
            }

            // check upgrade buttons들을 활성화 할 지말지 .
            GM.check_all_function_when_coin_changed();
        }
    }


    
}
