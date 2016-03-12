using UnityEngine;
using System.Collections;
using Devwin;
using gamedata;

public class NPC01_make : MonoBehaviour,IAnimEventListener {

	public DevCharacter character;

    void Start()
	{
        character.Info.order = 1;
		character.Info.unit_part = "human-male";
        character.Info.unit_index = 2;

        character.InitWithoutTextureBaking();

		// Add Attack event clip interface.
		character.event_listener.Add (new NPC01_make ());

        // attack animation coroutine about 2sec.
        StartCoroutine("npc_attack_func");
    }

	// attack animation coroutine about 2sec.
    IEnumerator npc_attack_func()
    {
		yield return new WaitForSeconds(1f);         // 모든 NPC 공격 default속도는 3. attack. 무한반복.
		character.PlayAnimation("anim_melee_attack1", true);               			 // NPC공격 animation 실행.

        StartCoroutine("npc_attack_func");
    }

	// Interface about attacked.
	public void OnAnimation_Hitting(int _index)
	{
		print ("NPC01 attacked");
	}
	public void OnAnimation_AttackMove()
	{
	}

	// Change the Weapon.
	public void change_weapon(int index)
	{
		this.gameObject.SetActive(false);
		character.Info.order = 1;
		character.Info.unit_part = "human-male";
		character.Info.unit_index = 2;
		character.Info.main_weapon_part = "dagger-a";
		character.Info.main_weapon_index = index;

		character.InitWithoutTextureBaking();
		this.gameObject.SetActive(true);

		// attack animation coroutine about 2sec.
		StartCoroutine("npc_attack_func");
	}


}
