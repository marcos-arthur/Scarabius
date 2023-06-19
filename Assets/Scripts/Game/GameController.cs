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
    private List<string> mapsPointer =  new List<string>{ "1", "2", "3", "4", "5" };

    // Changeable Variables
    private GameObject[] ChestsSP, enemiesLeft;    
    [SerializeField] private GameObject map, newMap, newItem, newChest;
    [SerializeField] public GameObject lockedDoor;

    // Prefabs
    public GameObject chest,item;
    public List<GameObject> enemies;

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
        compendium = ItemCompendium.Instance;
        /* Scene scene;
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings;i++)
        {
            scene = SceneManager.GetSceneByBuildIndex(i);
            if (scene.name.Contains("Level_")) maps.Add(scene);
            Debug.Log(scene.name);
            Debug.Log(maps.Count);
        }*/

        loadMap();
        
    }

    // Update is called once per frame
    void Update()
    {
        print($"AQUI {lockedDoor.activeSelf}");
        if (!enemiesLeft.IsUnityNull() && enemiesLeft.Length > 0)
        {
            enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy");
        }
        else if (lockedDoor.activeSelf == false)
        {
            openDoor();
        }
    }
    void generateMap(Scene scene, LoadSceneMode mode)
    {
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy");
        /*lockedDoor = GameObject.FindGameObjectWithTag("LockedDoor");
        print($"lockedDoor{lockedDoor}");
        lockedDoor.SetActive(false);*/
        map = GameObject.FindGameObjectWithTag("Map");
        ChestsSP = GameObject.FindGameObjectsWithTag("ChestSpawnPoint");
        generateChests();
    }

    public void loadMap()
    {
        if(mapsPointer.Count <= 0)
        {
            gameOver = true;
        }
        generator = Random.Range(1, mapsPointer.Count) - 1;
        SceneManager.LoadScene("Level_" + mapsPointer[generator]);
        mapsPointer.Remove(mapsPointer[generator]);
        SceneManager.sceneLoaded += generateMap;
    }
    void generateChests()
    {
        foreach (GameObject chestSP in ChestsSP)
        {
            generator = Random.Range(0, 2);                        
            if (generator == 1)
            {
                newChest = Instantiate(chest, chestSP.transform.position, Quaternion.identity);
                //newChest.transform.SetParent(map.transform);
            }
        }
    }
    public void openChest(GameObject chest)
    {     
        newItem = Instantiate(item, chest.transform.position, Quaternion.identity);
        generator = Random.Range(0, compendium.itemGlossary.Count);
        aux = newItem.GetComponent<SpriteRenderer>();
        itemScript = newItem.GetComponent<CollectibleItem>();
        aux.sprite = compendium.sprites[generator];        
        itemScript.currentItem = compendium.itemGlossary[generator];
        Destroy(chest);
    }
    void openDoor()
    {
        lockedDoor.SetActive(true);
    }
}
