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

	public void Attract(Transform otherTrans, Rigidbody otherBody) {
		Vector3 gravityUp = (otherTrans.position - trans.position).normalized;
		Vector3 bodyUp = otherTrans.up;

		otherBody.AddForce(gravityUp * gravity);
		//Quaternion rot = Quaternion.FromToRotation(bodyUp, gravityUp) * otherTrans.rotation;
		//otherTrans.rotation = Quaternion.Slerp(otherTrans.rotation, rot, 50 * Time.deltaTime);
	}
}
