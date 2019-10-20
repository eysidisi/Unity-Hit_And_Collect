using UnityEngine;

public class Snowball : Projectile
{

    public override float Damage => 5;

    public override float Speed => 10;

    public override Color ProjectileColor => Color.white;
}
