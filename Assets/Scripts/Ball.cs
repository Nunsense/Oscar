using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	public ParticleSystem creatureParticles;
	public UIManager ui;
	private BallMovement movement;

	float oxigen = 100;
	float speed = 0;
	int score = 0;

	public float oxigenConsumption = 0.4f;
	public bool isPlaying;

	void Awake() {
		movement = GetComponent<BallMovement>();
		isPlaying = false;
	}

	void Update() {
		if (isPlaying) {
			speed = movement.Velocity();
			oxigen -= (oxigenConsumption + oxigenConsumption * (60f / speed)) * Time.deltaTime;

			ui.ShowInGameOxigen(oxigen);
			ui.ShowInGameSpeed(speed);

			if (oxigen <= 0) {
				isPlaying = false;
				ui.EndGame(score);		
			}
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.collider.tag == "creature") {
			col.collider.enabled = false;
			creatureParticles.transform.position = col.transform.position;
			creatureParticles.Play();
			col.transform.position = -col.transform.position;
			col.collider.enabled = true;
			score++;
			ui.ShowInGameScore(score);
		}
	}

	public void Reset() {
		oxigen = 100;
		score = 0;
		speed = 0;
		isPlaying = true;
		ui.ShowInGameScore(score);
	}
}
