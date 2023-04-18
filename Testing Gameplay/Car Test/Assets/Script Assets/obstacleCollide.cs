using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
