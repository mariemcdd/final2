using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 1;
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private PlayerHealth _playerHealth;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("I hit the player");
            _enemyMovement.EnemyAttack();
            _playerHealth.TakeDamage(_damageAmount);
        }
    }
}