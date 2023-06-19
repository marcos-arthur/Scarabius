using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Button ExitToMainMenuButton;
    [SerializeField] private Button ExitGameButton;
    // Start is called before the first frame update
    void Start()
    {
        if(GameController.Instance != null) Destroy(GameController.Instance.gameObject);

        ExitToMainMenuButton.onClick.AddListener(ExitToMainMenu);
        ExitGameButton.onClick.AddListener(ExitGame);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
