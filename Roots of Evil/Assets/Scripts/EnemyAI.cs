using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    private Transform player;
    private Rigidbody rb;
    private SpriteRenderer spriteRenderer;
    public LayerMask whatIsGround, whatIsPlayer;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ChasePlayer();

        FacePlayer();
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {

    }

    private void FacePlayer()
    {
        if (player.position.x - transform.position.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (player.position.x - transform.position.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
