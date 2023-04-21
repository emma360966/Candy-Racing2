using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyExplosion : MonoBehaviour
{
    public float timer;
    // Update is called once per frame
    void Update()
    {
        DestroyOrNo(timer);
        timer--;
    }

    private void DestroyOrNo(float timer)
    {
        if (timer == 0)
        {
            Destroy(gameObject);
        }
    }
}
