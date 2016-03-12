﻿using UnityEngine;
using System.Collections;
using Devwin;
using gamedata;

public class NPC02_make : MonoBehaviour,IAnimEventListener {
	public DevCharacter character;
    public GameObject NPC02_HUD;
	void Start()
	{
        NPC02_HUD = GameObject.Find("2nd_friend_HUD");

        character.Info.order = 1;
		character.Info.unit_part = "human-female";
        character.Info.unit_index = 8;
        character.Info.main_weapon_part = "dagger-a";
        character.Info.main_weapon_index = 0;

        // Inint Character Texture.
        character.InitWithoutTextureBaking ();

		// Add Attack event clip interface.
		character.event_listener.Add (new NPC02_make ());

		// attack animation coroutine about 2sec.
		StartCoroutine("start_attack_animation");
	}

	IEnumerator start_attack_animation()
	{
		yield return new WaitForSeconds(0.1f);
		character.SetAnimationSpeed (5f);
		character.PlayAnimation("anim_melee_attack1", true);

        // Test HUDText;;;;
        string get_coin_str = "+" + (GameData.chest_struct.attacked_gold * 2)+ " GOLD";
        NPC02_HUD.GetComponent<HUDText>().Add(get_coin_str, Color.yellow, 0.5f);

        StartCoroutine("start_attack_animation");
	}


	// Interface about attacked. Overload functions.
	public void OnAnimation_Hitting(int _index)
	{
		print ("NPC02 attacked");
	}
	public void OnAnimation_AttackMove()
	{
	}

}