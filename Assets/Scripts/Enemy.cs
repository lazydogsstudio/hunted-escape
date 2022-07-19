using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public float speed = 1.2f;
    public Transform follow;

    NavMeshAgent _navMashAgent;
    void Start()
    {
        _navMashAgent = GetComponent<NavMeshAgent>();

    }

    void LateUpdate()
    {
        _navMashAgent.destination = follow.position;

        transform.LookAt(follow.position);

    }
}
