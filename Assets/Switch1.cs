using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch1 : MonoBehaviour
{
    int cnt = 0;
    bool isOpen = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isOpen)
        {
            GameObject.Find("Door1").GetComponent<DoorOpen1>().Open();
            
        }

    }

    
}
