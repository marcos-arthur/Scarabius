using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{

    /*------------------------PUBLIC------------------------*/

    Rigidbody2D rb; // Reference to the Rigidbody2D component    
    Animator animator;
    public GameObject bulletPrefab; // Reference to the Bullet
    public Transform firePoint; // Reference to the player position


    /*------------------------PRIVATE-----------------------*/

    // Static Values
    [SerializeField] private double shotDelay, timeSinceLastShot;

    // Changeable Values
    [SerializeField] private int bulletsInChamber, maxBullets;
    [SerializeField] private int hearts,maxHearts;

    // Mutipliers
    [SerializeField] private float moveSpeed;
    [SerializeField] private double resistance, attackSpeed, bulletsOutput;

    // Active Effects
    [SerializeField] private double reflectingTimer, invisibleTimer, resistantTimer;
    // Start is called before the first frame update
    void Awake()
    {
        // Starting Values
        maxBullets = 6;
        bulletsInChamber = 6;
        hearts = 8;
        maxHearts = 8;
        moveSpeed = 5f;
        shotDelay = 0.25f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


        // Starting Mutipliers
        resistance = 1;
        attackSpeed = 1;
        bulletsOutput = 1;

    }

    // Update is called once per frame
    private void Update()
    {
        // Get the horizontal and vertical input axis values (left/right arrow and up/down arrow keys)
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate the movement vector based on the input values and the moveSpeed
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        if (movement.magnitude > 1) movement.Normalize();
        movement *= moveSpeed;

        if (movement != Vector2.zero)
        {
            rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
            animator.SetBool("isWalking", true);

            if(horizontalInput > 0)
            {
                transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot > shotDelay)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 0));
                Projectile bulletController = bullet.GetComponent<Projectile>();

                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * 25f;
                bulletController.isFromEnemy = false;
                bulletController.damage = 1;

                timeSinceLastShot = 0;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 180));
                Projectile bulletController = bullet.GetComponent<Projectile>();
                
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0) * 25f;
                bullet.GetComponent<Projectile>().isFromEnemy = false;
                bulletController.damage = 1;

                timeSinceLastShot = 0;
            }
        }


        // Method for applying the detemrined changes depending on used item
        void useItem()
        {
            if (false) // Max Bullets Buff
            {
                maxBullets++;
            }
            else if (false) // Move Speed Buff
            {
                moveSpeed += 2;
            }
            else if (false) // Max Health Buff
            {
                maxHearts += 1;
            }
            else if (false) // Health Potion
            {
                if (hearts < maxHearts) hearts += 1;
            }
            else if (false) // Resistance Buff
            {
                if (resistance >= 0.05) resistance -= 0.05;
            }
            else if (false) // Attack Speed Buff
            {
                attackSpeed += 0.05;
            }
            else if (false) // Bullets Output Buff
            {
                bulletsOutput*=2;
            }
            else if (false) // Reflecting Attacks Consumable
            {
                reflectingTimer = 120f;
            }
            else if (false) // Invisibility Consumer
            {
                invisibleTimer = 120f;
            }
            else if (false) // Shield Consumable
            {
                resistantTimer = 120f;
                if ((resistance - 0.5) >= 0.05) resistance -= 0.5;
                else resistance -= 0.5 - (resistance - 0.55);
            }
        }
    }
}
