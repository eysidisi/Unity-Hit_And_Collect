using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State
{
    public override Color StateColor => Color.red;

    public Attack(Character character)
    : base(character)
    {
        name = STATE.ATTACK;
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        if (character.environmentInfoManager.GetNumOfEnemy() == 0 ||
        !character.fireManager.HasAmmo())
        {
            return;
        }

        // Get closest enemy
        GameObject closestEnemy = character.environmentInfoManager.GetClosestEnemy();

        Debug.Log("enemy: " + closestEnemy);

        // Calculate the firing direction
        Vector3 fireDirection = closestEnemy.transform.position -
        character.transform.position;

        // Fire!
        character.fireManager.Fire(fireDirection, ProjectileType.Rock);


    }

    public override void Exit()
    {
        base.Exit();
    }


}
