using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Untagged") || hit.gameObject.CompareTag("Obstacle(Enemy)"))
        {
            hit.gameObject.SetActive(false);
        }
    }



}//class
