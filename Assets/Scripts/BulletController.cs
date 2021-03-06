﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BulletController : MonoBehaviour 
{
	public float minSpeed;
	public float maxSpeed;
	public float reflectAcc;
	public bool isP2Shot = false;
	public bool bulletIsPurple = false;
	private GameObject player;
	private PlayerController playerCont;
	public Sprite[] shotColours;
	private SpriteRenderer shotColour;
	public bool canChange = true;
	private float selfReflectFix = 0.0f;

	private Rigidbody2D rigidbody2D;
	// Use this for initialization
	void Start () 
	{
		rigidbody2D = this.GetComponent<Rigidbody2D> ();
		shotColour = GetComponent<SpriteRenderer>();
		canChange = true;
	}

	void Update ()
	{
		selfReflectFix = selfReflectFix + Time.deltaTime;

		if (canChange == true)
		{
			if (isP2Shot == false)
			{
				player = GameObject.FindGameObjectWithTag("P1");
				BulletColour();
			}
			
			if (isP2Shot == true)
			{
				player = GameObject.FindGameObjectWithTag("P2");
				BulletColour();
			}
			
			shotColour.sprite = shotColours[Convert.ToInt32(bulletIsPurple)];
			//Debug.Log(bulletIsPurple);
			canChange = false;
		}
	}

	void FixedUpdate () 
	{
		rigidbody2D.velocity = transform.up * UnityEngine.Random.Range(minSpeed, maxSpeed);
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "Reflect" && selfReflectFix > 0.02f)
		{
			//transform.localEulerAngles = new Vector3(0,0,180);
			transform.Rotate(0,0,180, Space.Self);
			minSpeed = minSpeed * reflectAcc;
			maxSpeed = maxSpeed * reflectAcc;
			bulletIsPurple = !bulletIsPurple;
			shotColour.sprite = shotColours[Convert.ToInt32(bulletIsPurple)];
		}
		if (other.tag == "P1")
		{
			player = GameObject.FindGameObjectWithTag("P1");
			playerCont = player.GetComponent<PlayerController>();

			if (playerCont.isAlt == true && bulletIsPurple == false)
			{
				Destroy(player);
				Destroy(this.gameObject);
				GameController.P1IsDead = true;
			}

			if (playerCont.isAlt == false && bulletIsPurple == true)
			{
				Destroy(player);
				Destroy(this.gameObject);
				GameController.P1IsDead = true;
			}

			else
			{
				Destroy(this.gameObject);
			}
		}
		if (other.tag == "P2")
		{
			player = GameObject.FindGameObjectWithTag("P2");
			playerCont = player.GetComponent<PlayerController>();
			
			if (playerCont.isAlt == true && bulletIsPurple == false)
			{
				Destroy(player);
				Destroy(this.gameObject);
				GameController.P2IsDead = true;
			}
			
			if (playerCont.isAlt == false && bulletIsPurple == true)
			{
				Destroy(player);
				Destroy(this.gameObject);
				GameController.P2IsDead = true;
			}
			
			else
			{
				Destroy(this.gameObject);
			}
		}
		if (other.tag == "Wall")
		{
			Destroy(this.gameObject);
		}
	}

	void BulletColour()
	{
		playerCont = player.GetComponent<PlayerController>();
				
				if (playerCont.isAlt == false)
				{
					bulletIsPurple = false;
				}
				if (playerCont.isAlt == true)
				{
					bulletIsPurple = true;
				}
	}
}
