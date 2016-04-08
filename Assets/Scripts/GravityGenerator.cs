using UnityEngine;
using System.Collections;

public class GravityGenerator : MonoBehaviour {

	public float gravity = -10f;

	Transform trans;

	void Awake() {
		trans = transform;
	}

	public void Attract(Rigidbody body) {
		Vector3 vector = (body.transform.position - trans.position);
		float distance2 = Mathf.Pow(vector.magnitude, 2);
		body.AddForce(vector.normalized * distance2 * gravity * Time.deltaTime);
//		body.AddForce(vector * gravity * Time.deltaTime);
	}
}
