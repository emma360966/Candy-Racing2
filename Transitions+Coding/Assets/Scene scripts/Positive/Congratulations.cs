using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Congratulations : MonoBehaviour
{
    public void Congrats()
    {
        
        if (Input.GetKey(KeyCode.Return))
        {
        Debug.Log("congrats");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
