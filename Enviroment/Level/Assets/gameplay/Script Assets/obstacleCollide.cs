using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Jobs.LowLevel.Unsafe;
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
    public GameObject gameOverUI;
    public GameObject winScreenUI;
    public GameObject playerObject;
    public GameObject healthPoint;
    public GameObject healthPointTwo;
    public GameObject healthPointThree;
    public GameObject healthPointFour;
    public GameObject healthPointFive;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.CompareTag("obstacle"))
        {
            damageTaken++;
            healthPoint.SetActive(false);
            print(damageTaken);
        }    
        else if (collision.collider.CompareTag("killBox"))
        {
            damageTaken = (int) playerMaxHits;
            healthPoint.SetActive(false);
            print(damageTaken);
        }
        else if (winScreenUI != null)
        {
            if (collision.collider.CompareTag("Victory"))
            {
                if (winScreenUI != null)
                {
                    winScreenUI.SetActive(true);
                }
            }
        }
    }
    
    public void Update()
    {
                    if (healthPoint!= null && healthPointTwo != null && healthPointThree != null && healthPointFour != null && healthPointFive != null)
            {
                if ( playerMaxHits - damageTaken == playerMaxHits)
                {
                    healthPoint.SetActive(true);
                    healthPointTwo.SetActive(true);
                    healthPointThree.SetActive(true);
                    healthPointFour.SetActive(true);
                    healthPointFive.SetActive(true);
                }
                else if (playerMaxHits - damageTaken == 4)
                {
                    healthPoint.SetActive(true);
                    healthPointTwo.SetActive(true);
                    healthPointThree.SetActive(true);
                    healthPointFour.SetActive(true);
                    healthPointFive.SetActive(false);
                }
                else if (playerMaxHits - damageTaken == 3)
                {
                    healthPoint.SetActive(true);
                    healthPointTwo.SetActive(true);
                    healthPointThree.SetActive(true);
                    healthPointFour.SetActive(false);
                    healthPointFive.SetActive(false);
                }
                else if (playerMaxHits - damageTaken == 2)
                {
                    healthPoint.SetActive(true);
                    healthPointTwo.SetActive(true);
                    healthPointThree.SetActive(false);
                    healthPointFour.SetActive(false);
                    healthPointFive.SetActive(false);
                }
                else if (playerMaxHits - damageTaken == 1)
                {
                    healthPoint.SetActive(true);
                    healthPointTwo.SetActive(false);
                    healthPointThree.SetActive(false);
                    healthPointFour.SetActive(false);
                    healthPointFive.SetActive(false);
                }
                else if (playerMaxHits - damageTaken == 0)
                {
                    healthPoint.SetActive(false);
                    healthPointTwo.SetActive(false);
                    healthPointThree.SetActive(false);
                    healthPointFour.SetActive(false);
                    healthPointFive.SetActive(false);
                }
                else
                {
                    healthPoint.SetActive(true);
                    healthPointTwo.SetActive(true);
                    healthPointThree.SetActive(true);
                    healthPointFour.SetActive(true);
                    healthPointFive.SetActive(true);
                }
            }
        //No idea if this hud thing works lol
        if (healthGUI != null)
        {
            healthGUI.SetText(playerMaxHits - damageTaken + "/" + playerMaxHits);
        }
        if (damageTaken == playerMaxHits)
        {
            playerObject.GetComponent<WheelControllerTest>().inputEnabled = false;
            damageTaken = 0;
            changeScreen();
            //gameOverUI.SetActive(true);
            //SceneManager.LoadScene("GameOverScreen");
        }
    }

    public void changeScreen()
    {
        print("Dead");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene("GameOverScreen");
    }



}
