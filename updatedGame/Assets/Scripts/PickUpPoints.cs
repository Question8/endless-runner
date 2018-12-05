using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoints : MonoBehaviour {

	public int scoreToGive;
	private ScoreManager scoreManager;

	// Use this for initialization
	void Start () {

		scoreManager = FindObjectOfType<ScoreManager>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			scoreManager.AddScore(scoreToGive);
			gameObject.SetActive(false);
		}
	}
}
