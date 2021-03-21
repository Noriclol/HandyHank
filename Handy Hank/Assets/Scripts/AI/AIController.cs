﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public float moveSpeed = 5;
    public Rigidbody2D rb;
	public Animator animator;

	Vector2 movement;


	private void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		animator.SetFloat("Horizontal", movement.x);
		animator.SetFloat("Vertical", movement.y);
		animator.SetFloat("Speed", movement.sqrMagnitude);
	}
	void FixedUpdate()
    {
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
