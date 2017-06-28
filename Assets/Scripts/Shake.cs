using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Shake the camera on space bar press and zoom slightly
/// </summary>
public class Shake : MonoBehaviour {

    public Transform source;
    public Transform zoomParent;
    public bool readyToShake = false;
    public float shakeDuration = 0.2f;
    public float shakeAmount = 0.1f;
    public float decreaseFactor = 1.0f;
    Vector3 originalPos;
    Vector3 originalScale = new Vector3(0, 0, 0);
    Vector3 zoomScale = new Vector3(0, 0, 0.5f);

    void LateUpdate () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            readyToShake = true;
            zoomParent.localScale = zoomScale;
        }
        if (readyToShake) {
            if (shakeDuration > 0) {
                source.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else {
                shakeDuration = 0.2f;
                source.localPosition = originalPos;
                readyToShake = false;
                zoomParent.localScale = originalScale;
            }
        }
    }
}
