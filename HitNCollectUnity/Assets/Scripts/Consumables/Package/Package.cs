
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
    protected virtual void Oncollected(StatusManager statusManager)
    {
        Debug.Log(typeOfPackage + " is picked up");
        statusManager.HandlePackage(this);
    }

    [SerializeField]
    protected int amount;
    public abstract int Amount { get; }
    public abstract PackageType typeOfPackage { get; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Character")
        {
            Oncollected(other.GetComponent<StatusManager>());
        }
    }
}
