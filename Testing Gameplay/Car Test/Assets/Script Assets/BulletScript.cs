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
    public bool explodeOnTouch = true;
    private int collisions;
    private PhysicMaterial physics_mat;

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
}
