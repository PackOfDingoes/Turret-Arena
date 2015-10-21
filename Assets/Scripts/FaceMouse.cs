using UnityEngine;
using System.Collections;

public class FaceMouse : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 upAxis  = new Vector3(0,0,1);
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = transform.position.z;
		Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);
		transform.LookAt(mousePosWorld,upAxis);
		transform.eulerAngles = new Vector3(0,0,-transform.eulerAngles.z);
	}

	void LateUpdate()
	{

	}
}
			