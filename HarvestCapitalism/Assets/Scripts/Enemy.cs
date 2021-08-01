using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private AttackScript attackScript;
    [SerializeField] public Animator animator;
    public GameObject target;
    #region Caracteristiques
    public float HP = 60f;
    public float movementSpeed = 5f;
    public float attackPower = 20f;
    public float attackRange = 2.3f;
    #endregion
    private StateMachine<Enemy> fsm;
    private Chasing chasing;
    //Attack
    private Attacking attacking;
    public StateMachine<Enemy> FSM
    {
        get
        {
            return fsm;
        }
        set
        {
            fsm = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        fsm = new StateMachine<Enemy>(this);
        chasing = GetComponent<Chasing>();
        attacking = GetComponent<Attacking>();
        animator = GetComponent<Animator>();
        SetNewTarget();

        fsm.ChangeState(ChasingState.Instance);

    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            StartCoroutine("Die");
            
        }
    }
    private void FixedUpdate()
    {
        FSM.UpdateFSM();
    }
    public void StartAttacking()
    {
        animator.SetTrigger("AttackTrigger");
        attacking.EnterAttackMode();
    }

    public void StopAttacking()
    {
        animator.SetBool("Attack", false);
        attacking.QuitAttackMode();
    }

    public void SetNewTarget()
    {
        if (GameManager.GetPlantsCount() > 0)
        {
            int rand = Random.Range(0, GameManager.GetPlantsCount());
            if (GameManager.GetPlant(rand) != null)
            {
                target = GameManager.GetPlant(rand).gameObject;
                chasing.target = target;
            }
        }
    }

    public void ChasingTarget()
    {
        animator.SetBool("Walk", true);
        chasing.StartChasing();
    }

    public void StopChasing()
    {
        animator.SetBool("Walk", false);
        chasing.QuitChasingMode();
    }
    //Animation Events
    public void attackTriggerEnable()
    {
        attackScript.gameObject.SetActive(true);
    }

    public void attackTriggerDisable()
    {
        attackScript.gameObject.SetActive(false);
    }

    IEnumerator Die()
    {
        animator.SetTrigger("Dead");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
