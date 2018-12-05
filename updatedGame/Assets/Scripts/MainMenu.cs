using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame()
	{
		SceneManager.LoadScene("Gameplay");
	}

	public void ReturnToMain()
	{
		SceneManager.LoadScene("Menu");
	}

	public void RestartGame()
	{
		FindObjectOfType<PlayManager>().ResetGame();
	}
	public void QuitGame()
	{
		Application.Quit();
	}
}
