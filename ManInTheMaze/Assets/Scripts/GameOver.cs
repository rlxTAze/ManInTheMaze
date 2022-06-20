using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    //public Text pointsText; https://www.youtube.com/watch?v=K4uOjb5p3Io

    //public void Setup(in score){   //se tiver-mos contador de pontos
    //    gameObject.SetActive(true);
    //    pointsText.text = score .ToString + "Points"
    //}

    public void RestartButton(int nivel) 
    {
        SceneManager.LoadScene("Game"); //"Game" sera o nome da cena do jogo
    }

    public void ExitButton() {
        SceneManager.LoadScene("MenuPrincipal");
    }


// No script GameController:
// public GameOverScreen GameOver;

//public void GameOver(){
    //GameOver.Setup( //aqui sera o int do proj)
//}
}

