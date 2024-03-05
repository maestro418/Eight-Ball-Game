using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    var ballNumber;

    //--default caller--//
    void Start()
    {
        objectName = gameObject.name;
        ballNumber = int.Parse(objectName.Replace("Ball", "")); ;
    }
    void Update()
    {
    }
    //--//

    //--State--//

    private void handleCollide()
    {

    }

    private void handleMoving()
    {

    }

    //--//

    //--Support functions--//

    private void isBallScored()
    {

    }
    private void setOwnerOfBall()
    {

    }

    //--//
}
