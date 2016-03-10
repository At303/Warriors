using UnityEngine;
using System.Collections;
using Devwin;
using gamedata;

public class NPC01_make : MonoBehaviour {

	public DevCharacter character;

    void Start()
	{
        character.Info.order = 1;
		character.Info.unit_part = "darkelf-male";
		character.Info.main_weapon_part = "sword-a";
		character.Info.main_weapon_index = 17;
		character.Info.wing_part = "cape-a";
		character.Info.wing_index = 9;

        //character.UpdateView(); // with texture-baking
        character.InitWithoutTextureBaking();
		
        // attack animation coroutine about 2sec.
        StartCoroutine("npc_attack_func");
    }

    IEnumerator npc_attack_func()
    {
        yield return new WaitForSeconds(1f);                                // 모든 NPC 공격 default속도는 3. attack. 무한반복.
       character.PlayAnimation("anim_npc01_attack", false);                // NPC공격 animation 실행.

        StartCoroutine("npc_attack_func");

    }


}
