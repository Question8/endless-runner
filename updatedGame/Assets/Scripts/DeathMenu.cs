using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

	public void ReturnToMain()
	{
		SceneManager.LoadScene("Menu");
	}

	public void RestartGame()
	{
		FindObjectOfType<PlayManager>().ResetGame();
	}

}
