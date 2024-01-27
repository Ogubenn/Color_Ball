using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int StageFinishCoin = 100; // Testten sonra private yap
    public UIManager uiManager;

    public void Start()
    {
        CoinCalculator(0);
        Debug.Log(PlayerPrefs.GetInt("Coinn"));
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && gameObject.CompareTag("FinishLine"))
        {
            Debug.Log("Level bitti");
            CoinCalculator(StageFinishCoin);
            uiManager.CoinTextUpdate();
            uiManager.FinishScreen();
            
        }
    }

    public void CoinCalculator(int coin)
    {
        if (PlayerPrefs.HasKey("Coinn"))
        {
            int oldScore = PlayerPrefs.GetInt("Coinn");
            PlayerPrefs.SetInt("Coinn", oldScore + coin);
        }

        else
            PlayerPrefs.SetInt("Coinn", 0);
    }


    //Oncollison metodu h�zl� �ekilde kulland���m�z zaman orta �l�ekli cihazlar bunu alg�layamabilir.Onun i�in trigger metodu daha mant�kl�d�r trigger her zaman �al���r ve daha sa�l�kl�d�r.Fizik i�lemini kullanmak istiyosak collison daha mant�kl�d�r.
}//class
