using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public int openSpeed = 4;
    enum ActionState { closed, opened, opening };
    ActionState actionState = ActionState.closed;

    private void doorOpening()
    {
        transform.position += Vector3.down * Time.deltaTime * openSpeed;
    }

    IEnumerator Delaying()
    {
        while (true)
        {
            doorOpening();
            yield return new WaitForEndOfFrame();
        }
            
    }
    IEnumerator StopDelaying()
    {
        yield return new WaitForSeconds(1); // ???
        StopCoroutine("Delaying");
        actionState = ActionState.opened;
        Destroy(gameObject);
    }

    IEnumerator Open()
    {
        bool loop = true;
        while (loop)
        {
            switch (actionState)
            {
                case ActionState.closed:
                    yield return null;
                    actionState = ActionState.opening;
                    break;
                case ActionState.opening:
                    StartCoroutine("Delaying");
                    StartCoroutine("StopDelaying");
                    loop = false;
                    break;
            }
        }
    }

    
    public void Triggered()
    {
        switch (actionState)
        {
            case ActionState.closed:
                break;
            default:
                return;
        }

        Debug.Log(actionState);
        StartCoroutine("Open");
        Debug.Log(actionState);
        actionState = ActionState.opening;
    }
}