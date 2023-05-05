using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story_back : MonoBehaviour
{
    public void Back()
    {
        Debug.Log("Back");
        SceneManager.LoadScene("Menu");

    
    }
}
