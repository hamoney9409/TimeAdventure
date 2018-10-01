using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch1 : MonoBehaviour
{
    public int swi = 0;
    int cnt = 0;
    bool isOpen = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isOpen) swi = 1;
        if (swi == 1)
        {
            GameObject.Find("Door1").GetComponent<DoorOpen1>().Open();
        }

    }

    
}
