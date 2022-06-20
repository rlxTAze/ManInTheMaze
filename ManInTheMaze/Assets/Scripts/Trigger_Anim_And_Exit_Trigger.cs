using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Anim_And_Exit_Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider colisao)
    {
        //if (other.CompareTag("jogador"))
        //{

            //myDoor.Play(doorOpen, 0, 0.0f);
        //}
        GetComponent<Animator> ().Play ("avanco");

    }
    void OnTriggerExit(Collider colisao){
        GetComponent<Animator> ().Play ("recuo");
    
    }
}
