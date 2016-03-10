using UnityEngine;
using System.Collections;
using Devwin;
using gamedata;

public class NPC12_make : MonoBehaviour {
    public DevCharacter character;

    // Use this for initialization
    void Start () {
        character.Info.order = 1;
        character.Info.unit_part = "troll";
        character.Info.main_weapon_part = "bow-a";
        character.Info.main_weapon_index = 0;
        character.Info.sub_weapon_part = "arrow-a";

        //character.UpdateView(); // with texture-baking
        character.InitWithoutTextureBaking();

        // attack animation coroutine about 2sec.
        StartCoroutine("npc_attack_func");
    }

    IEnumerator npc_attack_func()
    {
        yield return new WaitForSeconds(1f);                                // 모든 NPC 공격 default속도는 3. attack. 무한반복.
        character.PlayAnimation("anim_bow_shoot_1", true);                // NPC공격 animation 실행.

        StartCoroutine("npc_attack_func");

    }
}
