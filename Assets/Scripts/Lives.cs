using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public int health= 3;
    public Text LivesText;
  

   void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag == "enemy"){
            health--;
            LivesText.text ="lives:" + health;
              }
            if(health==0){
                SceneManager.LoadScene(0);
               

              
       
            }
        }
    }

    

