using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	public ParticleSystem creatureParticles;
	public Text scoreText;

	int score = 0;

	void OnCollisionEnter(Collision col) {
		if (col.collider.tag == "creature") {
			col.collider.enabled = false;
			creatureParticles.transform.position = col.transform.position;
			creatureParticles.Play();
			col.transform.position = -col.transform.position;
			col.collider.enabled = true;
			score++;
			scoreText.text = score.ToString();
		}
	}
}
