using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectorPlayerController : MonoBehaviour
{
    private GameController controller;
    private PlayerController playerController;

    private bool isSpaceDown;
    private float bTimer;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isSpaceDown)
        {
            if (collision.gameObject.tag.Equals("Item"))
            {
                Debug.Log("Você colidiu com um item");
                playerController.collectItem(collision.gameObject);
            }
            else if (collision.gameObject.tag.Equals("Chest"))
            {
                Debug.Log("Você colidiu com um bau");
                controller.openChest(collision.gameObject);

            }
            else if (collision.gameObject.tag.Equals("LockedDoor"))
            {
                Debug.Log("Você colidiu com a porta");
                controller.loadMap();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GameController.Instance;
        playerController = gameObject.GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!controller.gameOver)
        {
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
        }
    }
}
