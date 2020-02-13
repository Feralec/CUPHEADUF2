using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlatformState : GroundedState
{
    private Transform parentPlatform;
    public OnPlatformState(PlayerController p, Transform dad) : base(p)
    {
        parentPlatform = dad;
        myLayer = player.pm.platformLayer;
    }

    public override void OnStart()
    {
        player.transform.parent = parentPlatform;
        base.OnStart();
    }
    
    public override void OnFinish()
    {
        if (!shooting)
            player.transform.parent = null;
        base.OnFinish();
    }
}
