using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static int playerHP = 100;
    public static bool isGameOver;
    public Text playerHPText;

    [SerializeField] GameObject proj;
    public AudioSource Death;
    private CharacterController characterController;
    private Animator animator;
    //[SerializeField] Transform porta;
    [SerializeField] Transform player;
    [SerializeField] Transform respawnPoint_2;
    [SerializeField] Transform respawnPoint_3; //depois labirinto
    [SerializeField] Transform respawnPoint_4;

    void Start()
    {
        isGameOver = false;
        //Debug.Log(respawnPoint.transform.position);
        Debug.Log(respawnPoint_3.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        playerHPText.text = "HP:" + playerHP;
        if (isGameOver)
        {
            
            SceneManager.LoadScene("ManInTheMaze");
           // Debug.Log(player.transform.position);
            playerHP = 100;
            
        }

    }

    public void TakeDamage(int damageAmount)
    {
        playerHP -= damageAmount;
        if (playerHP <= 0)
        {
            
            isGameOver = true;
            Death.Play();
            
            
        }
    }

    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "inimigo")
        {
            TakeDamage(15);
            //print(playerHP);
            
        }
        if (other.CompareTag("Respawn"))
        {
            //isGameOver = true;
            TakeDamage(100);
            //Debug.Log("hp"+ playerHP);
            other.GetComponent<AudioSource>().Play();
            
            
        }
        if (other.CompareTag("colectavel"))
        {
            other.transform.gameObject.SetActive(false);

            characterController = GetComponent<CharacterController>();
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = respawnPoint_2.transform.position;
            player.GetComponent<CharacterController>().enabled = true;
            animator = GetComponent<Animator>();
            //porta.GetComponent<Animator> ().Play ("abrir");
        }
        if(other.CompareTag("colectavel_2"))
        {
            other.transform.gameObject.SetActive(false);
            //animacao da porta
        }

        if (other.CompareTag("colectavel_lab")) {
            characterController = GetComponent<CharacterController>();
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = respawnPoint_3.transform.position;
            player.GetComponent<CharacterController>().enabled = true;
            animator = GetComponent<Animator>();
        }
        if (other.CompareTag("Televisao_acionador"))
        {
      
            characterController = GetComponent<CharacterController>();
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = respawnPoint_4.transform.position;
            player.GetComponent<CharacterController>().enabled = true;
            animator = GetComponent<Animator>();
            
        }
        if (other.CompareTag("Space_ambience"))
        {
            other.GetComponent<AudioSource>().Play();

        }
        if (other.CompareTag("Slide_door"))
        {
            other.GetComponent<AudioSource>().Play();

        }
        if (other.CompareTag("Corredores_1"))
        {
            other.GetComponent<AudioSource>().Play();

        }
        if (other.CompareTag("Som_Natureza"))
        {
            other.GetComponent<AudioSource>().Play();

        }
        if (other.CompareTag("biblio_som"))
        {
            other.GetComponent<AudioSource>().Play();
    
    }
        if (other.CompareTag("space_sound"))
        {
            other.GetComponent<AudioSource>().Play();
            }
} 
    private void OnTriggerExit(Collider other){

        if (other.CompareTag("Corredores_1"))
        {
            other.GetComponent<AudioSource>().Stop();

        }
          if (other.CompareTag("Space_ambience"))
        {
            other.GetComponent<AudioSource>().Stop();

        }
         if (other.CompareTag("Door_ranger"))
        {
            other.GetComponent<AudioSource>().Play();
            }
        
        if (other.CompareTag("Som_Natureza")){

            other.GetComponent<AudioSource>().Stop();

        }
        if (other.CompareTag("biblio_som")){

            other.GetComponent<AudioSource>().Stop();
    }

        if (other.CompareTag("space_sound"))
        {
            other.GetComponent<AudioSource>().Stop();
            }
  /*private void OnCollisionEnter(Collision other)
    {
        if (proj.gameObject.CompareTag("inimigo"))
        {
            Destroy(proj);
        }

    }*/


}
}
