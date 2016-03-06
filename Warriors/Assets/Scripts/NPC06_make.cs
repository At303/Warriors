using UnityEngine;
using System.Collections;
using Devwin;


public class NPC06_make : MonoBehaviour {
	public DevCharacter character;

	// Use this for initialization
	void Start () {
		character.Info.order = 1;
		character.Info.unit_part = "darkelf-female";
		character.Info.unit_index = 2;
		character.Info.armor_part = "uniform-a";
		character.Info.armor_index = 1;
		character.Info.armor_color = 3;
		character.Info.main_weapon_part = "bow-a";
		character.Info.main_weapon_index = 8;
		character.Info.sub_weapon_part = "arrow-a";

		//character.UpdateView(); // with texture-baking
		character.InitWithoutTextureBaking ();

		// attack animation coroutine about 2sec.
		StartCoroutine("start_attack_animation");
	}
	IEnumerator start_attack_animation()
	{
		yield return new WaitForSeconds(2f);
		character.PlayAnimation("anim_bow_shoot_1", true);
		StartCoroutine("start_attack_animation");
	}

}
