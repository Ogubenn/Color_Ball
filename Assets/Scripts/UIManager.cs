using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image whiteEffect›mg;
    private int effectControl = 0;

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


}//class
