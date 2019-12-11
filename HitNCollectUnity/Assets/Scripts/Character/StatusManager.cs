using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour, IDamageable
{

    public void RecieveDamage(float damage)
    {
        print("Damage " + damage + " recieved");
    }


    [SerializeField]
    private int health;

    public void HandlePackage(Package package)
    {
        HealthPackage healthPackage = (HealthPackage)package;
        int packageHealthVal = healthPackage.Amount;
        IncreaseHealth(packageHealthVal);
    }

    private void IncreaseHealth(int increaseAmount)
    {
        health += increaseAmount;
    }


}
