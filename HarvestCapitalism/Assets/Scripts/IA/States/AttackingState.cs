using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : State<Enemy>
{
    private static AttackingState instance = null;

    public static AttackingState Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AttackingState();
            }
            return instance;
        }
    }
    public void Enter(Enemy enemy)
    {
        enemy.StartAttacking();
        enemy.animator.SetBool("hasKilledTarget", false);
        Debug.Log("Start Attacking");
    }
    public void Execute(Enemy enemy)
    {
        if(enemy.target != null)
        {
            enemy.transform.forward = enemy.target.transform.position - enemy.transform.position;
        }
        if(enemy.target == null)
        {
            enemy.FSM.ChangeState(TransitionState.Instance);
        }
    }

    public void Exit(Enemy enemy)
    {
        enemy.GetComponent<Rigidbody>().isKinematic = false;
        enemy.SetNewTarget();
        enemy.animator.SetBool("hasKilledTarget", true);
    }
}
