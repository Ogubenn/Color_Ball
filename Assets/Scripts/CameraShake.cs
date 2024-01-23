using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    private bool shakeControl = false;
    public IEnumerator cameraShake(float duration,float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
        Debug.Log("Camera Shake Ok");
    }

    public void CameraShakesCall()
    {
        if (!shakeControl)
        {
            StartCoroutine(cameraShake(0.22f, 0.4f));
            shakeControl = true;
        }
    }

}//class
