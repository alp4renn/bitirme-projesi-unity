using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resim : MonoBehaviour
{
    private bool isFirstTime = true; // ilk defa m� bu nesneye t�klanacak
    public static bool pictureOpened = false;  // ba�ka bir scriptte resimin a��ld���n� haber almak i�in static bool olu�turldu

    private void Start()
    {
        pictureOpened = false;
    }
    private void Update()
    {
        // nesnenin �zerine t�kland���nda bu nesne pasif hale gelsin ama karde� objeleri aktif olsun kodlar�:
        if (isFirstTime == true && pictureOpened == true)
        {

            isFirstTime = false;

            if (this.gameObject.transform.parent.childCount > 0)   // bu nesnenin ebeveyn objesinin i�erisinde objeler varsa �al��s�n komutu
            {

                for (int i = 1; i < this.gameObject.transform.parent.childCount - 1; i++)
                {
                    
                    this.gameObject.transform.parent.GetChild(i).gameObject.SetActive(true); // objeleri aktif hale getir
                }



            }
            Destroy(this.gameObject.transform.parent.GetChild(this.gameObject.transform.parent.childCount - 1).gameObject); // ipucu i�aretini sil
                                                                                                                            // Not: ipucu i�areti ebeveny objesinin son �ocu�u
            this.gameObject.SetActive(false); // bu objeyi pasif hale getir
        }
    }
}
