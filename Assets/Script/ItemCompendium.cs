using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemCompendium : MonoBehaviour
{
    public static ItemCompendium Instance{ get; private set; }
    public List<ItemCompendium.ItemData> itemGlossary;
    

    public int testeCoisa = 15;
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

        ItemData item = new("Item1", 0, "ItemTestDescription1");
        ItemData item2 = new ItemData("Item2", 1, "ItemTestDescription2");
        ItemData item3 = new ItemData("Item3", 2, "ItemTestDescription3");
        ItemData item4 = new ItemData("Item4", 3, "ItemTestDescription4");
        ItemData item5 = new ItemData("Item5", 4, "ItemTestDescription5");
        itemGlossary = new List<ItemData>{item, item2, item3, item4, item5};

        testeCoisa = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
