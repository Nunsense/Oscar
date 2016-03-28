using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public GravityBody player;
	public Transform planet;

	void Update() {
//		Vector3 gravityUp = (player.position - planet.position)  + player.forward;
//		Vector3 bodyUp = transform.up + transform.forward;
//
//		Quaternion rot = Quaternion.FromToRotation(bodyUp, gravityUp) * transform.rotation;
//		transform.rotation = Quaternion.Slerp(transform.rotation, rot, 20f * Time.deltaTime);
	
	}
}
