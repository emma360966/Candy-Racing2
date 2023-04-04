using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleCollide : MonoBehaviour
{
    //Player HP
    public float playerMaxHits;
    private int damageTaken;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("obstacle"))
        {
            damageTaken++;
        }    
    }

    public void Update()
    {
        if (damageTaken == playerMaxHits)
        {
            //Insert your code here that will bring it to the gameover screen.
            print("dead");
        }
    }



}
