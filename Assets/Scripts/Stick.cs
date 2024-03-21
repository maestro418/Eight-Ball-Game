using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    private Ball cueBallScript;
    private GameObject cueBall;
    private GameObject mainCamera;
    private GameObject redBalls;
    private float cueDirection = -1;
    private float speed = 7;
    private Quaternion cueRotation;

    public Vector3 strikeDirection;
    public Vector3 cueOffset;
    public bool isStrikingStatus = false;
    public bool isStriked = false;

    //--default caller--//

    void Start()
    {
        initData();
    }

    void Update()
    {
        controlStickBasedOnMouseEvent();
        if (!!isStrikingStatus)
        {
            MoveStickWithMouseMove();
        }
        if (!!isStriked)
        {
            bool isAllBallsStopped = false;
            Debug.Log("redBalls :::" + redBalls);
            for (int i = 0; i < redBalls.transform.childCount; i++)
            {
                Transform child = redBalls.transform.GetChild(i);
                Rigidbody rigidbody = child.GetComponent<Rigidbody>();
                Debug.Log("rigidbody.velocity " + rigidbody.velocity);
                if (rigidbody.velocity == Vector3.zero)
                {
                    isAllBallsStopped = true;
                }
                else
                {
                    isAllBallsStopped = false;
                }
            }
            if (isAllBallsStopped)
            {
                PlaceStick();
            }
        }
    }

    //--//


    //--Support functions--//


    public void initData()
    {
        cueBall = GameObject.Find("CueBall");
        mainCamera = GameObject.Find("Main Camera");
        cueRotation = transform.rotation;
        cueOffset = getCueOffset();
        redBalls = GameObject.Find("RedBalls");
    }

    public void PlaceStick()
    {
        //var distanceFromCamera = Vector3.Distance(mainCamera.transform.position, cueBall.transform.position);
        transform.position = cueBall.transform.position - cueOffset;
        transform.rotation = cueRotation;
        GetComponent<Renderer>().enabled = true;
        isStriked = false;
    }

    public Vector3 getCueOffset()
    {
        Vector3 cueOffset;
        cueOffset = cueBall.transform.position - transform.position;
        return cueOffset;
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
            isStriked = true;
            isStrikingStatus = false;
            GetComponent<Renderer>().enabled = false;
            cueBallScript = cueBall.GetComponent<Ball>();
            cueBallScript.addForceInCueBallCase();
        }
    }
    //--//

}
