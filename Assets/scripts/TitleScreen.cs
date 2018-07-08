using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TitleScreen : MonoBehaviour {

	public GameObject[] bars;
	public GameObject pressSpaceBar;

	private float timer = 0f;
	private int index = 0;
	private Renderer pressSpaceBarRenderer;

	void Update () {
		if (index < bars.Length) {
			if (timer > index * 3f) {
				bars [index].GetComponent<MoveBar> ().StartMove ();
				index++;
			}
			timer += Time.deltaTime;
		} else if (bars.All(x => !x.GetComponent<MoveBar>().moving)) { // All bars moved
			pressSpaceBarRenderer = pressSpaceBar.GetComponent<Renderer>();
			pressSpaceBarRenderer.enabled = true;
			if (Input.GetKeyDown("space"))
				print("Space pressed");
		}
	}
}
