using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movement;

    //Use this to change the player's base speed per game
    //  (can be changed in inspector)
    public float moveSpeed = 3f;

    //Use this to slow diagonal movement
    //  (can be changed in inspector)
    public float moveLimiter = 0.7f;

    //Use these if you want to restrict movement on any axis for any reason
    //  (can be changed in inspector)
    public bool movementEnabled = true;
    public bool canMoveHorizontally = true;
    public bool canMoveVertically = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Get movement axes
        if (canMoveHorizontally) movement.x = Input.GetAxisRaw("Horizontal");
        else movement.x = 0;
        if (canMoveVertically) movement.y = Input.GetAxisRaw("Vertical");
        else movement.y = 0;
    }

    private void FixedUpdate()
    {
        if (movement.x != 0 && movement.y != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            movement.x *= moveLimiter;
            movement.y *= moveLimiter;
        }

        if (movementEnabled)
        {
            //Change object velocity
            rb.velocity = movement * moveSpeed;
        }
    }

    //If you want anything to happen when the player gets in contact with something,
    //  use this. To check for specific objects, check collision.gameObject.tag
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
