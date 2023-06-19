using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public Transform pauseMenu;

    [SerializeField] private Button PauseButton;
    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button MainMenuButton;
    [SerializeField] private Button ExitButton;

    // Start is called before the first frame update
    void Start()
    {
        PauseButton.onClick.AddListener(Pause);
        ResumeButton.onClick.AddListener(ResumeGame);
        MainMenuButton.onClick.AddListener(MainMenu);
        ExitButton.onClick.AddListener(Exit);
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

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();
        //SceneManager.LoadScene("Menu"); caso queiram mudar o quit para voltar ao menu.

    }
}
