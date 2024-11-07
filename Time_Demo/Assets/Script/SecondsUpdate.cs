using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondsUpdate : MonoBehaviour
{
    float timestartoffset = 0;
    bool gotstartime = false;
    void Update()
    {
        if(!gotstartime){
            timestartoffset = Time.realtimeSinceStartup;
            gotstartime = true;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, Time.realtimeSinceStartup - timestartoffset);
    }
}
