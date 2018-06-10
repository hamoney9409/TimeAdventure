using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen1 : MonoBehaviour
{

    int cnt = 0;
    bool isOpen = false; 
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player" && !isOpen) Open(); 
    }
    void Open()
    {
        isOpen = true; 
        cnt++; 
        Vector3 rot = transform.eulerAngles; 
        rot.y -= 1f; 
        transform.eulerAngles = rot;
        if (cnt < 90) Invoke("Open", Time.deltaTime); 
        else 
            cnt = 0; 
    }
}