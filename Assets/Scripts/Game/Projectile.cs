using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool isFromEnemy = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals(isFromEnemy ? "PlayerHitBox" : "EnemyHitbox"))
        {
            // TODO
            print("Dano");

            Destroy(gameObject);
        }
        else if (collision.tag.Equals("Wall"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
