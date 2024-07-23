using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public GameObject player; // playerObject
    public Rigidbody rb;    // Player model
    public CapsuleCollider cc;
    public float moveSpeed;    // Move speed
    private Vector3 moveInput;   // Player movement in the world
    //jump stuff
    private bool isGrounded;
    public float jumpForce;
//test
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     // Player movement in the x(left and right) direction. Covers A, D, Left key, Right key
     moveInput.x = Input.GetAxisRaw("Horizontal");
        
     moveInput.Normalize();

     // Updates the player model
     rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.z * moveSpeed);

    //player Jump
    if (Input.GetButtonDown("Jump")){
        //Debug.Log("jump");
        rb.velocity = new Vector3(rb.velocity.x, jumpForce);
     }
        
    }
}
