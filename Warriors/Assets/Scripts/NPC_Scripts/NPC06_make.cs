using UnityEngine;
using System.Collections;
using Devwin;
using gamedata;

public class NPC06_make : MonoBehaviour {
	public DevCharacter character;
    bool enable = true;
	// Use this for initialization
	void Start () {

        character.Info.order = 1;
        character.Info.unit_part = "dwarf-female";
        character.Info.unit_index = 4;
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
		yield return new WaitForSeconds(1.9f);

		print ("npc06");
        character.PlayAnimation("anim_bow_shoot_1", true);
        character.SetAnimationSpeed(1f);
        StartCoroutine("start_attack_animation");


        /* 나중에 캐릭터 이미지 업데이트시 아래와 같이 하면됨.

        if (enable)
        {
            this.gameObject.SetActive(false);
            character.Info.order = 1;
            character.Info.unit_part = "human-male";
            character.Info.unit_index = 6;
            character.Info.armor_part = "uniform-a";
            character.Info.armor_index = 1;
            character.Info.armor_color = 3;
            character.Info.main_weapon_part = "bow-a";
            character.Info.main_weapon_index = 1;
            character.Info.sub_weapon_part = "arrow-a";
            character.Info.wing_part = "cape-a";
            character.Info.wing_index = 3;
            character.InitWithoutTextureBaking();
            this.gameObject.SetActive(true);
            enable = false;
        }
        */
    }

	public void change_weapon()
	{
		
		this.gameObject.SetActive(false);
		character.Info.order = 1;
		character.Info.unit_part = "human-male";
		character.Info.unit_index = 6;
		character.Info.armor_part = "uniform-a";
		character.Info.armor_index = 1;
		character.Info.armor_color = 3;
		character.Info.main_weapon_part = "bow-a";
		character.Info.main_weapon_index = 7;
		character.Info.sub_weapon_part = "arrow-a";
		character.Info.wing_part = "cape-a";
		character.Info.wing_index = 3;
		character.InitWithoutTextureBaking();
		this.gameObject.SetActive(true);
		print ("here");
		StartCoroutine("start_attack_animation");

	}

}
