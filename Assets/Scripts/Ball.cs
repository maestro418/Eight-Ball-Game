using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    var ballNumber;

    public Vector3 strikeDirection = Vector3.forward;
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

    //--State--//



    //--//

    //--Support functions--//

    private void initBallNumber()
    {
        var objectName = gameObject.name;
        if (objectName !== "CueBall")
        {
            ballNumber = int.Parse(objectName.Replace("Ball", ""));
        }
        else
        {
            ballNumber = 0;
        }

    }

    private void addForceInCueBallCase()
    {
        var force = getForceForCueBall();
        GetComponent<RigidBody>().AddForce(force * strikeDirection);
    }

    private void getForceForCueBall()
    {
        var force;
        var forceAmplitude = maxForce - minForce;
        Vector3 cuePosition = GameObject.Find("CueBall").transform.position;
        var relativeDistance = (Vector3.Distance(cuePosition, transform.position) - MIN_DISTANCE) / (MAX_DISTANCE - MIN_DISTANCE);
        force = forceAmplitude * relativeDistance + minForce;
        return force;
    }


    // private void isBallScored()
    // {

    // }
    // private void setOwnerOfBall()
    // {

    // }


    //--//
}
