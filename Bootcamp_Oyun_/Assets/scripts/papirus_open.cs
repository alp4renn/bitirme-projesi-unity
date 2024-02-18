using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class papirus_open : MonoBehaviour
{

    private bool onenter = false; // mouse bu game objeninin �zerinde mi de�il mi diye kontrol edilecek
    [SerializeField] GameObject papirusCanvas; // aktive edilecek olan papirus canvas

    private AudioSource audioSource_;

    public AudioClip paperSound; // papirus a��l�rken �alacak olan ses klibi

    

    private void Start()
    {
        papirusCanvas.gameObject.SetActive(false); // papirus ba�lang��ta kapal� olsun

        audioSource_ = this.gameObject.GetComponent<AudioSource>();  
        audioSource_.clip = paperSound; // ses klibi atama

        
    }
    private void Update()
    {

        

        if (onenter==true && Input.GetMouseButtonDown(0)) // scriptin bulundu�u nesnenin �zerine t�kland���nda papirus a��ls�n ve ses klibi �al�ns�n
        {
            
            audioSource_.Play();
            papirusCanvas.gameObject.SetActive(true);
            
        }
    }

    private void OnMouseEnter()
    {
        
        onenter = true; // mouse nesnenin  �zerinde
    }

    private void OnMouseExit()
    {
        
        onenter = false;  // mouse nesnenin �zerinde de�il
    }

    public void papirus_canvas_pasif() // papirus canvas�n i�inde ki panele button komponenti atand� bu panele t�kland���nda canvas kapan�yor
    {
        papirusCanvas.gameObject.SetActive(false);
    }
}
