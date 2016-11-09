using UnityEngine;
using System.Collections;

public class WellStats {

	private int waterPoints;
	private bool completed;

	public WellStats() {
		waterPoints = 0;
		completed = false;
	}

	public WellStats(int waterPoints) {
		this.waterPoints = waterPoints;
		completed = false;
	}

	public int getWaterPoints() {
		return waterPoints;
	}

	public void setWaterPoints(int waterPoints) {
		this.waterPoints = waterPoints;
	}

	public bool isCompleted() {
		return completed;
	}

	public void setCompleted(bool completed) {
		this.completed = completed;
	}

}
