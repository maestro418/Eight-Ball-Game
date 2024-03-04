using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    private float cueDirection = -1;
    private float speed = 7;
    private Vector3 strikeDirection = Vector3.forward;

    //--default caller--//
    void Start()
    {

    }

    void Update()
    {
        //PlaceStick();
        handleStriking();

    }
    //--//

    //--State--//
    private void handleStriking()
    {
    }

    private void handleStrike()
    {

    }

    private void handleAfterStrike()
    {

    }
    //--//

    //--Support functions
    public void PlaceStick()
    {
        Vector3 cueBallPosition = trackCueBallPosition();
        transform.position = cueBallPosition + new Vector3(0, 0, -10f);
    }

    private Vector3 trackCueBallPosition()
    {
        Vector3 cueBallPosition;
        cueBallPosition = GameObject.Find("CueBall").transform.position;
        return cueBallPosition;
    }

    private void MoveStickWithControl()
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

    private void collideWithCueBall()
    {
        if (Input.GetButtonUp(0))
        {
            renderer.enabled = false;
        }
    }

}
