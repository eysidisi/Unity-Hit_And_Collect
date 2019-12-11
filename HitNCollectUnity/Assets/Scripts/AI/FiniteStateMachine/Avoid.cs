using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoid : State
{
    public Avoid(Character character) : base(character)
    {
    }

    public override Color StateColor => Color.green;

    public override void Enter()
    {
        base.Enter();
    }
    
    public override void Exit()
    {
        base.Exit();
    }
    
    public override void Update()
    {
        base.Update();
    }
}
