using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBanner : MonoBehaviour
{
    private static SingletonBanner obje = null;

    private void Awake()
    {
        if(!obje)
        {
            obje = this;
            DontDestroyOnLoad(this); //*
        }
        else if(this != obje)
        {
            Destroy(gameObject);
        }
    }


}//class