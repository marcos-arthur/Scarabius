using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    // Controllers
    int generator;
    SpriteRenderer aux;
    private CollectibleItem itemScript;
    public bool gameOver;


    // Final Variables    
    public static GameController Instance { get; private set; }
    private List<Scene> maps;
    private ItemCompendium compendium;

    // Changeable Variables
    private GameObject[] ChestsSP;    
    private GameObject map, newMap, newItem, newChest;
    private List<GameObject> enemiesLeft;

    // Prefabs
    public GameObject chest,item;


    // Lists Of Possible Sprites

    public List<Sprite> traps, enemies, obstacles;

    // Lists of Possible Spawn Points

    private void Awake()
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
        gameOver = false;
        maps = new List<Scene>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Scene scene;
        compendium = ItemCompendium.Instance;
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings;i++)
        {
            scene = SceneManager.GetSceneByBuildIndex(i);
            if (scene.name.Contains("Level")) maps.Add(scene);
        }
        
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
       /* Debug.Log(playerItems[0].Name + " " + playerItems[0].Description +" "+  playerItems[0].ID) ;
        Debug.Log(playerItems[1].Name + " " + playerItems[1].Description + " " + playerItems[1].ID);*/
    }

    void generateMap()
    {
        generator = Random.Range(0, maps.Count);
        SceneManager.LoadScene(maps[generator].ToString());
        maps.Remove(maps[generator]);
        map = GameObject.FindWithTag("Map");
        ChestsSP = GameObject.FindGameObjectsWithTag("ChestSpawnPoint");

        /*
        generator = Random.Range(0, maps.Count);
        newMap = Instantiate(newMap, new Vector3(0, 0, 0), Quaternion.identity);
        aux = newMap.GetComponent<SpriteRenderer>();
        aux.sprite = maps[generator];
        */
        generateChests();
    }
    void generateChests()
    {
        foreach (GameObject chestSP in ChestsSP)
        {
            generator = Random.Range(0, 1);
            if (generator == 1)
            {
                newChest = Instantiate(chest, chestSP.transform.position, Quaternion.identity);
                newChest.transform.SetParent(map.transform);
            }
        }
    }
    public void openChest(GameObject chest)
    {        
        newItem = Instantiate(item, new Vector3(chest.transform.position.x, chest.transform.position.y,transform.position.z), Quaternion.identity);
        generator = Random.Range(0, compendium.itemGlossary.Count);
        aux = newItem.GetComponent<SpriteRenderer>();
        itemScript = newItem.GetComponent<CollectibleItem>();
        aux.sprite = compendium.sprites[generator];
        itemScript.currentItem = compendium.itemGlossary[generator];
        Destroy(chest);
    }

}
