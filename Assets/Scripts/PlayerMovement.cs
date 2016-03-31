using UnityEngine;
using System.Collections;

public class PlayerMovement : GravityBody {
	public Camera cam;
	private SwipeControl swipeControl;

	public Ball ball;
	Transform ballTransform;
	BallMovement ballMovement;

	private Vector3 move;
	private Vector3 torque;

	bool isMoving = false;

	void Awake() {
		Init();
		swipeControl = GetComponent<SwipeControl>();
		ballTransform = ball.transform;
		ballMovement = ball.GetComponent<BallMovement>();
	}

	void Update() {
		UpdateGravityPhisics();

		if (ball.isPlaying) {
			Vector2 swipe = swipeControl.SwipeVector();
			if (swipe != Vector2.zero) {
				move = (swipe.y * trans.forward + swipe.x * trans.right);
				torque = (-swipe.x * trans.forward + swipe.y * trans.right);
				isMoving = true;
				Debug.DrawRay(ballTransform.position, move * 10, Color.yellow, 5f);

				swipeControl.Reset();
			} else {
				isMoving = false;
			}
		}

		trans.position = ballTransform.position;

		Vector3 gravityUp = (transform.position - ballTransform.position);
	}


	void FixedUpdate() {
		if (isMoving)
			ballMovement.Move(-move, -torque);
	}
}
