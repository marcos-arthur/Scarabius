using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private int health = 5;
    [SerializeField] public int damage { get; private set; }
    [SerializeField] private float speed = 3.5f; // speed of enemy movement
    [SerializeField] private float stopRange = 5f; // distance from player to stop moving
    [SerializeField] private float attackRange = 5f; // distance from player to stop moving
    [SerializeField] private float cooldown = 1.5f;

    [Header("References")]
    [SerializeField] private Transform player; // reference to player's transform
    [SerializeField] private GameObject spriteObject;
    
    private Animator spriteAnimator;
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
        navMeshAgent.updateRotation = false;


        player = GameObject.FindGameObjectWithTag("Player").transform;

        if(spriteObject != null)
        {
            spriteObject.transform.rotation = Quaternion.Euler(90, 0, 0);

            spriteAnimator = spriteObject.GetComponent<Animator>();
        }
    }

    void Update()
    {
        bool isSteeringPlayer = navMeshAgent.steeringTarget.x.ToString("#.##") == player.position.x.ToString("#.##") && navMeshAgent.steeringTarget.y.ToString("#.##") == player.position.y.ToString("#.##");
        if (isSteeringPlayer)
        {
            navMeshAgent.stoppingDistance = stopRange;
            inRange = navMeshAgent.remainingDistance <= attackRange ? true : false;

           /* print($"Remaning: {navMeshAgent.remainingDistance}");
            print($"Stopping: {navMeshAgent.stoppingDistance}");*/
            if (Vector3.Distance(transform.position, player.position) <= navMeshAgent.stoppingDistance)
            {
                spriteAnimator.SetBool("isWalking", false);
            }
            else
            {
                spriteAnimator.SetBool("isWalking", true);
            }
        }
        else
        {
            navMeshAgent.stoppingDistance = 0;
            spriteAnimator.SetBool("isWalking", true);
        }

        navMeshAgent.destination = player.position;
    }

    public void TakeDamage(int damage)
    {
        print($"damage: {damage}");
        health -= damage;

        if(health <= 0)
        {
            // todo: death

            Destroy(gameObject);
        }
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
}