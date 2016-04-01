using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class button_manager_bossScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Clicked_boss_scene()
	{
		SceneManager.LoadScene ("warriors");

	}
}
