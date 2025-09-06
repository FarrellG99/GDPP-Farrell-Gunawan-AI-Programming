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

    private BaseState _currentState;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        _currentState = PatrolState;
        _currentState.EnterState(this);
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
}