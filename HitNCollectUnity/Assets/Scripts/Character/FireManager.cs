using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO: Use object pooling for projectiles
public class FireManager : MonoBehaviour
{
    [SerializeField]
    GameObject projectilePrefab;
    Dictionary<AmmoType, int> ammoList;

    private void Start()
    {
        ammoList = new Dictionary<AmmoType, int>();
    }
    public void Fire(Vector3 direction, ProjectileType projectileType)
    {
        GameObject newProjectile = Instantiate(projectilePrefab,
        transform.position, Quaternion.identity);

        newProjectile.GetComponent<ProjectileManager>()
            .Init(projectileType, GetComponent<Character>().CharacterID, direction);

        // TODO: This part is too noobie! Find a way to overcome this
        AmmoType firedWeaponAmmoType = (AmmoType)projectileType;

        ammoList[firedWeaponAmmoType]--;

    }

    // TODO: Implement for different type of guns types
    public bool HasAmmo()
    {
        foreach (var ammo in ammoList)
        {
            if (ammo.Value > 0)
            {
                return true;
            }
        }

        return false;
    }


    public void HandlePackage(Package package)
    {
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
    }

}
