﻿using UnityEngine;
using System.Collections;
using Devwin;
using gamedata;

public class NPC02_make : MonoBehaviour {
	public DevCharacter character;

	void Start()
	{
		character.Info.order = 1;
		character.Info.unit_part = "mummy";
		character.Info.main_weapon_part = "blunt-a";
		character.Info.main_weapon_index = 10;
		character.Info.wing_part = "cape-a";
		character.Info.wing_index = 5;

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
