using UnityEngine;
using System.Collections;

public class RegionManager : MonoBehaviour {

	public int region;

	// Use this for initialization
	void Awake () {
		GlobalVars.region = region;
		if (GlobalVars.wellsCompleted == null) {
			GlobalVars.wellsCompleted = new WellStats[GlobalVars.regionalWellNumbers[GlobalVars.region]];
			for (int i = 0; i < GlobalVars.wellsCompleted.Length; i++) {
				GlobalVars.wellsCompleted[i] = new WellStats();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
