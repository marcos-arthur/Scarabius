using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(EnemyController))]
public class MeleeEnemyController : MonoBehaviour
{
    EnemyController enemyController;
    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponent<EnemyController>();
    }

    void attack()
    {
        if (!enemyController.inCooldown && enemyController.inRange)
        {
            print("attack");
            // todo: deal damage in player

            StartCoroutine(enemyController.attackCooldown());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            attack();
        }
    }
}
