using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerObject : MonoBehaviour
{
    public GameObject objectToSpawn;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (objectToSpawn != null)
            {
                objectToSpawn.SetActive(true);
            }
        }
    }
}