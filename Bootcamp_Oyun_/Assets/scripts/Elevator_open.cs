using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_open : MonoBehaviour
{
    public static int totalButtonSolved; // toplanan asans�r d��mesi

    // T�m asans�r d��meleri topland���nda asans�r�n collider'� aktif olacak ve bu �ekilde �zerine t�klanabilcek 
    // �zerine t�kland���nda ba�ka bir script sayesinde sonraki sahneye ge�i� yap�lacak
    

    private void Start()
    {
        this.gameObject.GetComponent<Collider2D>().enabled=false;
        totalButtonSolved = 0;
    }

    private void Update()
    {
        if (totalButtonSolved == 2)
        {
            this.gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }
}
