using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingArrow : MonoBehaviour {

    public ArrowDetection Detector;
    public RectTransform MyTransform;
    public Vector3 Increment;

    public void Start() {
        Detector = GameObject.Find("InputManager").GetComponent<ArrowDetection>();
    }

    public void Update() {
        MyTransform.localPosition += Increment;
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        switch (collision.gameObject.name) {
            case ("ArrowRemover"):
                // Delete later?
                gameObject.SetActive(false);
                break;
            default: // Left, Right, Up, Down arrows
                Detector.CurrentArrow = MyTransform;
                break;
        }
    }
}
