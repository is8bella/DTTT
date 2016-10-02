using UnityEngine;
using System.Collections;

public class AppearWhenDug : MonoBehaviour {

	private SpriteRenderer r;

	// Use this for initialization
	void Start () {
		r = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		r.enabled = WellVars.doneDigging;
	}
}
