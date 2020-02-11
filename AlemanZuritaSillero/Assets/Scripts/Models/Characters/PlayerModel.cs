using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerModel", menuName = "Original/Characters/Player Model")]
public class PlayerModel : ObjectModel
{
    public float jumpImpulse, jumpingHorizontalLimiter, shootExitTime, downWardCastDistance, health;
    public LayerMask groundLayer;
    public CharacterStates currentState;
    public GameObject shot;
}
