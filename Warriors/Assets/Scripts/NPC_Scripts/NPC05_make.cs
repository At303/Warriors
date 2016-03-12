using UnityEngine;
using System.Collections;
using Devwin;

public class NPC05_make : MonoBehaviour {
	public DevCharacter character;

	// Use this for initialization
	void Start () 
	{
        character.Info.order = 1;
        character.Info.unit_part = "darkelf-male";
        character.Info.unit_index = 8;
        character.Info.main_weapon_part = "bow-a";
        character.Info.main_weapon_index = 0;
        character.Info.sub_weapon_part = "arrow-a";
        character.Info.sub_weapon_index = 0;

        //character.UpdateView(); // with texture-baking
        character.InitWithoutTextureBaking ();
			
		// attack animation coroutine about 2sec.
		StartCoroutine("start_attack_animation");
	}
	IEnumerator start_attack_animation()
	{
		yield return new WaitForSeconds(1f);
		character.PlayAnimation("anim_bow_shoot_1", true);
		StartCoroutine("start_attack_animation");
	}
}
