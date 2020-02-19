using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerModel", menuName = "Original/Characters/Player Model")]
public class PlayerModel : ObjectModel
{
    public float jumpImpulse, jumpingHorizontalLimiter, shootExitTime, downWardCastDistance;
    public LayerMask groundLayer,platformLayer;
    public CharacterStates currentState;
    public GameObject shot;
}
