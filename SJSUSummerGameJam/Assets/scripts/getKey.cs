using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class getKey : MonoBehaviour
{
    [SerializeField] GameObject _LockedDoor;    // Assign the locked door gameObject via inspector

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // collider checks for Player Tag
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Key picked up!");
            Destroy(gameObject);    //key is destroyed
            Destroy(_LockedDoor);   //Locked Door is Destroyed
        }
    }
}
