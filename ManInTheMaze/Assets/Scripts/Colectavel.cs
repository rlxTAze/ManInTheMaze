using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectavel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(45, 30, 15) * Time.deltaTime);
    }
}
