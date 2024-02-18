using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bolum_gecme : MonoBehaviour
{
    private bool onenter = false; // mouse bolum ge�me kap�s�n�n �st�nde mi

    public string sceneName=""; // gidilecek sahnenin ad�
    

    

    private void Update()
    {

        // // mouse bolum ge�me kap�s�n�n �st�nde ve mouse'un sol tu�una bas�l�yorsa sahneyi y�kle
        if ( onenter == true && Input.GetMouseButtonDown(0))
        {

            SceneManager.LoadScene(sceneName); // gidilecek sahneyi y�kle
        }

        
    }

  

    private void OnMouseEnter()
    {
        
        onenter = true;  // mouse bolum ge�me kap�s�n�n �st�nde
    }

    private void OnMouseExit()
    {
        
        onenter = false; // mouse bolum ge�me kap�s�n�n �st�nde de�il
    }
}
