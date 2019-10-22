using UnityEngine;

public enum ProjectileType
{
    Rock,
    Snowball
}



public class ProjectileManager : MonoBehaviour
{
    public void Init(ProjectileType type, int id, Vector3 direction)
    {
        this.type = type;
        this.id = id;
        this.direction = Vector3.Normalize(direction);

        switch (type)
        {
            case ProjectileType.Rock:
                projectile = new Rock();
                break;

            case ProjectileType.Snowball:
                projectile = new Snowball();
                break;

            default:
                break;
        }

        GetComponent<MeshRenderer>().material.color = projectile.ProjectileColor;
    }
    Projectile projectile;

    ProjectileType type;

    int id;

    Vector3 direction = Vector3.zero;

    private void OnTriggerEnter(Collider collidedObject)
    {
        if (collidedObject.GetComponent<Character>())
        {
            if (collidedObject.GetComponent<Character>().CharacterID == id)
            {
                return;
            }
        }
        if (collidedObject.GetComponent<IDamageable>() != null)
        {
            collidedObject.GetComponent<IDamageable>().RecieveDamage(projectile.Damage);
        }
    }

    private void Update()
    {
        transform.position = transform.position + direction * projectile.Speed * Time.deltaTime;
    }
}
