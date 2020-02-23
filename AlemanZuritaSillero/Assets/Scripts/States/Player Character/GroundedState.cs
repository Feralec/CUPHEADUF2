using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : PlayerStates
{
    protected float h; //los hago protected por si el shooting state lo hereda, si es que hago shooting state
    protected Rigidbody2D rb; 
    protected SpriteRenderer spr;
    protected bool shooting;
    protected LayerMask myLayer;

    public GroundedState(PlayerController p) : base(p)
    {
        rb = player.GetComponent<Rigidbody2D>();
        spr = player.GetComponent<SpriteRenderer>();
        myLayer = player.pm.groundLayer;
    }

    public override void OnStart()
    {
        anim.SetBool("isJumping", false);
        shooting = false;
    }
    public override void OnFinish()
    {
        base.OnFinish();
    }

    public override void CheckTransitions()
    {
        /* RaycastHit2D[] hitResults = new RaycastHit2D[2];
         if (rb.Cast(new Vector2(0, -1), hitResults, 0.1f) == 0)
             player.ChangeState(new JumpingState(player));*/
        if (GameManager.GInstance.playerHealth <= 0)
            player.ChangeState(new DeathState(player));
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, player.pm.downWardCastDistance,myLayer);
            if (hit.collider == null)
                player.ChangeState(new JumpingState(player));
            if (shooting)
                player.ChangeState(new ShootingState(player));
        }
    }

    public override void Execute()
    {
        IWantShootToInheritThis();
        IDontWantShootToInheritThis();
    }

    public void IWantShootToInheritThis()
    {
        h = Input.GetAxis("Horizontal");
        anim.SetFloat("absSpeed", Mathf.Abs(h));

        if (h < 0)
            spr.flipX = true;
        else if (h > 0)
            spr.flipX = false;
    }
    public void IDontWantShootToInheritThis()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            shooting = true;
        }
    }

    public override void FixedExecute()
    {
        if (Input.GetButtonDown("Jump"))
            rb.AddForce(new Vector2(0, player.pm.jumpImpulse), ForceMode2D.Impulse);

        rb.velocity = new Vector2(h * player.pm.horizontalSpeed, rb.velocity.y);
    }
}
