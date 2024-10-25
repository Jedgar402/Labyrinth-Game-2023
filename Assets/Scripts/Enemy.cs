using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    //public int Respawn;

    public int health = 3;


    public static int DamageEnemy(int health)
    {
        health -= 10;

        health = Mathf.Clamp(health, 0, 100);

        return health;

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Ball")
        {
            health--;
            //LivesText.text = "lives:" + health;

            if (health == 0)
            {
                SceneManager.LoadScene(0);
            }
            //SceneManager.LoadScene(Respawn);
        }
    }

    public object GetBall()
    {
        throw new NotImplementedException();
    }
}
