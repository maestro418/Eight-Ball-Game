using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject cueBall;
    private GameObject cue;
    private Vector3 cameraOffset;
    private Quaternion cameraRotation;
    Stick cueScript;
    //--default caller--//
    void Start()
    {
        initData();
    }

    void Update()
    {
        // if (cueScript.isStriked)
        // {
        //     updateCameraPosition();
        // }
        rotateCameraWithMouse();


    }
    //--//

    //--Support functions--//
    private void initData()
    {
        cueBall = GameObject.Find("CueBall");
        cue = GameObject.Find("Cue");
        cameraOffset = getCameraOffset();
        cameraRotation = transform.rotation;
        cueScript = cue.GetComponent<Stick>();
    }

    private void rotateCameraWithMouse()
    {

        if (Input.GetMouseButton(1))
        {
            Vector3 newStrikeDirection;
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            transform.RotateAround(cueBall.transform.position, Vector3.up, mouseX);
            transform.RotateAround(cueBall.transform.position, transform.right, -mouseY);
            cue.transform.RotateAround(cueBall.transform.position, Vector3.up, mouseX);
            newStrikeDirection = (cue.transform.position - cueBall.transform.position).normalized;
            cueScript.strikeDirection = -newStrikeDirection;
        }
    }

    private Vector3 getCameraOffset()
    {
        Vector3 cameraOffset;
        cameraOffset = cueBall.transform.position - transform.position;
        return cameraOffset;
    }
    private void updateCameraPosition()
    {
        transform.position = cueBall.transform.position - cameraOffset;
        transform.forward = cue.transform.forward;
    }
}
