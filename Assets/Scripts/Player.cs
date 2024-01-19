using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Get Component")]
    private Touch touch;
    private Rigidbody rb;


    public float speedModifier;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                rb.velocity = new Vector3(touch.deltaPosition.x * speedModifier * Time.deltaTime,
                                          transform.position.y,
                                          touch.deltaPosition.y * speedModifier * Time.deltaTime);
            }
        }
    }





}//class
