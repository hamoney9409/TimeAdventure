using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Assets.Scripts.Util;

[DisallowMultipleComponent]
[RequireComponent(typeof(NavMeshAgent))]

public class PlayerMove : MonoBehaviour{
    private Vector3 targetPosition;

    const int LEFT_MOUSE_BUTTON = 0;
    const int CHILDID_MODEL = 0;

    //NavMeshAgent agent;
    UnitPathfinder unitPathFinder;
    Animation anim;

    void Awake()
    {
        //agent = GetComponent<NavMeshAgent>();
        unitPathFinder = GetComponent<UnitPathfinder>();
        anim = transform.GetChild(CHILDID_MODEL).GetComponent<Animation>();
    }

    void Start() {
        targetPosition = transform.position;
        unitPathFinder.goTo(new Vector3(17, 2, 13));
    }


    void Update(){
        if (Input.GetMouseButton(0)) {
            SetTargetPosition();
        }
        MovePlayer();
    }


    void SetTargetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
            targetPosition = ray.GetPoint(point);

        Vector3Util.GridVectorInplace(ref targetPosition);

        Debug.Log(targetPosition);
        unitPathFinder.goTo(targetPosition);
    }

    void MovePlayer() {
        //agent.SetDestination(targetPosition);
    }
}
