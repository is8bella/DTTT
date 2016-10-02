using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TitleScreen : MonoBehaviour {

	public GameObject[] bars;

	private float timer;
	private int index;

	// Use this for initialization
	void Start () {
		timer = 0f;
		index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (index < bars.Length) {
			if (timer > index * 3f) {
				bars [index].GetComponent<MoveBar> ().StartMove ();
				index++;
			}
			timer += Time.deltaTime;
		}
	}
}
