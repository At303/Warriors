using UnityEngine;
using System.Collections;
using gamedata;
using gamedata_weapon;

public class GM_Boss : MonoBehaviour {

    // 어떤 Boss를 Enable할 지 index를 가져올 변수.
    public static int boss_index;

    int slash_index = 1;

    public float boss_hp;
	public float _boss_hp;              // 보스 HP 감소시 사용 할 Base 값.

    // 보스와 싸우기 전 Count 다운 Popup 테스트용.
    public static GameObject popup_window_3;
    public static GameObject popup_window_2;
    public static GameObject popup_window_1;
    public static GameObject popup_window_0;

    public float start_time = 0.0f;

    void Awake()
    {
        // Count 다운 Popup 테스트용.
        popup_window_3 = GameObject.Find("count_3rd");
        popup_window_2 = GameObject.Find("count_2nd");
        popup_window_1 = GameObject.Find("count_1st");
        popup_window_0 = GameObject.Find("count_fight");

        // 이전 씬에서 어떤 보스와 싸울지 index값을 가져오고, 해당 index에 맞는 boss HP return
        //Boss_make boss_make_obj = Boss_make.gameobject.GetComponent<Boss_make>();
        //boss_hp = _boss_hp = boss_make_obj.get_boss_hp(boss_index);

        print("boss HP : " + boss_hp.ToString());

    }

    // Use this for initialization
    void Start () {

        start_time = Time.time + 10;


    }

    // Update is called once per frame
    void Update () 
	{
        if (!Boss_make.start_boss_kill)
        {
            double time = (start_time - Time.time) / 10.0f;        // For test set 10 sec.

            string cmp = string.Format("{0:0.0}", time * 10);
            print(cmp.ToString());
            if (cmp == "9.0")
            {
                popup_window_3.SetActive(true);
            }
            else if (cmp == "8.0")
            {
                popup_window_3.SetActive(false);
                popup_window_2.SetActive(true);
            }
            else if (cmp == "7.0")
            {
                popup_window_2.SetActive(false);
                popup_window_1.SetActive(true);
            }
            else if (cmp == "6.0")
            {
                popup_window_1.SetActive(false);
                popup_window_0.SetActive(true);
            }
            else if (cmp == "5.0")
            {
                popup_window_0.SetActive(false);
                Boss_make.start_boss_kill = true;

                // Boss Kill Time 세팅.
                Boss_make.target_time = Time.time + 10;

            }
        }

        if (Input.GetMouseButtonDown(0) && Boss_make.start_boss_kill)
		{
				//Get the mouse position on the screen and send a raycast into the game world from that position.
				Vector2 worldPoint = UICamera.mainCamera.ScreenToWorldPoint(Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

				//If touch is on the fixed range, excute the code.
				if (hit.collider != null)
				{
                    // Random touch slash animation
                    if (slash_index == GameData.number_of_slash)
                    {
                        slash_index = 1;
                    }
                    string slash_animation_name = "slash" + slash_index.ToString();
                    GameData.slash_animation = GameObject.Find(slash_animation_name);
                    

                // slash sprite enable
                    GameData.slash_animation.GetComponent<Animator>().SetTrigger("enable");
					GameData.slash_animation.GetComponent<SpriteRenderer>().enabled = true;

                    float fHP;
					switch ((SLASH_TYPE)slash_index)
					{
						case SLASH_TYPE.SLASH1:
							boss_hp = boss_hp - GameData.slash1_struct.damage;
                            print(GameData.slash1_struct.damage);
                            fHP = boss_hp / _boss_hp;
							GameObject.Find ("Boss_Sprite").GetComponent<UIProgressBar> ().value = fHP;
							break;

					}

                slash_index++;
            }
		}
	}
}
