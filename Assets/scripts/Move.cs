using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
	public float Speed = 0f;
	private float movex = 0f;

	private Rigidbody2D rb;

	private Vector3 rightScale;
	private Vector3 leftScale;
	private float rotationTolerance = 0.2f;

	private Animator anim;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		leftScale = transform.localScale;
		rightScale = new Vector3 (-leftScale.x, leftScale.y, leftScale.z);
		if (!GlobalVars.started) {
			transform.position = new Vector3 (GlobalVars.playerX, GlobalVars.playerY, 0f);
		} else {
			GlobalVars.started = false;
		}
	}
	
	void FixedUpdate()
	{
		movex = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (movex*Speed, rb.velocity.y);
		if (movex > rotationTolerance) {
			transform.localScale = rightScale;
		}
		if (movex < -rotationTolerance) {
			transform.localScale = leftScale;
		}
		anim.speed = (Mathf.Abs (movex) > rotationTolerance) ? 1 : 0;
	}
	
}

