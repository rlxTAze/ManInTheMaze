using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{

    [SerializeField] GameObject painelWin;

    void Start()
    {
        painelWin.SetActive(true);
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