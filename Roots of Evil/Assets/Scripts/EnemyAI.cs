using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.AI;
using static Unity.VisualScripting.Member;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyAI : MonoBehaviour
{
    // Enemy prefab components
    private SpriteRenderer spriteRenderer;
    private NavMeshAgent navMeshAgent;

    // Attack variables
    [SerializeField] private float damage = 5f;
    [SerializeField] private float damageRadius = 1f;
    [SerializeField] private float attackCooldownTime = 2;
    private bool allowAttack = true;

    // Player variables
    private GameObject player;
    private Vector3 playerPos;
    private float distanceToPlayer;

    private void Awake()
    {
        // Get components from enemy prefab
        navMeshAgent = GetComponent<NavMeshAgent>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Get player game object
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        // Continuously chase the player and face the player's direction
        ChasePlayer();
        FacePlayer();

        // Get distance from enemy to player
        playerPos = player.transform.position;
        distanceToPlayer = Vector3.Distance(transform.position, playerPos);

        // If player is within range and attack cooldown is not active, attack the player
        if ((distanceToPlayer <= damageRadius) && allowAttack)
        {
            AttackPlayer();
        }
    }

    private void ChasePlayer()
    {
        navMeshAgent.SetDestination(playerPos);
    }

    private void FacePlayer()
    {
        if (playerPos.x - transform.position.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (playerPos.x - transform.position.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void AttackPlayer()
    {
        Debug.Log("Attack Player");
        PlayerHealth.TakeDamage(damage);
        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackCooldown()
    {
        allowAttack = false;
        yield return new WaitForSeconds(attackCooldownTime);
        allowAttack = true;
    }

    
}
