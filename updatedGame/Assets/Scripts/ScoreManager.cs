using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;
	public float scoreCount;
	public float highScoreCounter;

	public float pointsPerSecond;
	public bool scoreIncreasing;

	// Use this for initialization
	void Start () {

		if(PlayerPrefs.HasKey("HighScore"))
		{

			if (PlayerPrefs.GetFloat("HighScore") >= 1)
			{

				highScoreCounter = PlayerPrefs.GetFloat("HighScore");

			}

		}
		

	}
	
	// Update is called once per frame
	void Update () {
		if(scoreIncreasing)
		{
			scoreCount += pointsPerSecond * Time.deltaTime;
		}

		if (highScoreCounter == 0)
		{
			highScoreText.gameObject.SetActive(false);
		}
		else
		{
			highScoreText.gameObject.SetActive(true);
		}

		if (scoreCount > highScoreCounter)
		{
			highScoreCounter = scoreCount;
			PlayerPrefs.SetFloat("HighScore", highScoreCounter);
		}

		scoreText.text = "Score: " + Mathf.Round(scoreCount);
		highScoreText.text = "High Score: " + Mathf.Round(highScoreCounter);

		
	}

	public void AddScore(int points)
	{
		scoreCount += points;
	}
}
