using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public static float currentHealth { get; private set; }
	public float maxHealth { get; private set; } = 100.0f;

    [SerializeField] private bool healthDegredationOn;
	[SerializeField] private float healthDegredationPerSecond = 5f;
	private static bool deathSequenceComplete;

	private static PlayerAudio playerAudio;

    void Start()
	{
        playerAudio = GetComponent<PlayerAudio>();
        currentHealth = maxHealth;

        deathSequenceComplete = false;
    }

	void Update()
	{
		if (healthDegredationOn)
		{
            currentHealth -= healthDegredationPerSecond * Time.deltaTime;
        }

        if (currentHealth <= 0 && !deathSequenceComplete)
        {
            PlayerDeath();
        }
    }

	/// <summary>
	/// Deal damage to the player's health. Takes a float parameter and subtracts its value from the players health.
	/// </summary>
	/// <param name="damage"></param>
	/// <returns>No return value</returns>
	public static void TakeDamage(float damage)
	{
		currentHealth -= damage;
		if (!deathSequenceComplete)
		{
            playerAudio.PlayerHit();
        }
	}

	void PlayerDeath()
	{
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
		gameObject.GetComponent<PlayerMovement>().enabled = false;
		playerAudio.PlayerDead();
		deathSequenceComplete = true;
        //lmao dead
        //play death anim
        //game over screen
    }
}
