using UnityEngine;
using System.Collections;

public class PipesMenu : MonoBehaviour {

	public float newX;

	private bool doneMoving;

	// Use this for initialization
	void Start () {
		doneMoving = false;
	}

	void Update () {
		if (WellVars.doneDigging && !doneMoving) {
			transform.Translate(7f * Time.deltaTime * Vector2.right);
			if (transform.position.x >= newX) {
				doneMoving = true;
			}
		}
	}
}
