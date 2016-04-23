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

    public void Clicked_boss_kill_ok()
    {
        SceneManager.LoadScene("warriors");
        print("clicked boss kill ok button");
        //StartCoroutine(Load());

    }
	 IEnumerator Load()
	{

		AsyncOperation async = SceneManager.LoadSceneAsync("warriors");

		while(!async.isDone)
		{
		float progress = async.progress * 100.0f;
		int pRounded = Mathf.RoundToInt(progress);
		//progressLabel.text = “Loading…”+ pRounded.ToString() + “%”;
		print("Loading…"+ pRounded.ToString() + "%");

		yield return true;
		}

	}
}
