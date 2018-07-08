using UnityEngine;
using System.Collections;

public class MoveBar : MonoBehaviour {

	public bool moving = false;

	void Update () {
		if (moving) {
			transform.Translate(4f * Time.deltaTime,  0f, 0f);
			if (transform.position.x > 14.4f) {
				moving = false;
			}
		}
	}

	public void StartMove () {
		moving = true;
	}

}
