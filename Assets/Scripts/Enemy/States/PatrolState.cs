using UnityEngine;

public class PatrolState : BaseState
{
    private bool _isMoving;
    private Vector3 _destination;

    public void EnterState(Enemy enemy)
    {
        Debug.Log("Start Patrol");
        _isMoving = false;
    }

    public void UpdateState(Enemy enemy)
    {
        Debug.Log("Patrolling...");
        if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) < enemy.chaseDistance)
        {
            enemy.SwitchState(enemy.ChaseState);
        }

        if (!_isMoving)
        {
            _isMoving = true;
            int index = Random.Range(0, enemy.waypoints.Count);
            _destination = enemy.waypoints[index].transform.position;
            enemy.agent.destination = _destination;
        }
        else
        {
            if (Vector3.Distance(_destination, enemy.transform.position) <= 0.1f)
            {
                _isMoving = false;
            }
        }
    }

    public void ExitState(Enemy enemy)
    {
        Debug.Log("Stop Patrolling");
    }
}