using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    [Header("Bounds Transform")] //Topun sýnýrlarý için belirlenen transformlarla
    public Transform vectorBack;
    public Transform vectorForward;
    public Transform vectorRight;
    public Transform vectorLeft;

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.z = Mathf.Clamp(viewPos.z, vectorBack.transform.position.z, vectorForward.transform.position.z); //Clamp metodu verilen deðerler arasýný aþýp aþmadýðýný kontrol
        viewPos.x = Mathf.Clamp(viewPos.x, vectorLeft.transform.position.x, vectorRight.transform.position.x);
        transform.position = viewPos;
    }

}//class
