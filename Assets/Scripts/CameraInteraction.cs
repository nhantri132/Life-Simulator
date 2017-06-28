using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteraction : MonoBehaviour {

    public float ShakeAmount;

    private int _shakeCount;
    private bool _doneShaking;

    // ========================================================================

    public void ShakeRectTransform(RectTransform sprite) {
        ShakeRectTransform(sprite, ShakeAmount);
    }

    public void ShakeRectTransform(RectTransform sprite, float shakeAmount) {
        Vector3 originalPosition = sprite.transform.position;

        while (_shakeCount < 1000) {
            sprite.transform.position = new Vector3(sprite.transform.position.x, sprite.transform.position.y,
                                                    Random.Range(sprite.transform.position.z, sprite.transform.position.z + shakeAmount));
            _shakeCount++;
        }
        sprite.transform.position = originalPosition;
    }

}
