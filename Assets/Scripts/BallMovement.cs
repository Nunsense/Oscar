using System;
using UnityEngine;

public class BallMovement : GravityBody {
	[SerializeField] private float m_MovePower = 5;
	[SerializeField] private bool m_UseTorque = true;
	[SerializeField] private float m_MaxAngularVelocity = 25;

	[SerializeField] private float m_BreakPower = 0.8f;

	void Awake() {
		Init();
	}

	private void Start() {
		GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;
	}

	void FixedUpdate() {
		UpdateGravityPhisics();
	}

	public void Move(Vector3 move, Vector3 torque) {
		Debug.DrawRay(transform.position, move.normalized * 2f, Color.green);
		body.angularVelocity *= m_BreakPower;
		body.angularVelocity += torque * m_MovePower;

		body.AddForce(move.normalized * m_MovePower);
	}
}
