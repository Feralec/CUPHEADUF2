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

    public override void Execute()
<<<<<<< HEAD
    {
        //MonoBehaviour.print(GameManager.GInstance.playerHealth);
    }
=======
    {    }
>>>>>>> 7dabf8cdca4cd4ac3c2d7bcb32d901124f24a919

    public override void FixedExecute()
    {
    }
}
