using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewLvl : MonoBehaviour
{
    [SerializeField] int _lvlIndex;

    void OnTriggerEnter (Collider other){
        if (other.CompareTag("Player")){
            //Debug.Log ("Enter");
            SceneManager.LoadScene(_lvlIndex);
        }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}
