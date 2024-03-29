using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    int ballNumber;

    public const int maxForce = 7000;
    public const int minForce = 250;
    public const float MIN_DISTANCE = 27.5f;
    public const float MAX_DISTANCE = 32f;

    //--default caller--//
    void Start()
    {
        initBallNumber();
    }

    void Update()
    {

    }
    //--//

    //--Support functions--//

    public void initBallNumber()
    {
        var objectName = gameObject.name;
        if (objectName == "CueBall")
        {
            ballNumber = 0;
        }
        else
        {
            ballNumber = int.Parse(objectName.Replace("ball", ""));
        }
    }

    public void addForceInCueBallCase()
    {
        if (ballNumber == 0)
        {
            float force = getForceForCueBall();
            Vector3 strikeDirection = GameObject.Find("Cue").GetComponent<Stick>().strikeDirection;
            Debug.Log("force strike direction :::" + strikeDirection);
            Debug.Log("force :::" + force);
            GetComponent<Rigidbody>().AddForce(strikeDirection * force);
        }
    }

    public float getForceForCueBall()
    {
        float force;
        var forceAmplitude = maxForce - minForce;
        Vector3 cuePosition = GameObject.Find("Cue").transform.position;
        var relativeDistance = (Vector3.Distance(cuePosition, transform.position) - MIN_DISTANCE) / (MAX_DISTANCE - MIN_DISTANCE);
        force = forceAmplitude * relativeDistance + minForce;
        return force;
    }

    //--//
}
