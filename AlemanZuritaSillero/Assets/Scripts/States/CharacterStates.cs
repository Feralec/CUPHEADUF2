﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStates
{
    protected PlayerController player;
    public CharacterStates (PlayerController p)
    {
        player = p;
    }
    public abstract void Execute();
    public abstract void CheckTransitions();
    public abstract void FixedExecute();

    public virtual void OnStart() { } 
    public virtual void OnFinish() { }
    public virtual void OnTriggerEnter(Collider2D collision) { }
    public virtual void OnTriggerExit(Collider2D collision) { }
}
