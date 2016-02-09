using UnityEngine;
using System.Collections;
using gamedata;

public class GM_2 : MonoBehaviour {
	GameObject label;

	// Use this for initialization
	void Start () {
		label = GameObject.Find ("s2_test");
		label.GetComponent<UILabel> ().text = GameData.chest_struct.Level.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
