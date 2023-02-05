using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float[] spawnPosX = { 6.4f, -30f, 45f };
    private float spawnPosY = -1.9f;
    [SerializeField] private float spawnPosZ = 10f;

    public float delay;
    private float countdown = 0;

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0)
        {
            // spawn enemy
            Instantiate(enemyPrefab, new Vector3(spawnPosX[Random.Range(0, spawnPosX.Length)], spawnPosY, spawnPosZ), new Quaternion(0, 0, 0, 0));

            countdown = delay;
        }

        // continue countdown
        countdown -= 1 * Time.deltaTime;
    }
}
