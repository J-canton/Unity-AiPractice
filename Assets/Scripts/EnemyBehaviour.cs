using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBehaviour : MonoBehaviour
{
    public Transform patrolRoute;
    public List<Transform> waypoints;

    private int locationIndex = 0;
    private NavMeshAgent _agent;

    void Start() 
    {
        _agent = GetComponent<NavMeshAgent>();
        InitializeWayPoints();
    }

    void Update() 
    {
        if(_agent.remainingDistance < 0.5f && !_agent.pathPending)
        {
            MoveToNextWaypoint();
        }    
    }

    void InitializeWayPoints()
    {
        foreach(Transform wp in patrolRoute)
        {
           waypoints.Add(wp); 
        }
    }

    void MoveToNextWaypoint()
    {
        if(waypoints.Count == 0)
        {
            return;
        }
        _agent.SetDestination(waypoints[locationIndex].position);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.name == "Player")
        {
            Debug.Log("Juagdor detectado");
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.name == "Player")
        {
            Debug.Log("Jugador fuera de rango");
        }
    }
}
