using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tip_remove : MonoBehaviour
{

    //  Mankenin elinde papir�s bulunan game objesi a��ld���nda oyuncuya y�n g�stericek olan tip i�areti de a��l�yor.
    // Papir�s ve papir�s ile ba��nt�l� olan a�a� puzzle'� ��z�ld���nde papir�s�n tip i�areti kald�r�ls�n. Bu �ekilde ilgli olan puzzle'� ��zd��� de belli olsun.

    public GameObject papirus;

    private void Update()
    {
        if (papirus.transform.childCount>0)
        {
            Destroy(papirus.transform.GetChild(0).gameObject);
        }
    }
}
