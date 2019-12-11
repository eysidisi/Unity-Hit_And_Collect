using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    float speed = 5f;
    Vector3 targetPos;
    bool isMoving;
    float maxDistToTarget = 0.05f;
    [SerializeField]
    private bool isTesting;

    public void SetSpeed(int speed)
    {
        this.speed = speed;
    }

    private void Update()
    {
        if (isMoving)
        {
            Move();
        }

        if (isTesting)
        {
            ManuelMovement();
        }
    }

    private void ManuelMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * Time.deltaTime * speed;
        }
    }

    public void SetTargetPos(Vector3 targetPos)
    {
        isMoving = true;
        this.targetPos = targetPos;
    }

    private void Move()
    {
        if ((targetPos - transform.position).magnitude <= maxDistToTarget)
        {
            isMoving = false;
            return;
        }

        Vector3 direction = (targetPos - transform.position).normalized;

        transform.Translate(direction * Time.deltaTime * speed);
    }

}
