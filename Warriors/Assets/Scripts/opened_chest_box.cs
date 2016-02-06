using UnityEngine;
using System.Collections;
using gamedata;

public class opened_chest_box : MonoBehaviour {

	public static bool enable_disable_chest_open = false;
	public static float target_time = 0.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(enable_disable_chest_open)
		{
			float time = (target_time - Time.time) / 5.0f;

			GameData.chest_opened_sprite.GetComponent<UIProgressBar> ().value = time;
			if (time < 0) 
			{
				// chest box reinit
				float fHP = GameData.chest_struct._HP / GameData.chest_struct._HP;
				GameData.chest_opened_sprite.GetComponent<UIProgressBar> ().value = fHP;

				enable_disable_chest_open = false;
				GameData.chest_sprite.SetActive (true);
				GameData.chest_opened_sprite.SetActive (false);
			}

		}
	}


	void OnTriggerExit2D(Collider2D Collider2D) 
	{
		
	}
}
