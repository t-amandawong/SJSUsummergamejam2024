using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public GameObject[] players;

    public bool playerJumped = false;
    public bool isMoving = false;
    public int direction = 0;
    public Vector3 followingDistance = new Vector3(1,1,1);

    public float delay = 0.2f;      // delay between each character
    public float moveSpeed;
    public float jumpForce;

    public static GameManager Instance {
        get {
            if (_instance == null) {
                Debug.LogError("Game Manager is NULL");
            }

            return _instance;
        }
    }

    private IEnumerator JumpBehavior(float delay) {
        for(var i = 1; i < players.Length; i++) {
            yield return new WaitForSeconds(delay);
            players[i].GetComponent<followingBehavior>().Jump();
        }
    }

    private void Awake() {
        _instance = this;
    }

    private void Update() {
        if (playerJumped) {
            playerJumped = false;
            StartCoroutine(JumpBehavior(delay));
        }
    }
}
