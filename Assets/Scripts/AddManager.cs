using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AddManager : MonoBehaviour
{
    private void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            //Callback

        });
    }
}
