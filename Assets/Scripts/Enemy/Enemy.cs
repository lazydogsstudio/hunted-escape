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

    [Header("Player Following")]
    public Transform playerBody;
    [Range(1f, 15f)]
    public float followDistance;
    [Range(1f, 5f)]
    public float followSpeed;

    [Header("Random Walk")]
    [Range(1f, 5f)]
    public float walkSpeed;
    public List<Transform> randomPostions;
    public LayerMask layerMask;
    public Transform enemyEye;

    Vector3 _newDestination;
    NavMeshAgent _navMashAgent;

    Animator _anim;
    RaycastHit _hit;

    bool _allreadyRandomPostion;

    void Start()
    {
        _navMashAgent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        GoToRandomPostion();
    }

    void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, playerBody.transform.position);

        if (playerDistance < followDistance)
        {
            if (playerDistance < 3.5f)
            {
                _anim.SetTrigger("Attack");
                LevelManager.instance.SetGameoverPanel(true);

            }
            else
            {
                GoToPlayerPostion();
            }

        }
        else
        {
            GoToRandomPostion();
        }







        // if (Physics.Raycast(enemyEye.position, enemyEye.TransformDirection(Vector3.forward), out hit, 5f, layerMask))
        // {
        //     if (hit.collider.CompareTag("Door"))
        //     {
        //         GoRandomPostion();
        //     }
        // }

    }




    public void GoToPlayerPostion()
    {
        print("Go to Player");
        _navMashAgent.stoppingDistance = 2.5f;

        _navMashAgent.speed = followSpeed;
        _anim.SetFloat("Blend", 1f);
        _navMashAgent.destination = playerBody.position;
        _allreadyRandomPostion = false;
    }


    public void SetAllReadyRandomPostion(bool value)
    {
        _allreadyRandomPostion = value;
    }

    public void GoToRandomPostion()
    {
        // If Enemy not go for random postion
        if (!_allreadyRandomPostion)
        {
            print("Go to Random");

            _navMashAgent.speed = walkSpeed;
            _newDestination = randomPostions[GetRandomRange()].position;
            _navMashAgent.stoppingDistance = 1.5f;
            _anim.SetFloat("Blend", 0.5f);
            _navMashAgent.destination = _newDestination;
            _allreadyRandomPostion = true;

        }
        else
        {
            // Don't do any thing;
        }

    }

    int _prvRange;

    int GetRandomRange()
    {

        int _newRange = Random.Range(0, randomPostions.Count);
        if (_prvRange == _newRange)
        {
            GetRandomRange();
        }
        else
        {
            _prvRange = _newRange;
        }

        return _newRange;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Random"))
        {
            print("trigger");
            _allreadyRandomPostion = false;
            GoToRandomPostion();

        }

    }







}
