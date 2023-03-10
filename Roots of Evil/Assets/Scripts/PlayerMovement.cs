using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // variables and objects are all declared here
    public Rigidbody rb;
    public InputAction controls;
    public SpriteRenderer spriteRenderer;

    public static Vector2 moveDirection = Vector3.zero;
    [SerializeField] private float moveSpeed = 100;

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Input detection takes place in Update()
    void Update()
    {
        moveDirection = controls.ReadValue<Vector2>();
        if (moveDirection.x > 0)
        {
            FaceRight();
        }
        if(moveDirection.x < 0)
        {
            FaceLeft();
        }
    }

    // Movement takes place in FixedUpdate()
    private void FixedUpdate()
    {
        if (PlayerHealth.currentHealth > 0)
        {
            rb.velocity = new Vector3(moveDirection.x * moveSpeed * Time.deltaTime, 0, moveDirection.y * moveSpeed * Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
        
    }

    private void FaceRight()
    {
        //gameObject.transform.localScale = new Vector3(1, 1, 1);
        spriteRenderer.flipX = false;
    }

    private void FaceLeft()
    {
        //gameObject.transform.localScale = new Vector3(-1, 1, 1);
        spriteRenderer.flipX = true;
    }
}
