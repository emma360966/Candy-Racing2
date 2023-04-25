using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCOllision : MonoBehaviour
{
    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "box")
        {
            Debug.Log("we hit the ground");
        }
    }
}
