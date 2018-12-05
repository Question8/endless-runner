using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

	public ObjectPooler coinPool;

	public float distanceBTWNCoins;
	

	public void SpawnCoins(Vector3 pos)
	{

		GameObject coin1 = coinPool.GetPooledObject();
		coin1.transform.position = pos;
		coin1.SetActive(true);

		GameObject coin2 = coinPool.GetPooledObject();
		coin2.transform.position = new Vector3(pos.x - distanceBTWNCoins, pos.y, pos.z);
		coin2.SetActive(true);

		GameObject coin3 = coinPool.GetPooledObject();
		coin3.transform.position = new Vector3(pos.x + distanceBTWNCoins, pos.y, pos.z);
		coin3.SetActive(true);

	}
}
