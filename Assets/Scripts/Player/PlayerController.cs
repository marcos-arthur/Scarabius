using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{

    /*------------------------PUBLIC------------------------*/

    Rigidbody2D rb; // Reference to the Rigidbody2D component    
    Animator animator;
    public GameObject bulletPrefab; // Reference to the Bullet
    public Transform firePoint; // Reference to the player position

    [SerializeField] public Image[] heart;
    public Sprite full;
    public Sprite empty;


    /*------------------------PRIVATE-----------------------*/

    // Static Values
    [SerializeField] private double shotDelay, timeSinceLastShot;
    [SerializeField] GameController gameController;

    // Changeable Values
    [SerializeField] private int bulletsInChamber, maxBullets;
    [SerializeField] private int hearts,maxHearts;
    private bool invincible,isSpaceDown;
    private ItemCompendium.ItemData collectedItem;
    private CollectibleItem itemScript;
    private float bTimer;


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
        hearts = 3;
        maxHearts = 3;
        moveSpeed = 5f;
        shotDelay = 0.25f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();



        // Starting Mutipliers
        resistance = 1;
        attackSpeed = 1;
        bulletsOutput = 1;

    }

    private void Start()
    {
        gameController = GameController.Instance;
        invincible = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Trap"))
        {
            this.damagePlayer(1);
        }
        if (isSpaceDown)
        {
            Debug.Log("Voc� apertou espa�o");
            if (collision.gameObject.tag.Equals("Chest"))            
            {
                gameController.openChest(collision.gameObject);
            }
            else if (collision.gameObject.tag.Equals("Item"))
            {
                this.collectItem(collision.gameObject);
            }
            
        }
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (!gameController.gameOver)
        {
            HealthLogic();

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

                if (horizontalInput > 0)
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
                }
            }
            isSpaceDown = Input.GetKeyDown(KeyCode.Space);
            if (isSpaceDown)
            {
                bTimer += Time.deltaTime;
                if (bTimer > 0.3)
                {
                    isSpaceDown = false;
                }
            }
            else
            {
                bTimer = 0;
            }
            if (Input.GetKeyDown(KeyCode.F) && collectedItem.ID != -1)
            {
                useItem();
            }
        }
    }
    void HealthLogic()
    {

        if (hearts > maxHearts)
        {
            hearts = maxHearts;
        }

        for (int i = 0; i < heart.Length; i++)
        {
            if (i < hearts)
            {
                heart[i].sprite = full;
            }
            else
            {
                heart[i].sprite = empty;
            }

            if (i < maxHearts)
            {
                heart[i].enabled = true;
            }
            else
            {
                heart[i].enabled = false;
            }
        }
    }

    // Method for applying the determined changes depending on used item
    void useItem()
    {
        if (collectedItem.ID == 0) // Max Bullets Buff
        {
            maxBullets++;
        }
        else if (collectedItem.ID == 1) // Move Speed Buff
        {
            moveSpeed += 2;
        }
        else if (collectedItem.ID == 2) // Max Health Buff
        {
            maxHearts += 1;
        }
        else if (collectedItem.ID == 3) // Health Potion
        {
            if (hearts < maxHearts) hearts += 1;
        }
        else if (collectedItem.ID == 4) // Resistance Buff
        {
            if (resistance >= 0.05) resistance -= 0.05;
        }
        else if (collectedItem.ID == 5) // Attack Speed Buff
        {
            attackSpeed += 0.05;
        }
        else if (collectedItem.ID == 6) // Bullets Output Buff
        {
            bulletsOutput *= 2;
        }
        else if (collectedItem.ID == 7) // Reflecting Attacks Consumable
        {
            reflectingTimer = 120f;
        }
        else if (collectedItem.ID == 8) // Invisibility Consumer
        {
            invisibleTimer = 120f;
        }
        else if (collectedItem.ID == 9) // Shield Consumable
        {
            resistantTimer = 120f;
            if ((resistance - 0.5) >= 0.05) resistance -= 0.5;
            else resistance -= 0.5 - (resistance - 0.55);
        }
        collectedItem = new ItemCompendium.ItemData("NULL",-1,"NULL");
        Debug.Log("Usei um Item");
    }
    void damagePlayer(int damage)
    {
        if (!invincible)
        {
            hearts -= damage;           
            if (hearts <= 0)
            {
                gameController.gameOver = true;
            }
            StartCoroutine(StartInvincible());
        }
    }
    void collectItem(GameObject item)
    {
        itemScript = item.GetComponent<CollectibleItem>();
        collectedItem = itemScript.currentItem;
        Debug.Log("Coletei um Item");
    }
    private IEnumerator StartInvincible()
    {
        invincible = true;
        yield return new WaitForSeconds(1f);
        invincible = false;
    }
}
