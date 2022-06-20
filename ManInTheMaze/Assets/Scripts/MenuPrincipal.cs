using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{

    [SerializeField] GameObject painelMenu;
    [SerializeField] GameObject painelCreditos;

    void Start()
    {
        painelCreditos.SetActive(false);
        painelMenu.SetActive(true);
    }

    public void CarregaMenu(int ManInTheMaze)
    {
        SceneManager.LoadScene(ManInTheMaze);
    }

    public void Creditos()
    {
        painelCreditos.SetActive(true);
        painelMenu.SetActive(false);
    }

    public void Voltar()
    {
        painelCreditos.SetActive(false);
        painelMenu.SetActive(true);
    }
    public void Sair()
    {
        Debug.Log("Vamos sair");
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}