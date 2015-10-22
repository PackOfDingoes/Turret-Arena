using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public Canvas canvas;
	public Button button;
	public Light directionalLight;

	void Start ()
	{
		toggleMenu (true);
	}

	void Update () {
		// pressing escape will pause game and bring up menu
		if (Input.GetKeyDown ("escape")) 
		{
			Time.timeScale = 0.0f;
			toggleMenu (true);
		}
	}

	public void StartGame ()	
	{
		button.GetComponentInChildren<Text>().text = "Resume";
		toggleMenu (false);
	}

	private void toggleMenu(bool showMenu) 
	{
		if (showMenu == true) 
		{
			Time.timeScale = 0.0f;
			canvas.gameObject.SetActive (true);
			directionalLight.intensity = 0.5f;
		} 
		else 
		{
			Time.timeScale = 1.0f;
			canvas.gameObject.SetActive (false);
			directionalLight.intensity = 1.0f;
		}
	}
}