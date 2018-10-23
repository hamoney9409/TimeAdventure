using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class UnitPathfinder:MonoBehaviour
{
	//AI PARAMETERS
	public float speed=5;
	public rotationType updateRotation=rotationType.rotateLeftRight;
	
	//altro
	Vector3 destination;
	
	bool mustMove=true;
	float  pathRefreshTime=0;
    void FixedUpdate()
    {
		CorvoPathFinder pf=GetComponent<CorvoPathFinder>();
		if (destinationActive)
		{
			if (pf)
			{
				if (pf.havePath())
					checkReachedNode();
				if (Time.time > pathRefreshTime)
				{
					updatePath();
				}
				
				if (mustMove)
				{
					if (pf.havePath())
					{
						Vector3 _dir=(pf.getDestination()-transform.position).normalized;
						if (updateRotation!=rotationType.dontRotate)
						{
							Vector3 _dir2D;
							if (updateRotation==rotationType.rotateAll)//rotate all
								_dir2D=(pf.getDestination()-transform.position).normalized;
							else//don't update z axis
								_dir2D=((pf.getDestination()-Vector3.up*pf.getDestination().y)-(transform.position-Vector3.up*transform.position.y)).normalized;
							transform.rotation=Quaternion.RotateTowards(transform.rotation,Quaternion.LookRotation(_dir2D),Time.deltaTime*speed*60);
						}
						transform.position=Vector3.MoveTowards(transform.position,pf.getDestination(),Time.deltaTime*speed);
					}
				}
			}
			else
			{
				Debug.LogError("No PathFinder Assigned! please assign component CorvopathFinder to this object.",gameObject);
			}
		}
	}
	
	bool destinationActive=false;
	public void goTo(Vector3 _dest)//Start moving to position following pest path
	{
		destinationActive=true;
		destination=_dest;
		updatePath();
	}
	
	public void stop()//stop unit if moving
	{
		GetComponent<CorvoPathFinder>().forceStop();
		destinationActive=false;
	}
	
    public void updatePath()//reload the path to see if world has changed
    {
        if (GetComponent<CorvoPathFinder>().findPath(destination))
			pathRefreshTime = Time.time + Random.Range(9f, 12f);//update world path after X seconds (maybe world has changed?)
        else
            pathRefreshTime = Time.time + Random.Range(0.01f, 0.1f);//wait until can find new path
    }
	
	public void checkReachedNode()//Check if reached next Pathnode
    {
        if (GetComponent<CorvoPathFinder>().getDestination().Equals(transform.position) )
            GetComponent<CorvoPathFinder>().nextNode();

		//was last node?
		if (GetComponent<CorvoPathFinder>().foundPath == null)
		{
			if (transform.position.Equals(destination))
            {
                //arrived
                stop();
            }
			else
            {
                //not arrived yet
                updatePath();
            }
				
		}
    }
}

public enum rotationType
{
	dontRotate,
	rotateAll,
	rotateLeftRight
}