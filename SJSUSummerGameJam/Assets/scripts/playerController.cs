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
        // forward movement
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            transform.Translate(Vector3.back * Time.deltaTime * GameManager.Instance.moveSpeed);
            GameManager.Instance.direction = 1;
        } 
        // backward movement -- fix later
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(Vector3.forward * Time.deltaTime * GameManager.Instance.moveSpeed);
            GameManager.Instance.direction = -1;
        }

        //player Jump
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            //Debug.Log("jump");
            rb.velocity = new Vector3(rb.velocity.x, GameManager.Instance.jumpForce);
            GameManager.Instance.playerJumped = true;
        }
        
    }
}
