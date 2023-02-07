using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Attack variables
    [SerializeField] private float damage = 5f;
    [SerializeField] private float damageRadius = 1f;
    [SerializeField] private float attackCooldownTime = 2;
    private bool allowAttack = true;

    // Player variables
    private GameObject player;
    private Vector3 playerPos;
    private float distanceToPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        // Get player game object
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Get distance from enemy to player
        playerPos = player.transform.position;
        distanceToPlayer = Vector3.Distance(transform.position, playerPos);

        // If player is within range and attack cooldown is not active, attack the player
        if ((distanceToPlayer <= damageRadius) && allowAttack)
        {
            AttackPlayer();
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
