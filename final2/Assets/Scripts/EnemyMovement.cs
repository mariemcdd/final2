using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1f;
    public float rangeValue = 3f;
    private Vector3 _startingPosition;
    [SerializeField] private bool _isAttacking;
    [SerializeField] private Transform _player;
    [SerializeField] private Animator _enemyAnimation;
    [SerializeField] private Rigidbody _enemyRb;

    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDirection = (_player.position - transform.position).normalized;
        
        float distance = Vector3.Distance(_player.position, transform.position);
        //Debug.Log("Distance" + distance);
        if(!_isAttacking)
        {
            if(distance < rangeValue)
            {
                _enemyRb.velocity = movementDirection * speed;
                transform.LookAt(_player);
                _enemyAnimation.SetBool("IsMoving", true);
            }
            else
            {
                //_enemyRb.velocity = movementDirection * 0;
                _enemyAnimation.SetBool("IsMoving", false);
            }
        }
    }// end Update

    public void EnemyAttack()
    {
        _isAttacking = true;
        _enemyAnimation.SetBool("IsMoving", false);
        _enemyAnimation.SetTrigger("IsAttacking");
        StartCoroutine("EnemyAttackCoolDown");
    }

    IEnumerator EnemyAttackCoolDown()
    {
        yield return new WaitForSeconds(5f);
        _isAttacking = false;
    }
}