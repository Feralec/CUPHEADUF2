using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : GroundedState
{
    public float exitTime;
    private float timeCount=0f;
    public ShootingState(PlayerController p) : base(p)
    {
    }
    public override void OnStart()
    {
        anim.SetBool("isShooting",true);
        exitTime = player.pm.shootExitTime;
        base.OnStart();
    }
    public override void Execute()
    {
        IWantShootToInheritThis();
        timeCount += Time.deltaTime;
        if (timeCount >= exitTime)
        {
            player.ChangeState(new GroundedState(player));
        }
    }
    public override void OnFinish()
    {
        anim.SetBool("isShooting", false);
        base.OnFinish();
    }
}
