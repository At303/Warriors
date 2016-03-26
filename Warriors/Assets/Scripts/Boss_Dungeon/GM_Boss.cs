using UnityEngine;
using System.Collections;
using gamedata;
using gamedata_weapon;

public class GM_Boss : MonoBehaviour {

	// Boss HP
	public ulong boss_hp;
	public ulong _boss_hp;

	// Use this for initialization
	void Start () {
		
		// 이전 씬에서 어떤 보스와 싸울지 index값을 가져오고, 해당 index에 맞는 boss HP return
		Boss_make boss_make_obj = Boss_make.gameobject.GetComponent<Boss_make> ();
		boss_hp = _boss_hp = boss_make_obj.get_boss_hp (0);

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{


				//Get the mouse position on the screen and send a raycast into the game world from that position.
				Vector2 worldPoint = UICamera.mainCamera.ScreenToWorldPoint(Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

				//If touch is on the fixed range, excute the code.
				if (hit.collider != null)
				{
					// Random touch slash animation
					int slash_index = Random.Range(1, 2);
					string slash_animation_name = "slash" + slash_index.ToString();
					GameData.slash_animation = GameObject.Find(slash_animation_name);

					// slash sprite enable
					GameData.slash_animation.GetComponent<Animator>().SetTrigger("enable");
					GameData.slash_animation.GetComponent<SpriteRenderer>().enabled = true;

					float fHP;
					switch ((SLASH_TYPE)slash_index)
					{
						case SLASH_TYPE.SLASH1:
							print ("slash1");
							boss_hp = boss_hp - GameData.slash1_struct.damage;
							fHP = boss_hp / GameData.chest_struct.HP;
							GameObject.Find ("Boss_Sprite").GetComponent<UIProgressBar> ().value = fHP;
							break;

					}

					// check upgrade buttons들을 활성화 할 지말지 .
					GM.check_all_function_when_gold_changed();                          

				}


		}
	}
}
