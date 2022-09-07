using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    NavMeshAgent _agent;
    public Transform[] waypoints;
    int _waypointsIndex = 0;
    Vector3 _target = Vector3.zero;
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

  
    void Update()
    {
        if(_agent.remainingDistance < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        _target = waypoints[_waypointsIndex].position;
        _agent.SetDestination(_target);
    }

    void IterateWaypointIndex()
    {
        _waypointsIndex++;
        if(_waypointsIndex == waypoints.Length)
            _waypointsIndex = 0;
    }
}
