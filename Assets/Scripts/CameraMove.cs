using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public int forwordSpeed;
    void Update()
    {
        if(Variables.firtTouch == 1)
            transform.position += new Vector3(0, 0, forwordSpeed * Time.deltaTime);
    }
}//class
