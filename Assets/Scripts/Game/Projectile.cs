using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool isFromEnemy = true;
    [field: SerializeField] public int damage { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (isFromEnemy && collision.tag.Equals("PlayerHitBox"))
        {
            collision.gameObject.GetComponentInParent<PlayerController>().damagePlayer(damage);
            Destroy(gameObject);
        }
        else if(!isFromEnemy && collision.tag.Equals("EnemyHitbox"))
        {
            collision.gameObject.GetComponentInParent<EnemyController>().TakeDamage(damage);
            Destroy(gameObject);
        }
        
        if (collision.tag.Equals("Wall"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
