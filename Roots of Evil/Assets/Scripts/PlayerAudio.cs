using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    // variables needed
    public AudioSource source;
    public AudioClip[] steps;

    [SerializeField] private float delay;
    private float countdown = 0;

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.moveDirection != Vector2.zero)
        {
            if (countdown <= 0)
            {
                source.PlayOneShot(steps[Random.Range(0, steps.Length)]);
                countdown = delay;
            }

            countdown -= 1 * Time.deltaTime;
        }
    }
}
