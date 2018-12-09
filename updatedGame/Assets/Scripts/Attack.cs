using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	public Transform knifeSpawn;
	public GameObject knifePrefab;
	
	public void Throw()
	{
		Instantiate(knifePrefab, knifeSpawn.position, knifePrefab.transform.rotation);
	}
	
}
