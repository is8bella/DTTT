using System.Collections;
using UnityEngine;

class DragOutNew : MonoBehaviour
{
	public GameObject prefab = null;

	void OnMouseDown()
	{
		Instantiate (prefab, transform.position, Quaternion.identity);
	}

	void Update()
	{

	}
}

