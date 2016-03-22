using UnityEngine;
using System.Collections;

class Attracted : MonoBehaviour
{
	public GameObject attractedTo;
	public float strengthOfAttraction = 5.0f;
	void Start () {}
	void FixedUpdate ()
	{
		Vector3 direction = attractedTo.transform.position - transform.position;
		GetComponent<Rigidbody> ().AddForce (strengthOfAttraction * direction);

	}
}