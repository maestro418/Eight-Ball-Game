using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTable : MonoBehaviour
{

    void initTable()
    {
        transform.position = new Vector3(0, -16.5f, 0);
    }

    void Start()
    {
        initTable();
    }
}
