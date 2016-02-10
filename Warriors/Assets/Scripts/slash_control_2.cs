using UnityEngine;
using System.Collections;

public class slash_control_2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) 
	{
		print ("slash attacked");
		print ("name : " + coll.gameObject.name);


	}

}
