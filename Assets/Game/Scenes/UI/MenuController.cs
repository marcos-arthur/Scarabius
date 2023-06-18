using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadScene01()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void Exit()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();

    }
}
