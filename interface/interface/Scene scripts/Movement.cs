using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public GameManager gameManager;

    public ParticleSystem particleSystem;

    private float Speed = 10f;


    void Update()
{

    if(Input.GetKey(KeyCode.W))
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
    if(Input.GetKey(KeyCode.S))
    {
        transform.Translate(Vector3.back * Speed * Time.deltaTime);
    }
     if(Input.GetKey(KeyCode.A))
    {
        transform.Translate(Vector3.left*Speed*Time.deltaTime);
    }
     if(Input.GetKey(KeyCode.D))
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }
    if(Input.GetKey(KeyCode.Return))
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}

private void OnCollisionEnter(Collision collision)
{
    if (collision.transform.CompareTag("box"))
    { 
        Debug.Log("collided with box");
        gameObject.GetComponent<ParticleSystem>().Play();
		gameManager.GameOver();
    }
}

}