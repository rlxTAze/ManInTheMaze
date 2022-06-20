using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave_Trigger : MonoBehaviour
{
  void OnTriggerEnter(Collider colisao)
    {
        //if (other.CompareTag("jogador"))
        //{

            //myDoor.Play(doorOpen, 0, 0.0f);
        //}
        GetComponent<Animator> ().Play ("Move_nave");
        

    }
}
