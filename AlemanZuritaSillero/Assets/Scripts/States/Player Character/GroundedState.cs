using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : CharacterStates
{
    protected float h; //los hago protected por si el shooting state lo hereda, si es que hago shooting state
    protected Rigidbody2D rb; 
    protected Animator anim;
    protected SpriteRenderer spr;

    public GroundedState(PlayerController p) : base(p)
    {
        rb = player.GetComponent<Rigidbody2D>();
        anim = player.GetComponent<Animator>();
        spr = player.GetComponent<SpriteRenderer>();
    }

    public override void OnStart()
    {
        anim.SetBool("isJumping", false);
    }
    public override void OnFinish()
    {
        base.OnFinish();
    }

    public override void CheckTransitions()
    {
        RaycastHit2D[] hitResults = new RaycastHit2D[2];
        if (rb.Cast(new Vector2(0, -1), hitResults, 0.1f) == 0)
            player.ChangeState(new JumpingState(player)); //puedo dejarlo así, y así no tengo que hacer un cast diferente en OnPlatformState
        //pero, si veis que da problemas, usad el código de abajo, y el mismo para OnPlatformState pero con platformLayer en vez de groundLayer
        /*RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, player.pm.downWardCastDistance,player.pm.groundLayer);
        if (hit.collider == null)
            player.ChangeState(new JumpingState(player));*/
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
            player.ChangeState(new ShootingState(player));
        }
    }

    public override void FixedExecute()
    {
        if (Input.GetButtonDown("Jump"))
            rb.AddForce(new Vector2(0, player.pm.jumpImpulse), ForceMode2D.Impulse);

        rb.velocity = new Vector2(h * player.pm.horizontalSpeed, rb.velocity.y);
    }


}
