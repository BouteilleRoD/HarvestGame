using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : State<Enemy>
{
    private static ChasingState instance = null;

    public static ChasingState Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ChasingState();
            }
            return instance;
        }
    }
    public void Enter(Enemy enemy)
    {
        enemy.ChasingTarget();
    }
    public void Execute(Enemy enemy)
    {
        if (enemy.target != null)
        {
            if (Vector3.Distance(enemy.transform.position, enemy.target.transform.position) < enemy.attackRange)
            {

                enemy.FSM.ChangeState(AttackingState.Instance);
            }
        }
        else
        {
            enemy.FSM.ChangeState(TransitionState.Instance);
        }
    }

    public void Exit(Enemy enemy)
    {
        if(enemy.target != null)
        {
        enemy.transform.forward = enemy.target.transform.position - enemy.transform.position;
        }
        enemy.GetComponent<Rigidbody>().isKinematic = true;
        enemy.StopChasing();
    }

}
