using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{


    public enum enemyState
    {
        walk, chase, attack
    }

    public Transform follow;

    public List<Transform> randomPostions;

    public LayerMask layerMask;

    Vector3 _newDestination;

    NavMeshAgent _navMashAgent;

    RaycastHit hit;

    bool _playerFollow;



    void Start()
    {
        _navMashAgent = GetComponent<NavMeshAgent>();
        GoRandomPostion();

    }

    void Update()
    {

        //


    }

    public void GoToPlayerPostion()
    {
        _playerFollow = true;
        transform.LookAt(follow.position);
        _navMashAgent.destination = follow.position;



        _playerFollow = true;

    }

    int _prvRange, _newRange;


    void GetNewPostion()
    {
        _newRange = Random.Range(0, randomPostions.Count);
        if (_prvRange != _newRange)
        {
            return;
        }
        else
        {
            GetNewPostion();
        }
    }
    public void GoRandomPostion()
    {
        if (!_playerFollow)
        {
            print("Go to pos" + _newRange);

            GetNewPostion();
            _newDestination = randomPostions[_newRange].position;
            _navMashAgent.destination = _newDestination;

            _prvRange = _newRange;
        }
    }





}
