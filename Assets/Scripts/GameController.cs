using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour 
{
	//Menu Stuff
	public Canvas canvas;
	public Button button;
	public Light directionalLight;

	//Player Stuff
	public GameObject P1;
	public GameObject P2;
	private PlayerController P1cont;
	private PlayerController P2cont;
	private FaceKeys P1turret;
	private FaceKeys P2turret;

	//Respawn Stuff
	public GameObject[] spawnPoints;
	public static bool P1IsDead = false;
	public static bool P2IsDead = false;
	private int spawnNumber = 0;
	public float spawnDelay = 3;

	//scoring
	private int player1Score = 0;
	private int player2Score = 0;

	void Start ()
	{
		//getting the movement scripts
		P1cont = P1.GetComponent<PlayerController>();
		P2cont = P2.GetComponent<PlayerController>();
		P1turret = GameObject.FindGameObjectWithTag("Turret1").GetComponent<FaceKeys>();
		P2turret = GameObject.FindGameObjectWithTag("Turret2").GetComponent<FaceKeys>();


		toggleMenu (true);
	}

	void Update () {
		// pressing escape will pause game and bring up menu
		if (Input.GetKeyDown ("escape")) 
		{
			Time.timeScale = 0.0f;
			toggleMenu (true);
		}

		//spawn player if they are dead

		if (P1IsDead == true || P2IsDead == true)
		{
			spawnNumber = Random.Range(0, spawnPoints.Length);
			StartCoroutine(SpawnPlayer(spawnDelay));
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

			//disables movement scripts
			P1cont.enabled = false;
			P2cont.enabled = false;
			P1turret.enabled = false;
			P2turret.enabled = false;
		} 

		else 
		{
			Time.timeScale = 1.0f;
			canvas.gameObject.SetActive (false);
			directionalLight.intensity = 1.0f;

			//enables movement scripts
			P1cont.enabled = true;
			P2cont.enabled = true;
			P1turret.enabled = true;
			P2turret.enabled = true;

		}
	}

	IEnumerator SpawnPlayer(float spawnDelay)
	{
		if (P1IsDead == true)
		{
			P1IsDead = false;
			Debug.Log("spawn?");
			yield return new WaitForSeconds(spawnDelay);
			Instantiate(P1, spawnPoints[spawnNumber].transform.position, spawnPoints[spawnNumber].transform.rotation);
			P1cont = P1.GetComponent<PlayerController>();
			P1turret = GameObject.FindGameObjectWithTag("Turret1").GetComponent<FaceKeys>();
		}

		if (P2IsDead == true)
		{
			P2IsDead = false;
			Debug.Log("spawn?");
			yield return new WaitForSeconds(spawnDelay);
			Instantiate(P2, spawnPoints[spawnNumber].transform.position, spawnPoints[spawnNumber].transform.rotation);
			P2cont = P2.GetComponent<PlayerController>();
			P2turret = GameObject.FindGameObjectWithTag("Turret2").GetComponent<FaceKeys>();
		}
	}
}