using UnityEngine;
using System.Collections;
using Devwin;
using gamedata;

public class NPC02_make : MonoBehaviour,IAnimEventListener {

    // NPC02 struct
    public struct NPC02_struct
    {
        public static bool enable;  
        public static int Level;
        public static float damage;
        public static float attack_speed;
        public static float upgrade_cost;

        // NPC01 Label.
        public static GameObject npc02_gameobject;
        public static GameObject npc02_lv_label;
        public static GameObject npc02_lvup_cost_label;
        public static GameObject npc02_damage_label;

        // NPC01 Sprite.
        public static UISprite weapon_sp;
        public static UISprite clothes_sp;
        public static UISprite wing_sp;

        // NPC01 Button.
        public static GameObject npc02_lvup_btn;
    }

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
