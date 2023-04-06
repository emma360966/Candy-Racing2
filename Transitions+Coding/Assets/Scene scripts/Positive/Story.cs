using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    public void loadlevelstory()
    {
        Debug.Log("loadlevelstory");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    
    }
}
