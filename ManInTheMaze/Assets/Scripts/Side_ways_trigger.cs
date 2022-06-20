using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side_ways_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider colisao)
    {
        GetComponent<Animator> ().Play ("Open_Sideways");
    }

    // Update is called once per frame

}
