using UnityEngine;
using System.Collections;

public class CameraMovement : GravityBody {
	bool isMoving = false;
	public Transform ball;

	void Awake() {
		Init();
	}

	void Update() {
		UpdateGravityPhisics();
		trans.position = ball.position;
	}
}
