using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot_index : MonoBehaviour
{
    //public int Slot_Number_;
    //private inventory_new inventory_;
    //
    private string str = "";

    private bool nesneler_touch = false;
   //
   //
   //private void Start()
   //{
   //    inventory_ = GameObject.FindGameObjectWithTag("player").GetComponent<inventory_new>();
   //
   //
   //}
    void Update()
    {


        //if (drag_movement_new.place_correct == true && this.gameObject.transform.childCount > 0)
        //{
        //    inventory_.isFull[Slot_Number_] = false; // Buray� inventory de bug olup bo� slot kalmas�zn diye yazd�k
        //
        //    Destroy(gameObject.transform.GetChild(0).gameObject);
        //}

        //SomeMethod();

        if (nesneler_touch == true) { Debug.Log("nesneler de�iyor ccc"); }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
   
        
        Debug.Log("nesneler de�iyor");
        nesneler_touch = true;


        if (collision.gameObject.CompareTag("touchable"))
        {
            Debug.Log("nesneler de�iyor  xxx");
        }
   
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        nesneler_touch = false;
    }
}
