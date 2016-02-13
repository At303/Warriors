using UnityEngine;
using System.Collections;

public class slash_control_2 : MonoBehaviour {

	public static GameObject coll_object = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) 
	{
		//print ("slash attacked");
		print ("coll name : " + coll.gameObject.name);
		coll_object = coll.gameObject;

	}

	public static void destory_object()
	{
		print ("distory name : " + coll_object.name);
		slash_prefabs_2.make_enable = true;
		Destroy (coll_object);
	}
	public static string get_object_name()
	{
		return coll_object.gameObject.name;
	}

}
