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
	public static boss_struct[] weapon_struct_object = new boss_struct[5];

	public static float target_time = 0.0f;
	public static GameObject Boss_HP_Bar;
	public static GameObject Boss_kill_time_label;


	void Awake()
	{
		gameobject = GameObject.Find("Boss_Monster");
		weapon_struct_object [0].HP = (ulong)100;

	}

	// Use this for initialization
	void Start () {
		Boss_HP_Bar = GameObject.Find ("Boss_kill_time");
		Boss_kill_time_label = GameObject.Find ("_kill_time_label");
		target_time = Time.time+10;



	}
	
	// Update is called once per frame
	void Update () {
	
		// 보스 Kill Time 설정
		double time = (target_time - Time.time) / 10.0f;		// For test set 10 sec.

		// 보스 Kill Time progress bar 설정
		Boss_HP_Bar.GetComponent<UIProgressBar> ().value = (float)time;
		Boss_kill_time_label.GetComponent<UILabel> ().text = string.Format ("{0:0.0}",time*10);

	}

	public ulong get_boss_hp(int _index)
	{
		return weapon_struct_object [_index].HP;
	}
}
