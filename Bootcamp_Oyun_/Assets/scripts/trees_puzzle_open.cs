using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trees_puzzle_open : MonoBehaviour
{


    // Kahve puzzle'� ��z�ld���nde a�a� puzzle�n�n yap�labilmesi i�in a�a�lar�n collider'lar�n� a�ma

    public Collider2D[] trees; 
    

    private void Update()
    {
        if (this.gameObject.activeSelf)
        {
            for(int i=0; i<=trees.Length-1; i++)
            {
                trees[i].enabled = true;
            }
        }
    }
}
