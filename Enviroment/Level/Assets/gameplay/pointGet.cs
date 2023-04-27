using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class pointGet : MonoBehaviour
{
    private float points;
    public float scorePerPoint;
    public float multiplier;
    public float kills;
    public float detractions;
    public float tempKills;
    public float tempDetractions;
    public GameObject playerObject;
    public TextMeshProUGUI pointDisplay;

    private void Start()
    {
        if (playerObject != null)
        {
            multiplier = playerObject.GetComponent<obstacleCollide>().playerMaxHits; 
            print("multiplier: " + multiplier);   
        }
        print(kills);
    }

    private void Update()
    {
        InvokeRepeating("test", 2.0f,2.0f);
        if (pointDisplay != null)
        {
            pointDisplay.SetText(points.ToString());
        }
        if (tempKills != kills || tempDetractions != detractions)
         {
             pointUpdate();
            print("You have " + kills + " kills and " + detractions + " detractions. your points are " + points);
            
         }
    } 

    public void pointUpdate()
    {
        multiplier = multiplier - detractions;
        points = (kills * scorePerPoint) * multiplier;
        if (points <= 0)
        {
            points *= -1;
            kills = 0;
        }
    }
    public void test()
    {
        tempKills = kills;
        tempDetractions = detractions;
    }
}
