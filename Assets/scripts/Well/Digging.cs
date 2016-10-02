using UnityEngine;
using System.Collections;

public class Digging : MonoBehaviour {

	public int presses; 

	private int distNeeded;
	private float z;

	// Use this for initialization
	void Start () {
		distNeeded = WellVars.dirtDist;
		z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (!WellVars.doneDigging) {
			transform.position = new Vector3 (0f, -presses * 0.1f - 1.75f, z);
			if (Input.GetKeyDown (KeyCode.Space)) {
				presses++;
				if (presses == distNeeded) {
					WellVars.doneDigging = true;
				}
			}
		}
	}
}
