using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : CharacterStates
{
    protected PlayerController player;
    protected Animator anim;
    protected GameManager gm;

    public PlayerStates(PlayerController p)
    {
        player = p;
        anim = player.GetComponent<Animator>();
    }

    public override void CheckTransitions()
    {
    }

    public override void Execute()
    {
    }

    public override void FixedExecute()
    {
    }
}
