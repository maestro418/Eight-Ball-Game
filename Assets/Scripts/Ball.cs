using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public GameObject redBalls;
    public Vector3 ballPosition;
    void Start()
    {

    }
    void Update()
    {
        ballPosition = transform.position;
    }


    void handleCollide()
    {

    }
}
