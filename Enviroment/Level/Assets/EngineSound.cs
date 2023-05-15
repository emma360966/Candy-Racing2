using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{
    public AudioSource engineSound;

    public GameObject playerObject;
    // Update is called once per frame
    void Update()
    {
        while (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.S)))
        {
            if (engineSound != null)
            {
                engineSound.pitch = playerObject.GetComponent<getSpeed>().speed;
            } 
        } 
    }
}
