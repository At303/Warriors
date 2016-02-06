using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour {

	public static GameObject debug_label1;
	public static GameObject debug_label2;

	public static GameObject chest_sprite;
	public static GameObject slash_animation;
	int i = 0;
	// Use this for initialization
	void Start () {
		debug_label1 = GameObject.Find ("debug_label1");
		debug_label2 = GameObject.Find ("debug_label2");
		chest_sprite = GameObject.Find ("chest_sprite");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0)) {
			//Get the mouse position on the screen and send a raycast into the game world from that position.
			Vector2 worldPoint = UICamera.mainCamera.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero);

			// Random slash animation
			string slash_animation_name = "slash" + Random.Range(1,3).ToString();
			slash_animation = GameObject.Find (slash_animation_name);

			//If something was hit, the RaycastHit2D.collider will not be null.
			if (hit.collider != null) {

				// slash sprite enable
				slash_animation.GetComponent<Animator>().SetTrigger("enable");
				slash_animation.GetComponent<SpriteRenderer> ().enabled = true;

				// chest sprite animation enable
				chest_sprite.GetComponent<Animator>().SetTrigger("enable");

			}
			//i++;
			//debug_label1.GetComponent<UILabel> ().text = i.ToString ();

		}
	}


	void FixedUpdate()
	{
		// Single touch
		if (Input.touchCount == 1) 
		{
			Touch touch1 = Input.GetTouch (0);

			// if Touch is On
			if (touch1.phase == TouchPhase.Began) 
			{
				//Get the mouse position on the screen and send a raycast into the game world from that position.
				Vector2 worldPoint = UICamera.mainCamera.ScreenToWorldPoint(Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast(worldPoint,Vector2.zero);
				if (hit.collider != null) 
				{
					debug_label1.GetComponent<UILabel> ().text = "ColliderBox clicked";
				}
				i++;
				debug_label1.GetComponent<UILabel> ().text = i.ToString ();
			}
		}


	}

}
