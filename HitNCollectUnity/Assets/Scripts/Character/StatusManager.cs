using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour, IDamageable
{
    private void Start()
    {
        ammoList = new Dictionary<AmmoType, int>();
    }
    public void RecieveDamage(float damage)
    {
        print("Damage " + damage + " recieved");
    }

    Dictionary<AmmoType, int> ammoList;

    [SerializeField]
    private int health;

    public void HandlePackage(Package package)
    {
        switch (package.TypeOfPackage)
        {
            // If package contains ammo
            case PackageType.Ammo:
                AmmoPackage ammoPackage = (AmmoPackage)package;

                int packageAmmoVal;

                if (!ammoList.TryGetValue(ammoPackage.CurrentAmmoType, out packageAmmoVal))
                {
                    packageAmmoVal = ammoPackage.Amount;
                    ammoList.Add(ammoPackage.CurrentAmmoType, packageAmmoVal);
                }

                else
                {
                    packageAmmoVal = ammoPackage.Amount;
                    ammoList[ammoPackage.CurrentAmmoType] += packageAmmoVal;
                }
                break;

            // If package contains health
            case PackageType.Health:
                HealthPackage healthPackage = (HealthPackage)package;
                int packageHealthVal = healthPackage.Amount;
                IncreaseHealth(packageHealthVal);
                break;
            default:
                break;
        }
    }

    private void IncreaseHealth(int increaseAmount)
    {
        health += increaseAmount;
    }
}
