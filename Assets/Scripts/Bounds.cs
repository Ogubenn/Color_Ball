using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    [Header("Bound")]
    public Transform vectorBack;
    public Transform vectorRight;
    public Transform vectorLeft;
    public Transform vectorForward;

    public void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.z = Mathf.Clamp(viewPos.z, vectorBack.transform.position.z , vectorForward.transform.position.z);   //Min ve max degerleri tanimalamak icin Clamp
        viewPos.x = Mathf.Clamp(viewPos.x, vectorLeft.transform.position.x, vectorRight.transform.position.x);
        transform.position = viewPos;
    }




}//class
