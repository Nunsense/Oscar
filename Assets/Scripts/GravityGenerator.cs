using UnityEngine;
using System.Collections;

public class GravityGenerator : MonoBehaviour {

	public float gravity = -10f;

	Transform trans;

	void Awake() {
		trans = transform;
	}

	public void Attract(Rigidbody body) {
		Vector3 gravityUp = (body.transform.position - trans.position);

		body.AddForce(gravityUp * gravity * Time.deltaTime);
	}
}
