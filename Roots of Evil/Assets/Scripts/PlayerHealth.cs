using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public float currentHealth;
	public float MaxHealth = 100.0f;

	void Start()
	{
		currentHealth = MaxHealth;
	}

	void Update()
	{
		currentHealth -= 5 * Time.deltaTime;
		Debug.Log(currentHealth);
	}

	void TakeDamage(float amount)
	{
		currentHealth -= amount;

		if(currentHealth <= 0)
		{
			//lmao dead
			//play death anim
			//game over screen
		}
	}
}
