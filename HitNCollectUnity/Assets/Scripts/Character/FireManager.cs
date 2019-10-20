using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO: Use object pooling for projectiles
public class FireManager : MonoBehaviour
{
    [SerializeField]
    GameObject projectilePrefab;



    public void Fire(Vector3 direction, ProjectileType projectileType)
    {
        GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        newProjectile.GetComponent<ProjectileManager>()
            .Init(projectileType, GetComponent<AIManager>().AIId, direction);
    }
}
