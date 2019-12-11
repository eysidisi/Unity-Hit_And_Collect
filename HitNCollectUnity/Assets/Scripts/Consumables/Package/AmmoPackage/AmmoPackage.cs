
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AmmoType
{
    Snowball = ProjectileType.Snowball,
    Rock = ProjectileType.Rock
}
public class AmmoPackage : Package
{
    [SerializeField]
    private AmmoType ammoType = AmmoType.Rock;
    public AmmoType CurrentAmmoType
    {
        get
        {
            return ammoType;
        }

        set
        {
            ammoType = value;

            switch (ammoType)
            {
                case AmmoType.Snowball:
                    GetComponent<MeshRenderer>().material.color = Color.blue;
                    break;

                case AmmoType.Rock:
                    GetComponent<MeshRenderer>().material.color = Color.grey;
                    break;
                default:
                    break;
            }
        }
    }
    public override int Amount => amount;
    public override PackageType TypeOfPackage => PackageType.Ammo;

    protected override void Oncollected(Collider characterCollider)
    {
        if (characterCollider.GetComponent<FireManager>())
        {
            characterCollider.
            GetComponent<FireManager>().HandlePackage(this);
        }
    }
}
