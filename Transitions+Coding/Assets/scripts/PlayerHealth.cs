using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int playerHealth;
    public int damage = 1; 

    void Start()
    {
        playerHealth = maxHealth;
    }

    public void PlayerTakeDamage(int damage)
    {
        playerHealth = playerHealth - damage;
    }
}
