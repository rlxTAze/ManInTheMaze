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

    private CharacterController characterController;
    private Animator animator;

   [SerializeField] Transform player;
    [SerializeField] Transform respawnPoint_2;
    [SerializeField] Transform respawnPoint_3; //depois labirinto

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
            SceneManager.LoadScene("Jogo");
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
        }
    }

    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "inimigo")
        {
            TakeDamage(15);
            print(playerHP);
            
        }
        if (other.gameObject.tag == "Respawn")
        {
            isGameOver = true;
        }
        if (other.CompareTag("colectavel"))
        {
            other.transform.gameObject.SetActive(false);

            characterController = GetComponent<CharacterController>();
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = respawnPoint_2.transform.position;
            player.GetComponent<CharacterController>().enabled = true;
            animator = GetComponent<Animator>();
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
    }

  /*private void OnCollisionEnter(Collision other)
    {
        if (proj.gameObject.CompareTag("inimigo"))
        {
            Destroy(proj);
        }

    }*/

}