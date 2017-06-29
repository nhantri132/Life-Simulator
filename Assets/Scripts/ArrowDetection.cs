using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDetection : MonoBehaviour {

    public CameraInteraction CamInteraction;
    public RectTransform SceneBackground;
    public RectTransform TopLeft;
    public RectTransform TopUp;
    public RectTransform TopDown;
    public RectTransform TopRight;
    public RectTransform CurrentLeftArrow;
    public RectTransform CurrentUpArrow;
    public RectTransform CurrentRightArrow;
    public RectTransform CurrentDownArrow;
    public GameObject[] LeftArrowExplosions;
    public GameObject[] UpArrowExplosions;
    public GameObject[] DownArrowExplosions;
    public GameObject[] RightArrowExplosions;
    public float GreatLimit;
    public float PerfectLimit;
    public enum Score { Perfect, Great, Miss }
    public int NumOfEffects;

    private float _distanceFromCenterY;
    private float _distanceFromCenterX;
    private bool _recorded;
    private int _scoreOnHit;
    private int _effectCounter;

    private void Start() {
        _effectCounter = 0;
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && CurrentLeftArrow != null) {

            // Calculate Distance
            _distanceFromCenterY = Mathf.Abs(TopLeft.position.y - CurrentLeftArrow.position.y);
            _distanceFromCenterX = Mathf.Abs(TopLeft.position.x - CurrentLeftArrow.position.x);

            // Check Score
            if (_distanceFromCenterX > 0.1f) {
                _scoreOnHit = (int)Score.Miss;
            } else if (_distanceFromCenterY < PerfectLimit) { // Perfect
                CurrentLeftArrow.gameObject.SetActive(false);
                CurrentLeftArrow = null; 
                ApplyRandomEffect(LeftArrowExplosions);
                CamInteraction.ShakeRectTransform(SceneBackground);
                _scoreOnHit = (int)Score.Perfect;
            } else if (_distanceFromCenterY < GreatLimit) { // Great
                CurrentLeftArrow.gameObject.SetActive(false);
                CurrentLeftArrow = null;
                CamInteraction.ShakeRectTransform(SceneBackground);
                _scoreOnHit = (int)Score.Great;
            } else { // Miss
                _scoreOnHit = (int)Score.Miss;
            }

            DisplayScore(_scoreOnHit);

        } else if (Input.GetKeyDown(KeyCode.UpArrow) && CurrentUpArrow != null) {
            
            // Calculate Distance
            _distanceFromCenterY = Mathf.Abs(TopUp.position.y - CurrentUpArrow.position.y);
            _distanceFromCenterX = Mathf.Abs(TopUp.position.x - CurrentUpArrow.position.x);

            // Check Score
            if (_distanceFromCenterX > 0.1f) {
                _scoreOnHit = (int)Score.Miss;
            } else if (_distanceFromCenterY < PerfectLimit) { // Perfect
                CurrentUpArrow.gameObject.SetActive(false);
                CurrentUpArrow = null;
                ApplyRandomEffect(UpArrowExplosions);
                CamInteraction.ShakeRectTransform(SceneBackground);
                _scoreOnHit = (int)Score.Perfect;
            } else if (_distanceFromCenterY < GreatLimit) { // Great
                CurrentUpArrow.gameObject.SetActive(false);
                CurrentUpArrow = null;
                CamInteraction.ShakeRectTransform(SceneBackground);
                _scoreOnHit = (int)Score.Great;
            } else { // Miss
                _scoreOnHit = (int)Score.Miss;
            }

            DisplayScore(_scoreOnHit);

        } else if (Input.GetKeyDown(KeyCode.DownArrow) && CurrentDownArrow != null) {

            // Calculate Distance
            _distanceFromCenterY = Mathf.Abs(TopDown.position.y - CurrentDownArrow.position.y);
            _distanceFromCenterX = Mathf.Abs(TopDown.position.x - CurrentDownArrow.position.x);

            // Check Score
            if (_distanceFromCenterX > 0.1f) {
                _scoreOnHit = (int)Score.Miss;
            } else if (_distanceFromCenterY < PerfectLimit) { // Perfect
                CurrentDownArrow.gameObject.SetActive(false);
                CurrentDownArrow = null;
                ApplyRandomEffect(DownArrowExplosions);
                CamInteraction.ShakeRectTransform(SceneBackground);
                _scoreOnHit = (int)Score.Perfect;
            } else if (_distanceFromCenterY < GreatLimit) { // Great
                CurrentDownArrow.gameObject.SetActive(false);
                CurrentDownArrow = null;
                CamInteraction.ShakeRectTransform(SceneBackground);
                _scoreOnHit = (int)Score.Great;
            } else { // Miss
                _scoreOnHit = (int)Score.Miss;
            }

            DisplayScore(_scoreOnHit);

        } else if (Input.GetKeyDown(KeyCode.RightArrow) && CurrentRightArrow != null) {

            // Calculate Distance
            _distanceFromCenterY = Mathf.Abs(TopRight.position.y - CurrentRightArrow.position.y);
            _distanceFromCenterX = Mathf.Abs(TopRight.position.x - CurrentRightArrow.position.x);

            // Check Score
            if (_distanceFromCenterX > 0.1f) {
                _scoreOnHit = (int)Score.Miss;
            } else if (_distanceFromCenterY < PerfectLimit) { // Perfect
                CurrentRightArrow.gameObject.SetActive(false);
                CurrentRightArrow = null;
                ApplyRandomEffect(RightArrowExplosions);
                CamInteraction.ShakeRectTransform(SceneBackground);
                _scoreOnHit = (int)Score.Perfect;
            } else if (_distanceFromCenterY < GreatLimit) { // Great
                CurrentRightArrow.gameObject.SetActive(false);
                CurrentRightArrow = null;
                CamInteraction.ShakeRectTransform(SceneBackground);
                _scoreOnHit = (int)Score.Great;
            } else { // Miss
                _scoreOnHit = (int)Score.Miss;
            }

            DisplayScore(_scoreOnHit);

        } else if ((Input.GetKeyDown(KeyCode.LeftArrow) && CurrentLeftArrow == null) || (Input.GetKeyDown(KeyCode.RightArrow) && CurrentRightArrow == null) ||
                   (Input.GetKeyDown(KeyCode.UpArrow) && CurrentUpArrow == null) || (Input.GetKeyDown(KeyCode.DownArrow) && CurrentDownArrow == null)) {
            DisplayScore((int)Score.Miss);
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

    public void ApplyRandomEffect(GameObject[] effects) {
        if (_effectCounter == NumOfEffects) {
            _effectCounter = 0;
        }
        effects[_effectCounter].SetActive(true);
        StartCoroutine(ResetEffectAfterDuration(effects[_effectCounter]));
        _effectCounter++;
    }

    public IEnumerator ResetEffectAfterDuration(GameObject effect) {
        yield return new WaitForSeconds(1.0f);
        foreach (Transform child in effect.transform) {
            child.GetComponent<ExplosionEffect>().Reset();
        }
        effect.SetActive(false);
    }
}
