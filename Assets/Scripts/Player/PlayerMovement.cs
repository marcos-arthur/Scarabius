using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 5f; // The speed the player moves
    Rigidbody2D rb; // Reference to the Rigidbody2D component
    public float shotDelay = 0.25f;
    public float timeSinceLastShot;
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component on this object
    }

    private void Update()
    {
        // Get the horizontal and vertical input axis values (left/right arrow and up/down arrow keys)
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate the movement vector based on the input values and the moveSpeed
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        if (movement.magnitude > 1) movement.Normalize();
        movement *= moveSpeed;


        if (movement != Vector2.zero) rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);

        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot > shotDelay)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 0));
                timeSinceLastShot = 0;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 180));
                timeSinceLastShot = 0;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 90));
                timeSinceLastShot = 0;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, -90));
                timeSinceLastShot = 0;
            }
        }



    }
}


