using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {

	// Values to set:
	public float comfortZone = 100.0f;
	public float minSwipeDist = 5.0f;
	public float maxSwipeTime = 0.8f;
 
	private float startTime;
	private Vector2 startPos;
	private Vector2 endPos;
	private bool couldBeSwipe;

	private Vector2 swipeVector;
	SwipeState state;

	public enum SwipeState {
		None,
		Draging,
		Began,
		Ended
	}

	void Update() {
		MouseUpdate();
	}

	void MouseUpdate() {
		if (Input.GetMouseButtonDown(0)) {
			state = SwipeState.Began;
		} else if (Input.GetMouseButtonUp(0)) {
			state = SwipeState.Ended;
		}
		Swipe(Input.mousePosition);
	}

	void Swipe(Vector2 pos) {
		switch (state) {
		case SwipeState.Began:
			couldBeSwipe = true;
			startPos = pos;
			state = SwipeState.Draging;
			break;
		case SwipeState.Draging:
			Vector2 currentVector = pos - startPos;
			float swipeDist = currentVector.magnitude;
			  
			if (swipeDist > minSwipeDist) {
				swipeVector = currentVector;
			} else {
				swipeVector = Vector2.zero;
			}
			startPos = pos;
			break;
		}
	}

	public Vector2 SwipeVector() {
		return swipeVector;
	}

	public float SwipeAngle() {
		return Vector2.Angle(startPos, swipeVector);
	}

	public bool HasSwipe() {
		return swipeVector != Vector2.zero;
	}

	public void Reset() {
		swipeVector = Vector2.zero;
	}
}
