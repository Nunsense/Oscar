using UnityEngine;
using System.Collections;

public class PlayerMovement : GravityBody {
	public Camera cam;
	private SwipeControl swipeControl;

	public Transform ball;
	public PlanetMovement ballMovement;

	private Vector3 move;

	bool isMoving = false;

	void Awake() {
		Init();
		swipeControl = GetComponent<SwipeControl>();
	}

	void Update() {
		UpdateGravityPhisics();

		Vector2 swipe = swipeControl.SwipeVector();
		if (swipe != Vector2.zero) {
			move = (-swipe.x * trans.forward + swipe.y * trans.right).normalized;
			isMoving = true;
			Debug.DrawRay(ball.position, move * 10, Color.yellow, 5f);

			swipeControl.Reset();
		} else {
			isMoving = false;
		}

		trans.position = ball.position;

		Vector3 gravityUp = (transform.position - ball.position);

		Debug.DrawRay(ball.transform.position, gravityUp * 0.5f, Color.green);
		Debug.DrawRay(ball.transform.position, cam.transform.up * 10, Color.red);
		Debug.DrawRay(ball.transform.position, cam.transform.right * 10, Color.blue);
	}


	private void FixedUpdate() {
		if (isMoving)
			ballMovement.Move(move);
	}
}
