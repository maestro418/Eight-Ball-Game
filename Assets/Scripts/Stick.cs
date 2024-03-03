using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    void Start()
    {

    }

    public void initStick()
    {
        transform.position = trackCueBallPosition();
    }

    void Update()
    {
        initStick();
    }

    private Vector3 trackCueBallPosition()
    {
        Vector3 cueBallPosition;
        cueBallPosition = GameObject.Find("CueBall").transform.position;
        Debug.Log("cueBallPosition :::" + cueBallPosition);
        return cueBallPosition;
    }
}
