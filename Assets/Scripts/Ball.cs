using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	public ParticleSystem creatureParticles;
	public Text scoreText;
	public Text oxigenText;
	public Image oxigenImage;
	public Text speedText;
	public Image speedImage;

	private BallMovement movement;

	float maxImageSize = 400f;

	float oxigen = 100;
	float speed = 0;
	int score = 0;

	void Awake() {
		movement = GetComponent<BallMovement>();
	}

	void Update() {
		speed = movement.Velocity();
		oxigen -= (0.2f + 0.01f * (60f / speed)) * Time.deltaTime;

		SetImageSize(oxigenImage, oxigen * maxImageSize);
		oxigenText.text = Mathf.Round(oxigen) + "%";

		SetImageSize(speedImage, speed * maxImageSize);
		speedText.text = Mathf.Round(speed) + "%";
	}

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

	void SetImageSize(Image img, float perc) {
		RectTransform rec = img.rectTransform;
		Vector2 size = rec.sizeDelta;
		size.y = perc / 100;
		rec.sizeDelta = size;
	}
}
