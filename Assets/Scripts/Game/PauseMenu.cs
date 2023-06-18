using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public Transform pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (pauseMenu.gameObject.activeSelf){
                pauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else{
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
        
    }

    public void Pause(){
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame(){
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();

    }
}
