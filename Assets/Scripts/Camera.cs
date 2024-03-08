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
        initData();
    }

    void Update()
    {
        updateCameraPosition();
        rotateCameraWithMouse();
    }
    //--//

    //--Support functions--//
    private void initData()
    {
        cueBall = GameObject.Find("CueBall");
        cue = GameObject.Find("Cue");
        cameraOffset = getCameraOffset();
    }

    private void rotateCameraWithMouse()
    {
        Stick cueScript = cue.GetComponent<Stick>();
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            transform.RotateAround(cueBall.transform.position, Vector3.up, mouseX);
            transform.RotateAround(cueBall.transform.position, transform.right, -mouseY);
            cue.transform.RotateAround(cueBall.transform.position, Vector3.up, mouseX);
            Vector3 newStrikeDirection = (cue.transform.position - cueBall.transform.position).normalized;
            Debug.Log("newStrikeDirection :::" + -newStrikeDirection);
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
    }
}
