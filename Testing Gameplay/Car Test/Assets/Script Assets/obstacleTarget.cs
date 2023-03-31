using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleTarget : MonoBehaviour
{
       public float health;
       private bool isDead;

       public void TakeDamage(int damage)
       {
              health -= damage;
              if (health <= 0)
              {
                     isDead = true;
              }
       }

       public void Update()
       {
              if (isDead)
              {
                     Destroy(gameObject);
              }
       }
}
