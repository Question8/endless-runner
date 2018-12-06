using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseMenu;

	public void PauseGame()
	{
		gameObject.SetActive(false);
		Time.timeScale = 0f;
		pauseMenu.SetActive(true);

	}

	public void ResumeGame()
	{
		gameObject.SetActive(true);
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;

	}

	public void ReturnToMain()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("Menu");
	}

	public void RestartGame()
	{
		gameObject.SetActive(true);
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		FindObjectOfType<PlayManager>().ResetGame();
	}
}
