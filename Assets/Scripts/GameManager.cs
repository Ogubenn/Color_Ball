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


    //Oncollison metodu hýzlý þekilde kullandýðýmýz zaman orta ölçekli cihazlar bunu algýlayamabilir.Onun için trigger metodu daha mantýklýdýr trigger her zaman çalýþýr ve daha saðlýklýdýr.Fizik iþlemini kullanmak istiyosak collison daha mantýklýdýr.
}//class
