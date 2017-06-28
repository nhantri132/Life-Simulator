using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour {

    public GameObject[] Arrows;
    
    public GameObject GetTopArrow() {
        for (int i=0; i<Arrows.Length; i++) {
            if (Arrows[i] != null) {
                return Arrows[i]; // Top Arrow
            }
        }
        return null; // None left
    }
}
