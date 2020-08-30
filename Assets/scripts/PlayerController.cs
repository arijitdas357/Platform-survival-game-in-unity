using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Movement speed
    public float jumpHeight = 2f; // Jump height
    public float gravity = -9.81f; // Gravity force
    public Transform groundCheck; // Transform to check if the player is on the ground
    public float groundDistance = 0.6f; // Distance to check for ground
    public LayerMask groundMask; // Layer mask to define what is ground
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Debug.Log(isGrounded);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small negative value to keep the player grounded
        }

        // Get input for movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Apply movement
        characterController.Move(move * speed * Time.deltaTime);
        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }

        // Apply gravity
        velocity.y -= gravity * Time.deltaTime;

        // Apply velocity
        characterController.Move(velocity * Time.deltaTime);
    }
}
