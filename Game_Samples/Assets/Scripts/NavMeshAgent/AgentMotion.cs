/*
Script to control the motion of an agent that uses
NavMesh in 2D

Gilberto Echeverria
2023-04-10
*/

using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]

public class AgentMotion : MonoBehaviour
{
    [SerializeField] float searchDistance;

    NavMeshAgent nvAgent;
    Vector3 initialPos;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        nvAgent = GetComponent<NavMeshAgent>();
        nvAgent.updateRotation = false;
        nvAgent.updateUpAxis = false;
        // Store the position where the object was initialized
        initialPos = transform.position;
        // Find the player in the scene
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < searchDistance) {
            nvAgent.destination = player.position;
        } else {
            nvAgent.destination = initialPos;
        }
    }
}