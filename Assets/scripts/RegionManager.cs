using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RegionManager : MonoBehaviour {

	public Text pointText;
	public int region;

	// Use this for initialization
	void Awake () {
		GlobalVars.region = region;
		if (GlobalVars.wellStats == null) {
			GlobalVars.waterPoints = 0;
			GlobalVars.wellStats = new WellStats[GlobalVars.regionalWellNumbers[GlobalVars.region]];
			for (int i = 0; i < GlobalVars.wellStats.Length; i++) {
				GlobalVars.wellStats[i] = new WellStats();
			}
		}
	}

	void Start () {
		pointText.text = "" + GlobalVars.waterPoints;
	}

	// Update is called once per frame
	void Update () {

	}
}
