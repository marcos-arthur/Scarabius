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
            // todo: player take damage 

            Destroy(gameObject);
        }
        else if(!isFromEnemy && collision.tag.Equals("EnemyHitbox"))
        {
            // todo: enemy take damage 
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
