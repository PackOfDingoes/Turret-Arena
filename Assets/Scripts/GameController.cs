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
	public Sprite[] scoreSprites;
	public GameObject P1Scoreboard;
	public GameObject P2Scoreboard;
	private int P1Score = 0;
	private int P2Score = 0;

	void Start ()
	{
		//getting the movement scripts
		Instantiate(P1, spawnPoints[4].transform.position, spawnPoints[4].transform.rotation);
		Instantiate(P2, spawnPoints[5].transform.position, spawnPoints[5].transform.rotation);

		P1cont = GameObject.FindGameObjectWithTag("P1").GetComponent<PlayerController>();
		P2cont = GameObject.FindGameObjectWithTag("P2").GetComponent<PlayerController>();
		P1turret = GameObject.FindGameObjectWithTag("Turret1").GetComponent<FaceKeys>();
		P2turret = GameObject.FindGameObjectWithTag("Turret2").GetComponent<FaceKeys>();


		toggleMenu (true);
	}

	void Update () {
		// pressing escape will pause game and bring up menu
		if (Input.GetKeyDown ("escape")) 
		{
			Time.timeScale = 0.0f;
			toggleMenu(true);
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
		toggleMenu(false);
	}

	private void toggleMenu(bool showMenu) 
	{
		if (showMenu == true) 
		{
			Time.timeScale = 0.0f;
			canvas.gameObject.SetActive(true);
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
			canvas.gameObject.SetActive(false);
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
			P2Score++;
			updateScore(P2Scoreboard, P2Score);
			Debug.Log("Player 2 score:" +P2Score);
			P1IsDead = false;
			yield return new WaitForSeconds(spawnDelay);
			Instantiate(P1, spawnPoints[spawnNumber].transform.position, spawnPoints[spawnNumber].transform.rotation);
			P1cont = GameObject.FindGameObjectWithTag("P1").GetComponent<PlayerController>();
			P1turret = GameObject.FindGameObjectWithTag("Turret1").GetComponent<FaceKeys>();
		}

		if (P2IsDead == true)
		{
			P1Score++;
			updateScore(P1Scoreboard, P1Score);
			Debug.Log("Player 1 score:" +P1Score);
			P2IsDead = false;
			yield return new WaitForSeconds(spawnDelay);
			Instantiate(P2, spawnPoints[spawnNumber].transform.position, spawnPoints[spawnNumber].transform.rotation);
			P2cont = GameObject.FindGameObjectWithTag("P2").GetComponent<PlayerController>();
			P2turret = GameObject.FindGameObjectWithTag("Turret2").GetComponent<FaceKeys>();
		}
	}

	private void updateScore(GameObject playerScore, int score) {
		playerScore.gameObject.GetComponent<Image> ().sprite = scoreSprites [score-1];
	}
}