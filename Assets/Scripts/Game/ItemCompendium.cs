using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemCompendium : MonoBehaviour
{
    public static ItemCompendium Instance{ get; private set; }
    public List<ItemCompendium.ItemData> itemGlossary;
    
    public struct ItemData
    {
        public int ID;
        public string Name;
        public string Description;
        public ItemData(string name, int id, string description)
        {
            ID = id;
            Name = name;
            Description = description;
         }

    }

    void Awake()
    {

        if (Instance != null && Instance != this)
        {

            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

        ItemData item = new("Extra Slot", 0, "Increases the amount of maximum bullets you can shoot before reloading");
        ItemData item2 = new ItemData("Speed Cola", 1, "Increases the move spped of your character");
        ItemData item3 = new ItemData("Health Elixir", 2, "Cures wounds");
        ItemData item4 = new ItemData("Suvivor's Skillbook", 3, "Increases max health");
        ItemData item5 = new ItemData("Elixir of Hardening", 4, "Increases player resistance to damage");
        ItemData item6 = new ItemData("Shooter's Skillbook", 5, "Increases the bullet shooting speed");
        ItemData item7 = new ItemData("Double Tap", 6, "Increases the bullet amount output");
        ItemData item8 = new ItemData("Animated Shield", 7, "spawns a shield around you that moves around and reflects projectiles");
        ItemData item9 = new ItemData("Ilusionist Cola", 5, "Makes the player invisible for 2 minutes");
        ItemData item10 = new ItemData("Unbreakable Cola", 5, "Increases the player damage resistance by 50% for 2 minutes");
        itemGlossary = new List<ItemData>{item, item2, item3, item4, item5, item6, item7, item8, item9, item10 };

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
