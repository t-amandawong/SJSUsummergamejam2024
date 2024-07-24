using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followingBehavior : MonoBehaviour
{
    public Transform leader;
    public float followDistance = 1.0f;
    public float moveSpeed = 4.5f;
    private Vector3 moveInput; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Player movement in the x(left and right) direction. Covers A, D, Left key, Right key
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.Normalize();

        // Updates the player model
        rb.velocity = new Vector3(moveInput.x * GameManager.Instance.moveSpeed, rb.velocity.y, moveInput.z * GameManager.Instance.moveSpeed);
    }

    public void Jump() {
        rb.velocity = new Vector3(rb.velocity.x, GameManager.Instance.jumpForce);
    }
}
