using UnityEngine;
using System.Collections;

public class RegionManager : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		if (GlobalVars.wellsCompleted == null) {
			GlobalVars.wellsCompleted = new bool[2];
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
