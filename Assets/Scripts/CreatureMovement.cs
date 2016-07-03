using UnityEngine;
using System.Collections;

public class CreatureMovement : GravityBody {
	void Awake() {
		Init();
	}

	void Start() {
		trans.position = Random.onUnitSphere * 150;
		Vector3 dirOut = trans.position - gravity.transform.position;
		Ray ray = new Ray(trans.position, dirOut);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit)) {
			trans.position = hit.point; 
		}
	}

	void Update() {
		UpdateGravityPhisics();

//		trans.position = Vector3.Lerp(trans.position, trans.position + trans.forward.normalized * Random.Range(1f, 5f), Time.deltaTime);

//		trans.rotation = Quaternion.Lerp(trans.rotation, trans.rotation * Quaternion.FromToRotation(trans.forward, trans.forward + trans.right.normalized * Random.Range(-2f, 2f)), Time.deltaTime);
	}
}
