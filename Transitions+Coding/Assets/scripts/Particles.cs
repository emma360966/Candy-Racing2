using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    private bool parTriggered;	
		
    private void OnCollisionEnter(Collision collision)
    {
    if (collision.transform.CompareTag("box"))
     {
        gameObject.GetComponent<ParticleSystem>().Play();
     }
    }
}