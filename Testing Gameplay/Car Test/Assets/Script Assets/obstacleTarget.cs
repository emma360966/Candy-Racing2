using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleTarget : MonoBehaviour
{
       public float health;
       private bool isDestroyed;

       public void TakeDamage(int damage)
       {
              health -= damage;
              if (health <= 0)
              {
                     isDestroyed = true;
              }
       }

       public void Update()
       {
              if (isDestroyed)
              {
                     Destroy(gameObject);
              }
       }

       private void OnCollisionEnter(Collision collision)
       {
              if (collision.collider.CompareTag("Player"))
              {
                     Destroy(gameObject);
              }
       }
}
