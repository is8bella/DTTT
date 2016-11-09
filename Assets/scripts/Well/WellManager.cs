using UnityEngine;
using UnityEngine.UI;
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

		timer = WellVars.startTimes[WellVars.level];
		WellVars.timer = timer;

	}

	// Update is called once per frame
	void Update () {
		timerText.text = "TIME: " + timer.ToString ("F2");
		if (!WellVars.finished) {
			WellVars.timer -= Time.deltaTime;
			timer = WellVars.timer;
		} else {
			if (Input.GetKeyDown(KeyCode.Space)) {
				GlobalVars.wellsCompleted[WellVars.level].setCompleted(true);
				Application.LoadLevel("Level 1");
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
				int[] startTimes = new int[startTimesS.Length];
				for (int i = 0; i < startTimesS.Length; i++) {
					startTimes [i] = int.Parse (startTimesS [i]);
				}
				WellVars.startTimes = startTimes;
			}
			// Done reading, close the reader and return true to broadcast success    
			theReader.Close ();
			return true;
		}
	}
}
