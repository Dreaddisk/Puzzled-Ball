using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBall : MonoBehaviour
{
    #region Variables
    private Transform ballTarget;
    private Vector3 ballPositionDirection;

    private bool canAttack, readyToAttack;

    [HideInInspector]
    public bool stunned;

    private Rigidbody myBody;
    private RaycastHit ballHit;

    #endregion Varaibles




    #region UnityFunctions
    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckIfCanAttack();
    }

    private void FixedUpdate()
    {
        Attack();
    }

    #endregion UnityFunctions

    void GetBallTarget(Transform target)
    {
        ballTarget = target;
    }

    void CanAttackToggle(bool canAttack)
    {
        this.canAttack = canAttack;
    }

    void CheckIfCanAttack()
    {
        if(canAttack && !stunned &&(myBody.velocity.sqrMagnitude <= 0.11f))
        {
            ballPositionDirection = ballTarget.position - transform.position;

            if(Physics.Raycast(transform.position, ballPositionDirection, out ballHit, 25))
            {
                if(ballHit.transform.tag == "Ball")
                {
                    readyToAttack = true;
                }
            }
        }
    }


    void Attack()
    {
        if(readyToAttack)
        {
            myBody.AddForce(ballPositionDirection * 200f);
            readyToAttack = false;
        }
    }



} // EnemyBall class
