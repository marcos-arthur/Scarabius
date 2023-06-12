using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class RangedEnemyController : MonoBehaviour
{
    EnemyController enemyController;
    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        attack();
    }

    void attack()
    {
        if (!enemyController.inCooldown && enemyController.inRange)
        {
            print("attack");

            StartCoroutine(enemyController.attackCooldown());
        }
    }
}
