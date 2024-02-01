using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource buttonSource;
    public AudioSource blowUpSource;
    public AudioSource cashSource;
    public AudioSource completeSource;
    public AudioSource obejctHitSource;

    [Header("Audio Clip")]
    public AudioClip buttonClip;
    public AudioClip blowUpClip;
    public AudioClip cashClip;
    public AudioClip completeClip;
    public AudioClip objectHitClip;

    public void ButtonSound()
    {
        buttonSource.PlayOneShot(buttonClip);
    }

    public void BlowUpSound()
    {
        buttonSource.PlayOneShot(blowUpClip,0.4f);
    }
    public void CashSound()
    {
        buttonSource.PlayOneShot(cashClip);
    }
    public void ObjectHitSound()
    {
        buttonSource.PlayOneShot(objectHitClip);
    }
    public void CompleteSound()
    {
        buttonSource.PlayOneShot(completeClip);
    }
}
