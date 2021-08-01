using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField] private GameObject attacker;
    private float _attackPower;
    private void Start()
    {
        attacker = transform.parent.gameObject;
        if (attacker.CompareTag("Player"))
        {
            _attackPower = attacker.GetComponent<Player>().attackPower;
        }else
        {
            if (attacker.CompareTag("Enemy"))
            {
                _attackPower = attacker.GetComponent<Enemy>().attackPower;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (attacker.CompareTag("Enemy"))
        {
            if (other.gameObject.CompareTag("Plant"))
            {
                other.GetComponent<Plant>().HP -= _attackPower;
            }
        }
        if (attacker.CompareTag("Player"))
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().HP -= _attackPower;
            }
        }
    }

}
