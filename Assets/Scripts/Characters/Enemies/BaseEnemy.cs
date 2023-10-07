using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : Entity
{
    public override void GetDamaged(int damage)
    {
        hp -= damage;
        Debug.Log(hp);
    }
}
