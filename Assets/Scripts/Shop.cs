using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public UIManager uimanager;


    [Header("Particles")]
    public GameObject Particle1;
    public GameObject Particle2;
    public GameObject Particle3;
    public GameObject Particle4;
    public GameObject Particle5;
    public GameObject Particle6;
    public GameObject Particle7;

    [Header("Particle Background ›mage")]
    public Sprite Green›mage;
    public Sprite Yellow›mage;

    [Header("Shop Button Background Color")]
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    public GameObject Item5;
    public GameObject Item6;

    [Header("Items Money")]
    public int Item1Money;
    public int Item2Money;
    public int Item3Money;
    public int Item4Money;
    public int Item5Money;
    public int Item6Money;

    [Header("Locks")]
    public GameObject Lock1;
    public GameObject Lock2;
    public GameObject Lock3;
    public GameObject Lock4;
    public GameObject Lock5;


    public void Start()
    {
        if (PlayerPrefs.HasKey("Lock1Control") == false)
            PlayerPrefs.SetInt("Lock1Control", 0);

        if (PlayerPrefs.HasKey("Lock2Control") == false )
            PlayerPrefs.SetInt("Lock2Control", 0);

        if (PlayerPrefs.HasKey("Lock3Control") == false)
            PlayerPrefs.SetInt("Lock3Control", 0);

        if (PlayerPrefs.HasKey("Lock4Control") == false)
            PlayerPrefs.SetInt("Lock4Control", 0);

        if (PlayerPrefs.HasKey("Lock5Control") == false)
            PlayerPrefs.SetInt("Lock5Control", 0);

        if (PlayerPrefs.GetInt("Lock1Control") == 1)
            Lock1.SetActive(false);

        if (PlayerPrefs.GetInt("Lock2Control") == 1)
            Lock2.SetActive(false);

        if (PlayerPrefs.GetInt("Lock3Control") == 1)
            Lock3.SetActive(false);

        if (PlayerPrefs.GetInt("Lock4Control") == 1)
            Lock4.SetActive(false);

        if (PlayerPrefs.GetInt("Lock5Control") == 1)
            Lock5.SetActive(false);
    }

    public void Awake()
    {
        if (PlayerPrefs.HasKey("ItemSelect") == false)
            PlayerPrefs.SetInt("ItemSelect", 0);

        if (PlayerPrefs.GetInt("ItemSelect") == 0)
            Item1Open();

        else if (PlayerPrefs.GetInt("ItemSelect") == 1)
            Item2Open();

        else if (PlayerPrefs.GetInt("ItemSelect") == 2)
            Item3Open();

        else if (PlayerPrefs.GetInt("ItemSelect") == 3)
            Item4Open();

        else if (PlayerPrefs.GetInt("ItemSelect") == 4)
            Item5Open();

        else if (PlayerPrefs.GetInt("ItemSelect") == 5)
            Item6Open();
    }


    #region Item Open

    public void Item1Open()
    {
        Particle1.SetActive(true);
        Particle2.SetActive(false);
        Particle3.SetActive(false);
        Particle4.SetActive(false);
        Particle5.SetActive(false);
        Particle6.SetActive(false);
        Particle7.SetActive(false);

        Item1.GetComponent<Image>().sprite = Green›mage;
        Item2.GetComponent<Image>().sprite = Yellow›mage;
        Item3.GetComponent<Image>().sprite = Yellow›mage;
        Item4.GetComponent<Image>().sprite = Yellow›mage;
        Item5.GetComponent<Image>().sprite = Yellow›mage;
        Item6.GetComponent<Image>().sprite = Yellow›mage;

        PlayerPrefs.SetInt("ItemSelect", 0);
    }
    public void Item2Open()
    {
        Particle1.SetActive(false);
        Particle2.SetActive(true);
        Particle3.SetActive(false);
        Particle4.SetActive(false);
        Particle5.SetActive(false);
        Particle6.SetActive(false);
        Particle7.SetActive(false);

        Item2.GetComponent<Image>().sprite = Green›mage;
        Item1.GetComponent<Image>().sprite = Yellow›mage;
        Item3.GetComponent<Image>().sprite = Yellow›mage;
        Item4.GetComponent<Image>().sprite = Yellow›mage;
        Item5.GetComponent<Image>().sprite = Yellow›mage;
        Item6.GetComponent<Image>().sprite = Yellow›mage;

        PlayerPrefs.SetInt("ItemSelect", 1);
    }
    public void Item3Open()
    {
        Particle1.SetActive(false);
        Particle2.SetActive(false);
        Particle3.SetActive(true);
        Particle4.SetActive(false);
        Particle5.SetActive(false);
        Particle6.SetActive(false);
        Particle7.SetActive(false);

        Item3.GetComponent<Image>().sprite = Green›mage;
        Item1.GetComponent<Image>().sprite = Yellow›mage;
        Item2.GetComponent<Image>().sprite = Yellow›mage;
        Item4.GetComponent<Image>().sprite = Yellow›mage;
        Item5.GetComponent<Image>().sprite = Yellow›mage;
        Item6.GetComponent<Image>().sprite = Yellow›mage;

        PlayerPrefs.SetInt("ItemSelect", 2);
    }
    public void Item4Open()
    {
        Particle1.SetActive(false);
        Particle2.SetActive(false);
        Particle3.SetActive(false);
        Particle4.SetActive(true);
        Particle5.SetActive(false);
        Particle6.SetActive(false);
        Particle7.SetActive(false);

        Item4.GetComponent<Image>().sprite = Green›mage;
        Item1.GetComponent<Image>().sprite = Yellow›mage;
        Item3.GetComponent<Image>().sprite = Yellow›mage;
        Item2.GetComponent<Image>().sprite = Yellow›mage;
        Item5.GetComponent<Image>().sprite = Yellow›mage;
        Item6.GetComponent<Image>().sprite = Yellow›mage;

        PlayerPrefs.SetInt("ItemSelect", 3);
    }
    public void Item5Open()
    {
        Particle1.SetActive(false);
        Particle2.SetActive(false);
        Particle3.SetActive(false);
        Particle4.SetActive(false);
        Particle5.SetActive(true);
        Particle6.SetActive(false);
        Particle7.SetActive(false);

        Item5.GetComponent<Image>().sprite = Green›mage;
        Item1.GetComponent<Image>().sprite = Yellow›mage;
        Item3.GetComponent<Image>().sprite = Yellow›mage;
        Item4.GetComponent<Image>().sprite = Yellow›mage;
        Item2.GetComponent<Image>().sprite = Yellow›mage;
        Item6.GetComponent<Image>().sprite = Yellow›mage;

        PlayerPrefs.SetInt("ItemSelect", 4);
    }
    public void Item6Open()
    {
        Particle1.SetActive(false);
        Particle2.SetActive(false);
        Particle3.SetActive(false);
        Particle4.SetActive(false);
        Particle5.SetActive(false);
        Particle6.SetActive(true);
        Particle7.SetActive(false);

        Item6.GetComponent<Image>().sprite = Green›mage;
        Item1.GetComponent<Image>().sprite = Yellow›mage;
        Item3.GetComponent<Image>().sprite = Yellow›mage;
        Item4.GetComponent<Image>().sprite = Yellow›mage;
        Item5.GetComponent<Image>().sprite = Yellow›mage;
        Item2.GetComponent<Image>().sprite = Yellow›mage;

        PlayerPrefs.SetInt("ItemSelect", 5);
    }

    #endregion

    #region Lock Fonk.

    #region Lock1
    public void Lock1Open()
    {
        int money = PlayerPrefs.GetInt("Coinn");
        int lock1Control = PlayerPrefs.GetInt("Lock1Control");
        if(money >= Item1Money && lock1Control == 0)
        {
            Lock1.SetActive(false);
            PlayerPrefs.SetInt("Coinn", money - Item1Money);
            PlayerPrefs.SetInt("Lock1Control", 1);
            Item2Open();
            uimanager.CoinTextUpdate();
        }
    }
    #endregion

    #region Lock2
    public void Lock2Open()
    {
        int money = PlayerPrefs.GetInt("Coinn");
        int lock2Control = PlayerPrefs.GetInt("Lock2Control");
        if (money >= Item2Money && lock2Control == 0)
        {
            Lock2.SetActive(false);
            PlayerPrefs.SetInt("Coinn", money - Item2Money);
            PlayerPrefs.SetInt("Lock2Control", 1);
            Item3Open();
            uimanager.CoinTextUpdate();
        }
    }
    #endregion

    #region Lock3
    public void Lock3Open()
    {
        int money = PlayerPrefs.GetInt("Coinn");
        int lock3Control = PlayerPrefs.GetInt("Lock3Control");
        if (money >= Item3Money && lock3Control == 0)
        {
            Lock3.SetActive(false);
            PlayerPrefs.SetInt("Coinn", money - Item3Money);
            PlayerPrefs.SetInt("Lock3Control", 1);
            Item4Open();
            uimanager.CoinTextUpdate();
        }
    }
    #endregion

    #region Lock4
    public void Lock4Open()
    {
        int money = PlayerPrefs.GetInt("Coinn");
        int lock4Control = PlayerPrefs.GetInt("Lock4Control");
        if (money >= Item4Money && lock4Control == 0)
        {
            Lock4.SetActive(false);
            PlayerPrefs.SetInt("Coinn", money - Item4Money);
            PlayerPrefs.SetInt("Lock4Control", 1);
            Item5Open();
            uimanager.CoinTextUpdate();
        }
    }
    #endregion

    #region Lock5
    public void Lock5Open()
    {
        int money = PlayerPrefs.GetInt("Coinn");
        int lock5Control = PlayerPrefs.GetInt("Lock5Control");
        if (money >= Item5Money && lock5Control == 0)
        {
            Lock5.SetActive(false);
            PlayerPrefs.SetInt("Coinn", money - Item5Money);
            PlayerPrefs.SetInt("Lock5Control", 1);
            Item6Open();
            uimanager.CoinTextUpdate();
        }
    }
    #endregion




    #endregion



}//class
