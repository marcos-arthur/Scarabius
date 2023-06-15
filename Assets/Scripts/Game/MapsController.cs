using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapsBehaviour : MonoBehaviour
{
    // Controllers
    int generator;
    SpriteRenderer aux;

    // Final Variables
    private GameObject newMap,newItem;

    // Lists Of Possible Sprites

    public List<Sprite> maps, traps, enemies, obstacles, items;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void generateMap()
    {
        generator = Random.Range(0, maps.Count);
        newMap = Instantiate(newMap, new Vector3(0, 0, 0), Quaternion.identity);
        aux = newMap.GetComponent<SpriteRenderer>();
        aux.sprite = maps[generator];
    }
    void openChest(GameObject chest) {
        newItem = Instantiate(newItem, new Vector3(chest.transform.position.x, chest.transform.position.y+5),Quaternion.identity);
        generator = Random.Range(0, items.Count);
        aux = newItem.GetComponent<SpriteRenderer>();
        aux.sprite = items[generator];
    }
}
