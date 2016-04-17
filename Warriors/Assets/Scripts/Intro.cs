using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

	public float target_time = 0.0f;

	// Use this for initialization
	void Start () {
	target_time = Time.time + 2;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float time = (target_time - Time.time) / 2.0f;
		print("time : " + time.ToString());

			if (time < 0) 
			{
			    SceneManager.LoadScene ("warriors");
			}
	}
}
