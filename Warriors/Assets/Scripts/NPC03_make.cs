using UnityEngine;
using System.Collections;
using Devwin;

public class NPC03_make : MonoBehaviour {
	public DevCharacter character;

	// Use this for initialization
	void Start () 
	{
		character.Info.order = 1;
		character.Info.unit_part = "undead";
		character.Info.unit_index = 1;
		character.Info.main_weapon_part = "axe-a";
		character.Info.main_weapon_index = 6;

		//character.UpdateView(); // with texture-baking
		character.InitWithoutTextureBaking ();

		switch (character.main_weapon_type) {
		case PACKAGE_TYPE.WEAPON_BOW:
			//character.PlayAnimation("anim_bow_walk", false);
			break;
		case PACKAGE_TYPE.WEAPON_STAFF:
			//character.PlayAnimation("anim_staff_walk", false);
			break;
		case PACKAGE_TYPE.WEAPON_MELEE:
		default:
			//character.PlayAnimation("anim_melee_walk", false);
			break;
		}
		// attack animation coroutine about 2sec.
		StartCoroutine("start_attack_animation");
	}
	IEnumerator start_attack_animation()
	{
		yield return new WaitForSeconds(2f);
		character.PlayAnimation("anim_melee_attack1", true);
		StartCoroutine("start_attack_animation");
	}
}
