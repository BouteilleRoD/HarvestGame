using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attacking : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent navmeshAgent;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnterAttackMode()
    {
        navmeshAgent.SetDestination(gameObject.transform.position);
    }

    public void QuitAttackMode()
    {

    }
}
