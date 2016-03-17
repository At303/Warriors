using UnityEngine;
using System.Collections;
using gamedata;
using gamedata_weapon;

public class popup_window_button_mgr : MonoBehaviour {

    // 캐릭터 Index enum 값.
    public enum NPC_INDEX
    {
        NONE,
        NPC01,
        NPC02,
        NPC03,
        NPC04,
        NPC05,
    }
    
    public string npc01_weapon
    {
        get { return "npc01_weapon"; }
    }
    public string npc01_clothes
    {
        get { return "npc01_clothes"; }
    }
    public string npc01_bow
    {
        get { return "npc01_bow"; }
    }
    public string npc02
    {
        get { return "npc02"; }
    }
    public string npc03
    {
        get { return "npc03"; }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // 무기 선택을 위한 캐릭터 창 Close시키는 함수.
    public void Close_NPC_Sel_weapon_popup_Window()
    {
        GameData.weapon_sel_popup_window_obj.SetActive(false);
    }
    // 옷 선택을 위한 캐릭터 창 Close시키는 함수.
    public void Close_NPC_Sel_clothes_popup_Window()
    {
        GameData.clothes_sel_popup_window_obj.SetActive(false);
    }
    // 활무기 선택을 위한 캐릭터 창 Close시키는 함수.
    public void Close_NPC_Sel_bow_popup_Window()
    {
        GameData.bow_sel_popup_window_obj.SetActive(false);
    }


    // 어떤 NPC를 선택했는지 처리하기 위한 함수.
    public void Select_NPC(string npc_name)
    {

        // npc0x에 따라서 실행.
        switch (npc_name)
        {
            case "npc01_weapon":
                weapon_to_selected_NPC(NPC_INDEX.NPC01, GameData.to_change_npc_struct.To_Change_Weapon_type, GameData.to_change_npc_struct.weapon_index);
                break;
            case "npc01_clothes":
                clothes_to_selected_NPC(NPC_INDEX.NPC01, GameData.to_change_npc_struct.To_Change_Armor_type, GameData.to_change_npc_struct.armor_index, GameData.to_change_npc_struct.armor_color );
                break;
            case "npc01_bow":
                weapon_to_selected_NPC(NPC_INDEX.NPC01, GameData.to_change_npc_struct.To_Change_bow_type, GameData.to_change_npc_struct.bow_index);
                break;
        }
        
    }
   
     // 해당 NPC에게 선택한 Weapon을 장착하게 하는 함수.
     void weapon_to_selected_NPC(NPC_INDEX _npc_index,string _weapon_name, int _weapon_index)
    {
        // npc0x에 따라서 실행.
        switch (_npc_index)
        {

            case NPC_INDEX.NPC01:
                // Change the NPC01 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                NPC01_make npc01 = NPC01_make.NPC01_struct.gameobject.GetComponent<NPC01_make>();

                // Change the NPC01 Weapon01 icon Sprite.
                NPC01_make.NPC01_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC01_make.NPC01_struct.weapon_sp.spriteName = GameData.to_change_npc_struct.To_Change_Weapon_type + GameData.to_change_npc_struct.weapon_index.ToString(); ;

                // NPC01 캐릭터 이미지 바꾸기.
                npc01.change_weapon(_weapon_index, _weapon_name);
                break;
            case NPC_INDEX.NPC02:
                // Change the NPC02 Character Sprite.
                NPC02_make npc02 = NPC02_make.NPC02_struct.gameobject.GetComponent<NPC02_make>();

                // Change the NPC02 Weapon01 icon Sprite.
                NPC02_make.NPC02_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC02_make.NPC02_struct.weapon_sp.spriteName = "weapon01_icon";

                // NPC02 캐릭터 이미지 바꾸기.
                //npc02_make.change_weapon(_weapon_index, _weapon_name);

                break;
        }

        // NPC선택 후 popUp window 비활성화.
        GameData.weapon_sel_popup_window_obj.SetActive(false);

    }

    // 해당 NPC에게 선택한 Clothes를 장착하게 하는 함수.
    void clothes_to_selected_NPC(NPC_INDEX _npc_index, string _armor_name, int _armor_index, int _armor_color)
    {
        // npc0x에 따라서 실행.
        switch (_npc_index)
        {

            case NPC_INDEX.NPC01:
                // Change the NPC01 Character Sprite. ( 다른 스크립트 함수 실행할떄 object 받아와야함. )
                NPC01_make npc01 = NPC01_make.NPC01_struct.gameobject.GetComponent<NPC01_make>();

                // Change the NPC01 Clothes icon Sprite.
                NPC01_make.NPC01_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC01_make.NPC01_struct.clothes_sp.spriteName = GameData.to_change_npc_struct.To_Change_Armor_type + GameData.to_change_npc_struct.armor_index.ToString();

                // NPC01 캐릭터 이미지 바꾸기.
                npc01.change_clothes(_armor_index, _armor_color, _armor_name);

                break;
            case NPC_INDEX.NPC02:
                // Change the NPC02 Character Sprite.
                NPC02_make npc02 = NPC02_make.NPC02_struct.gameobject.GetComponent<NPC02_make>();

                // Change the NPC02 Weapon01 icon Sprite.
                NPC02_make.NPC02_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC02_make.NPC02_struct.weapon_sp.spriteName = "weapon01_icon";

                // NPC02 캐릭터 이미지 바꾸기.

                break;
        }

        // NPC선택 후 popUp window 비활성화.
        GameData.weapon_sel_popup_window_obj.SetActive(false);

    }

   
}
