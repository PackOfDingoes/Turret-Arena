using UnityEngine;
using System.Collections;
using System;

public class isAlt : MonoBehaviour 
{
	private Renderer rend;
	private GameObject player;
	private PlayerController playerCont;


	// Use this for initialization
	void Start () 
	{
		rend = GetComponent<Renderer>();
		//changing which player it pulls information from and which player is changes
		if (transform.parent.tag == "P1" || transform.parent.tag == "Turret1")
		{
			player = GameObject.FindGameObjectWithTag("P1");
		}
		if (transform.parent.tag == "P2" || transform.parent.tag == "Turret2")
		{
			player = GameObject.FindGameObjectWithTag("P2");
		}
		playerCont = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//player 1 colour change
		if (this.tag == "SpriteAlt" && playerCont.isAlt == false)
		{
			rend.enabled = false;
		}			
		if (this.tag == "SpriteAlt" && playerCont.isAlt == true)
		{
			rend.enabled = true;
		}
		if (this.tag == "Sprite" && playerCont.isAlt == false)
		{
			rend.enabled = true;
		}
		if (this.tag == "Sprite" && playerCont.isAlt == true)
		{
			rend.enabled = false;
		}
	}
}
