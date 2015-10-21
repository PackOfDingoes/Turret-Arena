using UnityEngine;
using System.Collections;

public class WhyLive : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Nova.diePls == true)
		{
			Nova.diePls = false;
			Destroy(this.gameObject);
		}
	}
}
