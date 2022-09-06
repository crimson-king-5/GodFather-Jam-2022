using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointsIndex;
    Vector3 target;
    
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

  
    void Update()
    {
        if(Vector3.Distance(transform.position, target) < 4)
        {
            IterateWaypointIndex();
            UpdateDestination();
            Debug.Log("here i am ");
        }

        
    }

    void UpdateDestination()
    {
        target = waypoints[waypointsIndex].position;
        agent.SetDestination(target);
        Debug.Log(target);
    }

    void IterateWaypointIndex()
    {
        waypointsIndex++;
        if(waypointsIndex == waypoints.Length)
        {
            waypointsIndex = 0;
        }
    }
}
