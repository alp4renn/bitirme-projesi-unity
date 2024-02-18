using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picture_canvas : MonoBehaviour
{
    private bool onenter = false; // mouse bu game objeninin �zerinde mi de�il mi diye kontrol edilecek
    [SerializeField] GameObject pictureCanvas; // aktive edilecek olan resim canvas�

    private AudioSource audioSource_;

    public AudioClip pictureSound; // resim a��l�rken �alacak olan ses klibi

    //private bool isFirtTime = true;



    private bool isFirtTimeOpenDoor ; // Resim a��ld��nda ayn� zamanda di�er sahneye ge�i� kap�sada a��lacak. Kap� ilk defa m� a��lacak kontrol boolean'�


    private void Start()
    {
        pictureCanvas.gameObject.SetActive(false);  // resim ba�lang��ta kapal� olsun

        audioSource_ = this.gameObject.GetComponent<AudioSource>();  
        audioSource_.clip = pictureSound; // ses klibi atand�
        
        isFirtTimeOpenDoor = true;
    }
    private void Update()
    {

        

        if (onenter == true && Input.GetMouseButtonDown(0))  // scriptin bulundu�u nesnenin �zerine t�kland���nda resim a��ls�n ve ses klibi �al�ns�n
        {

            audioSource_.Play();
            pictureCanvas.gameObject.SetActive(true);

            

        }
    }

    private void OnMouseEnter()
    {

        onenter = true; // mouse nesnenin i�aretinin �zerinde
    }

    private void OnMouseExit()
    {

        onenter = false;  // mouse nesnenin �zerinde de�il
    }

    public void picture_canvas_pasif()   // resim canvas�n�n i�inde ki panele button komponenti atand� bu panele t�kland���nda canvas kapan�yor
    {

        if (isFirtTimeOpenDoor == true) // sonraki b�l�me ge�i� kap�s� aktive edilsin
        {
            door_open.nextSceneDoorOpen = true;
            isFirtTimeOpenDoor = false;
        }

        pictureCanvas.gameObject.SetActive(false);

    }
}
