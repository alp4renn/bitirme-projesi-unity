using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anahtar_ve_mendil : MonoBehaviour
{
    
    // Bu scriptte anahtar ve mendil'in kullan�c�ya daha raht g�z�kmesi i�in hareket fizi�i kat�lm��t�r.
    
    public float speed = 1.0f;  // h�z
    private Vector3 startPosition; // ba�lang�� konumu
    
    private Collider2D collider_; // collidor
    public float distance = 2.5f; // mesafe

    private AudioSource audioSource_;
    
    public AudioClip fallingSound;  // nesne b�rak�l�rken ��kan ses klibi
    private bool isFirstTimeSound = true; // ses yaln�zca bir defa �als�n diye boolean �zerinden ko�ul olu�turalacak

    private void Start()
    {
        startPosition = this.gameObject.transform.position;
        collider_ = this.gameObject.GetComponent<Collider2D>();
        collider_.enabled = false; // nesnenin hareket etmesi bitene kadar nesnenin �zerine t�klans�n istenmiyor bu y�zden collider kapal�

        audioSource_ = transform.parent.GetChild(1).gameObject.GetComponent<AudioSource>(); // parent �zerinden ses kilibi �al�anacak ��nk� kendi audio'sunda daha sonra �al�nmak �zere farkl� bir klib var
        audioSource_.clip = fallingSound;  //audio souce kompanentine audio clip atand�
    }

    private void Update()
    {
        if (Mathf.Abs(this.transform.position.y - startPosition.y) <= distance)  // belirlenmi� mesafeye gelene kadar hareket et
        {


            transform.Translate(0, speed * Time.deltaTime, 0); // hareket kodu
        }

        if (Mathf.Abs(this.transform.position.y - startPosition.y) >= distance) // belirlenmi� mesafeye gelindi�inde collider aktif olsun ve ses efekti �al�ns�n
        {
            collider_.enabled = true;
            //StartCoroutine("particle_destroy");

            if (speed < 0 && isFirstTimeSound == true)  //speed < 0 ko�ulunun anlam� anahtar a�a��ya d��ecek ve buradaki sesin yaln�zca anahtarda �al�nmas� isteniyor. 
            {
                audioSource_.Play();
                isFirstTimeSound = false;
            }
        }

        

    }

    
}
