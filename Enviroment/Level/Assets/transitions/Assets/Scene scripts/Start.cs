using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public void loadlevelstarts()
    {
        Debug.Log("loadlevelstarts");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

    }
}
