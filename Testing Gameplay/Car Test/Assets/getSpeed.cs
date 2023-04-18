using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class getSpeed : MonoBehaviour
{
    public Rigidbody playerRB;
    private float speed;
    public TextMeshProUGUI speedGUI;

    private Vector3 previousPosition;
    // Update is called once per frame
    void Update()
    {
         speed = playerRB.velocity.magnitude;
         if (Input.GetKeyDown("w") || Input.GetKeyDown("s"))
         {
              previousPosition = transform.position;
         }
         
         //speed = Mathf.RoundToInt(Vector3.Distance(transform.position, previousPosition) / Time.fixedDeltaTime);
         speed = Mathf.RoundToInt(speed);
         if (speedGUI != null)
        {
            speedGUI.SetText(speed.ToString() + " KPH");
        }
    }


}
