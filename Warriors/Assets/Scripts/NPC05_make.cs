using UnityEngine;
using System.Collections;
using Devwin;

public class NPC05_make : MonoBehaviour {
	public DevCharacter character;

	// Use this for initialization
	void Start () 
	{
		character.Info.order = 1;
		character.Info.unit_part = "human-male";
		character.Info.unit_index = 10;
		character.Info.armor_part = "ancient-b";
		character.Info.armor_index = 2;
		character.Info.main_weapon_part = "bow-a";
		character.Info.main_weapon_index = 14;
		character.Info.sub_weapon_part = "arrow-a";
		character.Info.wing_part = "cape-a";
		character.Info.wing_index = 10;

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
	
	}
	
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			character.PlayAnimation("anim_bow_shoot_1", true);
		}
	}
}
