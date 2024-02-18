using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left_move : MonoBehaviour
{
    
    public static bool onenter=false; //mouse nesnenin �zerinde mi
    public int speed = 12; // h�z
    public SpriteRenderer sr;
    public Color redish; //ok tu�una bas�ld���nda ok tu�unun alaca�� renk
    

    public static bool isLeftMove = false; // hareket ediyor mu
    public static float leftMovement; // hareket miktari

    
    public GameObject leftWall;    // kameran�n sola gitmesini engelleyecek olan engel

    public static float leftArrowPosition; // okun pozisyonu
    public static float leftWallPosition; // duvar�n pozisyonu

    public float normalSize = 3f;
    public float onPressSize = 4.5f;

    private float widht; // duvar�n(engelin) geni�li�i

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>(); // belle�e alma
        

        widht = leftWall.GetComponent<Collider2D>().bounds.size.x; // duvar�n geni�li�ini atama
    }

    private void Update()
    {

        leftArrowPosition = this.gameObject.transform.position.x; // okun pozisyonunu atama
        leftWallPosition = leftWall.transform.position.x + widht/2; // duvar�n okla etkile�ime ge�ti�i pozisyonu atama


        // oka bas�ld���nda sol tarafa hareket etsin
        if (onenter==true && Input.GetMouseButton(0) && this.gameObject.transform.position.x > leftWall.transform.position.x + widht / 2)
        {
            leftMovement = (-1 * speed * Time.deltaTime); // hareket miktar�n� hesapla

            // karakterin ve kameran�n yeni pozisyonunu atama:  
            gameObject.transform.parent.transform.position = new Vector3(gameObject.transform.parent.transform.position.x + leftMovement, gameObject.transform.parent.transform.position.y);
            
            sr.color = redish; // oka bas�l� tutuldu�unda rengi de�i�sin
            isLeftMove = true; // sol tarafa hareket ediyor
        }
        else //if(Input.GetMouseButtonUp(0)) // mouse tu�una bas�lma kesildi�inde
        {
            sr.color = Color.white; // okun rengi eski haline d�ns�n
            isLeftMove = false; // hareket etmiyor
        }


        
    }
    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(onPressSize, onPressSize, 1); // mouse ok �zerindeyken ok b�y�s�n
        onenter = true; // mouse ok i�aretinin �zerinde
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(normalSize, normalSize, 1); // mouse ok �zerinde de�ilken eski boyutunda olsun
        onenter = false; // mouse ok �zerinde de�il
    }

    

}

