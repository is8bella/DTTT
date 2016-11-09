using UnityEngine;
using System.Collections;

public class Well : MonoBehaviour {

	public int level;
	private SpriteRenderer r;
	private bool activated;
	private bool completed;

	private float timer;
	private Color faded;

	public GameObject popup;

	// Use this for initialization
	void Start () {
		activated = false;
		completed = false;
		timer = 0f;
		faded = new Color (1f, 1f, 1f, 0.5f);

		r = GetComponent<SpriteRenderer> ();
	}

	void Update () {
		completed = GlobalVars.wellsCompleted[level].isCompleted();
		if (!completed) {
			if (activated) {
				timer += Time.deltaTime;
				if (timer > 0.25f) {
					timer = -0.25f;
				}
				if (timer > 0) {
					r.color = faded;
				} else {
					r.color = Color.white;
				}

				if (Input.GetKeyDown (KeyCode.Space)) {
					WellVars.level = level;
					Application.LoadLevel ("WellGame");
				}
				}
		} else {
			r.color = Color.white;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!completed && col.gameObject.tag == "Player") {
			GlobalVars.playerX = col.gameObject.transform.position.x;
			GlobalVars.playerY = col.gameObject.transform.position.y;
			activated = true;
			timer = 0f;
			popup.GetComponent<PopUp>().appear();
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (!completed && col.gameObject.tag == "Player") {
			activated = false;
			r.color = faded;
			popup.GetComponent<PopUp>().disappear();
		}
	}

}
