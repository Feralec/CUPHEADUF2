using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerModel", menuName = "Original/Player Model")]
public class PlayerModel : ObjectModel
{
    public float horizontalSpeed, jumpImpulse, jumpingHorizontalLimiter, shootExitTime, downWardCastDistance;
    public LayerMask groundLayer;
    public CharacterStates currentState;
}
