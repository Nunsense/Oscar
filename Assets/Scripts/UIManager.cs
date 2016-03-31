using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	float maxImageSize = 400f;

	public Text scoreText;
	public Text oxigenText;
	public Image oxigenImage;
	public Text speedText;
	public Image speedImage;

	public Text endGameScoreText;

	public GameObject inGameCanvas;
	public GameObject menuCanvas;

	public Ball ball;

	void Start() {
		StartGame();
	}

	public void ShowInGameSpeed(float speed) {
		SetImageSize(speedImage, speed * maxImageSize);
		speedText.text = Mathf.Round(speed) + "%";
	}

	public void ShowInGameOxigen(float oxigen) {
		SetImageSize(oxigenImage, oxigen * maxImageSize);
		oxigenText.text = Mathf.Round(oxigen) + "%";
	}

	public void ShowInGameScore(float score) {
		scoreText.text = score.ToString();
	}

	public void EndGame(float score) {
		endGameScoreText.text = score.ToString();
		inGameCanvas.SetActive(false);
		menuCanvas.SetActive(true);
	}

	public void StartGame() {
		ball.Reset();
		menuCanvas.SetActive(false);
		inGameCanvas.SetActive(true);
	}


	void SetImageSize(Image img, float perc) {
		RectTransform rec = img.rectTransform;
		Vector2 size = rec.sizeDelta;
		size.y = perc / 100;
		rec.sizeDelta = size;
	}
}
