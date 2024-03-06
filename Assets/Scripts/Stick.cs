using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    private float cueDirection = -1;
    private float speed = 7;
    public Vector3 strikeDirection = Vector3.forward;
    public bool isStrikingStatus = false;

    //--default caller--//
    void Start()
    {

    }

    void FixedUpdate()
    {
        controlStickBasedOnMouseEvent();
    }

    void Update()
    {
        if (!!isStrikingStatus)
        {
            MoveStickWithMouseMove();
        }
    }

    //--//


    //--Support functions--//
    public void PlaceStick()
    {
        Vector3 cueBallPosition = trackCueBallPosition();
        transform.position = cueBallPosition + new Vector3(0, 0, -10f);
    }

    public Vector3 trackCueBallPosition()
    {
        Vector3 cueBallPosition;
        cueBallPosition = GameObject.Find("CueBall").transform.position;
        return cueBallPosition;
    }

    private void MoveStickWithMouseMove()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        if (mouseY < 0)
        {
            cueDirection = 1;
        }
        else if (mouseY > 0)
        {
            cueDirection = -1;
        }
        transform.Translate(Vector3.down * cueDirection * speed * Time.deltaTime);
    }

    private void controlStickBasedOnMouseEvent()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isStrikingStatus = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            isStrikingStatus = false;
            GetComponent<Renderer>().enabled = false;
            transform.Translate(Vector3.down * speed * Time.fixedDeltaTime);
            Debug.Log("cueBall :::" + );
            // for (int i = 0; i < balls.length; i++)
            // {
            //     if (balls[i].gameObject.name == "CueBall")
            //     {
            //         balls[i].addForceInCueBallCase();
            //     }
            // }
        }
    }

    //--//

}
