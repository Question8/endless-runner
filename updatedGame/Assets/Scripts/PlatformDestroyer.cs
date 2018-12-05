using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

	public GameObject PDP;

	// Use this for initialization
	void Start () {

		PDP = GameObject.Find("PlatformDestructionPoint");
		
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < PDP.transform.position.x)
		{

			//Destroy(gameObject);
			gameObject.SetActive(false);
		}
		
	}
}
