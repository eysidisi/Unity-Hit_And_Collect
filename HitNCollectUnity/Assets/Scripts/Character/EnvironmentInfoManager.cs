using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentInfoManager : MonoBehaviour
{
    List<GameObject> enemyList;

    private void Awake()
    {
        enemyList = new List<GameObject>();
        foreach (var character in
        GameObject.FindGameObjectsWithTag("Character"))
        {
            if (character != this.gameObject)
            {
                enemyList.Add(character);
            }
        }
    }

    public GameObject GetClosestEnemy()
    {
        if (enemyList.Count == 0)
        {
            throw new Exception("Check number of enemies first");
        }


        GameObject closestEnemy = null;

        float distance = float.MaxValue;

        foreach (var enemy in enemyList)
        {
            if (distance > CalcDistanceTo(enemy.GetComponent<Transform>()))
            {
                distance = CalcDistanceTo(enemy.GetComponent<Transform>());
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    private float CalcDistanceTo(Transform enemy)
    {
        return (transform.position - enemy.position).magnitude;
    }

    public int GetNumOfEnemy()
    {
        return enemyList.Count;
    }
}
