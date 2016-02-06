using UnityEngine;
using System.Collections;



namespace gamedata 
{
	public class GameData : MonoBehaviour {


// **************************************    GameObject data    ************************************************ //

		public static GameObject debug_label1;
		public static GameObject debug_label2;

		public static GameObject chest_sprite;
		public static GameObject slash_animation;
// ************************************************************************************************************* //


		// Use this for initialization
		void Start () {
			debug_label1 = GameObject.Find ("debug_label1");
			debug_label2 = GameObject.Find ("debug_label2");
			chest_sprite = GameObject.Find ("chest_sprite");
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}

}