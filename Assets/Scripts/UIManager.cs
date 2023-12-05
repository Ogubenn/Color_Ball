using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Range(0.0001f,0.001f)]
    public float WhiteEffectTimer = 0.001f; //Beyaz efektin s¸resi


    [SerializeField] Image WhiteScreen›mg;
    private bool WhiteEffectControl = false;

    public IEnumerator WhiteScreen()
    {
        Debug.Log("Test Courutine ok");
        WhiteScreen›mg.gameObject.SetActive(true);

        while (!WhiteEffectControl)
        {
            Debug.Log("Test While 1/2 ok");
            yield return new WaitForSeconds(WhiteEffectTimer);
            WhiteScreen›mg.color += new Color(0, 0, 0, 0.1f);
            if (WhiteScreen›mg.color == new Color(WhiteScreen›mg.color.r, WhiteScreen›mg.color.g, WhiteScreen›mg.color.b, 1))
            {
                Debug.Log("White effect test ok 1/2");
                WhiteEffectControl = true;
            }

        }

        while (WhiteEffectControl)
        {
            Debug.Log("Test While 2/2 ok");
            yield return new WaitForSeconds(WhiteEffectTimer);
            WhiteScreen›mg.color -= new Color(0, 0, 0, 0.1f);
            if(WhiteScreen›mg.color == new Color(WhiteScreen›mg.color.r, WhiteScreen›mg.color.g, WhiteScreen›mg.color.b, 0))
            {
                Debug.Log("White effect test ok 2/2");
                WhiteEffectControl = false;

            }
        }

    }



}//class
