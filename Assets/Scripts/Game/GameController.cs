using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    public List<ItemCompendium.ItemData> playerItems;
    // Start is called before the first frame update
    void Start()
    {

        playerItems = new List<ItemCompendium.ItemData>() {}; 
        
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
       /* Debug.Log(playerItems[0].Name + " " + playerItems[0].Description +" "+  playerItems[0].ID) ;
        Debug.Log(playerItems[1].Name + " " + playerItems[1].Description + " " + playerItems[1].ID);*/
    }
}
