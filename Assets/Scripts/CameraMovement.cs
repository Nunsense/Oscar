using UnityEngine;
using System.Collections;

public class CameraMovement : GravityBody {
	public Transform ball;

	public float speed = 20f;

	void Awake() {
		Init();
	}

	void Update() {
		UpdateGravityPhisics();
		trans.position = Vector3.Lerp(trans.position, ball.position, speed * Time.deltaTime);
	}
}
