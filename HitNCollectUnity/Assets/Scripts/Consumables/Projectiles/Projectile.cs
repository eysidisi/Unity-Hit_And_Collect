using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile
{

    public abstract float Damage { get; }
    public abstract float Speed { get; }
    public abstract Color ProjectileColor { get; }
    public abstract ProjectileType Type { get; }
    protected int? id = null;
    public int? Id
    {
        get { return id; }
        set
        {
            if (id == null)
            {
                id = value;
            }
        }
    }
}
