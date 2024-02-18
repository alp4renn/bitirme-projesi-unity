using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_mechanics : MonoBehaviour
{
    public GameObject[] trees; // a�a� objeleri konulacak bu array'e
    public bool[] isTargetPlacesTrue; // a�a� objelerinin do�ru yere konuldu�unu teyit etmesi i�in position'lar� kullan�lacak olan nesneler
    
    private tip_remove tipRemove; // Bu puzzle ��z�ld���nde bu puzzle'�n ��z�lmesi hakk�nda ipucu veren papir�s�n tip i�areti kald�r�ls�n

    public static bool isHeartTreeBroke = false; // Bu puzzle ��z�ld���nde kalp �eklinde ki a�a� k�r�lacak ve arkas�ndaki asans��r d��mesi ortaya ��kacak.
                                                 //  Bu puzzle'�n ��z�l�p heart tree'nin k�r�l�p k�r�lmayaca��n� ba�ka bir scripte bildiren static boolean de�eri

    private void Awake()
    {
        

        tipRemove = this.gameObject.GetComponent<tip_remove>();
        tipRemove.enabled = false;

        for (int i = 0; i <= trees.Length - 1; i++) // Papir�s a��lana kadar bu a�a�larla etkile�ime ge�ilememesi i�in collider'lar� kapatma
        {
            trees[i].GetComponent<Collider2D>().enabled = false;
            isTargetPlacesTrue[i] = false;
        }
        isHeartTreeBroke = false;

    }

    private void Update()
    {
        if (isTargetPlacesTrue[0] == true && isTargetPlacesTrue[1] == true && isTargetPlacesTrue[2] == true) // t�m a�a�lar�n yerleri do�rumu
        {
            for(int i =0; i<=isTargetPlacesTrue.Length-1; i++)
            {
                this.gameObject.transform.GetChild(i).gameObject.GetComponent<tree_mechanics2>().enabled = false; // a�a�lar� hareket kodlar�n�n buludnu�u scripti kapatma
                Destroy(this.gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject); // her a�ac�n tip i�aretini kald�rma

                
                this.gameObject.transform.GetChild(i).gameObject.tag = "Untagged"; // mouse imleci a�a�lar�n �zerine geldi�inde de�i�memesi i�in a�a�lar�n tag'�n� de�i�tiren kodlar
            }

            
            tipRemove.enabled = true; // papir�s�n tip i�aretini kald�ran scripti aktvive etme
            isHeartTreeBroke = true; ; // heart tree nin k�r�lmas� i�in boolean ko�ulunu de�i�tirme
        }
    }
}
