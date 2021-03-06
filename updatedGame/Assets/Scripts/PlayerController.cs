﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

	//game objects and references
	private Rigidbody2D rb;
	private Animator animator;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public PlayManager manager;
	private Attack attack;

	//movement variables
	private bool isSliding;
	public bool onGround;
	private bool isJumping;

	public float moveSpeed;
	private float moveSpeedStore;
	public float speedMultiplier;
	public float speedIncreaseMilestone;
	private float speedIncreaseMilestoneStore;
	private float speedMilestoneCap;
	private float speedMilestoneCapStore;

	public int jumpForce;
	public float groundCheckRadius;
	public float jumpTime;
	private float jumpTimeCounter;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		attack = GetComponent<Attack>();

		jumpTimeCounter = jumpTime;
		speedMilestoneCap = speedIncreaseMilestone;
		speedMilestoneCapStore = speedMilestoneCap;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;
		moveSpeedStore = moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x > speedMilestoneCap)
		{
			speedMilestoneCap += speedIncreaseMilestone;

			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			moveSpeed = moveSpeed * speedMultiplier;
		}

		rb.velocity = new Vector2(moveSpeed, rb.velocity.y);


		onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

		if (Input.GetMouseButtonDown(0) && onGround)
		{
			//so you dont jump when clicking the pause button
			if (EventSystem.current.IsPointerOverGameObject() )
			{
				return;
			}
			if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
			{
				if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
				{

					return;
				}
			}

			isJumping = true;
			jumpTimeCounter = jumpTime;
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}


		if (Input.GetMouseButton(0) && isJumping)
		{
			if(jumpTimeCounter > 0)
			{
				rb.velocity = new Vector2(rb.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
			else
			{
				isJumping = false;
			}
		}

		if (Input.GetMouseButtonUp(0))
		{
			jumpTimeCounter = 0;
			isJumping = false;

		}

		if (Input.GetMouseButtonDown(1))
		{
			animator.SetTrigger("throw");
			attack.Throw();
		}


		animator.SetBool("onGround", onGround);
		animator.SetFloat("Speed", rb.velocity.x);

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Floor")
		{
			manager.Fall();
			moveSpeed = moveSpeedStore;
			speedMilestoneCap = speedMilestoneCapStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
		}
	}
}
