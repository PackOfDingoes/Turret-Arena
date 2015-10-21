using UnityEngine;
using System.Collections;

public class FaceKeys : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		//transform.Rotate(Vector3.
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Player1
		//up
		if (Input.GetButtonDown ("P1FU") && this.name == "Turret1")
		{
			transform.eulerAngles = new Vector3(0,0,0);
		}
		//down
		if (Input.GetButtonDown ("P1FD") && this.name == "Turret1")
		{
			transform.eulerAngles = new Vector3(0,0,180);
		}
		//right
		if (Input.GetButtonDown ("P1FR") && this.name == "Turret1")
		{
			transform.eulerAngles = new Vector3(0,0,-90);
		}
		//left
		if (Input.GetButtonDown ("P1FL") && this.name == "Turret1")
		{
			transform.eulerAngles = new Vector3(0,0,90);
		}
		//Player2
		//up
		if (Input.GetButtonDown ("P2FU") && this.name == "Turret2")
		{
			transform.eulerAngles = new Vector3(0,0,0);
		}
		//down
		if (Input.GetButtonDown ("P2FD") && this.name == "Turret2")
		{
			transform.eulerAngles = new Vector3(0,0,180);
		}
		//right
		if (Input.GetButtonDown ("P2FR") && this.name == "Turret2")
		{
			transform.eulerAngles = new Vector3(0,0,-90);
		}
		//left
		if (Input.GetButtonDown ("P2FL") && this.name == "Turret2")
		{
			transform.eulerAngles = new Vector3(0,0,90);
		}
	}
}
