using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "bulletModel", menuName = "Original/Projectiles/Bullet")]
public class BulletModel : ObjectModel
{
    public float maxTimeOnScreen;
    public int damage;
}
