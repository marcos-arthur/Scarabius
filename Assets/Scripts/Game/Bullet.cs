using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float impulseForce = 100f; // set the desired impulse force in the inspector
    public float lifetime = 2f; // set the desired lifetime in the inspector
                                // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * impulseForce, ForceMode2D.Impulse);
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
