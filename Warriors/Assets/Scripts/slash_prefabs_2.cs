using UnityEngine;
using System.Collections;

public class slash_prefabs_2 : MonoBehaviour {
	public GameObject[] prefabs;
	public static GameObject[] move_prefabs;
	public static bool[] move_enable;
	public static bool make_enable = false;

	// Use this for initialization
	void Start () {
		move_prefabs = new GameObject[7];
		move_enable = new bool[7];

		for (int k = 0; k < 7; k++) 
		{
			prefabx_make (k);
			move_enable [k] = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

		for (int k = 0; k < 7; k++) 
		{
			if (move_enable [k])
			{
				move_prefabs_func (move_prefabs [k], k);
			}
		}
		if (make_enable)
		{
			prefabx_make (6);
		}
	}
	void FixedUpdate()
	{
		
	}

	public void prefabx_make(int Pindex)
	{
		int index = Random.Range(0,5);
		NGUITools.AddChild (this.gameObject, prefabs[index]);

		// prefabs name으로 gambeobjct가져오기
		string prefabs_name = "slash_prefabs" + (index).ToString () + "(Clone)";

		move_prefabs [Pindex] = GameObject.Find (prefabs_name);
		// naming을 해 야 동 일 한 이 름 의 prefabs가 생 기 지 않 음.
		// 동 일 한 name이 면 2개 의 object가 움 직 이 지 않 음.
		move_prefabs [Pindex].name = "prefabs"+index.ToString();
		print ("make : " + move_prefabs [Pindex].name);

		// disable make_enable flag
		make_enable = false;
	}

	void move_prefabs_func(GameObject move,int distance)
	{
		if (move.transform.localPosition.x > (-1192 + (220 * distance))) {
			move.transform.Translate (Vector2.left * 0.3f * Time.deltaTime, Space.World);
		} else
		{
			move_enable [distance] = false;
		}
	}

	public static void swap_prefabs_and_make_new()
	{
		GameObject temp = null;
		int i = 1;
		for( ;i<6;i++)
		{
			temp = move_prefabs [i];
			move_prefabs [i - 1] = temp;
			move_prefabs [i] = move_prefabs [i + 1];
		}

		// Make New gameobject to Last array
		//prefabx_make (i);

		//reset move flag
		for (i = 0; i < 7; i++)
		{
			move_enable [i] = true;
		}
	}

}
