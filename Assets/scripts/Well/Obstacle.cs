using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public int level;

	// Use this for initialization
	void Start () {
		if (level != WellVars.level) {
			gameObject.SetActive(false);
		}
	}

}
