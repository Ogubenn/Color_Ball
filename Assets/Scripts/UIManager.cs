using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image whiteEffect›mg;
    private int effectControl = 0;
    public Player Player;


    [Header("Layout Group Variables")]
    public Animator LayoutAnimator;

    [Header("Buttons")]
    public GameObject settingsOpen;
    public GameObject settingsClose;
    public GameObject soundsOn;
    public GameObject soundsClose;
    public GameObject vibrationOn;
    public GameObject vibrationClose;
    public GameObject ›ap;
    public GameObject info;

    [Header("First Disable Gameobject")]
    public GameObject TouchHand;
    public GameObject TopToMoveText;
    public GameObject shopU˝;
    public GameObject NoadsU˝;


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
    }


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
        NoadsU˝.SetActive(false);
        shopU˝.SetActive(false);
        ›ap.SetActive(false);
        info.SetActive(false);
    }


    #region Button Fonksiyon
    public void Settings_Open()
    {
        settingsOpen.SetActive(false);
        settingsClose.SetActive(true);
        LayoutAnimator.SetTrigger("Slide›n");
        Player.forwordSpeed = 0;
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

        Debug.Log("Slide›n Ok");
    }
    public void Settings_Close()
    {
        settingsOpen.SetActive(true);
        settingsClose.SetActive(false);
        LayoutAnimator.SetTrigger("SlideOut");
        Player.forwordSpeed = Player.BackupForwordSpeed;
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
        whiteEffect›mg.gameObject.SetActive(true);
        while (effectControl == 0)
        {
            yield return new WaitForSeconds(0.001f);
            whiteEffect›mg.color += new Color(0, 0, 0, 0.1f);
            if (whiteEffect›mg.color == new Color(whiteEffect›mg.color.r, whiteEffect›mg.color.g, whiteEffect›mg.color.b, 1))
            {
                Debug.Log("Renk paleti 1'e ulasti");
                effectControl = 1;

            }
        }
        while(effectControl == 1)
        {
            yield return new WaitForSeconds(0.001f);
            whiteEffect›mg.color -= new Color(0, 0, 0, 0.1f);
            if(whiteEffect›mg.color == new Color(whiteEffect›mg.color.r, whiteEffect›mg.color.g, whiteEffect›mg.color.b, 0))
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
