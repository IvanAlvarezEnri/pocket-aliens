using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardWeapon : Weapon
{
    [SerializeField] private BoxCollider2D attackZone;
    [SerializeField] private float attackTime;
    protected override void AttackEffect()
    {
        attackZone.enabled = true;
        Invoke("DisableZone", attackTime);
    }

    private void DisableZone()
    {
        attackZone.enabled = false;
    }
}
