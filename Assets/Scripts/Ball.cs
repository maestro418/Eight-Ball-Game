using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public GameObject redBalls;

    void Start() {
        Debug.Log("Transform Position :::");
        foreach (var transform in redBalls.GetComponentsInChildren<Transform>()) {
            Debug.Log("Transform Position :::" + transform.position);
        }
    }

    void Update() {

    }

    void initBall() {
    }

    void handleCollide() {

    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
}
