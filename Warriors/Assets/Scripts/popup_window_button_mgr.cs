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

    public string npc01
    {
        get { return "npc01"; }
    }
    public string npc02
    {
        get { return "npc02"; }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Close_NPC_Sel_popup_Window()
    {
        GameData.weapon_sel_popup_window_obj.SetActive(false);
    }

    // 어떤 NPC를 선택했는지 처리하기 위한 함수.
    public void Select_NPC(string npc_name)
    {

        // npc0x에 따라서 실행.
        switch (npc_name)
        {
            case "npc01":
                weapon_to_selected_NPC(NPC_INDEX.NPC01, GameData.to_change_weapon_struct.To_Change_Weapon_Name, GameData.to_change_weapon_struct.weapon_index);
                break;
            case "npc02":
                weapon_to_selected_NPC(NPC_INDEX.NPC02, GameData.to_change_weapon_struct.To_Change_Weapon_Name, GameData.to_change_weapon_struct.weapon_index);
                break;
        }


    }
   
     // 해당 NPC에게 선택한 Weapon을 장착하게 하는 함수.
     void weapon_to_selected_NPC(NPC_INDEX _npc_index,string _weapon_name, int _weapon_index)
    {
        GameObject otherGameObject;
        // npc0x에 따라서 실행.
        switch (_npc_index)
        {

            case NPC_INDEX.NPC01:
                // Change the NPC01 Character Sprite.
                otherGameObject = GameObject.Find("_NPC01_gameobj");
                NPC01_make npc01_make = otherGameObject.GetComponent<NPC01_make>();

                // Change the NPC01 Weapon01 icon Sprite.
                NPC01_make.NPC01_struct.weapon_sp.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                NPC01_make.NPC01_struct.weapon_sp.spriteName = GameData.to_change_weapon_struct.To_Change_Weapon_Name + GameData.to_change_weapon_struct.weapon_index.ToString(); ;

                // NPC01 캐릭터 이미지 바꾸기.
                npc01_make.change_weapon(_weapon_index, _weapon_name);
                break;
            case NPC_INDEX.NPC02:
                // Change the NPC02 Character Sprite.
                otherGameObject = GameObject.Find("_NPC02_gameobj");
                NPC02_make npc02_make = otherGameObject.GetComponent<NPC02_make>();

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

}
