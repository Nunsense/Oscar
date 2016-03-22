using UnityEngine;
using System.Collections;

public class GravityBody : MonoBehaviour {

	Transform trans;
	Rigidbody body;


	public GravityGenerator gravity;
	public bool freezeRotation = false;

	void Awake() {
		trans = transform;
		body = GetComponent<Rigidbody>();
		body.useGravity = false;
		if(freezeRotation)
			body.constraints = RigidbodyConstraints.FreezeRotation;
	}

	void Update() {
		gravity.Attract(trans, body);
	}
}
