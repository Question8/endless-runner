using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb;
	public float delay;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.up * speed;
		Destroy(gameObject, delay);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log(collision.name);
		if (collision.tag != "Player")
		{
			if (collision.tag == "Enemy")
			{
				Destroy(gameObject);
				collision.gameObject.SetActive(false);
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}

}
