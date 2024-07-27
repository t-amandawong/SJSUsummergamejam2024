using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public GameObject camera;
    public GameObject[] players;

    public bool playerJumped = false;
    public bool isMoving = false;
    public int direction = 0;
    public Vector3 followingDistance = new Vector3(1,1,1);

    public float delay = 0.2f;      // delay between each character
    public float moveSpeed;
    public float jumpForce;
    private int currentReplacementIndex = 0;

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

    public void HandleCollision(GameObject collidedObject) {
        if (players.Length > 0) {
            GameObject replacement = players[currentReplacementIndex + 1];
            Vector3 spawnPosition = players[currentReplacementIndex].transform.position;

            // Destroy the collided object and replace it
            collidedObject.gameObject.SetActive(false);
            Instantiate(replacement, spawnPosition, Quaternion.identity);
            if (camera.GetComponent<CameraController>().player == players[currentReplacementIndex]) {
                camera.GetComponent<CameraController>().player = players[currentReplacementIndex + 1];
            }

            // change tag to player and deactivate follower script
            players[currentReplacementIndex + 1].tag = "Player";
            players[currentReplacementIndex + 1].GetComponent<followingBehavior>().enabled = false;
            // change player layer to player
            players[currentReplacementIndex + 1].layer = 8;

            // change indicator to current player
            players[currentReplacementIndex + 1].gameObject.transform.GetChild(1).gameObject.SetActive(true);
            
            // Move to the next replacement object in the array
            currentReplacementIndex = (currentReplacementIndex + 1) % players.Length;
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
