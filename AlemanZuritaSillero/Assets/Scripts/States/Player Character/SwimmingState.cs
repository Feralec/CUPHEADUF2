using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingState : JumpingState
{
    public OnWaterState onWaterState;
    public enum OnWaterState //pongo dos sub-estados del agua, para que pueda saltar si está en la superfície, pero sólo en esta
    {
        SURFACE,DEEP,NONE
    }
    public SwimmingState(PlayerController p,OnWaterState ows) : base(p)
    {
        this.onWaterState = ows;
    }

    public override void OnStart()
    {
        anim.SetBool("isJumping", true);
        limiter = player.pm.jumpingHorizontalLimiter; //más que nada por si añado un limitador diferente para el agua
    }
    public override void Execute()
    {
        base.Execute();
        MonoBehaviour.print("uy que daño");
    }
    public override void FixedExecute()
    {
        base.FixedExecute();

        switch (ows)
        {
            case OnWaterState.DEEP:
                break;
            case OnWaterState.SURFACE:
                if (Input.GetButtonDown("Jump"))
                    rb.AddForce(new Vector2(0, player.pm.jumpImpulse), ForceMode2D.Impulse);
                break;
        }
    }
    public override void outOfTrigger(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeepWater")
            ows = OnWaterState.SURFACE;
        if (collision.gameObject.tag == "WaterSurface" && ows == OnWaterState.SURFACE) //esto hace que, si sale del agua hacia arriba, pase a ser salto, y si no, sigue en el agua
            ows = OnWaterState.NONE;
    }
    public override void CheckTransitions()
    {
        if (gm.playerHealth <= 0)
            player.ChangeState(new DeathState(player));
        else if (ows == OnWaterState.NONE)
            player.ChangeState(new JumpingState(player));
    }
}
