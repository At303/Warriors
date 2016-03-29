using UnityEngine;
using System.Collections;




public class Boss_make : MonoBehaviour {
	public struct boss_struct
	{
		public ulong HP;
		public static int hh;
	}

	public static GameObject gameobject;

	// 처음 시작시 Boss struct 초기화.
	public static boss_struct[] boss = new boss_struct[5];


    // 보스 HP && Kill Time을 위한 변수들.
	public static float target_time = 0.0f;
	public static GameObject Boss_HP_Bar;
	public static GameObject Boss_kill_time_label;
    public static bool start_boss_kill;

	void Awake()
	{
        // 카운트 다운이 끝났는지 check할 변수.
        start_boss_kill = false;

        // 0번째 Boss HP init시켜줌.
        boss[0].HP = (ulong)100;

        // GameObject 초기화.
        Boss_HP_Bar = GameObject.Find("Boss_kill_time");
        Boss_kill_time_label = GameObject.Find("_kill_time_label");
        gameobject = GameObject.Find("Boss_Monster");
    }

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update ()
    {

        // CountDown 끝나고 보스 Kill Time Start.
        if (start_boss_kill)
        {
            // 보스 Kill Time 설정
            double time = (target_time - Time.time) / 10.0f;        // For test set 10 sec.

            if (time > 0)
            {
                // 보스 Kill Time progress bar 설정
                Boss_HP_Bar.GetComponent<UIProgressBar>().value = (float)time;

                Boss_kill_time_label.GetComponent<UILabel>().text = string.Format("{0:0.0}", time * 10);
            }
            else
            {
                // Boss Kill TIme Expire.

            }



        }

    }

	public ulong get_boss_hp(int _index)
	{
		return boss[_index].HP;
	}
}
