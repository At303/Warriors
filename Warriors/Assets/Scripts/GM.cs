using UnityEngine;
using System.Collections;
using gamedata;

public class GM : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0)) {
			//Get the mouse position on the screen and send a raycast into the game world from that position.
			Vector2 worldPoint = UICamera.mainCamera.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero);

			// Random slash animation
			string slash_animation_name = "slash" + Random.Range(1,3).ToString();
			GameData.slash_animation = GameObject.Find (slash_animation_name);

			//If something was hit, the RaycastHit2D.collider will not be null.
			if (hit.collider != null) {

				// slash sprite enable
				GameData.slash_animation.GetComponent<Animator>().SetTrigger("enable");
				GameData.slash_animation.GetComponent<SpriteRenderer> ().enabled = true;

				// chest sprite animation enable
				GameData.chest_sprite.GetComponent<Animator>().SetTrigger("enable");

			}
			//i++;
			//debug_label1.GetComponent<UILabel> ().text = i.ToString ();

		}
	}


	void FixedUpdate()
	{
		// Single touch
		if (Input.touchCount > 0) 
		{
			Touch touch1 = Input.GetTouch (0);				// first touch

			// if Touch is On
			if (touch1.phase == TouchPhase.Began) 
			{
				//Get the mouse position on the screen and send a raycast into the game world from that position.
				Vector2 worldPoint = UICamera.mainCamera.ScreenToWorldPoint(Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast(worldPoint,Vector2.zero);

				// Random slash animation
				string slash_animation_name = "slash" + Random.Range(1,3).ToString();
				GameData.slash_animation = GameObject.Find (slash_animation_name);

				//If touch screen is on the fixed range, excute the code.
				if (hit.collider != null) 
				{
					// slash sprite enable
					GameData.slash_animation.GetComponent<Animator>().SetTrigger("enable");
					GameData.slash_animation.GetComponent<SpriteRenderer> ().enabled = true;

					// chest sprite animation enable
					GameData.chest_sprite.GetComponent<Animator>().SetTrigger("enable");

				}
			}
		}


	}

}
