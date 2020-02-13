using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlatformState : GroundedState
{
    private Transform parentPlatform;
    public OnPlatformState(PlayerController p, Transform dad) : base(p)
    {
        parentPlatform = dad;
    }

    public override void OnStart()
    {
        player.transform.parent = parentPlatform;
        base.OnStart();
    }
    public override void OnFinish()
    {
        player.transform.parent = null;
        base.OnFinish();
    }
}
