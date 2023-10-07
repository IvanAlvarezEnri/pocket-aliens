using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected GameObject player;

    protected bool attacking;
    public float attackCooldown;
    public int damage;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Attack()
    {
        if (attacking) {
            return;
        }

        attacking = true;

        AttackEffect();
        Invoke("StopAttack", attackCooldown);
    }

    protected virtual void AttackEffect()
    {

    }

    private void StopAttack()
    {
        attacking = false;
    }
}
