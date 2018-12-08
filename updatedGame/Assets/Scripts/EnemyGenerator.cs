using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	public ObjectPooler enemyPool;

	public void SpawnEnemy(Vector3 position)
	{
		GameObject enemy1 = enemyPool.GetPooledObject();
		enemy1.transform.position = position;
		enemy1.SetActive(true);
	}
}
