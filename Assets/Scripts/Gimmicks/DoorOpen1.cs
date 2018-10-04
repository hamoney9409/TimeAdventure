using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen1 : MonoBehaviour
{
    
    int cnt = 0;
    bool isOpen = false; 
   
    
    public void Open()
    {
        if (isOpen)
        {
            return;
        } 
        cnt++; 
        Vector3 rot = transform.eulerAngles; 
        rot.y -= 1f; 
        transform.eulerAngles = rot;
        if (cnt < 90) Invoke("Open", Time.deltaTime); 
        else
        {
            isOpen = true;
            cnt = 0;
        }
        
    }
}