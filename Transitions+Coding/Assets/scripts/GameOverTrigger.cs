using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverTrigger : MonoBehaviour
{

	public GameManager gameManager;

	void OnGameOverTrigger ()
	{
		gameManager.GameOver();
	}

	
}
