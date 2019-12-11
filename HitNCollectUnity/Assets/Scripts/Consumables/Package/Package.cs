
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PackageType
{
    Ammo,
    Health
}

public abstract class Package : MonoBehaviour
{
    protected abstract void Oncollected(Collider characterCollider);

    // declare delegate 
    public delegate void PackageIsPicked(Package package);

    //declare event of type delegate
    public event PackageIsPicked packageIsPickedEvent;

    [SerializeField]
    protected int amount;
    public abstract int Amount { get; }
    public abstract PackageType TypeOfPackage { get; }

    private void OnTriggerEnter(Collider triggeredObject)
    {
        if (triggeredObject.tag == "Character")
        {
            Oncollected(triggeredObject);

            // Manager needs to learn about picking event first
            GameAreaController.PackageIsPicked(this);

            //TODO: Learn about events and use it properly
            if (packageIsPickedEvent != null)
            {
                packageIsPickedEvent(this);
            }
        }
    }
}
