using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Assets.Scripts.Util;

[DisallowMultipleComponent]
//[RequireComponent(typeof(NavMeshAgent))]

public class PlayerMove : MonoBehaviour{
    private Vector3 targetPosition;

    const int LEFT_MOUSE_BUTTON = 0;
    const int CHILDID_MODEL = 0;

    public bool pathFindingTest = false;

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
    }


    void Update(){
        if (Input.GetMouseButton(0)) {
            SetTargetPosition();
        }
        MovePlayer();
    }

    void SetTargetPosition()
    {
        //Plane plane = new Plane(Vector3.up, transform.position);
        RaycastHit hit;
        Ray rayFromCamera = Camera.main.ScreenPointToRay(Input.mousePosition);
        //float point = 0f;

        if (true == (Physics.Raycast(rayFromCamera.origin, rayFromCamera.direction * 10, out hit)))
        {
            Vector3 gridPoint = Vector3Util.GridVector(hit.point); // 이동해야할 위치의 x, z좌표
            Collider selectedObjCollider = hit.collider;
            GameObject obj = hit.collider.gameObject;

            {
                int j = 1;
                for (int i = 0; i < 10; i++)
                {
                    Ray rayDown = new Ray(gridPoint + Vector3.up * j / 2, Vector3.down * j);

                    if (selectedObjCollider.Raycast(rayDown, out hit, j))
                    //if (Physics.Raycast(rayDown, out hit)) // 위로 광선을 쐈는데 터치된 오브젝트에 닿음 
                    {
                        targetPosition = hit.point;
                    }

                    j *= 2;
                }
            }

            Vector3 a = targetPosition;

            if (!pathFindingTest)
            {
                unitPathFinder.goTo(targetPosition);
            }
            else
            {
                GetComponent<CorvoPathFinder>().findPath(targetPosition);
            }
            
            
            //Debug.Log(a + "->" + targetPosition);
        }
    }

    void MovePlayer() {
        //agent.SetDestination(targetPosition);
    }
}
