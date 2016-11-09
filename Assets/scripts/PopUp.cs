using UnityEngine;
using System.Collections;

public class PopUp : MonoBehaviour {

	private bool appeared;
	private bool transitioning;
	private int i;

	private Vector3 size;
	private Vector3 startPos;
	private Vector3 endPos;

	// Use this for initialization
	void Start () {
		appeared = false;
		transitioning = false;
		size = Vector3.zero;
		transform.localScale = size;
		startPos = transform.position;
		endPos = transform.position + (4.4f * transform.up);
	}
	
	// Update is called once per frame
	void Update () {
		if (transitioning) {
			transform.localScale = size;
			if (appeared) {
				i++;
				size = size * 1.4f;
				transform.Translate(0.2f * Vector3.up);
				if (i >= 22) {
					transitioning = false;
				}
			} else {
				i--;
				size = size / 1.4f;
				transform.Translate(0.2f * Vector3.down);
				if (i <= 0) {
					size = Vector3.zero;
					transitioning = false;
				}
			}
		}
	}

	public void appear() {
		i = 0;
		size = Vector3.one / 1000;
		transform.position = startPos;
		appeared = true;
		transitioning = true;
	}

	public void disappear() {
		size = Vector3.one * 1.6399f;
		transform.position = endPos;
		appeared = false;
		transitioning = true;
	}
}
