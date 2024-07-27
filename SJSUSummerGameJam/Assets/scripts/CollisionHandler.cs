using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollisionHandler : MonoBehaviour
{
    public Animator enemyAnimator;
    public GameObject collisionBox;
    public Rigidbody rb;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("zombie collided with player");
            GameManager.Instance.HandleCollision(other.gameObject);
            enemyAnimator.SetBool("isEating", true);
            collisionBox.SetActive(false);
            rb.constraints |= RigidbodyConstraints.FreezePositionX;
        }
    }
}
