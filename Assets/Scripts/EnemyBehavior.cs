using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform patrolRoute;
    public List<Transform> locations;

    private int _locationIndex = 0;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        InitializePatrolRoute();

        MoveToNextPatrolLocation();
    }

    private void Update()
    {
        //Si _agent está muy cerca de su destino y no se está calculando ninguna otra ruta, la if declaración regresa true y llama a MoveToNextPatrolLocation()
        if (_agent.remainingDistance < 0.2f && !_agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }

    void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0) return;

        //Se mueve el enemy a la posicion actual de _locationIndex
        _agent.destination = locations[_locationIndex].position;

        //Actualizamos el valor de _locationIndex
        _locationIndex = (_locationIndex + 1) % locations.Count;

        Debug.Log(_locationIndex);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player detected - attack!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player out of range, resume patrol");
        }
    }
}
