using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour {

	public Transform platformGen;
	private Vector3 platformStartPoint;

	public PlayerController player;
	private Vector3 playerStart;

	private PlatformDestroyer[] platformList;

	private ScoreManager scoreManager;
	public DeathMenu deathMenu;

	// Use this for initialization
	void Start () {

		platformStartPoint = platformGen.position;
		playerStart = player.transform.position;

		scoreManager = FindObjectOfType<ScoreManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Fall()
	{
		scoreManager.scoreIncreasing = false;
		player.gameObject.SetActive(false);


		deathMenu.gameObject.SetActive(true);
		//StartCoroutine("RestartGameCo");

	}

	public void ResetGame()
	{
		deathMenu.gameObject.SetActive(false);
		platformList = FindObjectsOfType<PlatformDestroyer>();
		for (int i = 0; i < platformList.Length; i++)
		{
			platformList[i].gameObject.SetActive(false);
		}

		player.transform.position = playerStart;
		platformGen.position = platformStartPoint;
		player.gameObject.SetActive(true);
		scoreManager.scoreCount = 0;
		scoreManager.scoreIncreasing = true;
	}


	/*
	public IEnumerator RestartGameCo()
	{

		scoreManager.dead = true;
		player.gameObject.SetActive(false);
		yield return new WaitForSeconds(0.5f);

		platformList = FindObjectsOfType<PlatformDestroyer>();
		for (int i = 0; i < platformList.Length; i++)
		{
			platformList[i].gameObject.SetActive(false);
		}

		player.transform.position = playerStart;
		platformGen.position = platformStartPoint;
		player.gameObject.SetActive(true);
		scoreManager.dead = false;

	}
	*/
}
