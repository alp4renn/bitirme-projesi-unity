using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pool_button : MonoBehaviour
{
    
    // havuzdan asans�r d��mesi y�kselerek ��kmas� i�in yazd�lan kodlar
    
    
    private float speed = 1.5f; // h�z
    private Vector3 startPosition; // ba�lang�� pozisyonu
    private ParticleSystem ps;   // oynat�calak particle systemin komponentinin atanacak variable
    private Collider2D collider_; 
    public float distance = 2.5f; // asans�r d��mesinin yukaru y�kselme miktar�

    private void Start()
    {
        startPosition = this.gameObject.transform.position;
        collider_ = this.gameObject.GetComponent<Collider2D>();
        collider_.enabled = false; // asans�r d��mesi en y�ksek mesafeye ula�ana kadar �zerine dokunulmas�n yani envantere al�nmas�n
    }

    private void Update()
    {
        if (Mathf.Abs(this.transform.position.y - startPosition.y) <= distance)  // d��me istenilen mesafeyi kat edene kadar hareket etsin
        {


            transform.Translate(0, speed * Time.deltaTime, 0);   
        }

        if (Mathf.Abs(this.transform.position.y - startPosition.y) >= distance)  // belirlenmi� mesafeye gelindi�inde collider aktif olsun ve particle efekt oynas�n
        {
            collider_.enabled = true;
            StartCoroutine("particle_destroy"); // Particle efekt loop i�inde obje envantere girdi�inde de oynamamas� i�in particle efekti pasif hale getericek
                                                // fonksiyonun �al��t�r�lmas�
        }
        
        
    }

    IEnumerator particle_destroy()
    {
        if (this.gameObject.transform.childCount > 0)
        {
            for(int i =0; i<= this.gameObject.transform.childCount-1; i++)
            {
                if(this.gameObject.transform.GetChild(i).gameObject.tag == "loop particle")  // pasif hale gelecek olan particle'�n bulunmas�
                {
                    ps = this.gameObject.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
                    var main = ps.main;

                    

                    yield return new WaitForSeconds(1); // Particle efekt, asans�r d��mesi en y�kse�e gelsede 1 saniye daha oynas�n bu �ekilde daha g�zel g�z�k�yor
                                                        // Bu y�zden update fonksiyonu i�inde de�ilde IEnumerator i�inde pasif hale getirme i�lemi yap�ld�

                    //Destroy(this.gameObject.transform.GetChild(i).gameObject);
                    
                    main.loop = false; // particle'�n loop'tan ��kar�lmas�

                    this.gameObject.GetComponent<pool_button>().enabled = false;
                    break;
                }
            }
        }
    }
}
