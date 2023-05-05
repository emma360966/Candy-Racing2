using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Controls : MonoBehaviour
{
    public void loadlevel()
    {
        Debug.Log("loadlevel");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    
    }
}
