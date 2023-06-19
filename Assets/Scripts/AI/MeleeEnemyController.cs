using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class MeleeEnemyController : MonoBehaviour
{
    EnemyController enemyController;
    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponent<EnemyController>();
    }

    void attack(PlayerController Player)
    {
        if (!enemyController.inCooldown && enemyController.inRange)
        {
            Player.damagePlayer(enemyController.damage);
            StartCoroutine(enemyController.attackCooldown());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("PlayerHitBox"))
        {
            attack(collision.gameObject.GetComponentInParent<PlayerController>());
        }
    }
}
