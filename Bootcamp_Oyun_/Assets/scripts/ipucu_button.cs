using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ipucu_button : MonoBehaviour
{
    
    public GameObject[] tips_image; // tips imagelerinin inspector da atanmas� i�in public game object dizisi olu�turuldu
    
    private bool onenter = false; // mouse tips butonunun �st�nde mi
    public float normalSize = 4f;
    public float onPressSize = 5.5f;
    

    private void Update()
    {
        
        // E�er mosue tips butonunnun �st�nde ve bas�l�ysa sahnedeki tips i�aretlerini g�ster
        if (onenter && Input.GetMouseButton(0))
        {
            for(int i =0; i<=tips_image.Length-1; i++)
            {
                
                if(tips_image[i] != null) // nesneler targetlere kondu�u zaman tips i�aterleri siliniyor.
                                          // D�ng�de hata almamak i�in if ko�ulu kondu ve null de�ilse �art� eklendi
                {
                    tips_image[i].SetActive(true);
                }
            }
        }

        // mouse bas�lmad��� zaman tips i�aretleri pasif halde kals�n kodlar�:
        else if (Input.GetMouseButtonUp(0))
        {
            for (int i = 0; i <= tips_image.Length - 1; i++)
            {
                
                if (tips_image[i] != null)// nesneler targetlere kondu�u zaman tips i�aterleri siliniyor.
                                          // D�ng�de hata almamak i�in if ko�ulu kondu ve null de�ilse �art� eklendi
                {
                    tips_image[i].SetActive(false);
                }
            }
        }
    }
    
    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(onPressSize, onPressSize, 1);  // mouse tips butonunun �zerindeyken buton b�y�s�n
        onenter = true; // mouse tips butonunun �st�nde
    }
    
    private void OnMouseExit()
    {
        transform.localScale = new Vector3(normalSize, normalSize, 1); // mouse tips butonunun �zerinde de�ilken buton eski haline d�ns�n
        onenter = false;  // mouse tips butonunun �st�nde de�il
    }
}
