using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour 
{
    private Rigidbody2D rigidbody2D;
    public float speed = 10f;
	public float fireRate = 1.0F;
	public float fireCooldown = 0.0f;
	public bool isAlt = false;
	public GameObject[] shot;
    public GameObject Nova;
	public Transform shotSpawn;
    public Transform me;
	public float changeDelay = 0.25f;
	public bool isP2 = false;
	private string player;
	private BulletController bulletCont;
    
	void Start () 
    {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
		//sets player value
		if (isP2 == true)
		{
			player = "P2";
		}
		else
		{
			player = "P1";
		}
	}

	void Update ()
    {
		//checks if shooting, has cooldown
		if (Input.GetButtonDown(player+"Fire")&&Time.time > fireCooldown)
		{
			Shoot ();
		}
		if (Input.GetButtonDown (player+"Change")) 
		{
			StartCoroutine(ChangeColour(changeDelay));
        }
    }
	
	void FixedUpdate () 
    {
		//player movement
        float moveHorizontal = Input.GetAxis(player+"Horizontal");
        float moveVertical = Input.GetAxis(player+"Vertical");
		Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rigidbody2D.velocity = movement * speed;
	}

	void Shoot()
	{
		//starts cooldown
		fireCooldown = Time.time + fireRate;
		//spawns bullet
		Instantiate(shot[Convert.ToInt32(isP2)], shotSpawn.position, shotSpawn.rotation);

	}

	IEnumerator ChangeColour(float changeDelay)
	{
		//delay until change
		yield return new WaitForSeconds(changeDelay);
		//spawns the nova as a child of the player
        GameObject nova = Instantiate(Nova, me.position, Quaternion.identity) as GameObject;
        nova.transform.parent = gameObject.transform;
     	//isAlt switch
        isAlt = !isAlt;
	}
}
