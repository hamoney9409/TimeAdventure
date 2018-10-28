using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {
       
    public void SetChildrenGrid()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            child.position = new Vector3((int)child.position.x, (int)child.position.y, (int)child.position.z);
        }
    }
       
	// Use this for initialization
//	void Start ()
 //   {
//	    
//	}
	
	// Update is called once per frame
//	void Update () {
//		
//	}
}
