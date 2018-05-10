using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(NavMeshAgent))]

public class PlayerMove : MonoBehaviour{

    private Vector3 targetPosition;

    const int LEFT_MOUSE_BUTTON = 0;

    NavMeshAgent agent;

    void Awake() {
        agent = GetComponent<NavMeshAgent>();
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

    void SetTargetPosition() {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
            targetPosition = ray.GetPoint(point);

        targetPosition.x = (int)targetPosition.x;
        targetPosition.y = (int)targetPosition.y;
        targetPosition.z = (int)targetPosition.z;

        if (targetPosition.x % 2 == 0 && targetPosition.z % 2 == 0) {
            targetPosition.x = targetPosition.x + 1;
            targetPosition.z = targetPosition.z + 1;
        }

        else if (targetPosition.x % 2 == 1 && targetPosition.z % 2 == 0) {
            targetPosition.z = targetPosition.z + 1;
        }

        else if (targetPosition.x % 2 == 0 && targetPosition.z % 2 == 1) {
            targetPosition.x = targetPosition.x + 1;
        }

    }

    void MovePlayer() {
        agent.SetDestination(targetPosition);

    }
}
