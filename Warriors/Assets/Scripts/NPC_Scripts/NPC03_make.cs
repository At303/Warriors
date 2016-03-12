using UnityEngine;
using System.Collections;
using Devwin;

public class NPC03_make : MonoBehaviour,IAnimEventListener {
	public DevCharacter character;

	// Use this for initialization
	void Start () 
	{
		character.Info.order = 1;
		character.Info.unit_part = "undead";
		character.Info.unit_index = 1;
        character.Info.main_weapon_part = "dagger-a";
        character.Info.main_weapon_index = 0;

        character.InitWithoutTextureBaking ();

		// Add Attack event clip interface.
		character.event_listener.Add (new NPC03_make ());

		// attack animation coroutine about 2sec.
		StartCoroutine("start_attack_animation");
	}
	IEnumerator start_attack_animation()
	{
		yield return new WaitForSeconds(1f);
		character.PlayAnimation("anim_melee_attack1", true);
		StartCoroutine("start_attack_animation");
	}

	// Interface about attacked.
	public void OnAnimation_Hitting(int _index)
	{
		print ("NPC03 attacked");
	}
	public void OnAnimation_AttackMove()
	{
	}

}
