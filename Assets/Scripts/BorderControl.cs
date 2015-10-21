using UnityEngine;
using System.Collections;

public class BorderControl : MonoBehaviour {

	// Use this for initialization
	void OnTriggerExit2d(Collider2D other)
	{
		Destroy(other.gameObject);
	}

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
