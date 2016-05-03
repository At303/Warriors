using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using gamedata;

public class unity_ads : MonoBehaviour
{
    public static GameObject ads_object;
    public static Animator anim;

    void Start()
    {
        ads_object = this.gameObject;
    }
    public void ShowRewardedAd()
    {
        print("in the ads func");
        
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }

        // 광고 popup window닫아줌.
        GameData.Ads_popup_window.SetActive(false);

        // 광고클릭 후 10초동안 gold && gemstone획득량 2배.
        print("2배로 뿔려줌.");
        GameData.chest_struct.attacked_gold = GameData.chest_struct.attacked_gold * 2;
        GameData.chest_struct.attacked_gemstone = GameData.chest_struct.attacked_gemstone * 2;        

        // NPC가 enable되어 있는지 check후 해당 npc 색상을 변경해줌.
        Color tochange_color = new Color(0.8f, 0f, 0f, 1f);     // Set to red color     
        
        // 캐릭터 색상과 attack speed를 아래 함수에서 바꿔줌.  
        check_npc(tochange_color,true);


        GM.target_time = Time.time + 5;
        GM.enable_boost = true;
        GM.boost_time_label.SetActive(true);
    }
    public static void check_npc(Color tochange_color, bool speed_change_enable)
    {
        // npc가 enable인지 아닌지 check할 변수.
        int check_npc_enable;
        check_npc_enable = PlayerPrefs.GetInt("npc1_enable", 0);

        if (check_npc_enable == 1)
        {
            // 캐릭터의 애니메이션 속도도 빠르게 해줘야 애니메이션 클립함수가 동작.
            anim = GameObject.Find("Impl1").GetComponent<Animator>();
            print("npc1 speed :::" + anim.speed.ToString());
            anim.speed = 3.2f;

            NPC01_make npc01 = NPC01_make.NPC01_struct.gameobject.GetComponent<NPC01_make>();
            npc01.change_color(tochange_color);
            if(speed_change_enable)
            {
                npc01.change_attack_speed(0.2f);
            }
        }
        
        check_npc_enable = PlayerPrefs.GetInt("npc2_enable", 0);
        if (check_npc_enable == 1)
        {
            // 캐릭터의 애니메이션 속도도 빠르게 해줘야 애니메이션 클립함수가 동작.
            anim = GameObject.Find("Impl2").GetComponent<Animator>();
            print("npc2 speed :::" + anim.speed.ToString());
            anim.speed = 3.2f;

            NPC02_make npc02 = NPC02_make.NPC02_struct.gameobject.GetComponent<NPC02_make>();
            npc02.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc02.change_attack_speed(0.2f);
            }
        }

        check_npc_enable = PlayerPrefs.GetInt("npc3_enable", 0);
        if (check_npc_enable == 1)
        {
            // 캐릭터의 애니메이션 속도도 빠르게 해줘야 애니메이션 클립함수가 동작.
            anim = GameObject.Find("Impl3").GetComponent<Animator>();
            anim.speed = 3.2f;

            NPC03_make npc03 = NPC03_make.NPC03_struct.gameobject.GetComponent<NPC03_make>();
            npc03.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc03.change_attack_speed(0.2f);
            }
        }

        check_npc_enable = PlayerPrefs.GetInt("npc4_enable", 0);
        if (check_npc_enable == 1)
        {
            // 캐릭터의 애니메이션 속도도 빠르게 해줘야 애니메이션 클립함수가 동작.
            anim = GameObject.Find("Impl4").GetComponent<Animator>();
            anim.speed = 3.2f;

            NPC04_make npc04 = NPC04_make.NPC04_struct.gameobject.GetComponent<NPC04_make>();
            npc04.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc04.change_attack_speed(0.2f);
            }
        }

        check_npc_enable = PlayerPrefs.GetInt("npc5_enable", 0);
        if (check_npc_enable == 1)
        {
            // 캐릭터의 애니메이션 속도도 빠르게 해줘야 애니메이션 클립함수가 동작.
            anim = GameObject.Find("Impl5").GetComponent<Animator>();
            anim.speed = 3.2f;

            NPC05_make npc05 = NPC05_make.NPC05_struct.gameobject.GetComponent<NPC05_make>();
            npc05.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc05.change_attack_speed(0.2f);
            }
        }

        check_npc_enable = PlayerPrefs.GetInt("npc6_enable", 0);
        if (check_npc_enable == 1)
        {
            // 캐릭터의 애니메이션 속도도 빠르게 해줘야 애니메이션 클립함수가 동작.
            anim = GameObject.Find("Impl6").GetComponent<Animator>();
            anim.speed = 3.2f;

            NPC06_make npc06 = NPC06_make.NPC06_struct.gameobject.GetComponent<NPC06_make>();
            npc06.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc06.change_attack_speed(0.2f);
            }
        }

        check_npc_enable = PlayerPrefs.GetInt("npc7_enable", 0);
        if (check_npc_enable == 1)
        {
            // 캐릭터의 애니메이션 속도도 빠르게 해줘야 애니메이션 클립함수가 동작.
            anim = GameObject.Find("Impl7").GetComponent<Animator>();
            anim.speed = 3.2f;

            NPC07_make npc07 = NPC07_make.NPC07_struct.gameobject.GetComponent<NPC07_make>();
            npc07.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc07.change_attack_speed(0.2f);
            }
        }

        check_npc_enable = PlayerPrefs.GetInt("npc8_enable", 0);
        if (check_npc_enable == 1)
        {
            // 캐릭터의 애니메이션 속도도 빠르게 해줘야 애니메이션 클립함수가 동작.
            anim = GameObject.Find("Impl8").GetComponent<Animator>();
            anim.speed = 3.2f;

            NPC08_make npc08 = NPC08_make.NPC08_struct.gameobject.GetComponent<NPC08_make>();
            npc08.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc08.change_attack_speed(0.2f);
            }
        }

        check_npc_enable = PlayerPrefs.GetInt("npc9_enable", 0);
        if (check_npc_enable == 1)
        {
            // 캐릭터의 애니메이션 속도도 빠르게 해줘야 애니메이션 클립함수가 동작.
            anim = GameObject.Find("Impl9").GetComponent<Animator>();
            anim.speed = 3.2f;

            NPC09_make npc09 = NPC09_make.NPC09_struct.gameobject.GetComponent<NPC09_make>();
            npc09.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc09.change_attack_speed(0.2f);
            }
        }

        check_npc_enable = PlayerPrefs.GetInt("npc10_enable", 0);
        if (check_npc_enable == 1)
        {
            // 캐릭터의 애니메이션 속도도 빠르게 해줘야 애니메이션 클립함수가 동작.
            anim = GameObject.Find("Impl10").GetComponent<Animator>();
            anim.speed = 3.2f;

            NPC10_make npc10 = NPC10_make.NPC10_struct.gameobject.GetComponent<NPC10_make>();
            npc10.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc10.change_attack_speed(0.2f);
            }
        }

        check_npc_enable = PlayerPrefs.GetInt("npc11_enable", 0);
        if (check_npc_enable == 1)
        {
            // 캐릭터의 애니메이션 속도도 빠르게 해줘야 애니메이션 클립함수가 동작.
            anim = GameObject.Find("Impl11").GetComponent<Animator>();
            anim.speed = 3.2f;

            NPC11_make npc11 = NPC11_make.NPC11_struct.gameobject.GetComponent<NPC11_make>();
            npc11.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc11.change_attack_speed(0.2f);
            }
        }

        check_npc_enable = PlayerPrefs.GetInt("npc12_enable", 0);
        if (check_npc_enable == 1)
        {
            // 캐릭터의 애니메이션 속도도 빠르게 해줘야 애니메이션 클립함수가 동작.
            anim = GameObject.Find("Impl12").GetComponent<Animator>();
            anim.speed = 3.2f;

            NPC12_make npc12 = NPC12_make.NPC12_struct.gameobject.GetComponent<NPC12_make>();
            npc12.change_color(tochange_color);
            if (speed_change_enable)
            {
                npc12.change_attack_speed(0.2f);
            }
        }
        
    }

    public static void reset_npc()
    {
        // npc가 enable인지 아닌지 check할 변수.
        int check_npc_enable;
        check_npc_enable = PlayerPrefs.GetInt("npc1_enable", 0);

        if (check_npc_enable == 1)
        {
            NPC01_make npc01 = NPC01_make.NPC01_struct.gameobject.GetComponent<NPC01_make>();
            npc01.reset_attack_speed();

            // 캐릭터의 애니메이션 속도도 reset.
            anim = GameObject.Find("Impl1").GetComponent<Animator>();
            anim.speed = 1f;
        }

        check_npc_enable = PlayerPrefs.GetInt("npc2_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC02_make npc02 = NPC02_make.NPC02_struct.gameobject.GetComponent<NPC02_make>();
            npc02.reset_attack_speed();

            // 캐릭터의 애니메이션 속도도 reset.
            anim = GameObject.Find("Impl2").GetComponent<Animator>();
            anim.speed = 1f;
        }

        check_npc_enable = PlayerPrefs.GetInt("npc3_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC03_make npc03 = NPC03_make.NPC03_struct.gameobject.GetComponent<NPC03_make>();
            npc03.reset_attack_speed();

            // 캐릭터의 애니메이션 속도도 reset.
            anim = GameObject.Find("Impl3").GetComponent<Animator>();
            anim.speed = 1f;
        }

        check_npc_enable = PlayerPrefs.GetInt("npc4_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC04_make npc04 = NPC04_make.NPC04_struct.gameobject.GetComponent<NPC04_make>();
            npc04.reset_attack_speed();

            // 캐릭터의 애니메이션 속도도 reset.
            anim = GameObject.Find("Impl4").GetComponent<Animator>();
            anim.speed = 1f;
        }

        check_npc_enable = PlayerPrefs.GetInt("npc5_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC05_make npc05 = NPC05_make.NPC05_struct.gameobject.GetComponent<NPC05_make>();
            npc05.reset_attack_speed();

            // 캐릭터의 애니메이션 속도도 reset.
            anim = GameObject.Find("Impl5").GetComponent<Animator>();
            anim.speed = 1f;
        }

        check_npc_enable = PlayerPrefs.GetInt("npc6_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC06_make npc06 = NPC06_make.NPC06_struct.gameobject.GetComponent<NPC06_make>();
            npc06.reset_attack_speed();

            // 캐릭터의 애니메이션 속도도 reset.
            anim = GameObject.Find("Impl6").GetComponent<Animator>();
            anim.speed = 1f;
        }

        check_npc_enable = PlayerPrefs.GetInt("npc7_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC07_make npc07 = NPC07_make.NPC07_struct.gameobject.GetComponent<NPC07_make>();
            npc07.reset_attack_speed();

            // 캐릭터의 애니메이션 속도도 reset.
            anim = GameObject.Find("Impl7").GetComponent<Animator>();
            anim.speed = 1f;
        }

        check_npc_enable = PlayerPrefs.GetInt("npc8_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC08_make npc08 = NPC08_make.NPC08_struct.gameobject.GetComponent<NPC08_make>();
            npc08.reset_attack_speed();

            // 캐릭터의 애니메이션 속도도 reset.
            anim = GameObject.Find("Impl8").GetComponent<Animator>();
            anim.speed = 1f;
        }

        check_npc_enable = PlayerPrefs.GetInt("npc9_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC09_make npc09 = NPC09_make.NPC09_struct.gameobject.GetComponent<NPC09_make>();
            npc09.reset_attack_speed();

            // 캐릭터의 애니메이션 속도도 reset.
            anim = GameObject.Find("Impl9").GetComponent<Animator>();
            anim.speed = 1f;
        }

        check_npc_enable = PlayerPrefs.GetInt("npc10_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC10_make npc10 = NPC10_make.NPC10_struct.gameobject.GetComponent<NPC10_make>();
            npc10.reset_attack_speed();

            // 캐릭터의 애니메이션 속도도 reset.
            anim = GameObject.Find("Impl10").GetComponent<Animator>();
            anim.speed = 1f;
        }

        check_npc_enable = PlayerPrefs.GetInt("npc11_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC11_make npc11 = NPC11_make.NPC11_struct.gameobject.GetComponent<NPC11_make>();
            npc11.reset_attack_speed();

            // 캐릭터의 애니메이션 속도도 reset.
            anim = GameObject.Find("Impl11").GetComponent<Animator>();
            anim.speed = 1f;
        }

        check_npc_enable = PlayerPrefs.GetInt("npc12_enable", 0);
        if (check_npc_enable == 1)
        {
            NPC12_make npc12 = NPC12_make.NPC12_struct.gameobject.GetComponent<NPC12_make>();
            npc12.reset_attack_speed();

            // 캐릭터의 애니메이션 속도도 reset.
            anim = GameObject.Find("Impl12").GetComponent<Animator>();
            anim.speed = 1f;
        }
      
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}
