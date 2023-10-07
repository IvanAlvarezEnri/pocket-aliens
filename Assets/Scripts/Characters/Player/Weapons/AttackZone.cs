using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    [SerializeField]private Weapon weapon;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<Entity>())
        {
            if (gameObject.tag == "Player" && collision.gameObject.tag == "Enemy"){
                collision.gameObject.GetComponent<Entity>().GetDamaged(weapon.damage);
            }
            else if (gameObject.tag == "Enemy" && collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Entity>().GetDamaged(weapon.damage);
            }
        }
    }
}
