using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField]
    public GameObject currentMainMenu;

    [SerializeField]
    public GameObject nextMainMenu;


    public void loadScene()
    {

        currentMainMenu.SetActive(false);

        nextMainMenu.SetActive(true);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Game Started");
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}