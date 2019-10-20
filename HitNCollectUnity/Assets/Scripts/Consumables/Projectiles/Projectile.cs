using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile
{

    public abstract float Damage { get; }
    public abstract float Speed { get; }
    public abstract Color ProjectileColor { get; }
}
