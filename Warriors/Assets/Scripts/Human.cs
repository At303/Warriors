using UnityEngine;
using System.Collections;

public class Human : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	
	}

	void OnTriggerEnter2D(Collider2D coll) 
	{
		print("human attack");
		GM.attacked_chest ();

	}
}
