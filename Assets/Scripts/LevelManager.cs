using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI LoadingText;


    public void Start()
    {
        if(PlayerPrefs.HasKey("LevelIndex") == false)
        {
            PlayerPrefs.SetInt("LevelIndex", 1);
        }
        StartCoroutine("LoadingBar");
        LevelControl();
    }


    public void LevelControl()
    {
        int Level = PlayerPrefs.GetInt("LevelIndex");
        SceneManager.LoadSceneAsync(Level);
            //Çalýþýlacak async
    }


    public IEnumerator LoadingBar()
    {
        while(true)
        {
            LoadingText.text = "Loading".ToString();
            yield return new WaitForSecondsRealtime(0.5f);
            LoadingText.text = "Loading.".ToString();
            yield return new WaitForSecondsRealtime(0.5f);
            LoadingText.text = "Loading..".ToString();
            yield return new WaitForSecondsRealtime(0.5f);
            LoadingText.text = "Loading...".ToString();
        }
    }


}//class

