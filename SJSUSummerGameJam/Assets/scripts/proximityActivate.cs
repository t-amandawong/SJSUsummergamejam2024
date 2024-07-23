using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class proximityActivate : MonoBehaviour
{
    [SerializeField] GameObject _TextUI;    //assign canvas as text UI. Note: Canvas must be deactivated prior
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        //trigger events
     void OnTriggerEnter (Collider other){
           if (other.CompareTag("Player")){
           //Debug.Log ("Enter");
            _TextUI.SetActive(true);        //activate dialogue
           }
      }

     void OnTriggerStay (Collider other){
         if (other.CompareTag("Player")){
         //Debug.Log ("Staying");
         }
         
      }

    void OnTriggerExit (Collider other){
          if (other.CompareTag("Player")){
          //Debug.Log ("Exit");
          _TextUI.SetActive(false);       //deactivate
          }
}
}
