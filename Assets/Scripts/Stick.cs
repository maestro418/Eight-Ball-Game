using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    private Ball cueBallScript;
    private GameObject cueBall;
    private float cueDirection = -1;
    private float speed = 7;
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
    }

    void FixedUpdate()
    {
        if (!!isStriked)
        {
            PlaceStick();
        }

    }

    //--//


    //--Support functions--//

    public void initData()
    {
        cueBall = GameObject.Find("CueBall");
        cueOffset = getCueOffset();
    }

    public void PlaceStick()
    {
        GetComponent<Renderer>().enabled = true;
        transform.position = cueBall.transform.position - cueOffset;
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
            var distance = Vector3.Distance(transform.position, cueBall.transform.position);
            cueBallScript = cueBall.GetComponent<Ball>();
            GetComponent<Renderer>().enabled = false;
            cueBallScript = cueBall.GetComponent<Ball>();
            cueBallScript.addForceInCueBallCase();
        }
    }
    //--//

}
