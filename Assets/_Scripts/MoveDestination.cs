// MoveDestination.cs
using UnityEngine;
using UnityEngine.AI;

public class MoveDestination : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform goal;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        agent.speed = Random.Range(1, 7);
        agent.angularSpeed = Random.Range(200,500);
        agent.acceleration = Random.Range(4, 20);
    }

    void Update()
    {
        agent.destination = goal.position;
    }

}