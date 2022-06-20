using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Animations : MonoBehaviour

    
{
    //[SerializeField] private Animator myDoor;
    //[SerializeField] private string doorOpen = "abrir";

    //private void OnTriggerEnter(Collider other)
    void OnTriggerEnter(Collider colisao)
    {
        //if (other.CompareTag("jogador"))
        //{

            //myDoor.Play(doorOpen, 0, 0.0f);
        //}
        GetComponent<Animator> ().Play ("abrir");
        GetComponent<Animator> ().Play ("Open_Sideways");


    }
    //void OnTriggerExit(Collider colisao){
      //  GetComponent<Animator> ().Play ("fechar");

    //}
     
}
