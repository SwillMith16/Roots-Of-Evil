using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;
    private float[] enemySpawnPosX = { 6.4f, -30f, 45f };
    private float enemySpawnPosY = -1.9f;
    private float enemySpawnPosZ = 10f;
    private Vector3 playerSpawnPos = new Vector3(0, -1.9f, 0);

    public float enemySpawnDelay;
    private bool spawnEnemy;

    private void Start()
    {
        spawnEnemy = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnEnemy)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        // Instantiate enemy prefab
        Instantiate(enemyPrefab, new Vector3(enemySpawnPosX[Random.Range(0, enemySpawnPosX.Length)], enemySpawnPosY, enemySpawnPosZ), new Quaternion(0, 0, 0, 0));

        // Start enemy spawn cooldown
        StartCoroutine(EnemySpawnCooldown());
    }

    IEnumerator EnemySpawnCooldown()
    {
        spawnEnemy = false;
        yield return new WaitForSeconds(enemySpawnDelay);
        spawnEnemy = true;
    }
}
