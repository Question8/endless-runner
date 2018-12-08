using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Transform groundCheck;

	public float speed;
	private bool movingRight = true;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(Vector2.right * speed * Time.deltaTime);

		RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, 2f);
	

		if (groundInfo.collider == false)
		{
			

			if (movingRight == true)
			{
				transform.eulerAngles = new Vector3(0, -180, 0);
				movingRight = false;
			}
			else
			{
				transform.eulerAngles = new Vector3(0, 0, 0);
				movingRight = true;
			}
		}

	}
}
