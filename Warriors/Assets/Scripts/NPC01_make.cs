using UnityEngine;
using System.Collections;
using Devwin;

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
		//GameData.debug_label2.GetComponent<UILabel> ().text = character.main_weapon_type.ToString ();

		switch (character.main_weapon_type)
		{
		case PACKAGE_TYPE.WEAPON_BOW:
			//character.PlayAnimation("anim_melee_attack1", false);
			break;
		case PACKAGE_TYPE.WEAPON_STAFF:
			//character.PlayAnimation("anim_staff_walk", false);
			break;
		case PACKAGE_TYPE.WEAPON_MELEE:
		default:
			character.PlayAnimation("anim_melee_attack1", true);
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
