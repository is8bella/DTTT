using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public GameObject subject;
	private Transform sbjTransform;

	private float y;
	private float z;

	// Use this for initialization
	void Start () {
		sbjTransform = subject.transform;
		y = transform.position.y;
		z = transform.position.z;
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (sbjTransform.position.x, y, z);
	}
}
