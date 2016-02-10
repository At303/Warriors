﻿using UnityEngine;
using System.Collections;

public class slash_prefabs_2 : MonoBehaviour {
	public GameObject[] prefabs = null;
	public GameObject[] move_prefabs;

	// Use this for initialization
	void Start () {
		move_prefabs = new GameObject[10];
		prefabx_make();
	}
	
	// Update is called once per frame
	void Update () {
		move_prefabs_func (move_prefabs [0], 0);
		move_prefabs_func (move_prefabs [1], 1);
		move_prefabs_func (move_prefabs [2], 2);
		move_prefabs_func (move_prefabs [3], 3);
		move_prefabs_func (move_prefabs [4], 4);
		move_prefabs_func (move_prefabs [5], 5);
		move_prefabs_func (move_prefabs [6], 6);

		if (Input.GetMouseButtonDown (0)) 
		{
			print ("name : " + move_prefabs [0].name);
			print ("name : " + move_prefabs [1].name);
			print ("name : " + move_prefabs [2].name);




		}

	}
	void FixedUpdate()
	{
		
	}
	void prefabx_make()
	{
		for (int i = 0; i < 9; i++) {
			// prefabs 생성.
			int index = Random.Range(0,5);
			NGUITools.AddChild (this.gameObject, prefabs[index]);

			// prefabs name으로 gambeobjct가져오기
			string prefabs_name = "slash_prefabs" + (index).ToString () + "(Clone)";

			move_prefabs [i] = GameObject.Find (prefabs_name);
			move_prefabs [i].name = "prefabs"+i.ToString();
		}
	}

	void move_prefabs_func(GameObject move,int distance)
	{
		if(move.transform.localPosition.x > (-1022+(170*distance)) )
		{
			move.transform.Translate (Vector2.left * 0.3f * Time.deltaTime, Space.World);
		}
	}
}
