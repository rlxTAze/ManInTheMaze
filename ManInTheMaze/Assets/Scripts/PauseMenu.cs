using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;


    // Update is called once per frame
    /*  void Update()
       {
           if(Input.GetKeyDown(KeyCode.Escape))
           {
               if (GameIsPaused)
               {
                   Resume();

               } else 
               {
                   Pause();
               }
           }
       }

       */
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void QuitGame()
    {
        Debug.Log("Vamos Sair...");
        Application.Quit();
    }

    public void pauseMenu(InputAction.CallbackContext esc)
    {

      //Debug.Log("Cliquei esc");

        //if (esc.performed) 
        //{
        if (GameIsPaused)
        {
            Resume();
            Debug.Log("Jogo retomado");

        }
        else
        {
            Pause();
            Debug.Log("Jogo pausado");

        }
        //}

    }
}