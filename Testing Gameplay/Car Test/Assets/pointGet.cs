using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointGet : MonoBehaviour
{
    private float points;
    public float scorePerPoint;
    private float multiplier;
    public float kills;
    public float detractions;
    public float temp;
    public GameObject playerObject;

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
        if (temp != kills)
         {
             pointUpdate();
            print("You have " + kills + " kills and " + detractions + " detractions. your points are " + points);
            
         }
    } 

    public void pointUpdate()
    {
        points = (kills * scorePerPoint) * multiplier;
        multiplier = multiplier - detractions;
        points = points * multiplier;
    }
    public void test()
    {
        temp = kills;
    }
}
