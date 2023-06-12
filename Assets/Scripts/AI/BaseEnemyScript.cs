using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemyScript : MonoBehaviour
{
    public float speed = 5f; // speed of enemy movement
    public float stoppingDistance = 1f; // distance from player to stop moving
    public Transform player; // reference to player's transform

    private NavMeshAgent navMeshAgent;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        /*navMeshAgent.updateRotation = false;
        navMeshAgent.updatePosition = false;*/
    }

    void Start()
    {
        // find the player object using tag
    }

    void Update()
    {
        navMeshAgent.destination = player.position;

        /*// check if player is within stopping distance
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            // move towards the player
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }*/
    }
}