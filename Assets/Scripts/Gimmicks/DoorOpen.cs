using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    enum NowBehavior { closed, opened, opening };
    NowBehavior now = NowBehavior.closed;

    private void goDown()
    {
        transform.position += Vector3.down * Time.deltaTime * 4;
    }

    IEnumerator Delaying()
    {
        while (true)
        {
            goDown();
            yield return new WaitForEndOfFrame();
        }
            
    }
    IEnumerator StopDelaying()
    {
        yield return new WaitForSeconds(1);
        StopCoroutine("Delaying");
        now = NowBehavior.opened;
        Destroy(gameObject);
    }

    IEnumerator Open()
    {

        while (true)
        {
            if (now == NowBehavior.closed)
            {
                yield return null;
                now = NowBehavior.opening;
            }
            else if (now == NowBehavior.opening)
            {
                StartCoroutine("Delaying");
                StartCoroutine("StopDelaying");
                break;
            }
            
         
        }

        
        
    }

    
    public void Triggered()
    {
        if (now == NowBehavior.closed)
        {
            StartCoroutine("Open");
        }
        else
        {
            return;
        }
    }


}