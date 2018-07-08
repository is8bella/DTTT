using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Text;
using System.IO;

public class WellManager : MonoBehaviour {

	public Text timerText;
	public float timer;

	// Use this for initialization
	void Start () {
		Load ("WellData.txt");

		WellVars.finished = false;
		WellVars.doneDigging = false;

		timer = WellVars.startTime;
		WellVars.timer = timer;
		WellVars.waterPt = 0;

	}

	// Update is called once per frame
	void Update () {
		timerText.text = "TIME: " + timer.ToString ("F2");
		if (!WellVars.finished) {
			WellVars.timer -= Time.deltaTime;
			timer = WellVars.timer;
		} else {
			if (Input.GetKeyDown(KeyCode.Space)) {
				GlobalVars.wellStats[WellVars.level].setCompleted(true);

				if (WellVars.waterPt > GlobalVars.wellStats[WellVars.level].getWaterPoints()) {
					Debug.Log ("New High Score: " + WellVars.waterPt);
					GlobalVars.waterPoints += WellVars.waterPt - GlobalVars.wellStats[WellVars.level].getWaterPoints();
					GlobalVars.wellStats[WellVars.level].setWaterPoints(WellVars.waterPt);
					Debug.Log ("New Total: " + GlobalVars.waterPoints);
				} else {
					Debug.Log ("Derp Score: " + WellVars.waterPt);
				}
				SceneManager.LoadScene("Level 1");
			}
		}
	}

	private bool Load(string fileName)
	{
		string line;
		// Create a new StreamReader, tell it which file to read and what encoding the file
		// was saved as
		StreamReader theReader = new StreamReader (fileName, Encoding.Default);
		// Immediately clean up the reader after this block of code is done.
		// You generally use the "using" statement for potentially memory-intensive objects
		// instead of relying on garbage collection.
		// (Do not confuse this with the using directive for namespace at the
		// beginning of a class!)
		using (theReader) {
			// While there's lines left in the text file, do this:
			line = theReader.ReadLine ();
			if (line != null) {
				// Do whatever you need to do with the text line, it's a string now
				// In this example, I split it into arguments based on comma
				// deliniators, then send that array to DoStuff()
				string[] startTimesS = line.Split (',');
				int startTime;
				startTime = int.Parse(startTimesS[WellVars.level]);
				WellVars.startTime = startTime;
			}
			// Done reading, close the reader and return true to broadcast success
			theReader.Close ();
			return true;
		}
	}
}
