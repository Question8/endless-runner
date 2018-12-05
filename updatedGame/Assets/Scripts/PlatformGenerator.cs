using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	//public GameObject[] platforms;
	public Transform genPoint;
	private float distanceBTWN;
	public float distanceBtwnMin;
	public float distanceBtwnMax;
	private float platFormWidth;
	public ObjectPooler[] theObjectPools;
	private int platformSelector;

	private float[] platformWidths;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;

	public float maxHeightChange;
	private float heightChange;

	private CoinGenerator coinGen;
	public float randomCoinThreshold;


	// Use this for initialization
	void Start () {

		//platFormWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
		coinGen = FindObjectOfType<CoinGenerator>();
		platformWidths = new float[theObjectPools.Length];

		for (int i = 0; i < theObjectPools.Length; i++)
		{
			platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < genPoint.position.x)
		{

			distanceBTWN = Random.Range(distanceBtwnMin, distanceBtwnMax);
			platformSelector = Random.Range(0, theObjectPools.Length);

			heightChange = transform.position.y + Random.Range(maxHeightChange, - maxHeightChange);
			if(heightChange > maxHeight)
			{
				heightChange = maxHeight;
			}else if(heightChange < minHeight)
			{
				heightChange = minHeight;
			}


			transform.position = new Vector3(x: transform.position.x + (platformWidths[platformSelector] / 2) + distanceBTWN, y: heightChange, z: transform.position.z);


			//Instantiate(/*thePlatform*/ platforms[platformSelector], transform.position, transform.rotation);

			
			GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive(true);
			if (Random.Range(0f, 100f) < randomCoinThreshold)
			{

				coinGen.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));

			}

			transform.position = new Vector3(x: transform.position.x + (platformWidths[platformSelector] / 2), y: transform.position.y, z: transform.position.z);

		}
		
	}
}
