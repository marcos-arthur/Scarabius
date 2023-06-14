using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private int health = 5;
    [SerializeField] private float speed = 3.5f; // speed of enemy movement
    [SerializeField] private float stopRange = 5f; // distance from player to stop moving
    [SerializeField] private float attackRange = 5f; // distance from player to stop moving
    [SerializeField] private float cooldown = 1.5f;

    [Header("References")]
    [SerializeField] private Transform player; // reference to player's transform
    [SerializeField] private GameObject spriteObject;

    private NavMeshAgent navMeshAgent;
    
    public bool inRange;
    public bool inCooldown = false;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        navMeshAgent.speed = speed;
        navMeshAgent.stoppingDistance = stopRange;

        spriteObject.transform.rotation = Quaternion.Euler(90, 0, 0);

        player = GameObject.FindGameObjectWithTag("Player").transform;

        if(spriteObject != null)
        {
            /*spriteObject.transform.position = new Vector3(spriteObject.transform.position.x, spriteObject.transform.position.y, 0);*/
        }
    }

    void Update()
    {
        bool isSteeringPlayer = navMeshAgent.steeringTarget.x.ToString("#.##") == player.position.x.ToString("#.##") && navMeshAgent.steeringTarget.y.ToString("#.##") == player.position.y.ToString("#.##");
        if (isSteeringPlayer)
        {
            navMeshAgent.stoppingDistance = stopRange;
            inRange = navMeshAgent.remainingDistance <= attackRange ? true : false;
        }
        else
        {
            navMeshAgent.stoppingDistance = 0;
        }

        navMeshAgent.destination = player.position;
    }

    public Vector3 GetPlayerPosition()
    {
        if(player != null)
        {
            return player.position;
        }
        else 
        {
            Debug.LogError("IS NOT POSSIBLE TO HAVE A NULL PLAYER");
            return Vector3.zero;
        }
    }

    public IEnumerator attackCooldown()
    {
        inCooldown = true;
        yield return new WaitForSeconds(cooldown);
        inCooldown = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }
}