using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour 
{
	public float maxHP;
	private float currentHP;

	void Start () 
	{
		currentHP = maxHP;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy") 
		{
			return;
		}
		currentHP -= 1;
		Destroy (other.gameObject);
	}
	
	void Update () 
	{
		//Debug.Log (currentHP);

		if (currentHP <= 0) 
		{
			Destroy(this.gameObject);
		}
	}
}
