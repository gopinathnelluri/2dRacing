using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class uiManager : MonoBehaviour {

	public Button[] buttons;
	public Text scoreText;
	int score;
	bool gameOver;
	public AudioManager am;

	// Use this for initialization
	void Start () {
		score = 0;
		gameOver = false;

		InvokeRepeating("scoreUpdate",1.0f,0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver && score >=0) {
			scoreText.text = "Score: " + score;
		}
	}

	void scoreUpdate () {
		if (!gameOver) {
			score += 1;
		}
	}

	public void gameOverNow(){
		gameOver = true;
		foreach (Button button in buttons) {
			button.gameObject.SetActive(true);
		}
	}

	public void replay(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
			foreach (Button button in buttons) {
				button.gameObject.SetActive (false);
			}
		}
	}

	public void menu(){
		foreach (Button button in buttons) {
			button.gameObject.SetActive(false);
		}
		SceneManager.LoadScene ("menuScene");
	}

	public void quit(){
		Application.Quit ();
	}

	public void Play(){
		SceneManager.LoadScene ("level1");
		//Application.LoadLevel ("level1");
	}

	public void pause(){
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
			foreach (Button button in buttons) {
				button.gameObject.SetActive(true);
			}
			am.carSound.Stop ();
		} else if (Time.timeScale == 0) {
			Time.timeScale = 1;
			foreach (Button button in buttons) {
				button.gameObject.SetActive(false);
			}
			am.carSound.Play ();
		}
	}


}
