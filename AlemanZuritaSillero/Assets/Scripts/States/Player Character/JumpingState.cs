using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SwimmingState;

public class JumpingState : PlayerStates
{
    protected float h, limiter;
    protected Rigidbody2D rb;
    protected OnWaterState ows;

    public JumpingState(PlayerController p) : base(p)
    {
        rb = player.GetComponent<Rigidbody2D>();
    }
    public override void OnStart()
    {
        anim.SetBool("isJumping", true);
        limiter = player.pm.jumpingHorizontalLimiter;
        ows = OnWaterState.NONE;
    }
    public override void OnFinish()
    {
        base.OnFinish();
    }

    public override void CheckTransitions()
    {
        /*RaycastHit2D[] hitResults = new RaycastHit2D[2];
        if (rb.Cast(Vector2.down, hitResults, 0.1f) > 0)
            player.ChangeState(new GroundedState(player));
            */
        //uso raycast en vez de rb.Cast para que pueda detectar el suelo
        if (health <= 0)
            player.ChangeState(new DeathState(player));
        else {
            RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, player.pm.downWardCastDistance, player.pm.groundLayer);
            if (hit.collider != null)
                player.ChangeState(new GroundedState(player));
            RaycastHit2D hit2 = Physics2D.Raycast(rb.position, Vector2.down, player.pm.downWardCastDistance, player.pm.platformLayer);
            if (hit2.collider != null)
                player.ChangeState(new OnPlatformState(player, hit2.collider.gameObject.transform));
            if (ows != OnWaterState.NONE)
                player.ChangeState(new SwimmingState(player, ows));
            }
        
    }

    public override void Execute()
    {
        h = Input.GetAxis("Horizontal");
    }

    public override void FixedExecute()
    {
        rb.velocity = new Vector2(h * player.pm.horizontalSpeed * limiter, rb.velocity.y);
    }
    public override void intoTrigger(Collider2D collision)
    {
        if (collision.gameObject.tag == "WaterSurface")
            ows = OnWaterState.SURFACE;
        /*else if (collision.gameObject.tag == "DeepWater") //esto no hace falta pero lo mantengo aquí comentado por si acaso
            ows = OnWaterState.DEEP;*/
    }
}
