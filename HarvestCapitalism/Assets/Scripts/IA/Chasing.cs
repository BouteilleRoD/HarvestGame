using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chasing : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent navmeshAgent;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartChasing()
    {
        if (target != null)
        {
            navmeshAgent.SetDestination(target.transform.position);
        }
    }
    public void QuitChasingMode()
    {
        navmeshAgent.SetDestination(transform.position);
    }

}
