using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class obstacleCollide : MonoBehaviour
{
    //Player HP
    public float playerMaxHits;
    private int damageTaken;
    public TextMeshProUGUI healthGUI;
    private pointGet pointGet;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.CompareTag("obstacle"))
        {
            damageTaken++;
            print(damageTaken);
        }    
        else if (collision.collider.CompareTag("killBox"))
        {
            damageTaken = 100;
            print(damageTaken);
        }
        
    }

    public void Update()
    {
        //No idea if this hud thing works lol
        if (healthGUI != null)
        {
            healthGUI.SetText(playerMaxHits - damageTaken + "/" + playerMaxHits);
        }
        if (damageTaken == playerMaxHits)
        {
            SceneManager.LoadScene("GameOverScreen");
            print("dead");
        }
    }



}
