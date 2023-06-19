using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectorPlayerController : MonoBehaviour
{
    private GameController controller;
    private PlayerController playerController;

    [SerializeField] private bool isSpaceDown;

    private float bTimer;

    private bool isAboveChest;
    private GameObject chest;

    private bool isAboveItem;
    private GameObject item;

    private bool isAboveDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Item"))
        {
            Debug.Log("Você colidiu com um item");
            isAboveItem = true;
            item = collision.gameObject;
        }

        if (collision.gameObject.tag.Equals("Chest"))
        {
            Debug.Log("Você colidiu com um bau");
            isAboveChest = true;
            chest = collision.gameObject;
        }

        if (collision.gameObject.tag.Equals("LockedDoor"))
        {
            Debug.Log("Você colidiu com a porta");
            isAboveDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Item"))
        {
            Debug.Log("Você saiu de um item");
            isAboveItem = false;
            item = null;
        }

        if (collision.gameObject.tag.Equals("Chest"))
        {
            Debug.Log("Você saiu de um bau");
            isAboveChest = false;
            chest = null;
        }

        if (collision.gameObject.tag.Equals("LockedDoor"))
        {
            Debug.Log("Você saiu de um porta");
            isAboveDoor = false;
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
            if (Input.GetKeyDown("space"))
            {
                if (isAboveItem) { playerController.collectItem(item); }
                else if (isAboveChest) { controller.openChest(chest); }
                else if (isAboveDoor) { controller.loadMap(); }
            }
        }
    }
}
