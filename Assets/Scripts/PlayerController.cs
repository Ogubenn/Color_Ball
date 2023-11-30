using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject camera;
    private Rigidbody rb;
    private Touch touch;

    [Header("Bounds")]
    public GameObject vectorBack;
    public GameObject vectorForward;

    [Header("Player")]
    [Range(20, 40)]
    public float speedModifier;
    public float playerSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if(Variables.firstTouch == 1)
        {
            transform.position += new Vector3(0, 0, playerSpeed * Time.deltaTime);
            camera.transform.position += new Vector3(0, 0, playerSpeed * Time.deltaTime);
            vectorBack.transform.position += new Vector3(0, 0, playerSpeed * Time.deltaTime);
            vectorForward.transform.position += new Vector3(0, 0, playerSpeed * Time.deltaTime);
        }

        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                Variables.firstTouch = 1;
            }

            else if(touch.phase == TouchPhase.Moved)
            {
                rb.velocity = new Vector3(touch.deltaPosition.x * speedModifier * Time.deltaTime,
                                          transform.position.y,
                                          touch.deltaPosition.y * speedModifier * Time.deltaTime);
            }

            else if(touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

}//class
