using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float chaseDistance;
    public Player player;

    public PatrolState PatrolState = new PatrolState();
    public ChaseState ChaseState = new ChaseState();
    public RetreatState RetreatState = new RetreatState();

    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Animator animator;

    private BaseState _currentState;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        _currentState = PatrolState;
        _currentState.EnterState(this);
    }

    private void OnEnable()
    {
        player.OnPowerUpStart += StartRetreating;
        player.OnPowerUpEnd += StopRetreating;
    }

    private void OnDisable()
    {
        player.OnPowerUpStart  -= StartRetreating;
        player.OnPowerUpEnd -= StopRetreating;
    }

    private void Update()
    {
        if(_currentState != null) _currentState.UpdateState(this);
    }

    public void SwitchState(BaseState state)
    {
        _currentState.ExitState(this);
        _currentState = state;
        _currentState.EnterState(this);
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

    private void StartRetreating()
    {
        SwitchState(RetreatState);
    }

    private void StopRetreating()
    {
        SwitchState(PatrolState);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_currentState != RetreatState)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<Player>().Dead();
            }
        }
    }
}