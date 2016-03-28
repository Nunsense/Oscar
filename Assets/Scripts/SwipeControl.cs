using UnityEngine;
using System.Collections;

public class SwipeControl : MonoBehaviour {

	// Values to set:
	public float comfortZone = 70.0f;
	public float minSwipeDist = 14.0f;
	public float maxSwipeTime = 0.5f;
 
	private float startTime;
	private Vector2 startPos;
	private bool couldBeSwipe;

	private Vector2 swipeVector;

	public enum SwipeDirection {
		None,
		Up,
		Down
	}

	public enum SwipeState {
		None,
		Draging,
		Began,
		Ended
	}

	private float lastSwipeTime;

	void Update() {
		MouseUpdate();
	}

	void TouchUpdate() {
		if (Input.touchCount > 0) {
			Touch touch = Input.touches[0];
			SwipeState state = SwipeState.None;

			switch (touch.phase) {
			case TouchPhase.Began:
				state = SwipeState.Began;
				break;
			case TouchPhase.Moved:
				state = SwipeState.Draging;
				break;
			case TouchPhase.Ended:
				state = SwipeState.Ended;
				break;
			}
			Swipe(touch.position, state);
		}
	}

	void MouseUpdate() {
		SwipeState state = SwipeState.None;
		if (Input.GetMouseButtonDown(0)) {
			state = SwipeState.Began;
		} else if (Input.GetMouseButtonDown(0)) {
			state = SwipeState.Draging;
		} else if (Input.GetMouseButtonUp(0)) {
			state = SwipeState.Ended;
		}

		Swipe(Input.mousePosition, state);
	}

	void Swipe(Vector2 pos, SwipeState state) {
		switch (state) {
		case SwipeState.Began:
			lastSwipeTime = 0;
			couldBeSwipe = true;
			startPos = pos;
			startTime = Time.time;
			break;
		case SwipeState.Draging:
			if ((pos - startPos).magnitude > comfortZone) {
				Debug.Log("Not a swipe. Swipe strayed " + (int)Mathf.Abs(pos.x - startPos.x) +
				"px which is " + (int)(Mathf.Abs(pos.x - startPos.x) - comfortZone) +
				"px outside the comfort zone.");
				couldBeSwipe = false;
			}
			break;
		case SwipeState.Ended:
			if (couldBeSwipe) {
				float swipeTime = Time.time - startTime;
				Vector2 currentVector = pos - startPos;
				float swipeDist = currentVector.magnitude;
                   
				if (swipeTime < maxSwipeTime && swipeDist > minSwipeDist) {
					swipeVector = currentVector;
					                       
					lastSwipeTime = Time.time;
//					Debug.Log("Swipe");
				} else {
					swipeVector = Vector2.zero;
				}
			}
			break;
		}
	}

	public Vector2 SwipeVector() {
		return swipeVector;
	}

	public void Reset() {
		swipeVector = Vector2.zero;
	}
}
