using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStates
{
    public CharacterStates ()
    {
    }
    public abstract void Execute();
    public abstract void CheckTransitions();
    public abstract void FixedExecute();

    public virtual void OnStart() { } 
    public virtual void OnFinish() { }
    public virtual void intoTrigger(Collider2D collision) { }
    public virtual void outOfTrigger(Collider2D collision) { }
}
