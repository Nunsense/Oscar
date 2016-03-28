using System;
using UnityEngine;

public class PlanetMovement : GravityBody {
	[SerializeField] private float m_MovePower = 5;
	[SerializeField] private bool m_UseTorque = true;
	[SerializeField] private float m_MaxAngularVelocity = 25;

	void Awake() {
		Init();
	}

	private void Start() {
		GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;
	}

	void Update() {
		UpdateGravityPhisics();
	}

	public void Move(Vector3 moveDirection) {
		body.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x) * m_MovePower);
	}
}
