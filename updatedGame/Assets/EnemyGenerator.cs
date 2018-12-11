using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	public ObjectPooler enemyPool;

	public void SpawnCoins(Vector3 pos)
	{

		GameObject coin1 = enemyPool.GetPooledObject();
		coin1.transform.position = pos;
		coin1.SetActive(true);

	}
}
