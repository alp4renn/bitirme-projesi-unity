using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obje_saklama : MonoBehaviour
{

    private bool onenter = false; //mouse nesnenin �zerinde mi
    private bool isFirstTimeTouched = true; // ilk defa m� bu nesneye t�klanacak

   
        
    private void Update()
    {
        // nesnenin �zerine t�kland���nda bu nesne pasif hale gelsin ama karde� objeleri aktif olsun kodlar�:
       if (onenter == true && isFirstTimeTouched == true && Input.GetMouseButtonDown(0))
       {
            
           isFirstTimeTouched = false;
       
           if (this.gameObject.transform.parent.childCount> 0)   // bu nesnenin ebeveyn objesinin i�erisinde objeler varsa �al��s�n komutu
            {
               
               for (int i = 1; i < this.gameObject.transform.parent.childCount-1; i++)
               {
                   //Destroy(this.gameObject.transform.GetChild(0).gameObject);
                   this.gameObject.transform.parent.GetChild(i).gameObject.SetActive(true); // objeleri aktif hale getir
               }


       
           }
            Destroy(this.gameObject.transform.parent.GetChild(this.gameObject.transform.parent.childCount-1).gameObject); // ipucu i�aretini sil
                                                                                                  // Not: ipucu i�areti ebeveny objesinin son �ocu�u
            this.gameObject.SetActive(false); // bu objeyi pasif hale getir
        }
    }


    private void OnMouseEnter()
    {

        onenter = true; // mouse nesnenin �zerinde
    }

    private void OnMouseExit()
    {

        onenter = false; // mouse nesnenin �zerinde de�il
    }
}

