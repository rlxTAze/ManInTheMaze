using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    public NavMeshAgent agent;

    public Transform jogador;

    public LayerMask whatIsGround, whatIsPlayer;

    //patrol

    public Vector3 walkPoint;
    bool walkpointSet;
    public float walkPointRange;

    //attack

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //estados

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Start() //Awake
    {
        jogador = GameObject.Find("jogador").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInSightRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (walkpointSet) SearchWalkPoint();

        if(walkpointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f)
        {
            walkpointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkpointSet = true;
        }
    }
    private void ChasePlayer()
    {
        agent.SetDestination(jogador.position);
    }
    private void AttackPlayer()
    {
        //agent.SetDestination(transform.position);

        transform.LookAt(jogador);

        if (!alreadyAttacked)
        {

            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up* 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
