using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_true : MonoBehaviour
{
    
    // Havuz puzzle'� ��z�ld���nde havuzdan asans�r d��mesini ��karma kodlar�
    
    public GameObject puzzleObject; // havuzdan d��meyi alacak olan nesne (havuz puzzle'�n�n ��z�lmesi i�in gerekli olan nesne)
    private set_active setActive; // asans�r d��mesini aktif etmek i�in kullan�lacak olan script
    private Vector3 targetCenter;  // puzzleObject'in yerle�mesi gerek koordinat

    private void Start()
    {
        setActive = this.gameObject.GetComponent<set_active>();
        setActive.enabled = false;
        setActive.openedObject.SetActive(false); // setActive scriptinin i�indeki obje bug olup oyunun ba��nda a��lmamas� i�in tedbir
        targetCenter = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Collider2D>().bounds.center;
    }

    private void Update()
    {
        if(targetCenter == puzzleObject.transform.position) // puzzleObject do�ru yere yerle�ti havuzun i�inden saklanan nesneyi aktive edecek kod 
        {
            setActive.enabled = true; //havuzun i�inden saklanan nesneyi aktive edecek kod 
        }
    }
}
