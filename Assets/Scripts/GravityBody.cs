using UnityEngine;
using System.Collections;

public class GravityBody : MonoBehaviour {

	public bool keepStandingUp = true;
	public bool useGravity = true;

	protected Transform trans;

	protected Vector3 normal;

	public GravityGenerator gravity;
	protected Rigidbody body;

	Vector3 gravityUp;

	Vector3 origin;

	public void Init() {
		trans = transform;
		body = GetComponent<Rigidbody>();
		origin = trans.position;

		if (gravity == null) {
			gravity = GetComponentInParent<GravityGenerator>();
		}
	}

	public void UpdateGravityPhisics() {
		if (useGravity) {
			gravity.Attract(body);
		}

		if (keepStandingUp) {
			gravityUp = (trans.position - gravity.transform.position) + trans.position;

			Quaternion rot = Quaternion.FromToRotation(trans.up, gravityUp) * trans.rotation;
			trans.rotation = Quaternion.Slerp(trans.rotation, rot, body.mass * Time.deltaTime);
		}

		normal = trans.position - gravity.transform.position;
	}

	public Vector3 Normal() {
		return normal;
	}
}
