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
    public Animator playerAnimator; //player animator
    bool facingRight = false;
    public float moveSpeed;
    //jump stuff
    private bool isGrounded;
    public float jumpForce;
    public int maxJumps = 2;           // Maximum number of jumps allowed

    private int jumpCount = 0;         // Current jump count
    public float rayLength = 3.0f;  //for raycast
    public LayerMask groundLayer;

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
        playerAnimator.SetFloat("horizontalSpeed", Mathf.Abs(moveInput.x));   //set float speed to change animation state to run

        // Updates the player model
        rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.z * moveSpeed);
        playerAnimator.SetFloat("vertVelocity", rb.velocity.y);

        //player Jump
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){   //press space to jump
            //Debug.Log("jump");
            jumpCount++;
            if (jumpCount < maxJumps){
                rb.velocity = new Vector3(rb.velocity.x, jumpForce);
                GameManager.Instance.playerJumped = true;
            }
        }

        // Flip character
        if (moveInput.x > 0 && facingRight){
                Flip();
            }
        if (moveInput.x < 0 && !facingRight){
                Flip();
            }

        isGrounded = Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayer); //check if grounded using raycast
        playerAnimator.SetBool("isGrounded", isGrounded);
        if (isGrounded == true){
            jumpCount = 0;
        }
        //Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.red);
        //Debug.Log("Is Grounded: " + isGrounded);
        
    }

    // Controls flipping of character
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
