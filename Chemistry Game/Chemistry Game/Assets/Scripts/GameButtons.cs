using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameButtons : MonoBehaviour {

	public Canvas pauseCanvas;

	// Use this for initialization
	void Start () {
		pauseCanvas.enabled = false;
		if (pauseCanvas == null) {
			pauseCanvas = GetComponent<Canvas> ();
		}
	}

	// Update is called once per frame
	//void Update () {}

	public void PauseGame()
	{
		Time.timeScale = 0.0f;
		pauseCanvas.enabled = true;
	}

	public void ResumeGame()
	{
		pauseCanvas.enabled = false;
		Time.timeScale = 1.0f;
	}

	public void Menu()
	{
		SceneManager.LoadScene ("Menu");
	}
}
