using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide_up_door : MonoBehaviour
{
    // Start is called before the first frame update
    
    void OnTriggerEnter(Collider colisao)
    {
        //if (other.CompareTag("jogador"))
        //{

            //myDoor.Play(doorOpen, 0, 0.0f);
        //}
        GetComponent<Animator> ().Play ("slide_up");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
