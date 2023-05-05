using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public float restartDelay = 1f;

   public GameObject completeLevelUI; 
   
   public GameObject gameOverUI;



   public void CompleteLevel ()
   {
		  completeLevelUI.SetActive(true);
   }

   public void GameOver ()
   {
		  gameOverUI.SetActive(true);
   }

}
