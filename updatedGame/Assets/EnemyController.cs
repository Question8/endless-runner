using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float speed;
	private bool movingRight;

	public Transform groundCheck;
	public Transform playerCheck;

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.right * speed * Time.deltaTime);

		RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, 2f);

		if ( groundInfo.collider == false)
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

		//onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Floor")
		{
			gameObject.SetActive(false);
		}
	}
}
