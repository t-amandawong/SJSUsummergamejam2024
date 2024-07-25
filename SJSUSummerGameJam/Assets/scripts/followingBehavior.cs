using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followingBehavior : MonoBehaviour
{
    public GameObject target; // target object
    public Rigidbody rb;    // Player model

    //jump stuff
    private bool isGrounded;

    public void Jump () {
        rb.velocity = new Vector3(rb.velocity.x, GameManager.Instance.jumpForce);
    }

    public void Follow(int direction) {
        transform.Translate(direction * Vector3.back * Time.deltaTime * GameManager.Instance.moveSpeed);
    }
}
