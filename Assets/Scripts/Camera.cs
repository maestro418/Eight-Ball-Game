using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject cueBall;
    private GameObject cue;
    private Vector3 cameraOffset;
    //--default caller--//
    void Start()
    {
        cueBall = GameObject.Find("CueBall");
        cue = GameObject.Find("Cue");
    }

    void Update()
    {
        rotateCameraWithMouse();
    }
    //--//

    //--Support functions--//

    private void rotateCameraWithMouse()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            transform.RotateAround(cueBall.transform.position, Vector3.up, mouseX);
            transform.RotateAround(cueBall.transform.position, transform.right, -mouseY);
            cue.transform.RotateAround(cueBall.transform.position, Vector3.up, mouseX);
            Debug.Log("cue ::::" + cue.transform.position + "cueBall :::" + cueBall.transform.position);
            Vector3 newStrikeDirection = (cue.transform.position - cueBall.transform.position).normalized;
            Debug.Log("newStrikeDirection :::" + -newStrikeDirection);
            Stick cueScript = cue.GetComponent<Stick>();
            cueScript.strikeDirection = -newStrikeDirection;
        }

    }
}
