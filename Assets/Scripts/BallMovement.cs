using System;
using UnityEngine;

public class BallMovement : GravityBody {
	[SerializeField] private float m_MovePower = 5;
	[SerializeField] private bool m_UseTorque = true;
	[SerializeField] private float m_MaxAngularVelocity = 25;

	[SerializeField] private float m_BreakPower = 0.8f;

	[SerializeField] private float m_MoveFactor = 0.2f;

	void Awake() {
		Init();
	}

	private void Start() {
		GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;
		body.velocity = Vector3.zero;
		body.angularVelocity = Vector3.zero;
	}

	void FixedUpdate() {
		UpdateGravityPhisics();
	}

	public void Move(Vector3 move, Vector3 torque) {
		Debug.DrawRay(transform.position, move.normalized, Color.green);
		body.angularVelocity *= m_BreakPower;
		body.angularVelocity += torque * m_MovePower;

		body.AddForce(move * m_MoveFactor * m_MovePower);
	}

	public float Velocity() {
		return Mathf.Clamp(body.velocity.magnitude, -m_MaxAngularVelocity, m_MaxAngularVelocity);
	}
}
