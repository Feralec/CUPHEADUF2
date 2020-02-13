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

    public override void CheckTransitions()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, player.pm.downWardCastDistance, player.pm.platformLayer);
        if (hit.collider == null)
            player.ChangeState(new JumpingState(player));
    }
    
    public override void OnFinish()
    {
        player.transform.parent = null;
        base.OnFinish();
    }
}
