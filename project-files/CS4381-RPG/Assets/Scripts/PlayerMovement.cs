using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;     // floating point variable to store player's movement speed.

    private Rigidbody2D rb2d;   // Store a reference to the RigidBody2D component of the player game object

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> (); // Store a reference to player rigidbody2d component to allow access
    }

    // FixedUpdate is called independent of frame rate at a fixed interval
    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxis("Horizontal"); //Get the current horizontal movement input
        float verticalMove = Input.GetAxis("Vertical");     //Get the current vertical movement input

        // Create a new vector to represent the combination of horizontal and vertical movement
        Vector2 move = new Vector2(horizontalMove, verticalMove);
        
        // Apply the desired force to the player rigid body
        rb2d.AddForce(move * speed);

    }
}
