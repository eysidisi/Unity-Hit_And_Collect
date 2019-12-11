using UnityEngine;

public enum ProjectileType
{
    Rock,
    Snowball
}

public class ProjectileManager : MonoBehaviour
{
    Projectile projectile;

    Vector3 projectileDirection;

    public void Init(ProjectileType type, int id, Vector3 direction)
    {
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

        projectile.Id = id;

        print("direction " + direction);

        projectileDirection = direction;

        GetComponent<MeshRenderer>().material.color = projectile.ProjectileColor;
    }
    private void OnTriggerEnter(Collider collidedObject)
    {
        if (collidedObject.GetComponent<Character>())
        {
            if (collidedObject.GetComponent<Character>().CharacterID == projectile.Id)
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
        transform.position += projectile.Speed * projectileDirection*Time.deltaTime;
    }

}
