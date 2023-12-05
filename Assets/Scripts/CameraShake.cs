using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    private bool shakeControll;
    public IEnumerator cameraShakes(float duration,float magnetidue)
    {
        Vector3 orgPos = transform.localPosition; //Kamera orjinal pozisyon

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnetidue;
            float y = Random.Range(-1f, 1f) * magnetidue;

            transform.localPosition = new Vector3(x, y, orgPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = orgPos;


    }
    public void CameraShakesCall()
    {
        if(shakeControll == false)
        {
            StartCoroutine(cameraShakes(0.22f, 0.4f));
            shakeControll = true;
        }
    }


}//class
