using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_atach : MonoBehaviour
{

    public GameObject Jogador;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Jogador)
        {
            Jogador.transform.parent = transform;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == Jogador){
            Jogador.transform.parent = null;

        }

    }

}
