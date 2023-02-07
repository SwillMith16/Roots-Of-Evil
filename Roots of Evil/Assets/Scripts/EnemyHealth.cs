using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public static float currentHealth { get; private set; }
    public float maxHealth { get; private set; } = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // If health hits zero, destroy enemy object
        // TODO: change this to a death animation
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
	/// Deal damage to the enemies health. Takes a float parameter and subtracts its value from the enemies health.
	/// </summary>
	/// <param name="damage"></param>
	/// <returns>No return value</returns>
	public static void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
