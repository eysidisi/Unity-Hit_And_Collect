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

    protected Character character;
    protected STATE_EVENT stage;
    State(Character character)
    {
        this.character = character;
        stage = STATE_EVENT.ENTER;
    }



}
