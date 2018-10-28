﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch1 : MonoBehaviour
{
    int cnt = 0;
    bool isOpen = false;
    int check = 0;
    public GameObject Door;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isOpen)
        {
            if (check == 0)
            {
                check = 1;
                Door.GetComponent<AudioSource>().Play();
                Door.GetComponent<DoorOpen1>().Open();
            }
            else return;
        }

    }

    
}
