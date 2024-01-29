using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Image whiteEffectÝmg;
    private int effectControl = 0;
    public Player Player;
    public Image FillLevelÝmg;
    public GameObject player;
    public GameObject FinishLine;

    [Header("Layout Group Variables")]
    public Animator LayoutAnimator;

    [Header("Buttons")]
    public GameObject settingsOpen;
    public GameObject settingsClose;
    public GameObject soundsOn;
    public GameObject soundsClose;
    public GameObject vibrationOn;
    public GameObject vibrationClose;
    public GameObject Ýap;
    public GameObject info;
    public GameObject LayoutBackground;

    [Header("First Disable Gameobject")]
    public GameObject TouchHand;
    public GameObject TopToMoveText;
    public GameObject shopUý;
    public GameObject NoadsUý;

    public GameObject RestartButton;
    public Text CoinText;

    [Header("Game Finish Screen")]
    public GameObject finishScreen;
    public GameObject Finishbackground;
    public GameObject FinishCompleted;
    public GameObject FinishRadialShane;
    public GameObject FinishCoin;
    public GameObject FinishRewarded;
    public GameObject FinishNoThanks;
    private bool radianeShane = false;
    public float RadialShaneSpeed = 15f;
    public GameObject AchievedCoin;
    public GameObject NextLevel;
    public Text AchievedcoinText;


    private void Start()
    {
        if(!PlayerPrefs.HasKey("Sound"))
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
        if(!PlayerPrefs.HasKey("Vibration"))
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }

        CoinTextUpdate();
    }


    private void Update()
    {
         if(radianeShane)
        {
            FinishRadialShane.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, RadialShaneSpeed * Time.deltaTime));
        }

        FillLevelÝmg.fillAmount = ((Player.transform.position.z*100) / (FinishLine.transform.position.z))/100; //100 le çarpýp 100e bölmemizin sebebi baþlangýç pozisyonunu gözardý etmek istememiz.
    }


    #region First Touch Funk.
    public void FirtTouch()
    {
        settingsOpen.SetActive(false);
        settingsClose.SetActive(false);
        soundsOn.SetActive(false);
        soundsClose.SetActive(false);
        vibrationClose.SetActive(false);
        vibrationOn.SetActive(false);
        TopToMoveText.SetActive(false);
        TouchHand.SetActive(false);
        NoadsUý.SetActive(false);
        shopUý.SetActive(false);
        Ýap.SetActive(false);
        info.SetActive(false);
        LayoutBackground.SetActive(false);
    }
    #endregion

    #region Coin Text Funk.
    public void CoinTextUpdate()
    {
        CoinText.text = PlayerPrefs.GetInt("Coinn").ToString();
    }
    #endregion

    #region Restart Funk.

    public void RestartButtonActive()
    {
        RestartButton.SetActive(true);
    }

    public void RestartSceene()
    {
        Variables.firtTouch = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }

    public void NextSceene()
    {
        Variables.firtTouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    #endregion

    #region Button Fonksiyon
    public void Settings_Open()
    {
        settingsOpen.SetActive(false);
        settingsClose.SetActive(true);
        LayoutAnimator.SetTrigger("SlideÝn");
        if(PlayerPrefs.GetInt("Sound") == 1)
        {
            soundsOn.SetActive(true);
            soundsClose.SetActive(false);
            AudioListener.volume = 1;
        }
        else if(PlayerPrefs.GetInt("Sound") == 2)
        {
            soundsClose.SetActive(true);
            soundsOn.SetActive(false);
            AudioListener.volume = 0;
        }
        if(PlayerPrefs.GetInt("Vibration") == 1)
        {
            vibrationOn.SetActive(true);
            vibrationClose.SetActive(false);
        }
        else if(PlayerPrefs.GetInt("Vibration") == 2)
        {
            vibrationOn.SetActive(false);
            vibrationClose.SetActive(true);
        }

        Debug.Log("SlideÝn Ok");
    }
    public void Settings_Close()
    {
        settingsOpen.SetActive(true);
        settingsClose.SetActive(false);
        LayoutAnimator.SetTrigger("SlideOut");
        Debug.Log("SlideOut Ok");
    }

    public void Sound_On()
    {
        soundsOn.SetActive(false);
        soundsClose.SetActive(true);
        Debug.Log("Sounds On");
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
    } 
    public void Sound_Close()
    {
        soundsOn.SetActive(true);
        soundsClose.SetActive(false);
        Debug.Log("Sounds Close");
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }
    public void Vibration_On()
    {
        vibrationOn.SetActive(false);
        vibrationClose.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 2);
        Debug.Log("Vibration On");
    }
    public void Vibration_Off()
    {
        vibrationOn.SetActive(true);
        vibrationClose.SetActive(false);
        PlayerPrefs.SetInt("Vibration", 1);
        Debug.Log("Vibration Off");
    }

    public void FinishScreen()
    {
        StartCoroutine("FinishLaunch");
    }
    

    public IEnumerator FinishLaunch()
    {
        Time.timeScale = 0.5f;
        radianeShane = true;
        finishScreen.SetActive(true);
        Finishbackground.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);
        FinishCompleted.SetActive(true);
        yield return new WaitForSecondsRealtime(1.3f);
        FinishCoin.SetActive(true);
        FinishRadialShane.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);
        FinishRewarded.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        FinishNoThanks.SetActive(true);
    }

    public IEnumerator AfterRewardButton()
    {
        AchievedCoin.SetActive(true);
        AchievedcoinText.gameObject.SetActive(true);
        FinishRewarded.SetActive(false);
        FinishNoThanks.SetActive(false);
        for (int i = 0; i <= 400; i += 4)
        {
            AchievedcoinText.text = "+" + i.ToString();
            yield return new WaitForSeconds(0.0001f);
        }  
        yield return new WaitForSecondsRealtime(1f);
        NextLevel.SetActive(true);



    }




    public void PrivacyPolicy()
    {
        Application.OpenURL("https://ogubenn.com.tr/");
    }
    public void TermOfUse()
    {
        Application.OpenURL("https://ogubenn.com.tr/");
    }

    #endregion




    #region White Effect Damage
    public IEnumerator WhiteEffect()
    {
        whiteEffectÝmg.gameObject.SetActive(true);
        while (effectControl == 0)
        {
            yield return new WaitForSeconds(0.001f);
            whiteEffectÝmg.color += new Color(0, 0, 0, 0.1f);
            if (whiteEffectÝmg.color == new Color(whiteEffectÝmg.color.r, whiteEffectÝmg.color.g, whiteEffectÝmg.color.b, 1))
            {
                Debug.Log("Renk paleti 1'e ulasti");
                effectControl = 1;

            }
        }
        while(effectControl == 1)
        {
            yield return new WaitForSeconds(0.001f);
            whiteEffectÝmg.color -= new Color(0, 0, 0, 0.1f);
            if(whiteEffectÝmg.color == new Color(whiteEffectÝmg.color.r, whiteEffectÝmg.color.g, whiteEffectÝmg.color.b, 0))
            {
                effectControl = 2;
            }
        }

        if(effectControl == 2)
        {
            Debug.Log("White effect bitti");
        }
    }
    #endregion


}//class
