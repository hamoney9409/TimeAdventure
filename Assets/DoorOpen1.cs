using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen1 : MonoBehaviour
{
    public int swi = 0;
    int cnt = 0;
    bool isOpen = false; 
   
    
    public void Open()
    {
        isOpen = true; 
        cnt++; 
        Vector3 rot = transform.eulerAngles; 
        rot.y -= 1f; 
        transform.eulerAngles = rot;
        if (cnt < 45) Invoke("Open", Time.deltaTime); 
        else 
            cnt = 0; 
    }
}