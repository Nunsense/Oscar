using UnityEngine;
using System.Collections;

public class GravityGenerator : MonoBehaviour {

	public float gravity = -10f;

	Transform trans;

	void Awake() {
		trans = transform;
	}

	void Start() {
	
	}

	public void Attract(Rigidbody otherBody) {
		Vector3 gravityUp = (otherBody.transform.position - trans.position);
		Vector3 bodyUp = otherBody.transform.up;

		otherBody.AddForce(gravityUp * gravity);
	}
}
