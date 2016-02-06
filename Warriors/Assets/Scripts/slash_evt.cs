using UnityEngine;
using System.Collections;

public class slash_evt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void sprite_disalbe()
	{
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
	}
}
