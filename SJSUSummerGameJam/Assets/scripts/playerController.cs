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
    private Vector3 moveInput;   // Player movement in the world
    private bool facingForward = true;

    //jump stuff
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        // Player movement in the x(left and right) direction. Covers A, D, Left key, Right key
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.Normalize();

        // Updates the player model
        rb.velocity = new Vector3(moveInput.x * GameManager.Instance.moveSpeed, rb.velocity.y, moveInput.z * GameManager.Instance.moveSpeed);

        //player Jump
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            //Debug.Log("jump");
            rb.velocity = new Vector3(rb.velocity.x, GameManager.Instance.jumpForce);
            GameManager.Instance.playerJumped = true;
        }
        
    }
}
