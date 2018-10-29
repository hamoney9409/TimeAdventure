using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    //int cnt = 0;
    //int down_count;
    //bool isOpen = false;
    enum NowBehavior { closed, opened, opening };

    IEnumerator Delaying()
    {
        while (true)
        {
            goDown();
            //Debug.Log("time = " + Time.time);
            yield return new WaitForEndOfFrame();
        }
            
    }
    IEnumerator StopDelaying()
    {
        yield return new WaitForSeconds(4);
        StopCoroutine("Delaying");
        Destroy(gameObject);
    }

    private void goDown()
    {
        transform.position += Vector3.down * Time.deltaTime;
    }

    private void Open(NowBehavior now)
    {
        while (true)
        {
            if (now == NowBehavior.closed)
            {
                now = NowBehavior.opening;
                //Debug.Log("start!!");
                //cnt++;
            }
            else if (now == NowBehavior.opening)
            {

                StartCoroutine("Delaying");
                StartCoroutine("StopDelaying");
                //Debug.Log("dtd!! " + cnt);
                //Debug.Log("time!! " + Time.time);
                break;
            }
            
         
        }

        now = NowBehavior.opened;
        //Debug.Log("fuckoff!!");
        //Destroy(gameObject);
        
    }

    
    public void Triggered()
    {

        
        //Debug.Log("triggered!");
        NowBehavior now = NowBehavior.closed;

        Open(now);


        /*if (isOpen)
        {
            return;
        }

        while (cnt<200)
        {
            Invoke("goDown", Time.deltaTime*10);
            cnt++;
        }

        isOpen = true;
        cnt = 0;
        Destroy(gameObject);
              
        cnt++;
        Vector3 rot = transform.eulerAngles; 
        rot.y -= 1f; 
        transform.eulerAngles = rot;
        transform.position += Vector3.down * Time.deltaTime;
        if (cnt < 200)
        {
            Invoke("Open", Time.deltaTime);

        }
        else
        {
            isOpen = true;
            cnt = 0;
            Destroy(gameObject);
        }*/



    }


}