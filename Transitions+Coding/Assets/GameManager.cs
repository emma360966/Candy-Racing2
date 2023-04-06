using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
    public float restartDelay = 1f;

    public GameObject completelevelUI;

    public void CompleteLevel ()
    {
        completelevelUI.SetActive(true);
    }

}
