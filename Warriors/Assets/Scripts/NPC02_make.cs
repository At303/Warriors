using UnityEngine;
using System.Collections;
using Devwin;
using gamedata;

public class NPC02_make : MonoBehaviour {
	public DevCharacter character;

	void Start()
	{
		character.Info.order = 1;
		character.Info.unit_part = "troll";
		character.Info.main_weapon_part = "sword-a";
		character.Info.main_weapon_index = 17;
		character.Info.wing_part = "cape-a";
		character.Info.wing_index = 5;

		//character.UpdateView(); // with texture-baking
		character.InitWithoutTextureBaking ();
		//GameData.debug_label2.GetComponent<UILabel> ().text = character.main_weapon_type.ToString();

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
	}
}
