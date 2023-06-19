using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CollectibleItem : MonoBehaviour
{

    public TextMeshProUGUI info;

    private GameController gameController;
    private ItemCompendium compendium;

    public int randomID;

    public int itemID;
    public string itemName = "Test";
    public string itemDescription = "Testing bro";
    public bool collected = false;

    
    public ItemCompendium.ItemData currentItem;

    // Start is called before the first frame update

    /*public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collected = true;
            Update();
            Debug.Log(collected.ToString());
            info.text = itemName + "\n\n" + itemDescription;

            // Destroy the collectible item
            Destroy(gameObject);
        }
    }*/
    void Start()
    {
        compendium = ItemCompendium.Instance;
        gameController = GameController.Instance;

        randomID = Random.Range(0, compendium.itemGlossary.Count);

        itemName = ItemCompendium.Instance.itemGlossary[randomID].Name;
        ItemCompendium.ItemData currentItem = new(ItemCompendium.Instance.itemGlossary[randomID].Name, ItemCompendium.Instance.itemGlossary[randomID].ID, ItemCompendium.Instance.itemGlossary[randomID].Description);


        itemName = currentItem.Name;
        itemDescription = currentItem.Description;
        itemID = currentItem.ID;




        //Debug.Log(ItemCompendium.Instance.testeCoisa);

    }

     void Update()
    {
        /*if(collected == true)
        {
            ItemCompendium.ItemData currentItem = new(ItemCompendium.Instance.itemGlossary[randomID].Name, ItemCompendium.Instance.itemGlossary[randomID].ID, ItemCompendium.Instance.itemGlossary[randomID].Description);


            //gameController.playerItems.Add(currentItem);
            
            collected = false;
        }*/
    }

    
    // Update is called once per frame




}
