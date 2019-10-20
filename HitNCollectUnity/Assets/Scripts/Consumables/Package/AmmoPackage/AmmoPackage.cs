
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
    private AmmoType ammoType;
    public AmmoType AmmoType
    {
        get
        {
            return ammoType;
        }
    }
    public override int Amount => amount;
    public override PackageType typeOfPackage => PackageType.Ammo;

    protected override void Oncollected(StatusManager statusManager)
    {
        base.Oncollected(statusManager);
        Debug.Log(ammoType + " ammo is collected");
    }

}
