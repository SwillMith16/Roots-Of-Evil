using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    // variables needed
    private static AudioSource source;
    [SerializeField] private AudioClip[] steps;
    [SerializeField] private AudioClip[] playerHit;
    [SerializeField] private AudioClip playerDead;


    [SerializeField] private float stepDelay;
    private float countdown = 0;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.moveDirection != Vector2.zero)
        {
            Steps(stepDelay);
        }
    }

    void Steps(float delay)
    {
        if (countdown <= 0)
        {
            source.PlayOneShot(steps[Random.Range(0, steps.Length)]);
            countdown = delay;
        }

        countdown -= 1 * Time.deltaTime;
    }

    /// <summary>
    /// Play a sound clip of the player taking damage.
    /// </summary>
    public void PlayerHit()
    {
        source.PlayOneShot(playerHit[Random.Range(0, playerHit.Length)]);
    }

    /// <summary>
    /// Play a sound clip of the player dying.
    /// </summary>
    public void PlayerDead()
    {
        source.PlayOneShot(playerDead);
    }
}
