using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //Assignables
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsTarget;
    
    //Stats
    [Range(0f,1f)] 
    public float bounciness;

    public bool useGravity;
    //Damage
    public int explosionDamage;
    public float explosionRange;
    
    //Lifetime
    public int maxCollisions;
    public float maxLifetime;
}
