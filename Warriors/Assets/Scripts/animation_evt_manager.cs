using UnityEngine;
using System.Collections;
using gamedata;

public class animation_evt_manager : MonoBehaviour {

	public static bool enable_chest_animation = false;

    /// 보물상자 애니메이션 끝났을때.
	public void chest_animation_end()
	{
		NGUIDebug.Log( "chest_animation_end" );

		// 보물상자 false시키고 , open된 보물상자 enable
		GameData.chest_sprite.SetActive (false);
		opened_chest_box.enable_disable_chest_open = true;

		opened_chest_box.target_time = Time.time + 5.0f;
		GameData.chest_struct._HP = GameData.chest_struct.HP;
		GameData.chest_sprite.GetComponent<UIProgressBar> ().value = (float)GameData.chest_struct._HP;

	}

	public void chest_animation_enable()
	{
		enable_chest_animation = true;

	}
	public void chest_animation_disable()
	{
		enable_chest_animation = false;
	}
}
