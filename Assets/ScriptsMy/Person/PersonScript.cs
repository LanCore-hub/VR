using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PersonScript : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    private int currentPointIndex = 1;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        WalkToNextPoint();
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            WalkToNextPoint();
        }
    }

    private void WalkToNextPoint()
    {
        agent.SetDestination(points[currentPointIndex].position);

        //currentPointIndex = (currentPointIndex + 1) % points.Length; // Для повтора
        currentPointIndex = (currentPointIndex + 1);

        if (currentPointIndex == points.Length)
        {
            Destroy(gameObject);
        }
    }

    public void SetWaypoints(Transform[] newPoints)
    {
        points = newPoints;
    }
}
