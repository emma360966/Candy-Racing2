using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleTarget : MonoBehaviour
{
       public float health;
       private bool isDestroyed;
       public GameObject myPlayer;
       [SerializeField] pointGet pointGetter;

       private void Start()
       {
              pointGetter = GameObject.Find("pointManager").GetComponent<pointGet>();
       }

       public void TakeDamage(int damage)
       {
              //more efficient
              //health -= damage;
              //more readable
              health = health - damage;
              if (health <= 0)
              {
                     isDestroyed = true;
              }
       }

        void Update()
       {
              if (isDestroyed)
              {
                     pointGetter.kills++;
                     Destroy(gameObject);
              }
       }

       private void OnCollisionEnter(Collision collision)
       {
              if (collision.collider.CompareTag("Player"))
              {
                     pointGetter.detractions++;
                     Destroy(gameObject);
              }
       }
}
