using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDetection : MonoBehaviour {

    public RectTransform TopLeft;
    public RectTransform TopUp;
    public RectTransform TopDown;
    public RectTransform TopRight;
    public RectTransform CurrentArrow;
    public float GreatLimit;
    public float PerfectLimit;
    public enum Score { Perfect, Great, Miss }

    private float _distanceFromCenterY;
    private float _distanceFromCenterX;
    private bool _recorded;
    private int _scoreOnHit;
	
	void Update () {

        // Collect distance
        if (Input.GetKeyDown(KeyCode.LeftArrow) && CurrentArrow != null) {
            _distanceFromCenterY = Mathf.Abs(TopLeft.position.y - CurrentArrow.position.y);
            _distanceFromCenterX = Mathf.Abs(TopLeft.position.x - CurrentArrow.position.x);
            _recorded = true;
        } else if (Input.GetKeyDown(KeyCode.UpArrow) && CurrentArrow != null) {
            _distanceFromCenterY = Mathf.Abs(TopUp.position.y - CurrentArrow.position.y);
            _distanceFromCenterX = Mathf.Abs(TopUp.position.x - CurrentArrow.position.x);
            _recorded = true;
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && CurrentArrow != null) {
            _distanceFromCenterY = Mathf.Abs(TopDown.position.y - CurrentArrow.position.y);
            _distanceFromCenterX = Mathf.Abs(TopDown.position.x - CurrentArrow.position.x);
            _recorded = true;
        } else if (Input.GetKeyDown(KeyCode.RightArrow) && CurrentArrow != null) {
            _distanceFromCenterY = Mathf.Abs(TopRight.position.y - CurrentArrow.position.y);
            _distanceFromCenterX = Mathf.Abs(TopRight.position.x - CurrentArrow.position.x);
            _recorded = true;
        } else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)) && CurrentArrow == null) {
            DisplayScore((int)Score.Miss);
        }

        if (_recorded) {
            // Record ScoreOnHit
            if (_distanceFromCenterY < PerfectLimit) { // Perfect
                CurrentArrow.gameObject.SetActive(false);
                Debug.Log(_distanceFromCenterY);
                _scoreOnHit = (int)Score.Perfect;
            } else if (_distanceFromCenterY < GreatLimit) { // Great
                CurrentArrow.gameObject.SetActive(false);
                Debug.Log(_distanceFromCenterY);
                _scoreOnHit = (int)Score.Great;
            } else { // Miss
                _scoreOnHit = (int)Score.Miss;
            }

            DisplayScore(_scoreOnHit);

            // Reset flag
            _recorded = false;
        }
    }

    /// <summary>
    /// Display Perfect, Great, or Miss
    /// </summary>
    /// <param name="score"></param>
    public void DisplayScore(int score) {
        switch (score) {
            case ((int)Score.Miss):
                Debug.Log("MISS");
                break;
            case ((int)Score.Great):
                Debug.Log("GREAT");
                break;
            case ((int)Score.Perfect):
                Debug.Log("PERFECT");
                break;
        }
    }
}
