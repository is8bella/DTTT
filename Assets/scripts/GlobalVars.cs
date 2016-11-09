using UnityEngine;
using System.Collections;

public class GlobalVars : MonoBehaviour {

	//general overall blah
	public static int[] regionalWellNumbers = {2};

	//specific to the region you're in blah
	public static int region;
	public static WellStats[] wellsCompleted;
	public static bool started = true;
	public static float playerX;
	public static float playerY;

}
