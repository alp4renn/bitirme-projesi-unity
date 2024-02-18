using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_mechanics2 : MonoBehaviour
{
    public GameObject treesParentObject; // a�a�lar�n parent objesi
    public GameObject targetPlace; // a�ac�n varmas� gerekn do�ru konuml

    private tree_mechanics trees_mech;
    private bool onenter = false; // mouse a�ac�n �zerinde mi de�il mi kontrol boolean'�

    private int a; // a�a�lar�n ebevyn obesi i�inde array tan�ml� ve bu a�a�larda o arrayin i�inde tan�ml�. Bu hareket kodunda array i�inde de hareket edicekler.
                   // array i�inde hareket etmesine yard�mc� olacak bir variable tan�mlan�r
    private Vector3 startPosition; // a�ac�n ba�lang�� pozisyonu
    private GameObject nextTree; // a�ac�n array i�inde hareket ederken yer de�i�tirece�i di�er a�a�


    private AudioSource audioSource_;

    public AudioClip movingSound; // 

    private void Start()
    {
        trees_mech = treesParentObject.GetComponent<tree_mechanics>(); // scriptin variable olarak atanmas�
        audioSource_ = this.gameObject.GetComponent<AudioSource>();  
        audioSource_.clip = movingSound; //  ses klibi atand�
    }

    private void Update()
    {
        //startPosition = this.gameObject.transform.position;

        for (int i = 0; i <= trees_mech.trees.Length - 1; i++) // bu a�a� objesi array'in ka��nc� eleman�
        {
            if (this.gameObject.transform.position == trees_mech.trees[i].transform.position)
            {
                a = i;
            }
        }

        if (onenter == true && Input.GetMouseButtonDown(0)) // a�ac�n �zerine t�klad���nda yer de�i�tir
        {
            move();
            audioSource_.Play();
        }

        if (Mathf.Abs(this.transform.position.x - targetPlace.transform.position.x) <= 0.5f &&
                Mathf.Abs(this.transform.position.y - targetPlace.transform.position.y) <= 0.5f) // a�a� do�ru konumda ise do�ru konumda oldu�unu boolean olatak bildir
        {

            trees_mech.isTargetPlacesTrue[a] = true;
            Debug.Log("trees_mech.isTargetPlacesTrue[a] = true");
        }
        else 
        {
            trees_mech.isTargetPlacesTrue[a] = false; // // a�a� do�ru konumda ise do�ru konumda de�ilse boolean olatak bildir
        }

    }

    public void move() // a�a�lar�n hareket kodlar�
    {
        startPosition = this.gameObject.transform.position; // a�ac�n �zerine t�kland��� andaki pozisyonu atan�r
        

        if (a != trees_mech.trees.Length - 1) // Bu a�a� arrayin son eleman� de�ilse sa�a hareket etsin
        {
            nextTree = trees_mech.trees[a + 1]; // bu a�a� ile yer de�i�tirecek olan a�a� atan�r

            trees_mech.trees[a] = null;
            this.gameObject.transform.position = trees_mech.trees[a + 1].transform.position; // pozisyon atan�r
            trees_mech.trees[a+1].transform.position = startPosition; // yer de�i�tirilecek olan a�ac�n pozisyonu bu a�ac�n eski pozisyonuna atan�r

            trees_mech.trees[a + 1] =  this.gameObject;  // bu a�a�, sa��ndaki a�ac�n array deki yerine ge�er
            trees_mech.trees[a] = nextTree;  // bu a�a� ile sa��ndaki a�a� , bu a�ac�n array deki yerine ge�er
        }

        if(a == trees_mech.trees.Length - 1) // Bu a�a� arrayin son eleman� ise sola hareket etsin
        {
            nextTree = trees_mech.trees[a - 1]; // bu a�a� ile yer de�i�tirecek olan a�a� atan�r

            this.gameObject.transform.position = trees_mech.trees[a -1].transform.position; // pozisyon atan�r
            trees_mech.trees[a-1].transform.position = startPosition; // yer de�i�tirilecek olan a�ac�n pozisyonu bu a�ac�n eski pozisyonuna atan�r

            trees_mech.trees[a - 1] = this.gameObject; // bu a�a�, solundaki a�ac�n array deki yerine ge�er
            trees_mech.trees[a] = nextTree;  // bu a�ac�n solundaki a�a�, bu a�ac�n array deki yerine ge�er
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
}
