using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionState : State<Enemy>
{
    private static TransitionState instance = null;

    public static TransitionState Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TransitionState();
            }
            return instance;
        }
    }
    public void Enter(Enemy enemy)
    {
        enemy.animator.SetBool("Walk", false);
        enemy.animator.ResetTrigger("AttackTrigger");
    }
    public void Execute(Enemy enemy)
    {
        enemy.SetNewTarget();
       if(enemy.target != null)
        {
            enemy.FSM.ChangeState(ChasingState.Instance);
        }
    }

    public void Exit(Enemy enemy)
    {
      
    }
}

