using System.Collections;
using UnityEngine;

class DragTransform : MonoBehaviour
{

	public int dir = Location.DOWN;
	public int dir2 = Location.UP;
	private int x;
	private int y;

	public float posRoundFactor = 3f;

	private Color mouseOverColor = new Color(1f, 1f, 1f, 0.8f);
	private Color unselectedColor = new Color(1f, 1f, 1f, 1f);
	private bool dragging = false;
	private bool availableSpot = true;
	private float distance;
	private SpriteRenderer sr;
	
	void Start() {
		sr = GetComponent<SpriteRenderer> ();
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		dragging = true;
		availableSpot = true;
		sr.material.color = mouseOverColor;
	}

	void OnMouseDown()
	{
		if (!dragging) {
			PipeManager.RemovePipe (x, y);
			Destroy(gameObject);
		}
	}
	
	void OnMouseUp()
	{
//		if (availableSpot) {
//			dragging = false;
//			sr.material.color = unselectedColor;
//			x = Mathf.FloorToInt ((transform.position.x - WellVars.waterSourcePos.x) / posRoundFactor);
//			y = Mathf.FloorToInt ((transform.position.y - WellVars.waterSourcePos.y) / posRoundFactor);
//			PipeManager.AddPipe (x, y, dir, dir2);
//		} else {
//			Destroy(gameObject);
//		}
	}

	void OnTriggerEnter2D (Collider2D c) {
		//if (c.gameObject.tag == "Obstacle") {
			availableSpot = false;
		//}
	}

	void OnTriggerExit2D (Collider2D c) {
		//if (c.gameObject.tag == "Obstacle") {
			availableSpot = true;
		//}
	}

	void Update()
	{
		if (dragging)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint(distance);
			float xPos = Mathf.Round(rayPoint.x / posRoundFactor) * posRoundFactor;
			float yPos = Mathf.Round(rayPoint.y / posRoundFactor) * posRoundFactor;
			rayPoint = new Vector3(xPos, yPos, 8);
			transform.position = rayPoint;
			if (Input.GetMouseButtonUp(0)) {
				if (availableSpot) {
					dragging = false;
					sr.material.color = unselectedColor;
					x = Mathf.FloorToInt ((transform.position.x - WellVars.waterSourcePos.x) / posRoundFactor);
					y = Mathf.FloorToInt ((transform.position.y - WellVars.waterSourcePos.y) / posRoundFactor);
					PipeManager.AddPipe (x, y, dir, dir2);
				} else {
					Destroy(gameObject);
				}
			}
		}
	}
}

