using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackage : Package
{
    public override int Amount => amount;

    public override PackageType TypeOfPackage => PackageType.Health;


    protected override void Oncollected(Collider characterCollider)
    {
        if (characterCollider.GetComponent<StatusManager>())
        {
            characterCollider.GetComponent<StatusManager>().
            HandlePackage(this);
        }
    }

}
