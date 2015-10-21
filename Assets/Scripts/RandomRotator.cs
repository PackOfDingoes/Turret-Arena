using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour 
{
	public float spinner;
	// Use this for initialization
	void Start () 
	{
		Rigidbody rb;
		rb = GetComponent<Rigidbody> ();
		rb.angularVelocity = Random.insideUnitSphere * spinner;
		rb.angularVelocity = Random.insideUnitSphere * spinner * 0.5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
