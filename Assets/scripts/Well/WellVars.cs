using UnityEngine;
using System.Collections;

public class WellVars : MonoBehaviour {

	public static float timer = 60f;
	public static bool finished = false;

	public static int dirtDist = 54;
	public static bool doneDigging = false;

	public static Vector2 waterSourcePos = new Vector2(0f, -2.8f);


	public static int level = 1;

	public static int[] startTimes;	//start time for each level

}
