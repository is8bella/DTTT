using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PipeManager : MonoBehaviour {

	public static Dictionary<Location, Pipe> pipes = new Dictionary<Location, Pipe>(new LocationComparer());

	private float posRoundFactor = 0.7f;
	public GameObject wellPrefab;
	private static GameObject well;

	// Use this for initialization
	void Start () {
		well = wellPrefab;
		pipes = new Dictionary<Location, Pipe> (new LocationComparer ());
	}

	public static void AddPipe (int xPos, int yPos, int dir, int dir2) {
		//Debug.Log ("Placed at: " + xPos + ", " + yPos);
		pipes.Add(new Location (xPos, yPos), new Pipe(dir, dir2));

		//decide whether the pipes are complete
		int previousDir = Location.UP;
		Location furthestPos = new Location (0, 0);
		while (!WellVars.finished) {
			if (furthestPos.y > 6) {
				WellVars.finished = true;											//you win!!
				float wellx = furthestPos.x * 0.7f + WellVars.waterSourcePos.x;
				float welly = furthestPos.y * 0.7f + WellVars.waterSourcePos.y + 0.4f;
				Instantiate(well, new Vector3(wellx, welly, 0), Quaternion.identity);
				break;
			}
			if (pipes.ContainsKey(furthestPos)) {
				Pipe furthestPipe = pipes[furthestPos];
				//check if the pipe's direction is opposite of previous direction, and assigns pipe's other direction to openDir
				int openDir;
				if (furthestPipe.dir == -previousDir) {
					openDir = furthestPipe.dir2;
				} else if (furthestPipe.dir2 == -previousDir) {
					openDir = furthestPipe.dir;
				} else {
					Debug.Log ("Wrong direction! Furthest at " + furthestPos.x + ", " + furthestPos.y + " direction " + previousDir);
					break;
				}
				switch (openDir) {
				case Location.LEFT:
					furthestPos = new Location (furthestPos.x - 1, furthestPos.y);
					break;
				case Location.RIGHT:
					furthestPos = new Location (furthestPos.x + 1, furthestPos.y);
					break;
				case Location.UP:
					furthestPos = new Location (furthestPos.x, furthestPos.y + 1);
					break;
				case Location.DOWN:
					furthestPos = new Location (furthestPos.x, furthestPos.y - 1);
					break;
				default:
					Debug.LogError ("ERROAR: Dis Pipe has a not-real direction");
					break;
				}
				previousDir = openDir;
			} else {
				Debug.Log ("Nowhere to go! Furthest at " + furthestPos.x + ", " + furthestPos.y);
				break;
			}
		}
		/*Debug.Log ("KEYS:");
		foreach (Location l in pipes.Keys) {
			Debug.Log (l.x + ", " + l.y);
		}*/
	}

	public static void RemovePipe (int xPos, int yPos) {
		pipes.Remove(new Location(xPos, yPos));
	}

}

public class Location {
	//note that opposing directions are negative of each other
	public const int LEFT = -1;
	public const int RIGHT = 1;
	public const int UP = 2;
	public const int DOWN = -2;
	
	public int x;
	public int y;
	
	public Location (int x_, int y_) {
		x = x_;
		y = y_;
	}
}

public class LocationComparer : IEqualityComparer<Location>
{
	public bool Equals (Location a, Location b)
	{ 
		return a.x == b.x && a.y == b.y; 
	}
	
	public int GetHashCode (Location a)
	{
		return a.x.GetHashCode() + a.y.GetHashCode();
	}
}

public class Pipe {
	public int dir;
	public int dir2;

	public Pipe (int dir_, int dir2_) {
		dir = dir_;
		dir2 = dir2_;
	}
}
