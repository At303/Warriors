using UnityEngine;
using System.Collections;
using gamedata;
using gamedata_weapon;

public class GM_Boss : MonoBehaviour {

    public struct boss_struct
    {
        public ulong HP;
    }

    // 처음 시작시 Boss struct 초기화.
    public static GameObject[] boss_obj = new GameObject[30];
    public static boss_struct[] boss_st = new boss_struct[30];

    // 어떤 Boss를 Enable할 지 index를 가져올 변수.
    public static int boss_index;

    int slash_index = 0;

    public static float boss_hp;
	public static float _boss_hp;              // 보스 HP 감소시 사용 할 Base 값.

    // 보스와 싸우기 전 Count 다운 Popup 테스트용.
    public static GameObject popup_window_3;
    public static GameObject popup_window_2;
    public static GameObject popup_window_1;
    public static GameObject popup_window_0;
    public static GameObject getitem_window;

    public float start_time = 0.0f;

    // For 데미지 HUD Text.
    public static GameObject slash_HUD;

    void Awake()
    {
        // Count 다운 Popup 테스트용.
        popup_window_3 = GameObject.Find("count_3rd");
        popup_window_2 = GameObject.Find("count_2nd");
        popup_window_1 = GameObject.Find("count_1st");
        popup_window_0 = GameObject.Find("count_fight");

        // Boss Kill시 popup window object.
        getitem_window = GameObject.Find("get_item_pop_window");

        // Boss HP init && object 가져오기.
        for (int i = 0; i < 30; i++)
        {
			boss_st[i].HP = (ulong)((i+1) * 200);                                            // Boss HP init.
            boss_obj[i] = GameObject.Find("Boss" + i.ToString() + "_Sprite");               // object 가져오기.

            boss_obj[i].SetActive(false);                                                   // 처음에는 전부 False시켜줌.
        }


    }

    // Use this for initialization
    void Start () {

        start_time = Time.time + 10;

        // 이전 씬에서 어떤 보스와 싸울지 index값을 가져오고, 해당 index에 맞는 boss HP return
        boss_hp = _boss_hp = boss_st[boss_index].HP;
        print("Boss HP : " + boss_hp.ToString());

        // 가져온 Boss Index에 해당하는 보스 몬스터를 Active 시켜줌.
        boss_obj[boss_index].SetActive(true);

        // Boss에 Damage입힐 시, HUD
        slash_HUD = GameObject.Find("slash_HUD");

    }

    // Update is called once per frame
    void Update () 
	{
        // 처음 Boss Scene진입 시 카운트 다운 시작.
        if (!Boss_make.start_boss_kill)
        {
            double time = (start_time - Time.time) / 10.0f;        // For test set 10 sec.

            string cmp = string.Format("{0:0.0}", time * 10);
            if (cmp == "9.5")
            {
                popup_window_3.SetActive(true);
            }
            else if (cmp == "8.5")
            {
                popup_window_3.SetActive(false);
                popup_window_2.SetActive(true);
            }
            else if (cmp == "7.5")
            {
                popup_window_2.SetActive(false);
                popup_window_1.SetActive(true);
            }
            else if (cmp == "6.5")
            {
                popup_window_1.SetActive(false);
                popup_window_0.SetActive(true);
            }
            else if (cmp == "5.5")
            {
                popup_window_0.SetActive(false);
                Boss_make.start_boss_kill = true;

                // Boss Kill Time 세팅.
                Boss_make.target_time = Time.time + 20;

            }
        }

        if (Input.GetMouseButtonDown(0) && Boss_make.start_boss_kill)
		{
            float fHP = 0;

            //Get the mouse position on the screen and send a raycast into the game world from that position.
            Vector2 worldPoint = UICamera.mainCamera.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

			//If touch is on the fixed range, excute the code.
			if (hit.collider != null)
			{
                
				string slash_animation_name = "slash" + (slash_index+1).ToString();
                GameData.slash_animation = GameObject.Find(slash_animation_name);
				slash_index++;
				    

           		// slash sprite enable
                GameData.slash_animation.GetComponent<Animator>().SetTrigger("enable");
				GameData.slash_animation.GetComponent<SpriteRenderer>().enabled = true;

				switch ((SLASH_TYPE)slash_index)
				{
					case SLASH_TYPE.SLASH1:
                        boss_hp = boss_hp - (GameData.slash1_struct.damage + GameData.slash1_struct.add_damage);
                        fHP = boss_hp / _boss_hp;
						GameObject.Find ("Boss_Object").GetComponent<UIProgressBar> ().value = fHP;
						break;
                    case SLASH_TYPE.SLASH2:
                        boss_hp = boss_hp - (GameData.slash2_struct.damage + GameData.slash2_struct.add_damage);
                        fHP = boss_hp / _boss_hp;
                        GameObject.Find("Boss_Object").GetComponent<UIProgressBar>().value = fHP;
                        break;
                    case SLASH_TYPE.SLASH3:
                        boss_hp = boss_hp - (GameData.slash3_struct.damage + GameData.slash3_struct.add_damage);
                        fHP = boss_hp / _boss_hp;
                        GameObject.Find("Boss_Object").GetComponent<UIProgressBar>().value = fHP;
                        break;
                    case SLASH_TYPE.SLASH4:
                        boss_hp = boss_hp - (GameData.slash4_struct.damage + GameData.slash4_struct.add_damage);
                        fHP = boss_hp / _boss_hp;
                        GameObject.Find("Boss_Object").GetComponent<UIProgressBar>().value = fHP;
                        break;
                    case SLASH_TYPE.SLASH5:
                        boss_hp = boss_hp - (GameData.slash5_struct.damage + GameData.slash5_struct.add_damage);
                        fHP = boss_hp / _boss_hp;
                        GameObject.Find("Boss_Object").GetComponent<UIProgressBar>().value = fHP;
                        break;

                }

                // Damage HUDText.
                string slash_damage_hud_str = "-" + (GameData.slash1_struct.damage + GameData.slash1_struct.add_damage).ToString();
                slash_HUD.GetComponent<HUDText>().Add(slash_damage_hud_str, Color.red, 0.5f);

                // Random touch slash animation
                if (slash_index == GameData.number_of_slash)
				{
					slash_index = 0;
				}
                if(fHP < 0)
                {
                    print("kill the boss!!!!!!!");

                    // 보스를 Kill so Kill timer stop
                    Boss_make.start_boss_kill = false;

                    // Get Item popup window 오브젝트가 보스씬 실행시 처음 한번 활성화 되므로 bool변수로 control해줘야 함.
                    boss_popup_window.enable_item_popup = true;

                    // Get Item popup window 띄워줌.
                    getitem_window.SetActive(true);

                }

            }
		}
	}


}
