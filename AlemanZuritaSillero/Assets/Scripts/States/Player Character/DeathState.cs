using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : PlayerStates
{
    public DeathState(PlayerController p) : base(p)
    {
    }
    public override void OnStart()
    {
        anim.SetTrigger("isDead");
    }

    public override void CheckTransitions()
    {
    }

    public override void FixedExecute()
    {
    }
}
