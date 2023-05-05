using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class randomlyGenerate : MonoBehaviour
{
    public GameObject itemToSpread;
    public float itemXSpread = 10;
    public float itemYSpread = 0;
    public float itemZSpread = 10;
    public float amount;

    void Start()
    {
        for (int i = 0; i <= amount; i++)
        {
            spreadItem();
        }
    }

    void spreadItem()
    {
        Vector3 randPosition = new Vector3(Random.Range(-itemXSpread, itemXSpread), 
            Random.Range(-itemYSpread, itemYSpread), Random.Range(-itemZSpread, itemZSpread)) + transform.position;
        GameObject dupe = Instantiate(itemToSpread, randPosition, Quaternion.identity);
    }
}
