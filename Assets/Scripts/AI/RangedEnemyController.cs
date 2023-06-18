using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(EnemyController))]
public class RangedEnemyController : MonoBehaviour
{
    EnemyController enemyController;

    [Header("Values")]
    [SerializeField] private float shootingPower = 5f;

    [Header("References")]
    [SerializeField] private Projectile ProjectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponent<EnemyController>();
        ProjectilePrefab.GetComponent<Projectile>().damage = enemyController.damage;

        if(ProjectilePrefab != null )
        {
            ProjectilePrefab.isFromEnemy = true;
        }
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
            Projectile projectile = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
            Vector2 direction = enemyController.GetPlayerPosition() - transform.position;
            projectile.GetComponent<Rigidbody2D>().velocity = direction * shootingPower;

            StartCoroutine(enemyController.attackCooldown());
        }
    }
}
