using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour {

	public static GameObject debug_label1;
	public static GameObject debug_label2;

	int i = 0;
	// Use this for initialization
	void Start () {
		debug_label1 = GameObject.Find ("Debug_Label");
		debug_label2 = GameObject.Find ("Debug_Label2");

	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0)) {
			//Get the mouse position on the screen and send a raycast into the game world from that position.
			Vector2 worldPoint = UICamera.mainCamera.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero);

			//If something was hit, the RaycastHit2D.collider will not be null.
			if (hit.collider != null) {
				debug_label2.GetComponent<UILabel> ().text = hit.collider.ToString ();
				i++;
				debug_label1.GetComponent<UILabel> ().text = i.ToString ();

			}

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
