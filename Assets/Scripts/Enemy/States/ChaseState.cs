using UnityEngine;

public class ChaseState : BaseState
{
    public void EnterState(Enemy enemy)
    {
        Debug.Log("Start Chasing");
    }

    public void UpdateState(Enemy enemy)
    {
        if (enemy.player)
        {
            enemy.agent.destination = enemy.player.transform.position;
            if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) > enemy.chaseDistance)
            {
                enemy.SwitchState(enemy.PatrolState);
            }
        }
    }

    public void ExitState(Enemy enemy)
    {
        Debug.Log("Stop Chasing");
    }
}