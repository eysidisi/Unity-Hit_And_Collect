using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public enum STATE
    {
        ATTACK,
        AVOID
    }

    public enum STATE_EVENT
    {
        ENTER,
        UPDATE,
        EXIT
    }

    public State name;
    protected Character character;
    protected STATE_EVENT stage;
    protected State nextState;
    protected Color stateColor = Color.grey;

    public State(Character character)
    {
        this.character = character;
        stage = STATE_EVENT.ENTER;
    }

    public virtual void Enter()
    {
        character.SetStateColor(stateColor);
        stage = STATE_EVENT.UPDATE;
    }

    public virtual void Update()
    {
        stage = STATE_EVENT.UPDATE;
    }

    public virtual void Exit()
    {
        stage = STATE_EVENT.EXIT;
    }

    public State Process()
    {
        switch (stage)
        {
            case STATE_EVENT.ENTER:
                Enter();
                break;

            case STATE_EVENT.UPDATE:
                Update();
                break;

            case STATE_EVENT.EXIT:
                Exit();
                return nextState;

            default:
                break;
        }

        return this;
    }

}
