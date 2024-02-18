using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hider_objects : MonoBehaviour
{
    public float x = 0; // nesnenin x ekseninde kayma miktar�
    public float y = 0;  // nesnenin y ekseninde kayma miktar�


    private bool onenter = false; // mouse nesnenin �zerinde mi
    public GameObject saklanan_nesne; // saklanacak olan nesne

    private bool isFirstTimeTouched=true; // bu nesneye ilk defa m� t�klanacak 

    private void Awake()
    {
        //saklanan_nesne =GameObject.GetComponent<Collider2D>();
        //saklanan_nesne.gameObject.GetComponent<Collider2D>().enabled = false;

        saklanan_nesne.gameObject.SetActive(false); // saklanan nesneyi pasif hale getirme buglardan ka��nmak i�in
    }

    private void Update()
    {
     
        // Nesnenin �zerine t�kland���nda nesne yana kays�n ve etkile�imli nesne olmaktan ��ks�n. Ayr�ca saklanan nesne aktif hale gelsin kodlar�:
        if(onenter ==true && isFirstTimeTouched == true && Input.GetMouseButtonDown(0))
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + x, this.gameObject.transform.position.y + y, this.gameObject.transform.position.z);

            //saklanan_nesne.gameObject.GetComponent<Collider2D>().enabled = true;
            saklanan_nesne.gameObject.SetActive(true); //saklanan nesne aktif hale gelsin

            isFirstTimeTouched = false;

            this.gameObject.GetComponent<mouse_effect>().enabled = false; /// etkile�imli nesne olmaktan ��karma
            this.gameObject.tag = "Untagged";

            if (this.gameObject.transform.childCount == 1)   // Game objenin i�indeki ipucu i�aretlerini silme
            {
                
                Destroy(this.gameObject.transform.GetChild(0).gameObject);
               
            }
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
