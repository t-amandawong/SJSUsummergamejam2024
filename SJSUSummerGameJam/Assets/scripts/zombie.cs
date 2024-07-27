using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombie : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject enemy;
    public GameObject player;
    [SerializeField] private float enemyspeed = 35f;
    private bool isPlayerDetected = false;
    public Animator enemyAnimator;
    //private NavMeshAgent agent;
    private bool facingRight = true;
    bool isMoving = false;
    bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDetected == true)
        {
            Chase();
        }
    }

    void Chase(){
    // Calculate the direction from the enemy to the player
    Vector3 directionToPlayer = player.transform.position - transform.position;
    // Normalize the direction to get a unit vector
    directionToPlayer.Normalize();
    // Move the enemy towards the player
    directionToPlayer.y = 0f;           //prevents enemy from moving in y axis
    //transform.position += directionToPlayer * enemyspeed * Time.deltaTime;

    Vector3 newPosition = transform.position + directionToPlayer * enemyspeed * Time.deltaTime;
    rb.MovePosition(newPosition);
    //Notes: enemies faze thru y axis, y axis problems

        enemyAnimator.SetBool("isMoving", true);
        if (directionToPlayer.x < 0 && facingRight)
        {
            Flip();
        }
        if (directionToPlayer.x > 0 && !facingRight)
        {
            Flip();
        }
    }

    // This function is called when another collider exits the trigger collider attached to this object
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject; // Set other player as playerobject object
            isPlayerDetected = true;
            enemyAnimator.SetBool("isMoving", true);
            isMoving = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerDetected = false;
            enemyAnimator.SetBool("isMoving", false);
            isMoving = false;
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
