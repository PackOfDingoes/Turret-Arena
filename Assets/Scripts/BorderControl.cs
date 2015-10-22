using UnityEngine;
using System.Collections;

public class BorderControl : MonoBehaviour {

	// Use this for initialization
	void OnTriggerExit2D(Collider2D other)
	{
		Destroy(other.gameObject);
		Debug.Log("Left");
	}

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
