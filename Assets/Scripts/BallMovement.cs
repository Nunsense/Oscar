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

	public void Move(Vector3 moveDirection) {
		Debug.DrawRay(transform.position, moveDirection.normalized * 5f, Color.green);
		body.angularVelocity *= m_BreakPower;
		body.angularVelocity += moveDirection * m_MovePower;
//		body.AddRelativeTorque(moveDirection * m_MovePower);
	}

	public Vector3 ForceToTorque(Vector3 force, Vector3 position, ForceMode forceMode = ForceMode.Force) {
		Vector3 t = Vector3.Cross(position - body.worldCenterOfMass, force);
		ToDeltaTorque(ref t, forceMode);
 
		return t;
	}

	private void ToDeltaTorque(ref Vector3 torque, ForceMode forceMode) {
		bool continuous = forceMode == ForceMode.Force || forceMode == ForceMode.Acceleration;
		bool useMass = forceMode == ForceMode.Force || forceMode == ForceMode.Impulse;
       
		if (continuous)
			torque *= Time.fixedDeltaTime;
		if (useMass)
			ApplyInertiaTensor(ref torque);
	}

	private void ApplyInertiaTensor(ref Vector3 v) {
		v = body.rotation * Div(Quaternion.Inverse(body.rotation) * v, body.inertiaTensor);
	}

	private static Vector3 Div(Vector3 v, Vector3 v2) {
		return new Vector3(v.x / v2.x, v.y / v2.y, v.z / v2.z);
	}
}
