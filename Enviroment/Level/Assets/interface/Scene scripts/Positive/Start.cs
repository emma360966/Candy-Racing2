using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public void loadlevelstart()
    {
        Debug.Log("loadlevelstart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

    }
}
