using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovement : MonoBehaviour
{
    // Enemy prefab components
    private SpriteRenderer spriteRenderer;
    private NavMeshAgent navMeshAgent;

    // Player variables
    private GameObject player;
    private Vector3 playerPos;

    // Start is called before the first frame update
    void Awake()
    {
        // Get components from enemy prefab
        navMeshAgent = GetComponent<NavMeshAgent>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Get player game object
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Continuously chase the player and face the player's direction
        playerPos = player.transform.position;
        ChasePlayer();
        FacePlayer();
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
}
