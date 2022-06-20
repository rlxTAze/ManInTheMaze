using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField]

    Transform player;


    [SerializeField] 
    
    Transform respawnPoint;

    [SerializeField]

    private float moveSpeed = 1;

    [SerializeField]

    private float lookSensitivity = 5;

    [SerializeField]

    private float jumpHeight;

    [SerializeField]

    private float gravity = 9.81f;

    public AudioSource walkNoise;
    public AudioSource jumpNoise;
    public AudioSource Morte;

    private Vector2 moveVector;
    private Vector2 lookVector;
    private Vector3 rotation;
    private float verticalVelocity;

    private CharacterController characterController;
    private Animator animator;

    [SerializeField] Transform respawnPoint_3;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = respawnPoint.transform.position;
        player.GetComponent<CharacterController>().enabled = true;
        animator = GetComponent<Animator>();
        Debug.Log("jogador"+ player.transform.position);
        Debug.Log("respawn" +respawnPoint.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();


    }


    public void OnMove(InputAction.CallbackContext context) //m�todo que l� os inputs 
    {
        moveVector = context.ReadValue<Vector2>();
        if (moveVector.magnitude > 0) //magnitude � a dist�ncia entre a origem do vetor e o final (se a personagem estiver parada (=0), n�o vai ativar o isWalking)
        {
            animator.SetBool("isWalking", true);
            walkNoise.Play();
        }
        else
        {
            animator.SetBool("isWalking", false);
            walkNoise.Pause();
        }
    }

    private void Move()
    {
        verticalVelocity += -gravity * Time.deltaTime;

        if (characterController.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -0.1f * gravity * Time.deltaTime; //sempre que o jogador est� no ch�o, � possivel saltar; se verticalvelocity=0, �s vezes n�o funciona
        }

        Vector3 move = transform.right * moveVector.x + transform.forward * moveVector.y + transform.up * verticalVelocity;
        characterController.Move(move * moveSpeed * Time.deltaTime);
    }

    public void onLook(InputAction.CallbackContext context)
    {
        lookVector = context.ReadValue<Vector2>();
    }

    private void Rotate() //o que faz rodar a c�mara. como � terceira pessoa n�o � preciso olhar para cima e baixo
    {
      rotation.y += lookVector.x * lookSensitivity * Time.deltaTime;
      transform.localEulerAngles = rotation; //roda o jogador no axis y baseado onde o utilizador posiciona o rato
      
    }

    public void onJump(InputAction.CallbackContext context)
    {
        if (characterController.isGrounded && context.performed)   //context.performed � para verificar se a tecla 'espa�o' foi premida
        {
            animator.Play("Jumping");
            jumpNoise.Play();
            //Jump();
        }


    }


    private void Jump()
    {
        verticalVelocity = Mathf.Sqrt(jumpHeight * gravity);

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if(rigidbody != null && rigidbody.tag == "mola")
        {
            verticalVelocity = Mathf.Sqrt((jumpHeight * gravity) * 3);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("isto est� a funcionar");
        if (other.tag == "lvl_4")
        {

            jumpHeight = 1.5f;
        }
    }

}