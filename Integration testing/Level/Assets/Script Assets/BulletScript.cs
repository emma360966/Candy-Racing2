using System;
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
    public float explosionForce; 
    
    //Lifetime
    public int maxCollisions;
    public float maxLifetime;
    public bool explodeOnTouch = true;
    private int collisions;
    private PhysicMaterial physics_mat;

    //kills
   // [SerializeField] pointGet pointGetter;
    
    private void Start()
    {
        //pointGetter = GameObject.Find("pointManager").GetComponent<pointGet>();
        Setup();
    }

    private void Update()
    {
        //When to explode
        if (collisions > maxCollisions)
        {
            Explode();
        }

        //count down life
        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0)
        {
            Explode();
        }


    }

    private void Explode()
    {
        //instantiate explosion
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
        //Check for enemies
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsTarget);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<obstacleTarget>().TakeDamage(explosionDamage);
            //add explosion force
            if (enemies[i].GetComponent<Rigidbody>())
            {
                enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position,explosionRange);
            }
        }
        //Add a delay
        Invoke("Delay",0.05f);
    }

   /** private void killIncrease()
    {
        pointGetter.kills++;
    }
    **/
    
    private void Delay()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        collisions++;
        if (collision.collider.CompareTag("obstacle"))
        {
         //   killIncrease();
        }
        if (collision.collider.CompareTag("obstacle") && explodeOnTouch)
        {
            Explode();
        }
        
    }

    private void Setup()
    {
        //create new physics material
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;
        //assign material
        GetComponent<SphereCollider>().material = physics_mat;
        
        //set gravity
        rb.useGravity = useGravity;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
